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
            this.btnImpostazioni = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCronologia)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStato
            // 
            this.lblStato.AutoSize = true;
            this.lblStato.Location = new System.Drawing.Point(13, 21);
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
            this.lblStatoCorrente.Location = new System.Drawing.Point(75, 21);
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
            this.btnStop.Location = new System.Drawing.Point(433, 14);
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
            this.btnStart.Location = new System.Drawing.Point(313, 14);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 35);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCronologiStampa
            // 
            this.btnCronologiStampa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCronologiStampa.Location = new System.Drawing.Point(13, 302);
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
            this.dgvCronologia.Location = new System.Drawing.Point(13, 59);
            this.dgvCronologia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCronologia.MultiSelect = false;
            this.dgvCronologia.Name = "dgvCronologia";
            this.dgvCronologia.ReadOnly = true;
            this.dgvCronologia.RowHeadersVisible = false;
            this.dgvCronologia.Size = new System.Drawing.Size(652, 233);
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
            this.lblUltimoControllo.Location = new System.Drawing.Point(391, 309);
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
            this.dateTimePicker.Location = new System.Drawing.Point(147, 16);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(159, 26);
            this.dateTimePicker.TabIndex = 13;
            // 
            // btnImpostazioni
            // 
            this.btnImpostazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImpostazioni.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnImpostazioni.Location = new System.Drawing.Point(553, 14);
            this.btnImpostazioni.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImpostazioni.Name = "btnImpostazioni";
            this.btnImpostazioni.Size = new System.Drawing.Size(112, 35);
            this.btnImpostazioni.TabIndex = 2;
            this.btnImpostazioni.Text = "Impostazioni";
            this.btnImpostazioni.UseVisualStyleBackColor = true;
            this.btnImpostazioni.Click += new System.EventHandler(this.btnImpostazioni_Click);
            // 
            // frmPrinterTimerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 344);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.lblUltimoControllo);
            this.Controls.Add(this.btnCronologiStampa);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnImpostazioni);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblStatoCorrente);
            this.Controls.Add(this.lblStato);
            this.Controls.Add(this.dgvCronologia);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "frmPrinterTimerControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Printer Timer Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrinterTimerControl_FormClosing);
            this.Load += new System.EventHandler(this.frmPrinterTimerControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCronologia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.Label lblStatoCorrente;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
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
        private System.Windows.Forms.Button btnImpostazioni;
    }
}

