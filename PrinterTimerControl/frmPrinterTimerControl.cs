using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Threading.Tasks;

namespace PrinterTimerControl
{
    public partial class frmPrinterTimerControl : Form
    {
        string versione = "2.5"; //cambiati tutti i percorsi relativi in assoluti al fine di rendere possibile l'esecuzione da parte di System
        //string versione = "2.4"; //sostituito il file di configurazione con uno in XML, apportate migliorie nella visualizzazione dei file, alla classe Sostituzione e alla gestione delle impostazioni, aggiunta la gestione della stampa da parte dell'utente, ora la visualizzazione a schermo continua a suonare finchè non confermi di averla guardata
        //string versione = "2.3"; //creazione di collegamenti nella cartella di avvio automatico
        //string versione = "2.2"; //criptazione del token di connessione (la classe che gestisce la criptazione non verrà publiccata per preservare la sicurezza)
        //string versione = "2.1"; //ora il file .mig viene aggiornato anche su dropbox online
        //string versione = "2.0"; //riorganizzazione delle impostazioni, create nuove form per gestire le impostazioni, integrazione con dropbox api completata
        //string versione = "1.5"; //Accesso alla cartella dropbox attraverso le dropbox api 
        //string versione = "1.4"; //aggiunta modalita' sound, cambiato il messaggio di conferma arresto e spostata la classe sostituzione in un file a parte
        //string versione = "1.3"; //modificate le modalità: messaggio, visualizza e stampa, aggiunto il file leggimi.txt che spiega le funzioni del file .config
        //string versione = "1.2"; // aggiunti campi alla tabella e la possibilità di aprire il file, gestione del file .mig come master, eliminazione della cronologia più vecchia di 3 giorni, corretto bug sul controllo filtrato delle estensioni, valutazione dell'uso del tryparse per il confronto delle date, abbandonata la visualizzazine attraverso una seconda form
        //string versione = "1.1"; //modifica della visualizzazione
        //string versione = "1.0"; //prima release del programma con aggiunta della gestione dei tipi di file
        public Settings settings { get; set; }
        public bool Viewed { get; set; }
        public frmPrinterTimerControl()
        {
            InitializeComponent();
        }
        private void frmPrinterTimerControl_Load(object sender, EventArgs e)
        {
            settings = new Settings();
            Text = "Printer Timer Control rev. " + versione;            
            try
            {
                if (settings.CaricaXML(Application.StartupPath + @"\Data\Impostazioni.xml"))
                    MessageBox.Show("E' stato trovato un errore nel file di configurazione del programma. Contattare l'amministratore", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnCronologiStampa_Click(null, null);
                if (settings.UseDropbox)
                    settings.Path = Application.StartupPath + @"\Data\Download";
                if (settings.MigMaster)
                    dateTimePicker.Visible = true;
                else
                    dateTimePicker.Visible = false; 
                if (settings.AutomaticStart)
                    btnStart_Click(null, null);
            }
            catch (Exception r)
            {
                MessageBox.Show("Non è stato possibile caricare le impostazioni : " + r.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (settings.Path != "" || Directory.Exists(settings.Path))
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                lblStatoCorrente.Text = "Attivo";
                lblStatoCorrente.ForeColor = Color.Green;
                btnImpostazioni.Enabled = false;
                dateTimePicker.Enabled = false;
                tmrTimer.Interval = 60000 * settings.Delay;
                //controlla se le impostazioni sono corrette
                if (settings.UseDropbox)
                {
                    try
                    {
                        settings.Connection = new DropboxConnection();
                        await settings.Connection.Connetti(Token.OpenCryptTokenSimple());
                        tmrTimer.Enabled = true;
                    }
                    catch
                    {
                        MessageBox.Show("Token errato o connessione assente", "Errore di Connessione");
                        btnStop_Click(null, null);
                    }
                }
                else
                    tmrTimer.Enabled = true;
            }
            else
                MessageBox.Show("Impossibile avviare il controllo, percorso mancante. Cambiare le Impostazioni", "Avvio Fallito", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            lblStatoCorrente.Text = "Inattivo";
            lblStatoCorrente.ForeColor = Color.DarkRed;
            btnImpostazioni.Enabled = true;
            tmrTimer.Enabled = false;
            dateTimePicker.Enabled = true;
        }                
        public void ControllaModifiche(string [] files)
        {//file: S_datacompilazione_orariocompilazione_datafinale.rtf            
            string daStampare = "";
            List<Sostituzione> fileSostituzioni = new List<Sostituzione>();
            string dataCorrente = "";
            try
            {
                tmrTimer.Enabled = false; //disabilito temporaneamente il timer
                for (int i = 0; i < files.Length; i++)
                {
                    files[i] = files[i].Split('\\')[files[i].Split('\\').Length - 1];
                    if (files[i].Split('.')[files[i].Split('.').Length - 1] == "mig")
                    {
                        #region MigMaster
                        if (settings.MigMaster)//se il programma è settato per salvare la data di oggi
                        {
                            dateTimePicker.Value = DateTime.Now;
                            if (dateTimePicker.Text != files[i].Split('.')[0])
                            {
                                if (settings.UseDropbox)
                                    settings.Connection.Delete("", files[i]);
                                if (File.Exists(settings.Path + @"\" + files[i]))
                                    File.Delete(settings.Path + @"\" + files[i]);
                                files[i] = dateTimePicker.Text + ".mig";
                                StreamWriter mig = new StreamWriter(settings.Path + @"\" + files[i]);
                                mig.WriteLine(dateTimePicker.Value);
                                mig.Close();
                                if (settings.UseDropbox)
                                    settings.Connection.Upload("", files[i], settings.Path + @"\" + files[i]);
                            }
                        }
                        #endregion
                        dataCorrente = files[i].Split('.')[0];//data di oggi
                        break;
                    }
                }
                for (int i = 0; i < files.Length; i++)
                {
                    files[i] = files[i].Split('\\')[files[i].Split('\\').Length - 1]; // estraggo il nome del file
                    if (files[i].Split('_')[0] == "S")
                        if (files[i].Split('_')[3].Split('.')[0] == dataCorrente)
                            fileSostituzioni.Add(new Sostituzione(files[i])); //trova i file della data di oggi                
                }
                foreach (Sostituzione file in fileSostituzioni)
                {
                    if (file.Estensione == settings.FileType || settings.FileType == "*") //controlla in base al filtro se il file è da stampare
                    {
                        if (daStampare == "")
                            daStampare = file.NomeFile;
                        else
                        {
                            if (file.DataMaggioreDi(daStampare))
                                daStampare = file.NomeFile;
                        }
                    }
                }
               if (daStampare != "")
                    ProcessoStampa(daStampare);
                lblUltimoControllo.Text = "Ultimo Controllo: " + DateTime.Now;
                tmrTimer.Enabled = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Non è stato possibile controllare la cartella\nErrore: " +e.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnStop_Click(null, null);
            }
        }
        public async void ProcessoStampa(string nomeFile)
        {
            bool stampa = true;
            try
            {
                StreamReader leggi = new StreamReader(Application.StartupPath + @"\Data\CronologiaStampe.csv");
                while (!leggi.EndOfStream)
                {
                    if (leggi.ReadLine().Split(';')[0] == nomeFile)
                        stampa = false;
                }
                leggi.Close();
            }
            catch
            {
            }
            if (stampa)
            {
                if (settings.UseDropbox)
                    try
                    {
                        await settings.Connection.Download("", nomeFile, settings.Path);
                    }
                    catch
                    {
                        try
                        {
                            await settings.Connection.Download("", nomeFile, settings.Path);
                        }
                        catch
                        {
                            MessageBox.Show("Controllare la connessione a Internet, la connessione potrebbe essere assente", "Errore di Connessione",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                
                // Sound
                SoundPlayer Player = new SoundPlayer();
                Player.SoundLocation = Application.StartupPath + @"\Data\Sound\StoreDoorChime.wav";
                Player.Play();                
                if (settings.AutomaticPrint)
                {
                    // Print
                    prssStampa.StartInfo.FileName = settings.Path + "\\" + nomeFile;
                    prssStampa.Start();
                }
                else
                {
                    Viewed = false;
                    Remember();
                    // Message
                    Activate();
                    MessageBox.Show("E' stato trovato un nuovo file", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Viewed = true;
                    // View File
                    System.Diagnostics.Process.Start(settings.Path + "\\" + nomeFile);
                }
                                        

                StreamWriter scrivi = new StreamWriter(Application.StartupPath + @"\Data\CronologiaStampe.csv", true);
                scrivi.WriteLine(nomeFile + ";" + nomeFile.Substring(8, 2) + "/" + nomeFile.Substring(6, 2) + "/" + nomeFile.Substring(2, 4) + ";" + nomeFile.Substring(11, 2) + ":" + nomeFile.Substring(13, 2) + ";" + nomeFile.Substring(22, 2) + "/" + nomeFile.Substring(20, 2) + "/" + nomeFile.Substring(16, 4) + ";" + DateTime.Now);
                scrivi.Close();
                btnCronologiStampa_Click(null, null);

            }
        }               
        private async void tmrTimer_Tick(object sender, EventArgs e)
        {
            if (settings.UseDropbox)
            {
                try
                {
                    await settings.Connection.RefreshFileList();
                    ControllaModifiche(settings.Connection.FileList);                    
                }
                catch
                {
                    MessageBox.Show("Errore nel controllo dei file, la connessione potrebbe essere assente", "Errore",MessageBoxButtons.OK,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                ControllaModifiche(Directory.GetFiles(settings.Path));
            }
        }
        private void btnCronologiStampa_Click(object sender, EventArgs e)
        {
            DateTime value;
            string temp;
            try
            {
                dgvCronologia.Rows.Clear();
                StreamReader fileCronologia = new StreamReader(Application.StartupPath +@"\Data\CronologiaStampe.csv");
                StreamWriter fileTemporaneo = new StreamWriter(Application.StartupPath + @"\Data\temp.csv");
                while (!fileCronologia.EndOfStream)
                {
                    temp = fileCronologia.ReadLine();
                    dgvCronologia.Rows.Add();
                    dgvCronologia.Rows[dgvCronologia.Rows.Count - 1].Cells[0].Value = temp.Split(';')[0];
                    dgvCronologia.Rows[dgvCronologia.Rows.Count - 1].Cells[1].Value = temp.Split(';')[1];
                    dgvCronologia.Rows[dgvCronologia.Rows.Count - 1].Cells[2].Value = temp.Split(';')[2];
                    dgvCronologia.Rows[dgvCronologia.Rows.Count - 1].Cells[3].Value = temp.Split(';')[3];
                    dgvCronologia.Rows[dgvCronologia.Rows.Count - 1].Cells[4].Value = temp.Split(';')[4];
                    dgvCronologia.Rows[dgvCronologia.Rows.Count - 1].Cells[5].Value = "Apri File";
                    if (DateTime.TryParse(temp.Split(';')[4], out value))//decido quali righe mantenere se sono meno vecchie di 3 giorni
                    {
                        if (DateTime.Now < value.AddDays(3))
                            fileTemporaneo.WriteLine(temp);
                        else
                        {
                            if (settings.UseDropbox)
                            {
                                File.Delete(settings.Path + @"\" + temp.Split(';')[0]);
                            }
                        }
                    }
                }
                fileTemporaneo.Close();
                fileCronologia.Close();
                File.Copy(Application.StartupPath + @"\Data\temp.csv", Application.StartupPath + @"\Data\CronologiaStampe.csv", true);
                File.Delete(Application.StartupPath + @"\Data\temp.csv");
            }
            catch
            {                
            }
        }                
        private void frmPrinterTimerControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult ris = MessageBox.Show("Se chiudi il programma non ti arriveranno più notifiche sugli aggiornamenti dei file. \n Sei sicuro di voler arrestare il programma ?", "Attenzione: Arresto in corso...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (ris == DialogResult.No)
                    e.Cancel = true;
            }
        }
        private void dgvCronologia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex>=0 && e.RowIndex>=0)
            {
                if (e.ColumnIndex == 5)// se è la colonna dei bottoni
                {
                    try
                    {
                        System.Diagnostics.Process.Start(settings.Path + "\\" + dgvCronologia.Rows[e.RowIndex].Cells[0].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Il file selezionato non è più presente nella lista dei file", "Impossibile trovare il file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
                    }
                }               
            }
        }
        private void btnImpostazioni_Click(object sender, EventArgs e)
        {
            Impostazioni impostazioni = new Impostazioni(settings);
            impostazioni.ShowDialog();
            btnCronologiStampa_Click(null, null);
        }                
        private async void Remember()
        {//serve per continuare a suonare finchè il nuovo file no viene visto
            await Task.Delay(10000);
            while(!Viewed)
            {
                // Sound
                SoundPlayer Player = new SoundPlayer();
                Player.SoundLocation = Application.StartupPath +@"\Data\Sound\StoreDoorChime.wav";
                Player.Play();

                await Task.Delay(10000); //ogni 10 secondi
            }
        }
    }
}