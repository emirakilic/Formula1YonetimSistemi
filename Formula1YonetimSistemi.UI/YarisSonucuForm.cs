using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Service;

namespace Formula1YonetimSistemi.UI
{
    public partial class FrmYarisSonucu : Form
    {
        private Dictionary<int, (int YarisSonucId, int PilotId, int YarisId)> satirIdleri = new Dictionary<int, (int, int, int)>();

        public FrmYarisSonucu()
        {
            InitializeComponent();
        }

        private void YarisSonucuForm_Load(object sender, EventArgs e)
        {
            ComboBoxlariDoldur();
            ListeyiYenile();

            cmbPilot.KeyPress += CmbSadeceMetin_KeyPress;
            cmbPist.KeyPress += CmbSadeceMetin_KeyPress;

            txtYarisPozisyonu.KeyPress += TxtPozisyon_KeyPress;
            txtYarisPuani.KeyPress += TxtPuan_KeyPress;
            txtEnHizliTur.KeyPress += TxtEnHizliTur_KeyPress;

            F1TemaMotoru.TemayiUygula(this);
        }

        private void ComboBoxlariDoldur()
        {
            try
            {
                cmbPilot.DataSource = null;
                cmbPilot.DataSource = new SPilot().SPilotlariGetir();
                cmbPilot.DisplayMember = "PilotAdSoyad";
                cmbPilot.ValueMember = "PilotId";

                cmbPist.DataSource = null;
                cmbPist.DataSource = new SYaris().SPistleriGetir();
                cmbPist.DisplayMember = "PistAdi";
                cmbPist.ValueMember = "YarisId";

                cmbPilot.SelectedIndex = -1;
                cmbPist.SelectedIndex = -1;
            }
            catch (Exception)
            {
            }
        }

        private void ListeyiYenile()
        {
            YarisSonucu aramaKriteri = new YarisSonucu();

            if (cmbPilot.SelectedIndex != -1 && cmbPilot.SelectedValue != null)
            {
                if (int.TryParse(cmbPilot.SelectedValue.ToString(), out int pId))
                {
                    aramaKriteri.PilotId = pId;
                }
            }

            if (cmbPist.SelectedIndex != -1 && cmbPist.SelectedItem != null)
            {
                string secilenPist = cmbPist.SelectedItem.ToString();
                aramaKriteri.PistAdi = secilenPist;
            }

            List<YarisSonucu> yarisSonucuListesi = new SYarisSonucu().SYarisSonuclariniGetir(aramaKriteri);

            satirIdleri.Clear();
            for (int i = 0; i < yarisSonucuListesi.Count; i++)
            {
                satirIdleri[i] = (yarisSonucuListesi[i].YarisSonucId, yarisSonucuListesi[i].PilotId, yarisSonucuListesi[i].YarisId);
            }

            var gorsterilecekVeriler = yarisSonucuListesi.Select(y => new
            {
                y.PistAdi,
                y.PilotAdi,
                y.PilotNumarasi,
                y.TakimAdi,
                y.YarisPozisyon,
                y.YarisPuani,
                y.YarisEnHizliTurZamani
            }).ToList();

            dgvYarisSonucu.DataSource = gorsterilecekVeriler;
            TabloyuDuzenle();
        }

