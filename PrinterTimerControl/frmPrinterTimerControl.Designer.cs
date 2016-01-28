namespace PrinterTimerControl
{
    partial class frmPrinterTimerControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrinterTimerControl));
            this.lblStato = new System.Windows.Forms.Label();
            this.lblStatoCorrente = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblTempo = new System.Windows.Forms.Label();
            this.nudIntervalloTempo = new System.Windows.Forms.NumericUpDown();
            this.ldlCartellaSelezionata = new System.Windows.Forms.Label();
            this.txtbCartellaSelezionata = new System.Windows.Forms.TextBox();
            this.btnCambiaCartella = new System.Windows.Forms.Button();
            this.chckAccensioneAutomatica = new System.Windows.Forms.CheckBox();
            this.btnCronologiStampa = new System.Windows.Forms.Button();
            this.fbdCartella = new System.Windows.Forms.FolderBrowserDialog();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.prssStampa = new System.Diagnostics.Process();
            this.dgvCronologia = new System.Windows.Forms.DataGridView();
            this.clmnNomeFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDataCompilazione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnOraCompilazione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDataFinale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDataStampa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnApri = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblUltimoControllo = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervalloTempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCronologia)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStato
            // 
            this.lblStato.AutoSize = true;
            this.lblStato.Location = new System.Drawing.Point(18, 26);
            this.lblStato.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(52, 20);
            this.lblStato.TabIndex = 0;
            this.lblStato.Text = "Stato:";
            // 
            // lblStatoCorrente
            // 
            this.lblStatoCorrente.AutoSize = true;
            this.lblStatoCorrente.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStatoCorrente.Location = new System.Drawing.Point(80, 26);
            this.lblStatoCorrente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatoCorrente.Name = "lblStatoCorrente";
            this.lblStatoCorrente.Size = new System.Drawing.Size(61, 20);
            this.lblStatoCorrente.TabIndex = 1;
            this.lblStatoCorrente.Text = "Inattivo";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.ForeColor = System.Drawing.Color.DarkRed;
            this.btnStop.Location = new System.Drawing.Point(666, 19);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(112, 35);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.ForeColor = System.Drawing.Color.Green;
            this.btnStart.Location = new System.Drawing.Point(546, 19);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 35);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblTempo
            // 
            this.lblTempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTempo.AutoSize = true;
            this.lblTempo.Location = new System.Drawing.Point(578, 66);
            this.lblTempo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(62, 20);
            this.lblTempo.TabIndex = 4;
            this.lblTempo.Text = "Tempo:";
            // 
            // nudIntervalloTempo
            // 
            this.nudIntervalloTempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudIntervalloTempo.Location = new System.Drawing.Point(666, 64);
            this.nudIntervalloTempo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudIntervalloTempo.Maximum = new decimal(new int[] {
            60,
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
            this.nudIntervalloTempo.TabIndex = 5;
            this.nudIntervalloTempo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudIntervalloTempo.ValueChanged += new System.EventHandler(this.nudIntervalloTempo_ValueChanged);
            // 
            // ldlCartellaSelezionata
            // 
            this.ldlCartellaSelezionata.AutoSize = true;
            this.ldlCartellaSelezionata.Location = new System.Drawing.Point(14, 114);
            this.ldlCartellaSelezionata.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ldlCartellaSelezionata.Name = "ldlCartellaSelezionata";
            this.ldlCartellaSelezionata.Size = new System.Drawing.Size(167, 20);
            this.ldlCartellaSelezionata.TabIndex = 6;
            this.ldlCartellaSelezionata.Text = "Cartella da controllare:";
            // 
            // txtbCartellaSelezionata
            // 
            this.txtbCartellaSelezionata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbCartellaSelezionata.Location = new System.Drawing.Point(18, 138);
            this.txtbCartellaSelezionata.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtbCartellaSelezionata.Name = "txtbCartellaSelezionata";
            this.txtbCartellaSelezionata.ReadOnly = true;
            this.txtbCartellaSelezionata.Size = new System.Drawing.Size(498, 26);
            this.txtbCartellaSelezionata.TabIndex = 7;
            // 
            // btnCambiaCartella
            // 
            this.btnCambiaCartella.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCambiaCartella.Location = new System.Drawing.Point(525, 134);
            this.btnCambiaCartella.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCambiaCartella.Name = "btnCambiaCartella";
            this.btnCambiaCartella.Size = new System.Drawing.Size(254, 35);
            this.btnCambiaCartella.TabIndex = 8;
            this.btnCambiaCartella.Text = "Scegli cartella";
            this.btnCambiaCartella.UseVisualStyleBackColor = true;
            this.btnCambiaCartella.Click += new System.EventHandler(this.btnCambiaCartella_Click);
            // 
            // chckAccensioneAutomatica
            // 
            this.chckAccensioneAutomatica.AutoSize = true;
            this.chckAccensioneAutomatica.Location = new System.Drawing.Point(18, 65);
            this.chckAccensioneAutomatica.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chckAccensioneAutomatica.Name = "chckAccensioneAutomatica";
            this.chckAccensioneAutomatica.Size = new System.Drawing.Size(365, 24);
            this.chckAccensioneAutomatica.TabIndex = 9;
            this.chckAccensioneAutomatica.Text = "Avvia automaticamente all\'accesso di Windows";
            this.chckAccensioneAutomatica.UseVisualStyleBackColor = true;
            this.chckAccensioneAutomatica.CheckedChanged += new System.EventHandler(this.chckAccensioneAutomatica_CheckedChanged);
            // 
            // btnCronologiStampa
            // 
            this.btnCronologiStampa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCronologiStampa.Location = new System.Drawing.Point(18, 366);
            this.btnCronologiStampa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCronologiStampa.Name = "btnCronologiStampa";
            this.btnCronologiStampa.Size = new System.Drawing.Size(164, 35);
            this.btnCronologiStampa.TabIndex = 10;
            this.btnCronologiStampa.Text = "Ricarica Cronologia";
            this.btnCronologiStampa.UseVisualStyleBackColor = true;
            this.btnCronologiStampa.Click += new System.EventHandler(this.btnCronologiStampa_Click);
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 60000;
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // prssStampa
            // 
            this.prssStampa.StartInfo.Domain = "";
            this.prssStampa.StartInfo.ErrorDialog = true;
            this.prssStampa.StartInfo.LoadUserProfile = false;
            this.prssStampa.StartInfo.Password = null;
            this.prssStampa.StartInfo.StandardErrorEncoding = null;
            this.prssStampa.StartInfo.StandardOutputEncoding = null;
            this.prssStampa.StartInfo.UserName = "";
            this.prssStampa.StartInfo.Verb = "print";
            this.prssStampa.SynchronizingObject = this;
            // 
            // dgvCronologia
            // 
            this.dgvCronologia.AllowUserToAddRows = false;
            this.dgvCronologia.AllowUserToDeleteRows = false;
            this.dgvCronologia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCronologia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCronologia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnNomeFile,
            this.clmnDataCompilazione,
            this.clmnOraCompilazione,
            this.clmnDataFinale,
            this.clmnDataStampa,
            this.clmnApri});
            this.dgvCronologia.Location = new System.Drawing.Point(18, 178);
            this.dgvCronologia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCronologia.MultiSelect = false;
            this.dgvCronologia.Name = "dgvCronologia";
            this.dgvCronologia.ReadOnly = true;
            this.dgvCronologia.RowHeadersVisible = false;
            this.dgvCronologia.Size = new System.Drawing.Size(761, 178);
            this.dgvCronologia.TabIndex = 11;
            this.dgvCronologia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCronologia_CellContentClick);
            // 
            // clmnNomeFile
            // 
            this.clmnNomeFile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnNomeFile.HeaderText = "Nome del File";
            this.clmnNomeFile.Name = "clmnNomeFile";
            this.clmnNomeFile.ReadOnly = true;
            // 
            // clmnDataCompilazione
            // 
            this.clmnDataCompilazione.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnDataCompilazione.HeaderText = "Data di Compilazione";
            this.clmnDataCompilazione.Name = "clmnDataCompilazione";
            this.clmnDataCompilazione.ReadOnly = true;
            // 
            // clmnOraCompilazione
            // 
            this.clmnOraCompilazione.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnOraCompilazione.HeaderText = "Ora di Compilazione";
            this.clmnOraCompilazione.Name = "clmnOraCompilazione";
            this.clmnOraCompilazione.ReadOnly = true;
            // 
            // clmnDataFinale
            // 
            this.clmnDataFinale.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnDataFinale.HeaderText = "Data Finale";
            this.clmnDataFinale.Name = "clmnDataFinale";
            this.clmnDataFinale.ReadOnly = true;
            // 
            // clmnDataStampa
            // 
            this.clmnDataStampa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnDataStampa.HeaderText = "Data di Stampa/Visualizzazione";
            this.clmnDataStampa.Name = "clmnDataStampa";
            this.clmnDataStampa.ReadOnly = true;
            // 
            // clmnApri
            // 
            this.clmnApri.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnApri.HeaderText = "Apertura";
            this.clmnApri.Name = "clmnApri";
            this.clmnApri.ReadOnly = true;
            this.clmnApri.Text = "Apri File";
            // 
            // lblUltimoControllo
            // 
            this.lblUltimoControllo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUltimoControllo.AutoSize = true;
            this.lblUltimoControllo.Location = new System.Drawing.Point(486, 374);
            this.lblUltimoControllo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUltimoControllo.Name = "lblUltimoControllo";
            this.lblUltimoControllo.Size = new System.Drawing.Size(154, 20);
            this.lblUltimoControllo.TabIndex = 12;
            this.lblUltimoControllo.Text = "Ultimo Controllo: Mai";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker.CustomFormat = "yyyyMMdd";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(380, 21);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(159, 26);
            this.dateTimePicker.TabIndex = 13;
            // 
            // frmPrinterTimerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 412);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.lblUltimoControllo);
            this.Controls.Add(this.btnCronologiStampa);
            this.Controls.Add(this.chckAccensioneAutomatica);
            this.Controls.Add(this.btnCambiaCartella);
            this.Controls.Add(this.txtbCartellaSelezionata);
            this.Controls.Add(this.ldlCartellaSelezionata);
            this.Controls.Add(this.nudIntervalloTempo);
            this.Controls.Add(this.lblTempo);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblStatoCorrente);
            this.Controls.Add(this.lblStato);
            this.Controls.Add(this.dgvCronologia);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(630, 398);
            this.Name = "frmPrinterTimerControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Printer Timer Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrinterTimerControl_FormClosing);
            this.Load += new System.EventHandler(this.frmPrinterTimerControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervalloTempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCronologia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.Label lblStatoCorrente;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.NumericUpDown nudIntervalloTempo;
        private System.Windows.Forms.Label ldlCartellaSelezionata;
        private System.Windows.Forms.TextBox txtbCartellaSelezionata;
        private System.Windows.Forms.Button btnCambiaCartella;
        private System.Windows.Forms.CheckBox chckAccensioneAutomatica;
        private System.Windows.Forms.Button btnCronologiStampa;
        private System.Windows.Forms.FolderBrowserDialog fbdCartella;
        private System.Windows.Forms.Timer tmrTimer;
        private System.Diagnostics.Process prssStampa;
        private System.Windows.Forms.DataGridView dgvCronologia;
        private System.Windows.Forms.Label lblUltimoControllo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnNomeFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDataCompilazione;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnOraCompilazione;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDataFinale;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDataStampa;
        private System.Windows.Forms.DataGridViewButtonColumn clmnApri;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}

