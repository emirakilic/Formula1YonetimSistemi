namespace Formula1YonetimSistemi.UI
{
    partial class FrmYaris
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
            txtYarisId = new TextBox();
            txtPistAdi = new TextBox();
            txtTurSayisi = new TextBox();
            txtSezonAyagi = new TextBox();
            dtpYarisTarihi = new DateTimePicker();
            txtSezon = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            dgvYaris = new DataGridView();
            btnEkle = new Button();
            btnSil = new Button();
            btnGuncelle = new Button();
            btnAra = new Button();
            txtGrandPrix = new TextBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvYaris).BeginInit();
            SuspendLayout();
            // 
            // txtYarisId
            // 
            txtYarisId.Location = new Point(936, 77);
            txtYarisId.Name = "txtYarisId";
            txtYarisId.ReadOnly = true;
            txtYarisId.Size = new Size(125, 27);
            txtYarisId.TabIndex = 0;
            txtYarisId.Visible = false;
            // 
            // txtPistAdi
            // 
            txtPistAdi.Location = new Point(254, 77);
            txtPistAdi.Name = "txtPistAdi";
            txtPistAdi.Size = new Size(125, 27);
            txtPistAdi.TabIndex = 1;
            txtPistAdi.TextChanged += textBox2_TextChanged;
            // 
            // txtTurSayisi
            // 
            txtTurSayisi.Location = new Point(524, 77);
            txtTurSayisi.Name = "txtTurSayisi";
            txtTurSayisi.Size = new Size(125, 27);
            txtTurSayisi.TabIndex = 2;
            // 
            // txtSezonAyagi
            // 
            txtSezonAyagi.Location = new Point(794, 77);
            txtSezonAyagi.Name = "txtSezonAyagi";
            txtSezonAyagi.Size = new Size(125, 27);
            txtSezonAyagi.TabIndex = 3;
            // 
            // dtpYarisTarihi
            // 
            dtpYarisTarihi.Format = DateTimePickerFormat.Short;
            dtpYarisTarihi.Location = new Point(389, 77);
            dtpYarisTarihi.Name = "dtpYarisTarihi";
            dtpYarisTarihi.Size = new Size(125, 27);
            dtpYarisTarihi.TabIndex = 4;
            // 
            // txtSezon
            // 
            txtSezon.Location = new Point(659, 77);
            txtSezon.Name = "txtSezon";
            txtSezon.Size = new Size(125, 27);
            txtSezon.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(959, 54);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 6;
            label1.Text = "Yarış ID";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(266, 54);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 7;
            label2.Text = "Pist Adı";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(395, 54);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 8;
            label3.Text = "Yarış Tarihi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(543, 54);
            label4.Name = "label4";
            label4.Size = new Size(71, 20);
            label4.TabIndex = 9;
            label4.Text = "Tur Sayısı";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(684, 54);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 10;
            label5.Text = "Sezon";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(803, 54);
            label6.Name = "label6";
            label6.Size = new Size(91, 20);
            label6.TabIndex = 11;
            label6.Text = "Sezon Ayağı";
            // 
            // dgvYaris
            // 
            dgvYaris.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvYaris.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvYaris.Location = new Point(29, 163);
            dgvYaris.Name = "dgvYaris";
            dgvYaris.RowHeadersWidth = 51;
            dgvYaris.Size = new Size(1032, 331);
            dgvYaris.TabIndex = 12;
            dgvYaris.CellClick += dataGridView1_CellClick;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(354, 541);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(125, 65);
            btnEkle.TabIndex = 13;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(844, 541);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(125, 65);
            btnSil.TabIndex = 14;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Location = new Point(599, 541);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(125, 65);
            btnGuncelle.TabIndex = 15;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnAra
            // 
            btnAra.Location = new Point(109, 541);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(125, 65);
            btnAra.TabIndex = 16;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = true;
            btnAra.Click += btnAra_Click;
            // 
            // txtGrandPrix
            // 
            txtGrandPrix.Location = new Point(119, 77);
            txtGrandPrix.Name = "txtGrandPrix";
            txtGrandPrix.Size = new Size(125, 27);
            txtGrandPrix.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(119, 54);
            label7.Name = "label7";
            label7.Size = new Size(77, 20);
            label7.TabIndex = 18;
            label7.Text = "Grand Prix";
            // 
            // FrmYaris
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1082, 653);
            Controls.Add(label7);
            Controls.Add(txtGrandPrix);
            Controls.Add(btnAra);
            Controls.Add(btnGuncelle);
            Controls.Add(btnSil);
            Controls.Add(btnEkle);
            Controls.Add(dgvYaris);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSezon);
            Controls.Add(dtpYarisTarihi);
            Controls.Add(txtSezonAyagi);
            Controls.Add(txtTurSayisi);
            Controls.Add(txtPistAdi);
            Controls.Add(txtYarisId);
            Name = "FrmYaris";
            Text = "YarisForm";
            Load += YarisForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvYaris).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtYarisId;
        private TextBox txtPistAdi;
        private TextBox txtTurSayisi;
        private TextBox txtSezonAyagi;
        private DateTimePicker dtpYarisTarihi;
        private TextBox txtSezon;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private DataGridView dgvYaris;
        private Button btnEkle;
        private Button btnSil;
        private Button btnGuncelle;
        private Button btnAra;
        private TextBox txtGrandPrix;
        private Label label7;
    }
}