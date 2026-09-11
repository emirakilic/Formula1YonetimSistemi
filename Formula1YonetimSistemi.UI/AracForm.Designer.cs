namespace Formula1YonetimSistemi.UI
{
    partial class FrmArac
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
            dgvArac = new DataGridView();
            txtAracId = new TextBox();
            txtSasiKodu = new TextBox();
            txtMotor = new TextBox();
            btnEkle = new Button();
            btnSil = new Button();
            btnGuncelle = new Button();
            lblAracId = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cmbTakim = new ComboBox();
            btnAra = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvArac).BeginInit();
            SuspendLayout();
            // 
            // dgvArac
            // 
            dgvArac.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArac.BackgroundColor = SystemColors.ControlLight;
            dgvArac.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArac.Location = new Point(12, 171);
            dgvArac.Name = "dgvArac";
            dgvArac.RowHeadersWidth = 51;
            dgvArac.Size = new Size(958, 284);
            dgvArac.TabIndex = 0;
            dgvArac.CellClick += dgvArac_CellClick;
            // 
            // txtAracId
            // 
            txtAracId.Location = new Point(45, 78);
            txtAracId.Name = "txtAracId";
            txtAracId.Size = new Size(146, 27);
            txtAracId.TabIndex = 1;
            txtAracId.Visible = false;
            // 
            // txtSasiKodu
            // 
            txtSasiKodu.Location = new Point(196, 78);
            txtSasiKodu.Name = "txtSasiKodu";
            txtSasiKodu.Size = new Size(149, 27);
            txtSasiKodu.TabIndex = 2;
            // 
            // txtMotor
            // 
            txtMotor.Location = new Point(439, 78);
            txtMotor.Name = "txtMotor";
            txtMotor.Size = new Size(143, 27);
            txtMotor.TabIndex = 3;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(329, 522);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(125, 65);
            btnEkle.TabIndex = 5;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(765, 522);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(125, 65);
            btnSil.TabIndex = 6;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Location = new Point(547, 522);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(125, 65);
            btnGuncelle.TabIndex = 7;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // lblAracId
            // 
            lblAracId.AutoSize = true;
            lblAracId.Location = new Point(47, 55);
            lblAracId.Name = "lblAracId";
            lblAracId.Size = new Size(58, 20);
            lblAracId.TabIndex = 8;
            lblAracId.Text = "Araç ID";
            lblAracId.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(197, 57);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 9;
            label2.Text = "Şasi Kodu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(437, 55);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 10;
            label3.Text = "Motor";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(676, 55);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 11;
            label4.Text = "Takım";
            // 
            // cmbTakim
            // 
            cmbTakim.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTakim.FormattingEnabled = true;
            cmbTakim.Location = new Point(676, 78);
            cmbTakim.Name = "cmbTakim";
            cmbTakim.Size = new Size(151, 28);
            cmbTakim.TabIndex = 12;
            // 
            // btnAra
            // 
            btnAra.Location = new Point(111, 522);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(125, 65);
            btnAra.TabIndex = 13;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = true;
            btnAra.Click += btnAra_Click;
            // 
            // FrmArac
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(982, 653);
            Controls.Add(btnAra);
            Controls.Add(cmbTakim);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblAracId);
            Controls.Add(btnGuncelle);
            Controls.Add(btnSil);
            Controls.Add(btnEkle);
            Controls.Add(txtMotor);
            Controls.Add(txtSasiKodu);
            Controls.Add(txtAracId);
            Controls.Add(dgvArac);
            Name = "FrmArac";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Arac Form";
            Load += AracForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvArac).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvArac;
        private TextBox txtAracId;
        private TextBox txtSasiKodu;
        private TextBox txtMotor;
        private TextBox textBox4;
        private Button btnEkle;
        private Button btnSil;
        private Button btnGuncelle;
        private Label lblAracId;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cmbTakim;
        private Button btnAra;
    }
}