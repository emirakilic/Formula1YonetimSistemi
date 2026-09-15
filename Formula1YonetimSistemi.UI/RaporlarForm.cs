using Formula1YonetimSistemi.Service;
using System;
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
            // 1. ŞAMPİYONA TÜRÜ VE SEZONLARI DOLDUR
            cmbSezonFiltresi.Items.Clear();
            cmbSezonFiltresi.Items.Add("Tüm Zamanlar");
            cmbSezonFiltresi.Items.Add(2024);
            cmbSezonFiltresi.Items.Add(2023);
            cmbSezonFiltresi.Items.Add(2022);
            cmbSezonFiltresi.Items.Add(2021);
            cmbSezonFiltresi.SelectedIndex = 0;

            cmbSampiyonaTuru.Items.Clear();
            cmbSampiyonaTuru.Items.Add("Pilotlar Şampiyonası");
            cmbSampiyonaTuru.Items.Add("Takımlar Şampiyonası");
            cmbSampiyonaTuru.SelectedIndex = 0;

            // 2. İSTİKRAR VE KIYASLAMA SEZONLARI
            cmbSezonIstikrar.Items.Clear();
            cmbSezonIstikrar.Items.Add("Tüm Zamanlar");
            cmbSezonIstikrar.Items.Add(2024);
            cmbSezonIstikrar.Items.Add(2023);
            cmbSezonIstikrar.Items.Add(2022);
            cmbSezonIstikrar.Items.Add(2021);

            cmbSezonKiyaslama.Items.Clear();
            cmbSezonKiyaslama.Items.Add("Tüm Zamanlar");
            cmbSezonKiyaslama.Items.Add(2024);
            cmbSezonKiyaslama.Items.Add(2023);
            cmbSezonKiyaslama.Items.Add(2022);
            cmbSezonKiyaslama.Items.Add(2021);

            // 3. PİLOT VE TAKIM KUTULARINI DOLDUR
            var takimListesi = new STakim().STakimlariGetir();
            cmbTakim.DataSource = takimListesi;
            cmbTakim.DisplayMember = "TakimAdi";
            cmbTakim.ValueMember = "TakimId";

            cmbIstikrarPilot.DataSource = new SPilot().SPilotlariGetir();
            cmbIstikrarPilot.DisplayMember = "PilotAdSoyad";
            cmbIstikrarPilot.ValueMember = "PilotId";

            // 4. GRAFİK İLK AYARLARI (Hata veren kısımlar düzeltildi)
            chartLiderlik.Series[0].IsXValueIndexed = true;
            chartLiderlik.ChartAreas[0].AxisX.Interval = 1;
            chartLiderlik.Legends[0].Enabled = false;

            // 5. OTOMATİK SEÇİMLERİ YAP
            if (cmbIstikrarPilot.Items.Count > 0) cmbIstikrarPilot.SelectedIndex = 0;
            if (cmbTakim.Items.Count > 0) cmbTakim.SelectedIndex = 0;
            if (cmbSezonIstikrar.Items.Count > 0) cmbSezonIstikrar.SelectedIndex = 0;
            if (cmbSezonKiyaslama.Items.Count > 0) cmbSezonKiyaslama.SelectedIndex = 0;

            // 6. BUTONLARI TETİKLE VE TEMAYI UYGULA
            btnIstikrarAnaliz_Click(null, null);
            btnKiyasla_Click(null, null);

            F1TemaMotoru.TemayiUygula(this);
            btnGetir.PerformClick();
        }

        private void btnKiyasla_Click(object sender, EventArgs e)
        {
            if (cmbTakim.SelectedIndex == -1 || cmbSezonKiyaslama.SelectedIndex == -1)
            {
                if (sender != null) MessageBox.Show("Lütfen kıyaslamak için bir takım ve sezon seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var secilenTakim = (Formula1YonetimSistemi.Common.DTO.Takim)cmbTakim.SelectedItem;
            int secilenTakimId = secilenTakim.TakimId;

            int seciliSezon = 0;
            if (cmbSezonKiyaslama.SelectedItem.ToString() != "Tüm Zamanlar")
            {
                seciliSezon = Convert.ToInt32(cmbSezonKiyaslama.SelectedItem);
            }

            var takimPilotlari = new SPilot().SPilotlariGetir(secilenTakimId);
            if (takimPilotlari.Count < 2)
            {
                if (sender != null) MessageBox.Show("Bu takımda kıyaslanacak yeterli pilot bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int pilot1Id = takimPilotlari[0].PilotId;
            int pilot2Id = takimPilotlari[1].PilotId;

            var h2hSonuc = new SRapor().IkiPilotuKiyasla(pilot1Id, pilot2Id, seciliSezon);

            lblP1Ortalama.Text = $"{h2hSonuc.Pilot1Adi} Ort. Puan: {h2hSonuc.Pilot1OrtalamaPuan:F2}";
            lblP2Ortalama.Text = $"{h2hSonuc.Pilot2Adi} Ort. Puan: {h2hSonuc.Pilot2OrtalamaPuan:F2}";
            lblP1Ustunluk.Text = $"{h2hSonuc.Pilot1Adi} H2H Üstünlük: {h2hSonuc.Pilot1UstunlukSayisi}";
            lblP2Ustunluk.Text = $"{h2hSonuc.Pilot2Adi} H2H Üstünlük: {h2hSonuc.Pilot2UstunlukSayisi}";

            chart1.Series.Clear();
            chart1.Titles.Clear();

            string baslikYili = seciliSezon == 0 ? "Tüm Zamanlar" : seciliSezon.ToString();
            chart1.Titles.Add($"{baslikYili} - Kafa Kafaya (H2H) Galibiyet Sayısı");
            chart1.Legends[0].Enabled = false;

            var seriesH2H = chart1.Series.Add("H2H Üstünlük");
            seriesH2H.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            seriesH2H.IsXValueIndexed = true;
            seriesH2H.IsValueShownAsLabel = true;

            seriesH2H.Points.AddXY(h2hSonuc.Pilot1Adi, h2hSonuc.Pilot1UstunlukSayisi);
            seriesH2H.Points.AddXY(h2hSonuc.Pilot2Adi, h2hSonuc.Pilot2UstunlukSayisi);

            seriesH2H.Points[0].Color = System.Drawing.Color.SteelBlue;
            seriesH2H.Points[1].Color = System.Drawing.Color.DarkOrange;

            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].RecalculateAxesScale();
            chart1.Update();
        }

        private void btnIstikrarAnaliz_Click(object sender, EventArgs e)
        {
            if (cmbIstikrarPilot.SelectedIndex == -1 || cmbSezonIstikrar.SelectedIndex == -1)
            {
                if (sender != null) MessageBox.Show("Lütfen analiz etmek için bir pilot ve sezon seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var secilenPilot = (Formula1YonetimSistemi.Common.DTO.Pilot)cmbIstikrarPilot.SelectedItem;
            int pilotId = secilenPilot.PilotId;

            int seciliSezon = 0;
            if (cmbSezonIstikrar.SelectedItem.ToString() != "Tüm Zamanlar")
            {
                seciliSezon = Convert.ToInt32(cmbSezonIstikrar.SelectedItem);
            }

            var istikrarVerisi = new SRapor().PilotIstikrariGetir(pilotId, seciliSezon);
            if (istikrarVerisi.Count == 0)
            {
                if (sender != null) MessageBox.Show("Bu pilota ait yarış sonucu bulunamadı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            chartIstikrar.Series.Clear();
            chartIstikrar.Titles.Clear();

            string baslikYili = seciliSezon == 0 ? "Tüm Zamanlar" : seciliSezon.ToString();
            chartIstikrar.Titles.Add($"{secilenPilot.PilotAdSoyad} - {baslikYili} Sezon İçi İstikrar Grafiği");

            var seriesLine = chartIstikrar.Series.Add("Pozisyon");
            seriesLine.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            seriesLine.IsXValueIndexed = true;
            seriesLine.BorderWidth = 3;
            seriesLine.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            seriesLine.MarkerSize = 8;
            seriesLine.IsValueShownAsLabel = true;
            seriesLine.Color = System.Drawing.Color.Crimson;

            foreach (var veri in istikrarVerisi)
            {
                seriesLine.Points.AddXY(veri.GrandPrix, veri.Pozisyon);
            }

            chartIstikrar.ChartAreas[0].AxisY.IsReversed = true;
            chartIstikrar.ChartAreas[0].AxisY.Minimum = 1;
            chartIstikrar.ChartAreas[0].AxisY.Maximum = 20;
            chartIstikrar.ChartAreas[0].AxisX.Interval = 1;
            chartIstikrar.ChartAreas[0].AxisY.Interval = 1;
            chartIstikrar.Legends[0].Enabled = false;

            chartIstikrar.ChartAreas[0].RecalculateAxesScale();
            chartIstikrar.Update();
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            if (cmbSampiyonaTuru.SelectedIndex == -1 || cmbSezonFiltresi.SelectedIndex == -1)
            {
                if (sender != null) MessageBox.Show("Lütfen önce sezon ve şampiyona türü seçin!");
                return;
            }

            try
            {
                chartLiderlik.Series[0].Points.Clear();
                dgvLiderlik.DataSource = null;
                dgvLiderlik.Columns.Clear();

                string secilenTur = cmbSampiyonaTuru.SelectedItem.ToString();
                int seciliSezon = 0;
                if (cmbSezonFiltresi.SelectedItem.ToString() != "Tüm Zamanlar")
                {
                    seciliSezon = Convert.ToInt32(cmbSezonFiltresi.SelectedItem);
                }

                if (secilenTur == "Pilotlar Şampiyonası")
                {
                    var pilotListesi = new SRapor().SPilotSampiyonasiSiralamasiGetir(seciliSezon);
                    dgvLiderlik.DataSource = pilotListesi;
                    dgvLiderlik.Columns["PilotAdi"].HeaderText = "Pilot Adı";
                    dgvLiderlik.Columns["ToplamPuan"].HeaderText = "Toplam Puan";

                    chartLiderlik.Series[0].Name = "Pilot Puanları";
                    foreach (var p in pilotListesi)
                    {
                        chartLiderlik.Series[0].Points.AddXY(p.PilotAdi, p.ToplamPuan);
                    }
                }
                else if (secilenTur == "Takımlar Şampiyonası")
                {
                    var takimListesi = new SRapor().STakimSampiyonasiSiralamasiGetir(seciliSezon);
                    dgvLiderlik.DataSource = takimListesi;
                    dgvLiderlik.Columns["TakimAdi"].HeaderText = "Takım Adı";
                    dgvLiderlik.Columns["ToplamPuan"].HeaderText = "Toplam Puan";

                    chartLiderlik.Series[0].Name = "Takım Puanları";
                    foreach (var t in takimListesi)
                    {
                        chartLiderlik.Series[0].Points.AddXY(t.TakimAdi, t.ToplamPuan);
                    }
                }

                dgvLiderlik.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        // Boş bırakılan Click event'leri temizlik açısından silindi (Eğer form tasarımından silmediysen hata vermemesi için aşağıda bırakıyorum)
        private void chartLiderlik_Click(object sender, EventArgs e) { }
        private void cmbTakimlar_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbSampiyonaTuru_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}