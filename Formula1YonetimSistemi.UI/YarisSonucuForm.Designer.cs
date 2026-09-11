namespace Formula1YonetimSistemi.UI
{
    partial class FrmYarisSonucu
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
            cmbPilot = new ComboBox();
            cmbPist = new ComboBox();
            txtEnHizliTur = new TextBox();
            txtYarisPuani = new TextBox();
            txtYarisPozisyonu = new TextBox();
            dgvYarisSonucu = new DataGridView();
            btnEkle = new Button();
            btnSil = new Button();
            btnGuncelle = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnAra = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvYarisSonucu).BeginInit();
            SuspendLayout();
            // 
            // cmbPilot
            // 
            cmbPilot.FormattingEnabled = true;
            cmbPilot.Location = new Point(29, 54);
            cmbPilot.Name = "cmbPilot";
            cmbPilot.Size = new Size(151, 28);
            cmbPilot.TabIndex = 0;
            // 
            // cmbPist
            // 
            cmbPist.FormattingEnabled = true;
            cmbPist.Location = new Point(241, 54);
            cmbPist.Name = "cmbPist";
            cmbPist.Size = new Size(151, 28);
            cmbPist.TabIndex = 1;
            // 
            // txtEnHizliTur
            // 
            txtEnHizliTur.Location = new Point(820, 55);
            txtEnHizliTur.Name = "txtEnHizliTur";
            txtEnHizliTur.Size = new Size(125, 27);
            txtEnHizliTur.TabIndex = 2;
            // 
            // txtYarisPuani
            // 
            txtYarisPuani.Location = new Point(641, 55);
            txtYarisPuani.Name = "txtYarisPuani";
            txtYarisPuani.Size = new Size(125, 27);
            txtYarisPuani.TabIndex = 3;
            // 
            // txtYarisPozisyonu
            // 
            txtYarisPozisyonu.Location = new Point(442, 55);
            txtYarisPozisyonu.Name = "txtYarisPozisyonu";
            txtYarisPozisyonu.Size = new Size(125, 27);
            txtYarisPozisyonu.TabIndex = 4;
            // 
            // dgvYarisSonucu
            // 
            dgvYarisSonucu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvYarisSonucu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvYarisSonucu.Location = new Point(38, 136);
            dgvYarisSonucu.Name = "dgvYarisSonucu";
            dgvYarisSonucu.RowHeadersWidth = 51;
            dgvYarisSonucu.Size = new Size(894, 324);
            dgvYarisSonucu.TabIndex = 5;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(313, 522);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(125, 65);
            btnEkle.TabIndex = 6;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(745, 522);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(125, 65);
            btnSil.TabIndex = 7;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Location = new Point(529, 522);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(125, 65);
            btnGuncelle.TabIndex = 8;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 31);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 9;
            label1.Text = "Pilot";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(241, 31);
            label2.Name = "label2";
            label2.Size = new Size(32, 20);
            label2.TabIndex = 10;
            label2.Text = "Pist";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(442, 32);
            label3.Name = "label3";
            label3.Size = new Size(108, 20);
            label3.TabIndex = 11;
            label3.Text = "Yarış Pozisyonu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(641, 32);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 12;
            label4.Text = "Yarış Puanı";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(820, 31);
            label5.Name = "label5";
            label5.Size = new Size(138, 20);
            label5.TabIndex = 13;
            label5.Text = "En Hızlı Tur Zamanı";
            // 
            // btnAra
            // 
            btnAra.Location = new Point(97, 522);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(125, 65);
            btnAra.TabIndex = 15;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = true;
            btnAra.Click += btnAra_Click;
            // 
            // FrmYarisSonucu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(982, 653);
            Controls.Add(btnAra);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGuncelle);
            Controls.Add(btnSil);
            Controls.Add(btnEkle);
            Controls.Add(dgvYarisSonucu);
            Controls.Add(txtYarisPozisyonu);
            Controls.Add(txtYarisPuani);
            Controls.Add(txtEnHizliTur);
            Controls.Add(cmbPist);
            Controls.Add(cmbPilot);
            Name = "FrmYarisSonucu";
            Text = "YarisSonucuForm";
            Load += YarisSonucuForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvYarisSonucu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbPilot;
        private ComboBox cmbPist;
        private TextBox txtEnHizliTur;
        private TextBox txtYarisPuani;
        private TextBox txtYarisPozisyonu;
        private DataGridView dgvYarisSonucu;
        private Button btnEkle;
        private Button btnSil;
        private Button btnGuncelle;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnAra;
    }
}