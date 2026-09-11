namespace Formula1YonetimSistemi.UI
{
    partial class FrmTakim
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            txtTakimId = new TextBox();
            txtTakimAdi = new TextBox();
            txtKisaAd = new TextBox();
            dgvTakim = new DataGridView();
            btnEkle = new Button();
            btnSil = new Button();
            btnGuncelle = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnAra = new Button();
            cmbMerkezUlke = new ComboBox();
            txtKurulusYili = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvTakim).BeginInit();
            SuspendLayout();
            // 
            // txtTakimId
            // 
            txtTakimId.BackColor = Color.FromArgb(35, 35, 45);
            txtTakimId.BorderStyle = BorderStyle.FixedSingle;
            txtTakimId.Enabled = false;
            txtTakimId.ForeColor = Color.White;
            txtTakimId.Location = new Point(59, 86);
            txtTakimId.Name = "txtTakimId";
            txtTakimId.ReadOnly = true;
            txtTakimId.Size = new Size(125, 27);
            txtTakimId.TabIndex = 0;
            txtTakimId.Visible = false;
            // 
            // txtTakimAdi
            // 
            txtTakimAdi.BackColor = Color.FromArgb(35, 35, 45);
            txtTakimAdi.BorderStyle = BorderStyle.FixedSingle;
            txtTakimAdi.ForeColor = Color.White;
            txtTakimAdi.Location = new Point(157, 86);
            txtTakimAdi.Name = "txtTakimAdi";
            txtTakimAdi.Size = new Size(125, 27);
            txtTakimAdi.TabIndex = 1;
            // 
            // txtKisaAd
            // 
            txtKisaAd.BackColor = Color.FromArgb(35, 35, 45);
            txtKisaAd.BorderStyle = BorderStyle.FixedSingle;
            txtKisaAd.ForeColor = Color.White;
            txtKisaAd.Location = new Point(339, 86);
            txtKisaAd.Name = "txtKisaAd";
            txtKisaAd.Size = new Size(125, 27);
            txtKisaAd.TabIndex = 2;
            // 
            // dgvTakim
            // 
            dgvTakim.AllowUserToAddRows = false;
            dgvTakim.AllowUserToDeleteRows = false;
            dgvTakim.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTakim.BackgroundColor = Color.FromArgb(245, 246, 248);
            dgvTakim.BorderStyle = BorderStyle.None;
            dgvTakim.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTakim.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(21, 21, 30);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(21, 21, 30);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dgvTakim.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTakim.ColumnHeadersHeight = 38;
            dgvTakim.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(225, 6, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTakim.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTakim.EnableHeadersVisualStyles = false;
            dgvTakim.GridColor = Color.FromArgb(220, 220, 225);
            dgvTakim.Location = new Point(59, 177);
            dgvTakim.MultiSelect = false;
            dgvTakim.Name = "dgvTakim";
            dgvTakim.ReadOnly = true;
            dgvTakim.RowHeadersVisible = false;
            dgvTakim.RowHeadersWidth = 51;
            dgvTakim.RowTemplate.Height = 32;
            dgvTakim.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTakim.Size = new Size(857, 309);
            dgvTakim.TabIndex = 4;
            dgvTakim.CellClick += dgvTakim_CellClick;
            // 
            // btnEkle
            // 
            btnEkle.BackColor = Color.FromArgb(225, 6, 0);
            btnEkle.FlatAppearance.BorderSize = 0;
            btnEkle.FlatStyle = FlatStyle.Flat;
            btnEkle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEkle.ForeColor = Color.White;
            btnEkle.Location = new Point(328, 536);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(125, 65);
            btnEkle.TabIndex = 5;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = false;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.FromArgb(45, 45, 55);
            btnSil.FlatAppearance.BorderSize = 0;
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSil.ForeColor = Color.White;
            btnSil.Location = new Point(762, 536);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(125, 65);
            btnSil.TabIndex = 6;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.BackColor = Color.FromArgb(30, 30, 40);
            btnGuncelle.FlatAppearance.BorderSize = 0;
            btnGuncelle.FlatStyle = FlatStyle.Flat;
            btnGuncelle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuncelle.ForeColor = Color.White;
            btnGuncelle.Location = new Point(545, 536);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(125, 65);
            btnGuncelle.TabIndex = 7;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = false;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(59, 63);
            label1.Name = "label1";
            label1.Size = new Size(71, 20);
            label1.TabIndex = 9;
            label1.Text = "Takım ID";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(157, 63);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 10;
            label2.Text = "Takım Adı";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(339, 63);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 11;
            label3.Text = "Kısa Ad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(525, 63);
            label4.Name = "label4";
            label4.Size = new Size(95, 20);
            label4.TabIndex = 12;
            label4.Text = "Merkez Ülke";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(697, 63);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 13;
            label5.Text = "Kuruluş Yılı";
            // 
            // btnAra
            // 
            btnAra.BackColor = Color.FromArgb(30, 30, 40);
            btnAra.FlatAppearance.BorderSize = 0;
            btnAra.FlatStyle = FlatStyle.Flat;
            btnAra.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAra.ForeColor = Color.White;
            btnAra.Location = new Point(111, 536);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(125, 65);
            btnAra.TabIndex = 14;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = false;
            btnAra.Click += btnAra_Click;
            // 
            // cmbMerkezUlke
            // 
            cmbMerkezUlke.BackColor = Color.FromArgb(35, 35, 45);
            cmbMerkezUlke.ForeColor = SystemColors.Window;
            cmbMerkezUlke.FormattingEnabled = true;
            cmbMerkezUlke.Location = new Point(509, 85);
            cmbMerkezUlke.Name = "cmbMerkezUlke";
            cmbMerkezUlke.Size = new Size(151, 28);
            cmbMerkezUlke.TabIndex = 15;
            // 
            // txtKurulusYili
            // 
            txtKurulusYili.Location = new Point(697, 85);
            txtKurulusYili.Name = "txtKurulusYili";
            txtKurulusYili.Size = new Size(125, 27);
            txtKurulusYili.TabIndex = 16;
            // 
            // FrmTakim
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 21, 30);
            ClientSize = new Size(982, 653);
            Controls.Add(txtKurulusYili);
            Controls.Add(cmbMerkezUlke);
            Controls.Add(btnAra);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGuncelle);
            Controls.Add(btnSil);
            Controls.Add(btnEkle);
            Controls.Add(dgvTakim);
            Controls.Add(txtKisaAd);
            Controls.Add(txtTakimAdi);
            Controls.Add(txtTakimId);
            Name = "FrmTakim";
            Text = "F1 Takım Yönetim Paneli";
            Load += TakimForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTakim).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTakimId;
        private TextBox txtTakimAdi;
        private TextBox txtKisaAd;
        private TextBox txtMerkezUlke;
        private DataGridView dataGridView1;
        private Button btnEkle;
        private Button btnSil;
        private Button btnGuncelle;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnAra;
        private ComboBox cmbMerkezUlke;
        private TextBox txtKurulusYili;
        private DataGridView dgvTakim;
    }
}