        private void TabloyuDuzenle()
        {
            if (dgvYarisSonucu.Columns.Count > 0)
            {
                if (dgvYarisSonucu.Columns["PistAdi"] != null) dgvYarisSonucu.Columns["PistAdi"].HeaderText = "Pist";
                if (dgvYarisSonucu.Columns["PilotAdi"] != null) dgvYarisSonucu.Columns["PilotAdi"].HeaderText = "Pilot";
                if (dgvYarisSonucu.Columns["PilotNumarasi"] != null) dgvYarisSonucu.Columns["PilotNumarasi"].HeaderText = "No";
                if (dgvYarisSonucu.Columns["TakimAdi"] != null) dgvYarisSonucu.Columns["TakimAdi"].HeaderText = "Takım";

                if (dgvYarisSonucu.Columns["YarisPozisyon"] != null) dgvYarisSonucu.Columns["YarisPozisyon"].HeaderText = "Pozisyon";
                if (dgvYarisSonucu.Columns["YarisPuani"] != null) dgvYarisSonucu.Columns["YarisPuani"].HeaderText = "Puan";
                if (dgvYarisSonucu.Columns["YarisEnHizliTurZamani"] != null) dgvYarisSonucu.Columns["YarisEnHizliTurZamani"].HeaderText = "En Hızlı Tur";

                if (dgvYarisSonucu.Columns["PilotNumarasi"] != null) dgvYarisSonucu.Columns["PilotNumarasi"].Width = 50;
                if (dgvYarisSonucu.Columns["YarisPozisyon"] != null) dgvYarisSonucu.Columns["YarisPozisyon"].Width = 70;
                if (dgvYarisSonucu.Columns["YarisPuani"] != null) dgvYarisSonucu.Columns["YarisPuani"].Width = 60;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbPilot.SelectedIndex == -1 || cmbPist.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtYarisPozisyonu.Text) || string.IsNullOrWhiteSpace(txtYarisPuani.Text))
            {
                MessageBox.Show("Lütfen Pilot, Pist, Pozisyon ve Puan alanlarını eksiksiz doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtYarisPozisyonu.Text, out int yarisPozisyon) || !decimal.TryParse(txtYarisPuani.Text, out decimal yarisPuani))
            {
                MessageBox.Show("Lütfen Pozisyon ve Puan için geçerli sayısal değerler giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            YarisSonucu yeniYarisSonucu = new YarisSonucu
            {
                PilotId = Convert.ToInt32(cmbPilot.SelectedValue),
                YarisId = Convert.ToInt32(cmbPist.SelectedValue),
                YarisPozisyon = yarisPozisyon,
                YarisPuani = yarisPuani,
                YarisEnHizliTurZamani = txtEnHizliTur.Text // Burası string olmalı
            };

            new SYarisSonucu().SYarisSonucuEkle(yeniYarisSonucu);
            ListeyiYenile();
            Temizle();
            MessageBox.Show("Yarış sonucu başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvYarisSonucu.CurrentRow == null)
            {
                MessageBox.Show("Lütfen güncellenecek yarış sonucunu tablodan seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPilot.SelectedIndex == -1 || cmbPist.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtYarisPozisyonu.Text) || string.IsNullOrWhiteSpace(txtYarisPuani.Text))
            {
                MessageBox.Show("Lütfen Pilot, Pist, Pozisyon ve Puan alanlarını eksiksiz doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtYarisPozisyonu.Text, out int yarisPozisyon) || !decimal.TryParse(txtYarisPuani.Text, out decimal yarisPuani))
            {
                MessageBox.Show("Lütfen Pozisyon ve Puan için geçerli sayısal değerler giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dgvYarisSonucu.CurrentRow.Index;

            if (satirIdleri.ContainsKey(rowIndex))
            {
                var (yarisSonucId, _, _) = satirIdleri[rowIndex];

                YarisSonucu guncellenecekYarisSonucu = new YarisSonucu
                {
                    YarisSonucId = yarisSonucId,
                    PilotId = Convert.ToInt32(cmbPilot.SelectedValue),
                    YarisId = Convert.ToInt32(cmbPist.SelectedValue),
                    YarisPozisyon = yarisPozisyon,
                    YarisPuani = yarisPuani,
                    YarisEnHizliTurZamani = txtEnHizliTur.Text // Burası string olmalı
                };

                new SYarisSonucu().SYarisSonucuGuncelle(guncellenecekYarisSonucu);
                ListeyiYenile();
                Temizle();
                MessageBox.Show("Yarış sonucu başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Hata: Yarış sonucu ID bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvYarisSonucu.CurrentRow != null)
            {
                DialogResult secim = MessageBox.Show("Bu yarış sonucunu silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (secim == DialogResult.Yes)
                {
                    int rowIndex = dgvYarisSonucu.CurrentRow.Index;

                    if (satirIdleri.ContainsKey(rowIndex))
                    {
                        var (yarisSonucId, _, _) = satirIdleri[rowIndex];
                        new SYarisSonucu().SYarisSonucuSil(yarisSonucId);
                        ListeyiYenile();
                        Temizle();
                    }
                    else
                    {
                        MessageBox.Show("Hata: Yarış sonucu ID bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz yarış sonucunu tablodan seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvYarisSonucu.Rows[e.RowIndex];

                if (satirIdleri.ContainsKey(e.RowIndex))
                {
                    var (yarisSonucId, pilotId, yarisId) = satirIdleri[e.RowIndex];

                    cmbPilot.SelectedValue = pilotId;
                    cmbPist.SelectedValue = yarisId;

                    txtYarisPozisyonu.Text = row.Cells["YarisPozisyon"].Value?.ToString();
                    txtYarisPuani.Text = row.Cells["YarisPuani"].Value?.ToString();
                    txtEnHizliTur.Text = row.Cells["YarisEnHizliTurZamani"].Value?.ToString();
                }
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            ListeyiYenile();
        }

        private void Temizle()
        {
            cmbPilot.SelectedIndex = -1;
            cmbPist.SelectedIndex = -1;
            txtYarisPozisyonu.Clear();
            txtYarisPuani.Clear();
            txtEnHizliTur.Clear();
        }

        private void TxtPozisyon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
                MessageBox.Show("Lütfen yarış pozisyonu için sadece sayı giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TxtPuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
                MessageBox.Show("Lütfen puan alanı için sadece sayı (veya ondalık ayırıcı) giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TxtEnHizliTur_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != ',' && e.KeyChar != '.' && e.KeyChar != ':')
            {
                e.Handled = true;
                MessageBox.Show("Lütfen tur zamanı için sadece sayı ve zaman ayırıcı (:, .) karakterler kullanınız! Harf giremezsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CmbSadeceMetin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Lütfen Pilot ve Pist alanına sadece metin girişi yapınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}