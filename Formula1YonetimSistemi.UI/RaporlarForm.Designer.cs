namespace Formula1YonetimSistemi.UI
{
    partial class FrmRapor
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            tabPilotKiyaslama = new TabControl();
            tabSampiyonaLiderlik = new TabPage();
            btnGetir = new Button();
            cmbSezonFiltresi = new ComboBox();
            cmbSampiyonaTuru = new ComboBox();
            chartLiderlik = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dgvLiderlik = new DataGridView();
            Tab = new TabPage();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            lblP2Ustunluk = new Label();
            lblP1Ustunluk = new Label();
            lblP2Ortalama = new Label();
            lblP1Ortalama = new Label();
            btnKiyasla = new Button();
            cmbTakim = new ComboBox();
            tabIstikrarAnalizi = new TabPage();
            cmbSezonIstikrar = new ComboBox();
            chartIstikrar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            btnIstikrarAnaliz = new Button();
            cmbIstikrarPilot = new ComboBox();
            cmbSezonKiyaslama = new ComboBox();
            tabPilotKiyaslama.SuspendLayout();
            tabSampiyonaLiderlik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartLiderlik).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLiderlik).BeginInit();
            Tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            tabIstikrarAnalizi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartIstikrar).BeginInit();
            SuspendLayout();
            // 
            // tabPilotKiyaslama
            // 
            tabPilotKiyaslama.Controls.Add(tabSampiyonaLiderlik);
            tabPilotKiyaslama.Controls.Add(Tab);
            tabPilotKiyaslama.Controls.Add(tabIstikrarAnalizi);
            tabPilotKiyaslama.Dock = DockStyle.Fill;
            tabPilotKiyaslama.Location = new Point(0, 0);
            tabPilotKiyaslama.Name = "tabPilotKiyaslama";
            tabPilotKiyaslama.SelectedIndex = 0;
            tabPilotKiyaslama.Size = new Size(1018, 700);
            tabPilotKiyaslama.TabIndex = 0;
            // 
            // tabSampiyonaLiderlik
            // 
            tabSampiyonaLiderlik.Controls.Add(btnGetir);
            tabSampiyonaLiderlik.Controls.Add(cmbSezonFiltresi);
            tabSampiyonaLiderlik.Controls.Add(cmbSampiyonaTuru);
            tabSampiyonaLiderlik.Controls.Add(chartLiderlik);
            tabSampiyonaLiderlik.Controls.Add(dgvLiderlik);
            tabSampiyonaLiderlik.Location = new Point(4, 29);
            tabSampiyonaLiderlik.Name = "tabSampiyonaLiderlik";
            tabSampiyonaLiderlik.Padding = new Padding(3);
            tabSampiyonaLiderlik.Size = new Size(1010, 667);
            tabSampiyonaLiderlik.TabIndex = 0;
            tabSampiyonaLiderlik.Text = "Şampiyona Liderlik";
            tabSampiyonaLiderlik.UseVisualStyleBackColor = true;
            // 
            // btnGetir
            // 
            btnGetir.Location = new Point(350, 27);
            btnGetir.Name = "btnGetir";
            btnGetir.Size = new Size(71, 29);
            btnGetir.TabIndex = 4;
            btnGetir.Text = "Getir";
            btnGetir.UseVisualStyleBackColor = true;
            btnGetir.Click += btnGetir_Click;
            // 
            // cmbSezonFiltresi
            // 
            cmbSezonFiltresi.FormattingEnabled = true;
            cmbSezonFiltresi.Location = new Point(222, 27);
            cmbSezonFiltresi.Name = "cmbSezonFiltresi";
            cmbSezonFiltresi.Size = new Size(122, 28);
            cmbSezonFiltresi.TabIndex = 3;
            // 
            // cmbSampiyonaTuru
            // 
            cmbSampiyonaTuru.FormattingEnabled = true;
            cmbSampiyonaTuru.Location = new Point(8, 27);
            cmbSampiyonaTuru.Name = "cmbSampiyonaTuru";
            cmbSampiyonaTuru.Size = new Size(208, 28);
            cmbSampiyonaTuru.TabIndex = 2;
            cmbSampiyonaTuru.SelectedIndexChanged += cmbSampiyonaTuru_SelectedIndexChanged;
            // 
            // chartLiderlik
            // 
            chartArea1.Name = "ChartArea1";
            chartLiderlik.ChartAreas.Add(chartArea1);
            chartLiderlik.Dock = DockStyle.Right;
            legend1.Name = "Legend1";
            chartLiderlik.Legends.Add(legend1);
            chartLiderlik.Location = new Point(436, 3);
            chartLiderlik.Name = "chartLiderlik";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartLiderlik.Series.Add(series1);
            chartLiderlik.Size = new Size(571, 661);
            chartLiderlik.TabIndex = 1;
            chartLiderlik.Text = "Liderlik";
            chartLiderlik.Click += chartLiderlik_Click;
            // 
            // dgvLiderlik
            // 
            dgvLiderlik.AllowUserToAddRows = false;
            dgvLiderlik.AllowUserToDeleteRows = false;
            dgvLiderlik.Anchor = AnchorStyles.Left;
            dgvLiderlik.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLiderlik.Location = new Point(3, 88);
            dgvLiderlik.Name = "dgvLiderlik";
            dgvLiderlik.ReadOnly = true;
            dgvLiderlik.RowHeadersWidth = 51;
            dgvLiderlik.Size = new Size(432, 592);
            dgvLiderlik.TabIndex = 0;
            // 
            // Tab
            // 
            Tab.BackColor = Color.DarkGray;
            Tab.Controls.Add(cmbSezonKiyaslama);
            Tab.Controls.Add(chart1);
            Tab.Controls.Add(lblP2Ustunluk);
            Tab.Controls.Add(lblP1Ustunluk);
            Tab.Controls.Add(lblP2Ortalama);
            Tab.Controls.Add(lblP1Ortalama);
            Tab.Controls.Add(btnKiyasla);
            Tab.Controls.Add(cmbTakim);
            Tab.Location = new Point(4, 29);
            Tab.Name = "Tab";
            Tab.Padding = new Padding(3);
            Tab.Size = new Size(1010, 667);
            Tab.TabIndex = 1;
            Tab.Text = "Pilot Kıyaslama";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(499, 0);
            chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart1.Series.Add(series2);
            chart1.Size = new Size(516, 636);
            chart1.TabIndex = 7;
            chart1.Text = "chart1";
            // 
            // lblP2Ustunluk
            // 
            lblP2Ustunluk.AutoSize = true;
            lblP2Ustunluk.Location = new Point(30, 494);
            lblP2Ustunluk.Name = "lblP2Ustunluk";
            lblP2Ustunluk.Size = new Size(85, 20);
            lblP2Ustunluk.TabIndex = 6;
            lblP2Ustunluk.Text = "P2 Üstünlük";
            // 
            // lblP1Ustunluk
            // 
            lblP1Ustunluk.AutoSize = true;
            lblP1Ustunluk.Location = new Point(30, 406);
            lblP1Ustunluk.Name = "lblP1Ustunluk";
            lblP1Ustunluk.Size = new Size(85, 20);
            lblP1Ustunluk.TabIndex = 5;
            lblP1Ustunluk.Text = "P1 Üstünlük";
            // 
            // lblP2Ortalama
            // 
            lblP2Ortalama.AutoSize = true;
            lblP2Ortalama.Location = new Point(30, 318);
            lblP2Ortalama.Name = "lblP2Ortalama";
            lblP2Ortalama.Size = new Size(91, 20);
            lblP2Ortalama.TabIndex = 4;
            lblP2Ortalama.Text = "P2 Ortalama";
            // 
            // lblP1Ortalama
            // 
            lblP1Ortalama.AutoSize = true;
            lblP1Ortalama.Location = new Point(30, 230);
            lblP1Ortalama.Name = "lblP1Ortalama";
            lblP1Ortalama.Size = new Size(91, 20);
            lblP1Ortalama.TabIndex = 3;
            lblP1Ortalama.Text = "P1 Ortalama";
            // 
            // btnKiyasla
            // 
            btnKiyasla.Location = new Point(210, 139);
            btnKiyasla.Name = "btnKiyasla";
            btnKiyasla.Size = new Size(94, 29);
            btnKiyasla.TabIndex = 2;
            btnKiyasla.Text = "Kıyasla";
            btnKiyasla.UseVisualStyleBackColor = true;
            btnKiyasla.Click += btnKiyasla_Click;
            // 
            // cmbTakim
            // 
            cmbTakim.FormattingEnabled = true;
            cmbTakim.Location = new Point(44, 74);
            cmbTakim.Name = "cmbTakim";
            cmbTakim.Size = new Size(194, 28);
            cmbTakim.TabIndex = 0;
            cmbTakim.SelectedIndexChanged += cmbTakimlar_SelectedIndexChanged;
            // 
            // tabIstikrarAnalizi
            // 
            tabIstikrarAnalizi.Controls.Add(cmbSezonIstikrar);
            tabIstikrarAnalizi.Controls.Add(chartIstikrar);
            tabIstikrarAnalizi.Controls.Add(btnIstikrarAnaliz);
            tabIstikrarAnalizi.Controls.Add(cmbIstikrarPilot);
            tabIstikrarAnalizi.Location = new Point(4, 29);
            tabIstikrarAnalizi.Name = "tabIstikrarAnalizi";
            tabIstikrarAnalizi.Size = new Size(1010, 667);
            tabIstikrarAnalizi.TabIndex = 0;
            tabIstikrarAnalizi.Text = "İstikrar Analizi";
            tabIstikrarAnalizi.UseVisualStyleBackColor = true;
            // 
            // cmbSezonIstikrar
            // 
            cmbSezonIstikrar.FormattingEnabled = true;
            cmbSezonIstikrar.Location = new Point(412, 18);
            cmbSezonIstikrar.Name = "cmbSezonIstikrar";
            cmbSezonIstikrar.Size = new Size(134, 28);
            cmbSezonIstikrar.TabIndex = 3;
            // 
            // chartIstikrar
            // 
            chartArea3.Name = "ChartArea1";
            chartIstikrar.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chartIstikrar.Legends.Add(legend3);
            chartIstikrar.Location = new Point(3, 66);
            chartIstikrar.Name = "chartIstikrar";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chartIstikrar.Series.Add(series3);
            chartIstikrar.Size = new Size(1012, 570);
            chartIstikrar.TabIndex = 2;
            chartIstikrar.Text = "chart2";
            // 
            // btnIstikrarAnaliz
            // 
            btnIstikrarAnaliz.Location = new Point(559, 17);
            btnIstikrarAnaliz.Name = "btnIstikrarAnaliz";
            btnIstikrarAnaliz.Size = new Size(94, 29);
            btnIstikrarAnaliz.TabIndex = 1;
            btnIstikrarAnaliz.Text = "Analiz Et";
            btnIstikrarAnaliz.UseVisualStyleBackColor = true;
            btnIstikrarAnaliz.Click += btnIstikrarAnaliz_Click;
            // 
            // cmbIstikrarPilot
            // 
            cmbIstikrarPilot.FormattingEnabled = true;
            cmbIstikrarPilot.Location = new Point(193, 17);
            cmbIstikrarPilot.Name = "cmbIstikrarPilot";
            cmbIstikrarPilot.Size = new Size(201, 28);
            cmbIstikrarPilot.TabIndex = 0;
            // 
            // cmbSezonKiyaslama
            // 
            cmbSezonKiyaslama.FormattingEnabled = true;
            cmbSezonKiyaslama.Location = new Point(259, 74);
            cmbSezonKiyaslama.Name = "cmbSezonKiyaslama";
            cmbSezonKiyaslama.Size = new Size(194, 28);
            cmbSezonKiyaslama.TabIndex = 8;
            // 
            // FrmRapor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            ClientSize = new Size(1018, 700);
            Controls.Add(tabPilotKiyaslama);
            Name = "FrmRapor";
            Text = "RaporlarForm";
            Load += RaporlarForm_Load;
            tabPilotKiyaslama.ResumeLayout(false);
            tabSampiyonaLiderlik.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartLiderlik).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLiderlik).EndInit();
            Tab.ResumeLayout(false);
            Tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            tabIstikrarAnalizi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartIstikrar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabPilotKiyaslama;
        private TabPage tabSampiyonaLiderlik;
        private TabPage Tab;
        private TabPage tabIstikrarAnalizi;
        private DataGridView dgvLiderlik;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLiderlik;
        private Button btnKiyasla;
        private ComboBox cmbTakim;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Label lblP2Ustunluk;
        private Label lblP1Ustunluk;
        private Label lblP2Ortalama;
        private Label lblP1Ortalama;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIstikrar;
        private Button btnIstikrarAnaliz;
        private ComboBox cmbIstikrarPilot;
        private ComboBox cmbSampiyonaTuru;
        private ComboBox cmbSezonFiltresi;
        private Button btnGetir;
        private ComboBox cmbSezonIstikrar;
        private ComboBox cmbSezonKiyaslama;
    }
}