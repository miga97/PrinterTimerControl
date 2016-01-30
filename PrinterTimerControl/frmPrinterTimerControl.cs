using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using IWshRuntimeLibrary;
using System.Media;

namespace PrinterTimerControl
{
    public partial class frmPrinterTimerControl : Form
    {
        string versione = "1.4"; //aggiunta modalita' sound, cambiato il messaggio di conferma arresto e spostata la classe sostituzione in un file a parte
        //string versione = "1.3"; //modificate le modalità: messaggio, visualizza e stampa, aggiunto il file leggimi.txt che spiega le funzioni del file .config
        //string versione = "1.2"; // aggiunti campi alla tabella e la possibilità di aprire il file, gestione del file .mig come master, eliminazione della cronologia più vecchia di 3 giorni, corretto bug sul controllo filtrato delle estensioni, valutazione dell'uso del tryparse per il confronto delle date, abbandonata la visualizzazine attraverso una seconda form
        //string versione = "1.1"; //modifica della visualizzazione
        //string versione = "1.0"; //prima release del programma con aggiunta della gestione dei tipi di file        
        public frmPrinterTimerControl()
        {
            InitializeComponent();
        }
        bool apertura = false, cambiaMig = false;
        string modalita = "message";
        string tipoFile = "*";
        private void frmPrinterTimerControl_Load(object sender, EventArgs e)
        {
            string riga;
            Text = "Printer Timer Control rev. " + versione;
            apertura = true;
            bool imprecisioneImpostazioni = false;
            try
            {
                StreamReader leggi = new StreamReader("Impostazioni.config");
                while (!leggi.EndOfStream)
                {
                    riga = leggi.ReadLine();
                    switch (riga.Split('>')[0])
                    {
                        case "<Path": txtbCartellaSelezionata.Text = riga.Split('>')[1]; break;
                        case "<Delay": nudIntervalloTempo.Value = Convert.ToInt32(riga.Split('>')[1]); break;
                        case "<AutomaticStart":
                            {
                                if (Convert.ToBoolean(riga.Split('>')[1]))
                                {
                                    chckAccensioneAutomatica.Checked = true;
                                    btnStart_Click(null, null);
                                }
                                break;
                            }
                        case "<Function":
                            {
                                modalita = riga.Split('>')[1].ToLower();                                
                                break;
                            } 
                        case "<FileType": tipoFile = riga.Split('>')[1].ToLower(); break;
                        case "<Mig":
                            {
                                if (riga.Split('>')[1].ToLower() == "master")
                                    cambiaMig = true;
                                else
                                    cambiaMig = false;
                                break;
                            }
                        default: imprecisioneImpostazioni = true; break;
                    }
                }
                leggi.Close();
                btnCronologiStampa_Click(null, null);
                if (cambiaMig)
                    dateTimePicker.Visible = true;
                else
                    dateTimePicker.Visible = false;
                if (imprecisioneImpostazioni)                
                    MessageBox.Show("E' stato trovato un errore nelle impostazioni del programma", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            catch (Exception r)
            {
                MessageBox.Show("Non è stato possibile caricare le impostazioni : " + r.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            apertura = false;
        }
        private void btnCambiaCartella_Click(object sender, EventArgs e)
        {            
            if (fbdCartella.ShowDialog() == DialogResult.OK)
            {
                txtbCartellaSelezionata.Text = fbdCartella.SelectedPath;
                SalvaImpostazioniCorrenti();
            }
        }
        public void SalvaImpostazioniCorrenti()
        {
            StreamWriter scrivi = new StreamWriter("Impostazioni.config");
            scrivi.WriteLine("<Path>" +txtbCartellaSelezionata.Text);
            scrivi.WriteLine("<Delay>" +nudIntervalloTempo.Value);
            if (chckAccensioneAutomatica.Checked)
            {
                scrivi.WriteLine("<AutomaticStart>True");
                //AttivaEsecuzioneAutomatica();
            }
            else
            {
                scrivi.WriteLine("<AutomaticStart>False");
                try
                {
                    //System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) +@"\PrinterTimerControl.lnk");
                }
                catch 
                {

                }
            }
            scrivi.WriteLine("<Function>" +modalita);            
            scrivi.WriteLine("<FileType>" +tipoFile);
            if (cambiaMig)
                scrivi.WriteLine("<Mig>master");
            scrivi.Close();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtbCartellaSelezionata.Text != "")
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                chckAccensioneAutomatica.Enabled = false;
                lblStatoCorrente.Text = "Attivo";
                lblStatoCorrente.ForeColor = Color.Green;
                nudIntervalloTempo.Enabled = false;
                btnCambiaCartella.Enabled = false;
                dateTimePicker.Enabled = false;
                tmrTimer.Interval = 60000 * Convert.ToInt32(nudIntervalloTempo.Value);
                tmrTimer.Enabled = true;
            }
            else
                MessageBox.Show("Selezionare prima la cartella da controllare", "Impossibile completare richiesta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            chckAccensioneAutomatica.Enabled = true;
            btnStart.Enabled = true;
            lblStatoCorrente.Text = "Inattivo";
            lblStatoCorrente.ForeColor = Color.DarkRed;
            nudIntervalloTempo.Enabled = true;
            btnCambiaCartella.Enabled = true;
            tmrTimer.Enabled = false;
            dateTimePicker.Enabled = true;
        }                
        public void ControllaModifiche()
        {//file: S_datacompilazione_orariocompilazione_datafinale.rtf
            string[] files;
            string daStampare = "";
            List<Sostituzione> fileSostituzioni = new List<Sostituzione>();
            string dataCorrente = "";
            try
            {                
                tmrTimer.Enabled = false; //disabilito temporaneamente il timer
                files = Directory.GetFiles(txtbCartellaSelezionata.Text); //cerco tutti i file
                for (int i = 0; i < files.Length; i++)
                {
                    files[i] = files[i].Split('\\')[files[i].Split('\\').Length - 1]; // estraggo il nome del file
                    if (files[i].Split('.')[files[i].Split('.').Length - 1] == "mig")
                    {
                        if (cambiaMig)//se il programma è settato per salvare la data di oggi
                        {
                            dateTimePicker.Value = DateTime.Now;
                            if (dateTimePicker.Text != files[i].Split('.')[0])
                            {
                                System.IO.File.Delete(txtbCartellaSelezionata.Text + @"\" + files[i]);
                                files[i] = dateTimePicker.Text + ".mig";
                                StreamWriter mig = new StreamWriter(txtbCartellaSelezionata.Text + @"\" + files[i]);
                                mig.WriteLine(dateTimePicker.Value);
                                mig.Close();
                                //System.IO.File.Create(txtbCartellaSelezionata.Text + @"\" + files[i]);
                            }
                        }
                        dataCorrente = files[i].Split('.')[0];//data di oggi
                    }
                    if (files[i].Split('_')[0] == "S")
                        if (files[i].Split('_')[3].Split('.')[0] == dataCorrente)
                            fileSostituzioni.Add(new Sostituzione(files[i])); //trova i file della data di oggi                
                }
                foreach (Sostituzione file in fileSostituzioni)
                {
                    if (file.Estensione() == tipoFile || tipoFile == "*") //controlla in base al filtro se il file è da stampare
                    {
                        if (daStampare == "")
                            daStampare = file.NomeFile;
                        else
                        {
                            if (file.DataMaggioreData2(daStampare))
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
        public void ProcessoStampa(string nomeFile)
        {
            bool stampa = true;
            try
            {
                StreamReader leggi = new StreamReader("CronologiaStampe.csv");
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
                Activate();
                string[] mod = modalita.Split(',');
                for (int i = 0; i < mod.Length; i++)
                    switch (mod[i])
                    {
                        case "print":
                            prssStampa.StartInfo.FileName = txtbCartellaSelezionata.Text + "\\" + nomeFile;
                            prssStampa.Start();
                            break;
                        case "view":
                            System.Diagnostics.Process.Start(txtbCartellaSelezionata.Text + "\\" + nomeFile);
                            break;
                        case "message":
                            MessageBox.Show("E' stato trovato un nuovo file", "Nuova Sostituzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "sound":
                            SoundPlayer Player = new SoundPlayer();
                            Player.SoundLocation = @"Sound\StoreDoorChime.wav";
                            Player.Play();
                            break;
                        default: break;
                    }
                StreamWriter scrivi = new StreamWriter("CronologiaStampe.csv", true);
                scrivi.WriteLine(nomeFile + ";" + nomeFile.Substring(8, 2) + "/" + nomeFile.Substring(6, 2) + "/" + nomeFile.Substring(2, 4) + ";" + nomeFile.Substring(11, 2) + ":" + nomeFile.Substring(13, 2) + ";" + nomeFile.Substring(22, 2) + "/" + nomeFile.Substring(20, 2) + "/" + nomeFile.Substring(16, 4) + ";" + DateTime.Now);
                scrivi.Close();
                btnCronologiStampa_Click(null, null);
            }
        }        
        private void nudIntervalloTempo_ValueChanged(object sender, EventArgs e)
        {
            if (!apertura)
                SalvaImpostazioniCorrenti();
        }
        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            ControllaModifiche();
        }
        private void btnCronologiStampa_Click(object sender, EventArgs e)
        {
            DateTime value;
            string temp;
            try
            {
                dgvCronologia.Rows.Clear();
                StreamReader fileCronologia = new StreamReader("CronologiaStampe.csv");
                StreamWriter fileTemporaneo = new StreamWriter("temp.csv");
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
                    if (DateTime.TryParse(temp.Split(';')[4], out value))//decido quali righe eliminare se sono più vecchie di 3 giorni
                    {
                        if (DateTime.Now < value.AddDays(3))
                            fileTemporaneo.WriteLine(temp);
                    }
                }
                fileTemporaneo.Close();
                fileCronologia.Close();
                System.IO.File.Copy("temp.csv", "CronologiaStampe.csv",true);
            }
            catch
            {                
            }
        }
        private void chckAccensioneAutomatica_CheckedChanged(object sender, EventArgs e)
        {
            if (!apertura)
                SalvaImpostazioniCorrenti();
        }
        public void AttivaEsecuzioneAutomatica()
        {
            //Dichiarazione varibili
            WshShellClass WshShell = new WshShellClass();
            IWshShortcut NewShortcut;

            //Indicate dove creare lo ShortCut
            NewShortcut = (IWshShortcut)WshShell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\PrinterTimerControl.lnk");
            //Indicate la destinazione del link appena creato – Con Application.ExecutablePath indicate l’exe della applicazione che sta creando il link
            NewShortcut.TargetPath = Application.ExecutablePath;
            //Descrizione del link appena creato
            NewShortcut.Description = "Avvia Applicazione PrinterTimerControl";
            //Indicate il percorso della icona del vostro link
            //NewShortcut.IconLocation = Application.StartupPath + @"\MiaIco.ico";
            //Alla fine si salva il link.
            NewShortcut.Save();
        }        
        private void frmPrinterTimerControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult ris = MessageBox.Show("Se chiudi il programma non ti arriveranno più notifiche sugli aggiornamenti dei file. \n Sei sicuro di voler arrestare il programma ?", "Attenzione: Arresto in corso...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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
                        System.Diagnostics.Process.Start(txtbCartellaSelezionata.Text + "\\" + dgvCronologia.Rows[e.RowIndex].Cells[0].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Il file selezionato non è più presente nella lista dei file", "Impossibile trovare il file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
                    }
                }               
            }
        }
    }
}