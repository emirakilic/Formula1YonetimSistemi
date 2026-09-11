namespace Formula1YonetimSistemi.UI
{
    partial class FrmPilot
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
            txtPilotId = new TextBox();
            dgvPilot = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnEkle = new Button();
            btnSil = new Button();
            btnGuncelle = new Button();
            btnAra = new Button();
            txtPilotAdSoyad = new TextBox();
            txtPilotNo = new TextBox();
            chkAktifMi = new CheckBox();
            cmbTakim = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvPilot).BeginInit();
            SuspendLayout();
            // 
            // txtPilotId
            // 
            txtPilotId.Location = new Point(39, 105);
            txtPilotId.Name = "txtPilotId";
            txtPilotId.Size = new Size(125, 27);
            txtPilotId.TabIndex = 0;
            txtPilotId.Visible = false;
            // 
            // dgvPilot
            // 
            dgvPilot.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPilot.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPilot.Location = new Point(54, 183);
            dgvPilot.Name = "dgvPilot";
            dgvPilot.RowHeadersWidth = 51;
            dgvPilot.Size = new Size(871, 278);
            dgvPilot.TabIndex = 5;
            dgvPilot.CellClick += dgvPilot_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 82);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 6;
            label1.Text = "Pilot ID";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(139, 81);
            label2.Name = "label2";
            label2.Size = new Size(107, 20);
            label2.TabIndex = 7;
            label2.Text = "Pilot Ad Soyad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(332, 81);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 8;
            label3.Text = "Pilot No";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(527, 81);
            label4.Name = "label4";
            label4.Size = new Size(102, 20);
            label4.TabIndex = 9;
            label4.Text = "Pilot Aktif Mi?";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(722, 81);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 10;
            label5.Text = "Takım Adı";
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(323, 518);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(125, 65);
            btnEkle.TabIndex = 11;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(747, 518);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(125, 65);
            btnSil.TabIndex = 12;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Location = new Point(535, 518);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(125, 65);
            btnGuncelle.TabIndex = 13;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnAra
            // 
            btnAra.Location = new Point(111, 518);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(125, 65);
            btnAra.TabIndex = 14;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = true;
            btnAra.Click += btnAra_Click;
            // 
            // txtPilotAdSoyad
            // 
            txtPilotAdSoyad.Location = new Point(139, 104);
            txtPilotAdSoyad.Name = "txtPilotAdSoyad";
            txtPilotAdSoyad.Size = new Size(125, 27);
            txtPilotAdSoyad.TabIndex = 15;
            // 
            // txtPilotNo
            // 
            txtPilotNo.Location = new Point(319, 104);
            txtPilotNo.Name = "txtPilotNo";
            txtPilotNo.Size = new Size(125, 27);
            txtPilotNo.TabIndex = 16;
            // 
            // chkAktifMi
            // 
            chkAktifMi.AutoSize = true;
            chkAktifMi.Location = new Point(528, 107);
            chkAktifMi.Name = "chkAktifMi";
            chkAktifMi.Size = new Size(62, 24);
            chkAktifMi.TabIndex = 17;
            chkAktifMi.Text = "Aktif";
            chkAktifMi.UseVisualStyleBackColor = true;
            // 
            // cmbTakim
            // 
            cmbTakim.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTakim.FormattingEnabled = true;
            cmbTakim.Location = new Point(680, 105);
            cmbTakim.Name = "cmbTakim";
            cmbTakim.Size = new Size(151, 28);
            cmbTakim.TabIndex = 18;
            // 
            // FrmPilot
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(982, 653);
            Controls.Add(cmbTakim);
            Controls.Add(chkAktifMi);
            Controls.Add(txtPilotNo);
            Controls.Add(txtPilotAdSoyad);
            Controls.Add(btnAra);
            Controls.Add(btnGuncelle);
            Controls.Add(btnSil);
            Controls.Add(btnEkle);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvPilot);
            Controls.Add(txtPilotId);
            Name = "FrmPilot";
            Text = "PilotForm";
            Load += PilotForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPilot).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPilotId;
        private TextBox txtPilotAdSoyad;
        private TextBox txtPilotNo;
        private DataGridView dgvPilot;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnEkle;
        private Button btnSil;
        private Button btnGuncelle;
        private Button btnAra;
        private ComboBox cmbTakim;
        private CheckBox chkAktifMi;
    }
}