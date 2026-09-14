using Formula1YonetimSistemi.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Formula1YonetimSistemi.UI
{
    public partial class FrmRapor : Form
    {
        public FrmRapor()
        {
            InitializeComponent();
        }

        private void RaporlarForm_Load(object sender, EventArgs e)
        {
            var liderlikListesi = new SRapor().SSampiyonaSiralamasiGetir();
            dgvLiderlik.DataSource = liderlikListesi;

            dgvLiderlik.Columns["PilotAdi"].HeaderText = "Pilot Adı";
            dgvLiderlik.Columns["ToplamPuan"].HeaderText = "Toplam\nPuan";
            dgvLiderlik.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLiderlik.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Sütunların üst üste binmesini engeller ve yan yana dizer:
            chartLiderlik.Series[0].IsXValueIndexed = true;

            // X ekseninde isimlerin atlanmadan (her bir pilotun) yazılmasını sağlar:
            chartLiderlik.ChartAreas[0].AxisX.Interval = 1;

            chartLiderlik.Series[0].Points.Clear();
            chartLiderlik.Series[0].Name = "Toplam Puan";

            foreach (var pilot in liderlikListesi)
            {
                chartLiderlik.Series[0].Points.AddXY(pilot.PilotAdi, pilot.ToplamPuan);
            }
            F1TemaMotoru.TemayiUygula(this);
        }

        private void chartLiderlik_Click(object sender, EventArgs e)
        {

        }
    }
}
