using System;
using System.Windows.Forms;
using System.IO;
using IWshRuntimeLibrary;

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
            chckStampaAutomatica.Checked = set.AutomaticPrint;
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
            if (chckAccensioneAutomatica.Checked)
            {
                set.AutomaticStart = true;
                AttivaEsecuzioneAutomatica();
            }
            else
            {
                set.AutomaticStart = false;
                string pathLnk = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                if (System.IO.File.Exists(pathLnk))                
                    System.IO.File.Delete(pathLnk + @"\PrinterTimerControl.lnk");
            }
            set.Path = txtbCartellaLocale.Text;
            set.Delay = Convert.ToInt32(nudIntervalloTempo.Value);
            if (rbtnOnline.Checked && !set.UseDropbox || rbtnLocale.Checked && set.UseDropbox)
            {
                System.IO.File.Delete(@"Data\CronologiaStampe.csv");
                if (rbtnLocale.Checked && set.UseDropbox)
                {
                    foreach (string file in Directory.GetFiles(@"Data\Download"))
                    {
                        System.IO.File.Delete(file);
                    }
                    Directory.Delete(@"Data\Download");
                    Token.DeleteFile();
                }
            }
            set.UseDropbox = rbtnOnline.Checked;
            set.AutomaticPrint = chckStampaAutomatica.Checked;
            set.SalvaXML(@"Data\Impostazioni.xml");
        }
        public void AttivaEsecuzioneAutomatica()
        {
            var wsh = new IWshShell_Class();
            string programPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\PrinterTimerControl.lnk";
            IWshShortcut shortcut = wsh.CreateShortcut(programPath) as IWshShortcut;            
            shortcut.Description = "Avvia Applicazione PrinterTimerControl";
            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.Save();            
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
