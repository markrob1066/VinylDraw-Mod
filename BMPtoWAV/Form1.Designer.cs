namespace VinylDraw
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdCreateWAVData = new System.Windows.Forms.Button();
            this.trkStartRadiusCm = new System.Windows.Forms.TrackBar();
            this.trkEndRadiusCm = new System.Windows.Forms.TrackBar();
            this.lblStartRadiusIn = new System.Windows.Forms.Label();
            this.lblEndRadiusIn = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbxSpeedRPM = new System.Windows.Forms.ListBox();
            this.trkLPcm = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLPcm = new System.Windows.Forms.Label();
            this.prgCreate = new System.Windows.Forms.ProgressBar();
            this.lblProcessingEnded = new System.Windows.Forms.Label();
            this.grpDiscData = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.dbLbl = new System.Windows.Forms.Label();
            this.deadbandSel = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCarrier = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trkCarrier = new System.Windows.Forms.TrackBar();
            this.sync = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkStartRadiusCm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkEndRadiusCm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkLPcm)).BeginInit();
            this.grpDiscData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkCarrier)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(893, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.openToolStripMenuItem.Text = "&Open BMP...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveToolStripMenuItem.Text = "&Save WAV...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // cmdCreateWAVData
            // 
            this.cmdCreateWAVData.Location = new System.Drawing.Point(12, 364);
            this.cmdCreateWAVData.Name = "cmdCreateWAVData";
            this.cmdCreateWAVData.Size = new System.Drawing.Size(106, 23);
            this.cmdCreateWAVData.TabIndex = 12;
            this.cmdCreateWAVData.Text = "Create WAV data";
            this.cmdCreateWAVData.UseVisualStyleBackColor = true;
            this.cmdCreateWAVData.Click += new System.EventHandler(this.button1_Click);
            // 
            // trkStartRadiusCm
            // 
            this.trkStartRadiusCm.LargeChange = 2;
            this.trkStartRadiusCm.Location = new System.Drawing.Point(87, 27);
            this.trkStartRadiusCm.Maximum = 100;
            this.trkStartRadiusCm.Minimum = 10;
            this.trkStartRadiusCm.Name = "trkStartRadiusCm";
            this.trkStartRadiusCm.Size = new System.Drawing.Size(178, 45);
            this.trkStartRadiusCm.TabIndex = 1;
            this.trkStartRadiusCm.Value = 10;
            this.trkStartRadiusCm.Scroll += new System.EventHandler(this.CollectValues);
            // 
            // trkEndRadiusCm
            // 
            this.trkEndRadiusCm.LargeChange = 2;
            this.trkEndRadiusCm.Location = new System.Drawing.Point(87, 78);
            this.trkEndRadiusCm.Maximum = 100;
            this.trkEndRadiusCm.Minimum = 10;
            this.trkEndRadiusCm.Name = "trkEndRadiusCm";
            this.trkEndRadiusCm.Size = new System.Drawing.Size(178, 45);
            this.trkEndRadiusCm.TabIndex = 2;
            this.trkEndRadiusCm.Value = 18;
            this.trkEndRadiusCm.Scroll += new System.EventHandler(this.CollectValues);
            // 
            // lblStartRadiusIn
            // 
            this.lblStartRadiusIn.AutoSize = true;
            this.lblStartRadiusIn.Location = new System.Drawing.Point(284, 36);
            this.lblStartRadiusIn.Name = "lblStartRadiusIn";
            this.lblStartRadiusIn.Size = new System.Drawing.Size(35, 13);
            this.lblStartRadiusIn.TabIndex = 10;
            this.lblStartRadiusIn.Text = "label1";
            // 
            // lblEndRadiusIn
            // 
            this.lblEndRadiusIn.AutoSize = true;
            this.lblEndRadiusIn.Location = new System.Drawing.Point(284, 90);
            this.lblEndRadiusIn.Name = "lblEndRadiusIn";
            this.lblEndRadiusIn.Size = new System.Drawing.Size(35, 13);
            this.lblEndRadiusIn.TabIndex = 11;
            this.lblEndRadiusIn.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Start Radius";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "End Radius";
            // 
            // lbxSpeedRPM
            // 
            this.lbxSpeedRPM.FormattingEnabled = true;
            this.lbxSpeedRPM.Location = new System.Drawing.Point(655, 28);
            this.lbxSpeedRPM.Name = "lbxSpeedRPM";
            this.lbxSpeedRPM.Size = new System.Drawing.Size(132, 95);
            this.lbxSpeedRPM.TabIndex = 20;
            this.lbxSpeedRPM.SelectedIndexChanged += new System.EventHandler(this.lbxSpeedRPM_SelectedIndexChanged);
            // 
            // trkLPcm
            // 
            this.trkLPcm.LargeChange = 2;
            this.trkLPcm.Location = new System.Drawing.Point(87, 132);
            this.trkLPcm.Maximum = 20;
            this.trkLPcm.Name = "trkLPcm";
            this.trkLPcm.Size = new System.Drawing.Size(178, 45);
            this.trkLPcm.TabIndex = 3;
            this.trkLPcm.Value = 20;
            this.trkLPcm.Scroll += new System.EventHandler(this.CollectValues);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "LPI";
            // 
            // lblLPcm
            // 
            this.lblLPcm.AutoSize = true;
            this.lblLPcm.Location = new System.Drawing.Point(284, 143);
            this.lblLPcm.Name = "lblLPcm";
            this.lblLPcm.Size = new System.Drawing.Size(35, 13);
            this.lblLPcm.TabIndex = 23;
            this.lblLPcm.Text = "label2";
            this.lblLPcm.Click += new System.EventHandler(this.lblLPcm_Click);
            // 
            // prgCreate
            // 
            this.prgCreate.Location = new System.Drawing.Point(155, 369);
            this.prgCreate.Name = "prgCreate";
            this.prgCreate.Size = new System.Drawing.Size(316, 18);
            this.prgCreate.TabIndex = 30;
            // 
            // lblProcessingEnded
            // 
            this.lblProcessingEnded.AutoSize = true;
            this.lblProcessingEnded.Location = new System.Drawing.Point(152, 369);
            this.lblProcessingEnded.Name = "lblProcessingEnded";
            this.lblProcessingEnded.Size = new System.Drawing.Size(14, 13);
            this.lblProcessingEnded.TabIndex = 31;
            this.lblProcessingEnded.Text = "X";
            // 
            // grpDiscData
            // 
            this.grpDiscData.Controls.Add(this.label2);
            this.grpDiscData.Controls.Add(this.txtDuration);
            this.grpDiscData.Controls.Add(this.dbLbl);
            this.grpDiscData.Controls.Add(this.deadbandSel);
            this.grpDiscData.Controls.Add(this.pictureBox1);
            this.grpDiscData.Controls.Add(this.lblCarrier);
            this.grpDiscData.Controls.Add(this.label1);
            this.grpDiscData.Controls.Add(this.trkCarrier);
            this.grpDiscData.Controls.Add(this.sync);
            this.grpDiscData.Controls.Add(this.label7);
            this.grpDiscData.Controls.Add(this.trkEndRadiusCm);
            this.grpDiscData.Controls.Add(this.trkStartRadiusCm);
            this.grpDiscData.Controls.Add(this.lblStartRadiusIn);
            this.grpDiscData.Controls.Add(this.lblEndRadiusIn);
            this.grpDiscData.Controls.Add(this.label4);
            this.grpDiscData.Controls.Add(this.label5);
            this.grpDiscData.Controls.Add(this.lbxSpeedRPM);
            this.grpDiscData.Controls.Add(this.trkLPcm);
            this.grpDiscData.Controls.Add(this.label6);
            this.grpDiscData.Controls.Add(this.lblLPcm);
            this.grpDiscData.Location = new System.Drawing.Point(12, 27);
            this.grpDiscData.Name = "grpDiscData";
            this.grpDiscData.Size = new System.Drawing.Size(869, 293);
            this.grpDiscData.TabIndex = 4;
            this.grpDiscData.TabStop = false;
            this.grpDiscData.Text = "Disc Cutting Parameters";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Duration";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(87, 240);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(151, 20);
            this.txtDuration.TabIndex = 57;
            // 
            // dbLbl
            // 
            this.dbLbl.AutoSize = true;
            this.dbLbl.Location = new System.Drawing.Point(652, 158);
            this.dbLbl.Name = "dbLbl";
            this.dbLbl.Size = new System.Drawing.Size(57, 13);
            this.dbLbl.TabIndex = 56;
            this.dbLbl.Text = "Deadband";
            // 
            // deadbandSel
            // 
            this.deadbandSel.FormattingEnabled = true;
            this.deadbandSel.Items.AddRange(new object[] {
            "1.0025",
            "1.005",
            "1.01",
            "1.02"});
            this.deadbandSel.Location = new System.Drawing.Point(655, 174);
            this.deadbandSel.Name = "deadbandSel";
            this.deadbandSel.Size = new System.Drawing.Size(121, 21);
            this.deadbandSel.TabIndex = 55;
            this.deadbandSel.Text = "1.01";
            this.deadbandSel.SelectedIndexChanged += new System.EventHandler(this.CollectValues);
            this.deadbandSel.TabIndexChanged += new System.EventHandler(this.CollectValues);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(374, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 225);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // lblCarrier
            // 
            this.lblCarrier.AutoSize = true;
            this.lblCarrier.Location = new System.Drawing.Point(284, 193);
            this.lblCarrier.Name = "lblCarrier";
            this.lblCarrier.Size = new System.Drawing.Size(35, 13);
            this.lblCarrier.TabIndex = 52;
            this.lblCarrier.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Carrier Freq";
            // 
            // trkCarrier
            // 
            this.trkCarrier.Location = new System.Drawing.Point(87, 185);
            this.trkCarrier.Maximum = 20;
            this.trkCarrier.Minimum = 1;
            this.trkCarrier.Name = "trkCarrier";
            this.trkCarrier.Size = new System.Drawing.Size(178, 45);
            this.trkCarrier.TabIndex = 53;
            this.trkCarrier.Value = 1;
            this.trkCarrier.Scroll += new System.EventHandler(this.CollectValues);
            // 
            // sync
            // 
            this.sync.AutoSize = true;
            this.sync.Location = new System.Drawing.Point(655, 129);
            this.sync.Name = "sync";
            this.sync.Size = new System.Drawing.Size(86, 17);
            this.sync.TabIndex = 28;
            this.sync.Text = "Sync Enable";
            this.sync.UseVisualStyleBackColor = true;
            this.sync.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(652, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Turntable RPM";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 399);
            this.Controls.Add(this.grpDiscData);
            this.Controls.Add(this.lblProcessingEnded);
            this.Controls.Add(this.prgCreate);
            this.Controls.Add(this.cmdCreateWAVData);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Vinyl Draw";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkStartRadiusCm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkEndRadiusCm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkLPcm)).EndInit();
            this.grpDiscData.ResumeLayout(false);
            this.grpDiscData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkCarrier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Button cmdCreateWAVData;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TrackBar trkStartRadiusCm;
        private System.Windows.Forms.TrackBar trkEndRadiusCm;
        private System.Windows.Forms.Label lblStartRadiusIn;
        private System.Windows.Forms.Label lblEndRadiusIn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbxSpeedRPM;
        private System.Windows.Forms.TrackBar trkLPcm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLPcm;
        private System.Windows.Forms.ProgressBar prgCreate;
        private System.Windows.Forms.Label lblProcessingEnded;
        private System.Windows.Forms.GroupBox grpDiscData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox sync;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCarrier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trkCarrier;
        private System.Windows.Forms.Label dbLbl;
        private System.Windows.Forms.ComboBox deadbandSel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDuration;
    }
}

