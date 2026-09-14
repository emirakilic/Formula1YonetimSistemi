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
            tabPilotKiyaslama = new TabControl();
            tabSampiyonaLiderlik = new TabPage();
            chartLiderlik = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dgvLiderlik = new DataGridView();
            Tab = new TabPage();
            tabIstikrarAnalizi = new TabPage();
            tabPilotKiyaslama.SuspendLayout();
            tabSampiyonaLiderlik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartLiderlik).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLiderlik).BeginInit();
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
            tabPilotKiyaslama.Size = new Size(1023, 669);
            tabPilotKiyaslama.TabIndex = 0;
            // 
            // tabSampiyonaLiderlik
            // 
            tabSampiyonaLiderlik.Controls.Add(chartLiderlik);
            tabSampiyonaLiderlik.Controls.Add(dgvLiderlik);
            tabSampiyonaLiderlik.Location = new Point(4, 29);
            tabSampiyonaLiderlik.Name = "tabSampiyonaLiderlik";
            tabSampiyonaLiderlik.Padding = new Padding(3);
            tabSampiyonaLiderlik.Size = new Size(1015, 636);
            tabSampiyonaLiderlik.TabIndex = 0;
            tabSampiyonaLiderlik.Text = "Şampiyona Liderlik";
            tabSampiyonaLiderlik.UseVisualStyleBackColor = true;
            // 
            // chartLiderlik
            // 
            chartArea1.Name = "ChartArea1";
            chartLiderlik.ChartAreas.Add(chartArea1);
            chartLiderlik.Dock = DockStyle.Right;
            legend1.Name = "Legend1";
            chartLiderlik.Legends.Add(legend1);
            chartLiderlik.Location = new Point(441, 3);
            chartLiderlik.Name = "chartLiderlik";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartLiderlik.Series.Add(series1);
            chartLiderlik.Size = new Size(571, 630);
            chartLiderlik.TabIndex = 1;
            chartLiderlik.Text = "Liderlik";
            chartLiderlik.Click += chartLiderlik_Click;
            // 
            // dgvLiderlik
            // 
            dgvLiderlik.AllowUserToAddRows = false;
            dgvLiderlik.AllowUserToDeleteRows = false;
            dgvLiderlik.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLiderlik.Dock = DockStyle.Left;
            dgvLiderlik.Location = new Point(3, 3);
            dgvLiderlik.Name = "dgvLiderlik";
            dgvLiderlik.ReadOnly = true;
            dgvLiderlik.RowHeadersWidth = 51;
            dgvLiderlik.Size = new Size(432, 630);
            dgvLiderlik.TabIndex = 0;
            // 
            // Tab
            // 
            Tab.Location = new Point(4, 29);
            Tab.Name = "Tab";
            Tab.Padding = new Padding(3);
            Tab.Size = new Size(1015, 636);
            Tab.TabIndex = 1;
            Tab.Text = "Pilot Kıyaslama";
            Tab.UseVisualStyleBackColor = true;
            // 
            // tabIstikrarAnalizi
            // 
            tabIstikrarAnalizi.Location = new Point(4, 29);
            tabIstikrarAnalizi.Name = "tabIstikrarAnalizi";
            tabIstikrarAnalizi.Size = new Size(1015, 636);
            tabIstikrarAnalizi.TabIndex = 0;
            tabIstikrarAnalizi.Text = "İstikrar Analizi";
            tabIstikrarAnalizi.UseVisualStyleBackColor = true;
            // 
            // FrmRapor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            ClientSize = new Size(1023, 669);
            Controls.Add(tabPilotKiyaslama);
            Name = "FrmRapor";
            Text = "RaporlarForm";
            Load += RaporlarForm_Load;
            tabPilotKiyaslama.ResumeLayout(false);
            tabSampiyonaLiderlik.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartLiderlik).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLiderlik).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabPilotKiyaslama;
        private TabPage tabSampiyonaLiderlik;
        private TabPage Tab;
        private TabPage tabIstikrarAnalizi;
        private DataGridView dgvLiderlik;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLiderlik;
    }
}