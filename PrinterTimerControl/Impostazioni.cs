using System;
using System.Windows.Forms;
using System.IO;
namespace PrinterTimerControl
{
    public partial class Impostazioni : Form
    {
        public Settings set { get; set; }
        public Impostazioni(Settings settings)
        {
            InitializeComponent();
            set = settings;
        }
        private void btnCambiaToken_Click(object sender, EventArgs e)
        {
            CambiaToken tokenChange = new CambiaToken(set);
            tokenChange.ShowDialog();
            if (set.Connection.Connection != null)
                txtInfoToken.Text = set.Connection.EmailAccount;
        }
        private void btnCambiaCartellaLocale_Click(object sender, EventArgs e)
        {
            if (fbdCartella.ShowDialog() == DialogResult.OK)
            {
                txtbCartellaLocale.Text = fbdCartella.SelectedPath;
            }
        }
        private async void Impostazioni_Load(object sender, EventArgs e)
        {
            chckAccensioneAutomatica.Checked = set.AutomaticStart;
            nudIntervalloTempo.Value = set.Delay;
            if (set.UseDropbox)
            {
                rbtnOnline.Checked = true;
                if (set.Connection == null)
                    try
                    {
                        set.Connection = new DropboxConnection();
                        await set.Connection.Connetti(Token.OpenCryptTokenSimple());
                    }
                    catch
                    {
                        MessageBox.Show("Token errato o connessione assente", "Errore di Connessione");
                    }
                txtInfoToken.Text = set.Connection.EmailAccount;
            }
            txtbCartellaLocale.Text = set.Path;
        }
        private void rbtnOnline_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnOnline.Checked)
            {
                btnCambiaToken.Enabled = true;
                btnCambiaCartellaLocale.Enabled = false;
                txtbCartellaLocale.Text = @"Data\Download";
            }
            else
            {
                txtbCartellaLocale.Text = "";
                btnCambiaToken.Enabled = false;
                btnCambiaCartellaLocale.Enabled = true;
            }
        }
        public void SalvaImpostazioniCorrenti()
        {
            set.AutomaticStart = chckAccensioneAutomatica.Checked;
            set.Path = txtbCartellaLocale.Text;
            set.Delay = Convert.ToInt32(nudIntervalloTempo.Value);
            if (rbtnOnline.Checked && !set.UseDropbox || rbtnLocale.Checked && set.UseDropbox)
            {
                File.Delete(@"Data\CronologiaStampe.csv");
                if (rbtnLocale.Checked && set.UseDropbox)
                {
                    foreach (string file in Directory.GetFiles(@"Data\Download"))
                    {
                        File.Delete(file);
                    }
                    Directory.Delete(@"Data\Download");
                    Token.DeleteFile();
                }
            }
            if (rbtnOnline.Checked)
                set.UseDropbox = true;
            else
                set.UseDropbox = false;

            StreamWriter scrivi = new StreamWriter(@"Data\Impostazioni.config");
            scrivi.WriteLine("<Path>" + set.Path);
            scrivi.WriteLine("<Delay>" + set.Delay);
            if (set.AutomaticStart)
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
            if (set.UseDropbox)
                scrivi.WriteLine("<UseDropbox>True");
            else
                scrivi.WriteLine("<UseDropbox>False");
            scrivi.WriteLine("<Function>" + set.Function);
            scrivi.WriteLine("<FileType>" + set.FileType);
            if (set.MigMaster)
                scrivi.WriteLine("<MigMaster>True");
            scrivi.Close();
        }
        public void AttivaEsecuzioneAutomatica()
        {
            //    //Dichiarazione varibili
            //    WshShellClass WshShell = new WshShellClass();
            //    IWshShortcut NewShortcut;

            //    //Indicate dove creare lo ShortCut
            //    NewShortcut = (IWshShortcut)WshShell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\PrinterTimerControl.lnk");
            //    //Indicate la destinazione del link appena creato – Con Application.ExecutablePath indicate l’exe della applicazione che sta creando il link
            //    NewShortcut.TargetPath = Application.ExecutablePath;
            //    //Descrizione del link appena creato
            //    NewShortcut.Description = "Avvia Applicazione PrinterTimerControl";
            //    //Indicate il percorso della icona del vostro link
            //    //NewShortcut.IconLocation = Application.StartupPath + @"\MiaIco.ico";
            //    //Alla fine si salva il link.
            //    NewShortcut.Save();
        }
        private void btnSalva_Click(object sender, EventArgs e)
        {
            if (txtbCartellaLocale.Text != "")
            {
                if (rbtnOnline.Checked)
                {
                    if (txtInfoToken.Text != "")
                    {
                        SalvaImpostazioniCorrenti();
                        Close();
                    }
                    else
                        MessageBox.Show("Inserire prima l'Account Dropbox", "Dati Mancanti", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    SalvaImpostazioniCorrenti();
                    Close();
                }
            }
            else
                MessageBox.Show("Inserire prima la cartella locale da sincronizzare", "Dati Mancanti", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);            
        }
        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
