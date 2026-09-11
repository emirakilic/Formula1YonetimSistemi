using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Entity;
using Formula1YonetimSistemi.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Formula1YonetimSistemi.UI
{
    public partial class FrmYaris : Form
    {
        public FrmYaris()
        {
            InitializeComponent();
        }

        private void YarisForm_Load(object sender, EventArgs e)
        {
            // DateTimePicker formatını dd.MM.yyyy şekline ayarla
            dtpYarisTarihi.Format = DateTimePickerFormat.Custom;
            dtpYarisTarihi.CustomFormat = "dd.MM.yyyy";

            ListeyiYenile();
            F1TemaMotoru.TemayiUygula(this);

            txtTurSayisi.KeyPress += TxtSadeceSayi_KeyPress;
            txtSezon.KeyPress += TxtSadeceSayi_KeyPress;
            txtSezonAyagi.KeyPress += TxtSadeceSayi_KeyPress;
        }

        private void ListeyiYenile()
        {
            dgvYaris.DataSource = new SYaris().SYarislariGetir();
            KolonBasliklariniTurkcelestir();
        }

        private void KolonBasliklariniTurkcelestir()
        {
            // ID Kolonunu Gizle
            if (dgvYaris.Columns["YarisId"] != null)
                dgvYaris.Columns["YarisId"].Visible = false;

            // Hem İsimleri Türkçeleştiriyoruz Hem de DisplayIndex ile Sıraya Sokuyoruz
            if (dgvYaris.Columns["GrandPrix"] != null)
            {
                dgvYaris.Columns["GrandPrix"].HeaderText = "Grand Prix";
                dgvYaris.Columns["GrandPrix"].DisplayIndex = 0;
            }

            if (dgvYaris.Columns["PistAdi"] != null)
            {
                dgvYaris.Columns["PistAdi"].HeaderText = "Pist Adı";
                dgvYaris.Columns["PistAdi"].DisplayIndex = 1;
            }

            if (dgvYaris.Columns["YarisTarihi"] != null)
            {
                dgvYaris.Columns["YarisTarihi"].HeaderText = "Yarış Tarihi";
                dgvYaris.Columns["YarisTarihi"].DisplayIndex = 2;
            }

            if (dgvYaris.Columns["TurSayisi"] != null)
            {
                dgvYaris.Columns["TurSayisi"].HeaderText = "Tur Sayısı";
                dgvYaris.Columns["TurSayisi"].DisplayIndex = 3;
            }

            if (dgvYaris.Columns["Sezon"] != null)
            {
                dgvYaris.Columns["Sezon"].HeaderText = "Sezon (Yıl)";
                dgvYaris.Columns["Sezon"].DisplayIndex = 4;
            }

            if (dgvYaris.Columns["SezonAyagi"] != null)
            {
                dgvYaris.Columns["SezonAyagi"].HeaderText = "Sezon Ayağı"; // İstediğin gibi değiştirildi
                dgvYaris.Columns["SezonAyagi"].DisplayIndex = 5;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvYaris.CurrentRow == null) return;

            DataGridViewRow row = dgvYaris.CurrentRow;

            txtYarisId.Text = row.Cells["YarisId"].Value?.ToString();
            txtGrandPrix.Text = row.Cells["GrandPrix"].Value?.ToString();
            txtPistAdi.Text = row.Cells["PistAdi"].Value?.ToString();

            if (row.Cells["YarisTarihi"].Value != DBNull.Value)
                dtpYarisTarihi.Value = Convert.ToDateTime(row.Cells["YarisTarihi"].Value);

            txtTurSayisi.Text = row.Cells["TurSayisi"].Value?.ToString();
            txtSezon.Text = row.Cells["Sezon"].Value?.ToString();
            txtSezonAyagi.Text = row.Cells["SezonAyagi"].Value?.ToString();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            // 1. Tüm alanların tek seferde doluluk kontrolü
            if (string.IsNullOrWhiteSpace(txtGrandPrix.Text) ||
                string.IsNullOrWhiteSpace(txtPistAdi.Text) ||
                string.IsNullOrWhiteSpace(txtTurSayisi.Text) ||
                string.IsNullOrWhiteSpace(txtSezon.Text) ||
                string.IsNullOrWhiteSpace(txtSezonAyagi.Text))
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Anlamsız veri kontrolü (Grand Prix sadece rakam olamaz)
            if (txtGrandPrix.Text.All(char.IsDigit) || txtPistAdi.Text.All(char.IsDigit))
            {
                MessageBox.Show("Grand Prix veya Pist Adı sadece rakamlardan oluşamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Sayısal değerlerin dönüştürülmesi ve ekleme işlemi
            int.TryParse(txtTurSayisi.Text, out int tur);
            int.TryParse(txtSezon.Text, out int sezon);
            int.TryParse(txtSezonAyagi.Text, out int ayak);

            Yaris yeniYaris = new Yaris
            {
                GrandPrix = txtGrandPrix.Text,
                PistAdi = txtPistAdi.Text,
                YarisTarihi = dtpYarisTarihi.Value,
                TurSayisi = tur,
                Sezon = sezon,
                SezonAyagi = ayak
            };

            new SYaris().SYarisEkle(yeniYaris);
            ListeyiYenile();
            KutulariTemizle();
            MessageBox.Show("Yarış takvime başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            // 0. Tablodan seçim yapıldı mı kontrolü
            if (!int.TryParse(txtYarisId.Text, out int yarisId))
            {
                MessageBox.Show("Lütfen tablodan güncellenecek yarışı seçtiğinizden emin olun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Tüm alanların doluluk kontrolü
            if (string.IsNullOrWhiteSpace(txtGrandPrix.Text) ||
                string.IsNullOrWhiteSpace(txtPistAdi.Text) ||
                string.IsNullOrWhiteSpace(txtTurSayisi.Text) ||
                string.IsNullOrWhiteSpace(txtSezon.Text) ||
                string.IsNullOrWhiteSpace(txtSezonAyagi.Text))
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Anlamsız veri kontrolü
            if (txtGrandPrix.Text.All(char.IsDigit) || txtPistAdi.Text.All(char.IsDigit))
            {
                MessageBox.Show("Grand Prix veya Pist Adı sadece rakamlardan oluşamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Güncelleme işlemi
            int.TryParse(txtTurSayisi.Text, out int tur);
            int.TryParse(txtSezon.Text, out int sezon);
            int.TryParse(txtSezonAyagi.Text, out int ayak);

            Yaris guncellenecekYaris = new Yaris
            {
                YarisId = yarisId,
                GrandPrix = txtGrandPrix.Text,
                PistAdi = txtPistAdi.Text,
                YarisTarihi = dtpYarisTarihi.Value,
                TurSayisi = tur,
                Sezon = sezon,
                SezonAyagi = ayak
            };

            new SYaris().SYarisGuncelle(guncellenecekYaris);
            ListeyiYenile();
            KutulariTemizle();
            MessageBox.Show("Yarış başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtYarisId.Text, out int silinecekId))
            {
                DialogResult secim = MessageBox.Show("Bu yarışı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (secim == DialogResult.Yes)
                {
                    new SYaris().SYarisSil(silinecekId);
                    ListeyiYenile();
                    KutulariTemizle();
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz yarışı önce tablodan seçiniz!");
            }
        }

        // ARAMA BUTONU METODU EKLENDİ
        private void btnAra_Click(object sender, EventArgs e)
        {
            List<Yaris> yarisListesi = new SYaris().SYarislariGetir();

            if (!string.IsNullOrWhiteSpace(txtGrandPrix.Text))
            {
                yarisListesi = yarisListesi.FindAll(y =>
                    y.GrandPrix.ToLower().Contains(txtGrandPrix.Text.ToLower())
                );
            }

            if (!string.IsNullOrWhiteSpace(txtPistAdi.Text))
            {
                yarisListesi = yarisListesi.FindAll(y =>
                    y.PistAdi.ToLower().Contains(txtPistAdi.Text.ToLower())
                );
            }

            if (!string.IsNullOrWhiteSpace(txtSezon.Text) && int.TryParse(txtSezon.Text, out int arananSezon))
            {
                yarisListesi = yarisListesi.FindAll(y => y.Sezon == arananSezon);
            }

            // Yarış tarihi filtrelemesi eklendi
            DateTime secilenTarih = dtpYarisTarihi.Value.Date;
            yarisListesi = yarisListesi.FindAll(y => y.YarisTarihi.Date == secilenTarih);

            dgvYaris.DataSource = yarisListesi;
        }

        private void KutulariTemizle()
        {
            txtYarisId.Clear();
            txtGrandPrix.Clear();
            txtPistAdi.Clear();
            dtpYarisTarihi.Value = DateTime.Now;
            txtTurSayisi.Clear();
            txtSezon.Clear();
            txtSezonAyagi.Clear();
        }

        // Sayı giriş kısıtlaması (Validation)
        private void TxtSadeceSayi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
                MessageBox.Show("Bu alana sadece sayı girebilirsiniz!");
            }
        }

        // Tasarım ekranında kazara tıkladığın boş metot
        private void textBox2_TextChanged(object sender, EventArgs e) { }
    }
}