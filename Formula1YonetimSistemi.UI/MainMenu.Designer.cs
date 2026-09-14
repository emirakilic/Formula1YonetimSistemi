namespace Formula1YonetimSistemi.UI
{
    partial class FrmMainMenu
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
            splitContainer1 = new SplitContainer();
            btnYarisSonucu = new Button();
            btnPilot = new Button();
            btnTakim = new Button();
            btnYaris = new Button();
            btnArac = new Button();
            btnRaporlar = new Button();
            gbGiris = new GroupBox();
            btnGiris = new Button();
            lblSifre = new Label();
            txtSifre = new TextBox();
            lblKullaniciAdi = new Label();
            txtKullaniciAdi = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            gbGiris.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.ActiveCaptionText;
            splitContainer1.Panel1.Controls.Add(btnYarisSonucu);
            splitContainer1.Panel1.Controls.Add(btnPilot);
            splitContainer1.Panel1.Controls.Add(btnTakim);
            splitContainer1.Panel1.Controls.Add(btnYaris);
            splitContainer1.Panel1.Controls.Add(btnArac);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ActiveCaptionText;
            splitContainer1.Panel2.Controls.Add(btnRaporlar);
            splitContainer1.Panel2.Controls.Add(gbGiris);
            splitContainer1.Size = new Size(1046, 474);
            splitContainer1.SplitterDistance = 81;
            splitContainer1.TabIndex = 0;
            // 
            // btnYarisSonucu
            // 
            btnYarisSonucu.BackColor = Color.FromArgb(225, 6, 0);
            btnYarisSonucu.FlatStyle = FlatStyle.Flat;
            btnYarisSonucu.Location = new Point(868, 12);
            btnYarisSonucu.Name = "btnYarisSonucu";
            btnYarisSonucu.Size = new Size(115, 53);
            btnYarisSonucu.TabIndex = 4;
            btnYarisSonucu.Text = "Yarış Sonucu";
            btnYarisSonucu.UseVisualStyleBackColor = false;
            btnYarisSonucu.Click += btnYarisSonucu_Click;
            // 
            // btnPilot
            // 
            btnPilot.BackColor = Color.FromArgb(225, 6, 0);
            btnPilot.FlatStyle = FlatStyle.Flat;
            btnPilot.Location = new Point(256, 12);
            btnPilot.Name = "btnPilot";
            btnPilot.Size = new Size(115, 53);
            btnPilot.TabIndex = 0;
            btnPilot.Text = "Pilot";
            btnPilot.UseVisualStyleBackColor = false;
            btnPilot.Click += btnPilot_Click;
            // 
            // btnTakim
            // 
            btnTakim.BackColor = Color.FromArgb(225, 6, 0);
            btnTakim.FlatStyle = FlatStyle.Flat;
            btnTakim.Location = new Point(458, 12);
            btnTakim.Name = "btnTakim";
            btnTakim.Size = new Size(115, 53);
            btnTakim.TabIndex = 2;
            btnTakim.Text = "Takım";
            btnTakim.UseVisualStyleBackColor = false;
            btnTakim.Click += btnTakim_Click;
            // 
            // btnYaris
            // 
            btnYaris.BackColor = Color.FromArgb(225, 6, 0);
            btnYaris.FlatStyle = FlatStyle.Flat;
            btnYaris.Location = new Point(663, 12);
            btnYaris.Name = "btnYaris";
            btnYaris.Size = new Size(115, 53);
            btnYaris.TabIndex = 3;
            btnYaris.Text = "Yarış";
            btnYaris.UseVisualStyleBackColor = false;
            btnYaris.Click += btnYaris_Click;
            // 
            // btnArac
            // 
            btnArac.BackColor = Color.FromArgb(225, 6, 0);
            btnArac.FlatStyle = FlatStyle.Flat;
            btnArac.Location = new Point(58, 12);
            btnArac.Name = "btnArac";
            btnArac.Size = new Size(115, 53);
            btnArac.TabIndex = 1;
            btnArac.Text = "Araç";
            btnArac.UseVisualStyleBackColor = false;
            btnArac.Click += btnArac_Click;
            // 
            // btnRaporlar
            // 
            btnRaporlar.BackColor = Color.FromArgb(225, 6, 0);
            btnRaporlar.FlatStyle = FlatStyle.Flat;
            btnRaporlar.Location = new Point(58, 55);
            btnRaporlar.Name = "btnRaporlar";
            btnRaporlar.Size = new Size(115, 53);
            btnRaporlar.TabIndex = 6;
            btnRaporlar.Text = "Raporlar";
            btnRaporlar.UseVisualStyleBackColor = false;
            btnRaporlar.Click += btnRaporlar_Click;
            // 
            // gbGiris
            // 
            gbGiris.Controls.Add(btnGiris);
            gbGiris.Controls.Add(lblSifre);
            gbGiris.Controls.Add(txtSifre);
            gbGiris.Controls.Add(lblKullaniciAdi);
            gbGiris.Controls.Add(txtKullaniciAdi);
            gbGiris.ForeColor = SystemColors.ControlLightLight;
            gbGiris.Location = new Point(300, 75);
            gbGiris.Name = "gbGiris";
            gbGiris.Size = new Size(446, 239);
            gbGiris.TabIndex = 5;
            gbGiris.TabStop = false;
            gbGiris.Text = "Giriş Bilgileri";
            // 
            // btnGiris
            // 
            btnGiris.Location = new Point(193, 140);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(103, 29);
            btnGiris.TabIndex = 4;
            btnGiris.Text = "Giriş";
            btnGiris.UseVisualStyleBackColor = true;
            // 
            // lblSifre
            // 
            lblSifre.AutoSize = true;
            lblSifre.Location = new Point(83, 110);
            lblSifre.Name = "lblSifre";
            lblSifre.Size = new Size(39, 20);
            lblSifre.TabIndex = 3;
            lblSifre.Text = "Şifre";
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(128, 107);
            txtSifre.Name = "txtSifre";
            txtSifre.PasswordChar = '*';
            txtSifre.Size = new Size(246, 27);
            txtSifre.TabIndex = 2;
            // 
            // lblKullaniciAdi
            // 
            lblKullaniciAdi.AutoSize = true;
            lblKullaniciAdi.Location = new Point(30, 72);
            lblKullaniciAdi.Name = "lblKullaniciAdi";
            lblKullaniciAdi.Size = new Size(92, 20);
            lblKullaniciAdi.TabIndex = 1;
            lblKullaniciAdi.Text = "Kullanıcı Adı";
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Location = new Point(128, 69);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.PlaceholderText = "Kullanıcı Adı";
            txtKullaniciAdi.Size = new Size(246, 27);
            txtKullaniciAdi.TabIndex = 0;
            // 
            // FrmMainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1046, 474);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmMainMenu";
            Text = "Ana Menü";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            gbGiris.ResumeLayout(false);
            gbGiris.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button btnPilot;
        private Button btnYarisSonucu;
        private Button btnTakim;
        private Button btnYaris;
        private Button btnArac;
        private GroupBox gbGiris;
        private Button btnGiris;
        private Label lblSifre;
        private TextBox txtSifre;
        private Label lblKullaniciAdi;
        private TextBox txtKullaniciAdi;
        private Button btnRaporlar;
    }
}