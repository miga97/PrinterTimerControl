﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
namespace PrinterTimerControl
{
    public partial class CambiaToken : Form
    {
        private Settings set { get; set; }
        public CambiaToken(Settings s)
        {
            InitializeComponent();
            set = s;
        }
        private async void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                DropboxConnection Connection = new DropboxConnection();
                await Connection.Connetti(txtToken.Text);
                set.Connection = Connection;
                if (!Token.SaveCryptTokenSimple(txtToken.Text))
                    throw new Exception();                  
                Directory.CreateDirectory(@"Data\Download");
                Close();
            }
            catch
            {
                lblValida.Text = "Errore di connessione: token errato o connessione assente";
                lblValida.ForeColor = Color.Red;
            }
        }
        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
