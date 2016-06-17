namespace PrinterTimerControl
{
    partial class Impostazioni
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chckAccensioneAutomatica = new System.Windows.Forms.CheckBox();
            this.nudIntervalloTempo = new System.Windows.Forms.NumericUpDown();
            this.lblTempo = new System.Windows.Forms.Label();
            this.btnCambiaCartellaLocale = new System.Windows.Forms.Button();
            this.txtbCartellaLocale = new System.Windows.Forms.TextBox();
            this.lblSceltaPosizioneCartella = new System.Windows.Forms.Label();
            this.rbtnLocale = new System.Windows.Forms.RadioButton();
            this.rbtnOnline = new System.Windows.Forms.RadioButton();
            this.txtInfoToken = new System.Windows.Forms.TextBox();
            this.lblDropbox = new System.Windows.Forms.Label();
            this.btnCambiaToken = new System.Windows.Forms.Button();
            this.fbdCartella = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSalva = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.chckStampaAutomatica = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervalloTempo)).BeginInit();
            this.SuspendLayout();
            // 
            // chckAccensioneAutomatica
            // 
            this.chckAccensioneAutomatica.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chckAccensioneAutomatica.AutoSize = true;
            this.chckAccensioneAutomatica.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chckAccensioneAutomatica.Location = new System.Drawing.Point(13, 43);
            this.chckAccensioneAutomatica.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chckAccensioneAutomatica.Name = "chckAccensioneAutomatica";
            this.chckAccensioneAutomatica.Size = new System.Drawing.Size(320, 24);
            this.chckAccensioneAutomatica.TabIndex = 12;
            this.chckAccensioneAutomatica.Text = "Esegui il programma all\'avvio di Windows";
            this.chckAccensioneAutomatica.UseVisualStyleBackColor = true;
            // 
            // nudIntervalloTempo
            // 
            this.nudIntervalloTempo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.nudIntervalloTempo.Location = new System.Drawing.Point(234, 80);
            this.nudIntervalloTempo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudIntervalloTempo.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudIntervalloTempo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudIntervalloTempo.Name = "nudIntervalloTempo";
            this.nudIntervalloTempo.Size = new System.Drawing.Size(112, 26);
            this.nudIntervalloTempo.TabIndex = 11;
            this.nudIntervalloTempo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTempo
            // 
            this.lblTempo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTempo.AutoSize = true;
            this.lblTempo.Location = new System.Drawing.Point(13, 82);
            this.lblTempo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(213, 20);
            this.lblTempo.TabIndex = 10;
            this.lblTempo.Text = "Intervallo di controllo (minuti):";
            // 
            // btnCambiaCartellaLocale
            // 
            this.btnCambiaCartellaLocale.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCambiaCartellaLocale.Location = new System.Drawing.Point(276, 158);
            this.btnCambiaCartellaLocale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCambiaCartellaLocale.Name = "btnCambiaCartellaLocale";
            this.btnCambiaCartellaLocale.Size = new System.Drawing.Size(254, 35);
            this.btnCambiaCartellaLocale.TabIndex = 14;
            this.btnCambiaCartellaLocale.Text = "Scegli cartella";
            this.btnCambiaCartellaLocale.UseVisualStyleBackColor = true;
            this.btnCambiaCartellaLocale.Click += new System.EventHandler(this.btnCambiaCartellaLocale_Click);
            // 
            // txtbCartellaLocale
            // 
            this.txtbCartellaLocale.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtbCartellaLocale.Location = new System.Drawing.Point(13, 162);
            this.txtbCartellaLocale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtbCartellaLocale.Name = "txtbCartellaLocale";
            this.txtbCartellaLocale.ReadOnly = true;
            this.txtbCartellaLocale.Size = new System.Drawing.Size(255, 26);
            this.txtbCartellaLocale.TabIndex = 13;
            // 
            // lblSceltaPosizioneCartella
            // 
            this.lblSceltaPosizioneCartella.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSceltaPosizioneCartella.AutoSize = true;
            this.lblSceltaPosizioneCartella.Location = new System.Drawing.Point(9, 126);
            this.lblSceltaPosizioneCartella.Name = "lblSceltaPosizioneCartella";
            this.lblSceltaPosizioneCartella.Size = new System.Drawing.Size(273, 20);
            this.lblSceltaPosizioneCartella.TabIndex = 15;
            this.lblSceltaPosizioneCartella.Text = "Posizione della cartella da controllare:";
            // 
            // rbtnLocale
            // 
            this.rbtnLocale.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rbtnLocale.AutoSize = true;
            this.rbtnLocale.Checked = true;
            this.rbtnLocale.Location = new System.Drawing.Point(288, 126);
            this.rbtnLocale.Name = "rbtnLocale";
            this.rbtnLocale.Size = new System.Drawing.Size(81, 24);
            this.rbtnLocale.TabIndex = 16;
            this.rbtnLocale.TabStop = true;
            this.rbtnLocale.Text = "Locale";
            this.rbtnLocale.UseVisualStyleBackColor = true;
            // 
            // rbtnOnline
            // 
            this.rbtnOnline.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rbtnOnline.AutoSize = true;
            this.rbtnOnline.Location = new System.Drawing.Point(375, 126);
            this.rbtnOnline.Name = "rbtnOnline";
            this.rbtnOnline.Size = new System.Drawing.Size(161, 24);
            this.rbtnOnline.TabIndex = 17;
            this.rbtnOnline.Text = "Online -> Dropbox";
            this.rbtnOnline.UseVisualStyleBackColor = true;
            this.rbtnOnline.CheckedChanged += new System.EventHandler(this.rbtnOnline_CheckedChanged);
            // 
            // txtInfoToken
            // 
            this.txtInfoToken.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtInfoToken.Location = new System.Drawing.Point(152, 205);
            this.txtInfoToken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInfoToken.Name = "txtInfoToken";
            this.txtInfoToken.ReadOnly = true;
            this.txtInfoToken.Size = new System.Drawing.Size(296, 26);
            this.txtInfoToken.TabIndex = 13;
            // 
            // lblDropbox
            // 
            this.lblDropbox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblDropbox.AutoSize = true;
            this.lblDropbox.Location = new System.Drawing.Point(9, 208);
            this.lblDropbox.Name = "lblDropbox";
            this.lblDropbox.Size = new System.Drawing.Size(136, 20);
            this.lblDropbox.TabIndex = 18;
            this.lblDropbox.Text = "Account Dropbox:";
            // 
            // btnCambiaToken
            // 
            this.btnCambiaToken.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCambiaToken.Enabled = false;
            this.btnCambiaToken.Location = new System.Drawing.Point(455, 201);
            this.btnCambiaToken.Name = "btnCambiaToken";
            this.btnCambiaToken.Size = new System.Drawing.Size(75, 35);
            this.btnCambiaToken.TabIndex = 19;
            this.btnCambiaToken.Text = "Cambia";
            this.btnCambiaToken.UseVisualStyleBackColor = true;
            this.btnCambiaToken.Click += new System.EventHandler(this.btnCambiaToken_Click);
            // 
            // btnSalva
            // 
            this.btnSalva.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSalva.Location = new System.Drawing.Point(455, 242);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(76, 35);
            this.btnSalva.TabIndex = 20;
            this.btnSalva.Text = "Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(373, 242);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(76, 35);
            this.btnAnnulla.TabIndex = 20;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // chckStampaAutomatica
            // 
            this.chckStampaAutomatica.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chckStampaAutomatica.AutoSize = true;
            this.chckStampaAutomatica.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chckStampaAutomatica.Location = new System.Drawing.Point(14, 9);
            this.chckStampaAutomatica.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chckStampaAutomatica.Name = "chckStampaAutomatica";
            this.chckStampaAutomatica.Size = new System.Drawing.Size(262, 24);
            this.chckStampaAutomatica.TabIndex = 12;
            this.chckStampaAutomatica.Text = "Stampa in automatico i nuovi file";
            this.chckStampaAutomatica.UseVisualStyleBackColor = true;
            // 
            // Impostazioni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(543, 285);
            this.ControlBox = false;
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.btnCambiaToken);
            this.Controls.Add(this.lblDropbox);
            this.Controls.Add(this.rbtnOnline);
            this.Controls.Add(this.rbtnLocale);
            this.Controls.Add(this.lblSceltaPosizioneCartella);
            this.Controls.Add(this.btnCambiaCartellaLocale);
            this.Controls.Add(this.txtInfoToken);
            this.Controls.Add(this.txtbCartellaLocale);
            this.Controls.Add(this.chckStampaAutomatica);
            this.Controls.Add(this.chckAccensioneAutomatica);
            this.Controls.Add(this.nudIntervalloTempo);
            this.Controls.Add(this.lblTempo);
            this.MaximumSize = new System.Drawing.Size(565, 400);
            this.MinimumSize = new System.Drawing.Size(565, 312);
            this.Name = "Impostazioni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impostazioni";
            this.Load += new System.EventHandler(this.Impostazioni_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervalloTempo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chckAccensioneAutomatica;
        private System.Windows.Forms.NumericUpDown nudIntervalloTempo;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Button btnCambiaCartellaLocale;
        private System.Windows.Forms.TextBox txtbCartellaLocale;
        private System.Windows.Forms.Label lblSceltaPosizioneCartella;
        private System.Windows.Forms.RadioButton rbtnLocale;
        private System.Windows.Forms.RadioButton rbtnOnline;
        private System.Windows.Forms.TextBox txtInfoToken;
        private System.Windows.Forms.Label lblDropbox;
        private System.Windows.Forms.Button btnCambiaToken;
        private System.Windows.Forms.FolderBrowserDialog fbdCartella;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.CheckBox chckStampaAutomatica;
    }
}