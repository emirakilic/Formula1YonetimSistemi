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
    public partial class FrmTakim : Form
    {
        public FrmTakim()
        {
            InitializeComponent();
        }

        private void TakimForm_Load(object sender, EventArgs e)
        {
            UlkeComboBoxDoldur();
            ListeyiYenile();

            txtTakimAdi.KeyPress += TxtTakimAdi_KeyPress;
            txtKisaAd.KeyPress += TxtKisaAd_KeyPress;
            txtKurulusYili.KeyPress += TxtKurulusYili_KeyPress;

            F1TemaMotoru.TemayiUygula(form: this);
        }

        private void ListeyiYenile()
        {
            dgvTakim.DataSource = new STakim().STakimlariGetir();
            KolonBasliklariniTurkcelestir();
        }

        private void KolonBasliklariniTurkcelestir()
        {
            if (dgvTakim.Columns["TakimId"] != null)
                dgvTakim.Columns["TakimId"].Visible = false;

            if (dgvTakim.Columns["TakimAdi"] != null)
                dgvTakim.Columns["TakimAdi"].HeaderText = "Takım Adı";

            if (dgvTakim.Columns["KisaAd"] != null)
                dgvTakim.Columns["KisaAd"].HeaderText = "Kısa Ad";

            if (dgvTakim.Columns["MerkezUlke"] != null)
                dgvTakim.Columns["MerkezUlke"].HeaderText = "Merkez Ülke";

            if (dgvTakim.Columns["KurulusYili"] != null)
                dgvTakim.Columns["KurulusYili"].HeaderText = "Kuruluş Yılı";
        }

        private void UlkeComboBoxDoldur()
        {
            cmbMerkezUlke.Items.Clear();
            cmbMerkezUlke.Items.Add("İngiltere");
            cmbMerkezUlke.Items.Add("İtalya");
            cmbMerkezUlke.Items.Add("İsviçre");
            cmbMerkezUlke.Items.Add("Almanya");
            cmbMerkezUlke.Items.Add("Fransa");
            cmbMerkezUlke.Items.Add("ABD");
            cmbMerkezUlke.SelectedIndex = -1;
        }

        private void dgvTakim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTakim.CurrentRow == null) return;

            DataGridViewRow row = dgvTakim.CurrentRow;

            txtTakimId.Text = row.Cells["TakimId"].Value.ToString();
            txtTakimAdi.Text = row.Cells["TakimAdi"].Value.ToString();
            txtKisaAd.Text = row.Cells["KisaAd"].Value.ToString();
            cmbMerkezUlke.Text = row.Cells["MerkezUlke"].Value.ToString();

            if (row.Cells["KurulusYili"].Value != DBNull.Value)
            {
                txtKurulusYili.Text = row.Cells["KurulusYili"].Value.ToString();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTakimAdi.Text) ||
                string.IsNullOrWhiteSpace(txtKisaAd.Text) ||
                string.IsNullOrWhiteSpace(cmbMerkezUlke.Text) ||
                string.IsNullOrWhiteSpace(txtKurulusYili.Text))
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtTakimAdi.Text.All(char.IsDigit))
            {
                MessageBox.Show("Takım Adı sadece rakamlardan oluşamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtKurulusYili.Text, out int kurulusYili))
            {
                MessageBox.Show("Lütfen Kuruluş Yılı için geçerli bir sayı giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Takim yeniTakim = new Takim
            {
                TakimAdi = txtTakimAdi.Text,
                KisaAd = txtKisaAd.Text,
                MerkezUlke = cmbMerkezUlke.Text,
                KurulusYili = kurulusYili
            };

            new STakim().STakimEkle(yeniTakim);
            ListeyiYenile();
            KutulariTemizle();
            MessageBox.Show("Takım başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtTakimId.Text, out int takimId))
            {
                MessageBox.Show("Lütfen güncellenecek takımı tablodan seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTakimAdi.Text) ||
                string.IsNullOrWhiteSpace(txtKisaAd.Text) ||
                string.IsNullOrWhiteSpace(cmbMerkezUlke.Text) ||
                string.IsNullOrWhiteSpace(txtKurulusYili.Text))
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtTakimAdi.Text.All(char.IsDigit))
            {
                MessageBox.Show("Takım Adı sadece rakamlardan oluşamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtKurulusYili.Text, out int kurulusYili))
            {
                MessageBox.Show("Lütfen Kuruluş Yılı için geçerli bir sayı giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Takim guncellenecekTakim = new Takim
            {
                TakimId = takimId,
                TakimAdi = txtTakimAdi.Text,
                KisaAd = txtKisaAd.Text,
                MerkezUlke = cmbMerkezUlke.Text,
                KurulusYili = kurulusYili
            };

            new STakim().STakimGuncelle(guncellenecekTakim);
            ListeyiYenile();
            KutulariTemizle();
            MessageBox.Show("Takım başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtTakimId.Text, out int silinecekId))
            {
                DialogResult secim = MessageBox.Show("Bu takımı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (secim == DialogResult.Yes)
                {
                    new STakim().STakimSil(silinecekId);
                    ListeyiYenile();
                    KutulariTemizle();
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz takımı önce tablodan seçiniz!");
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            List<Takim> takimListesi = new STakim().STakimlariGetir();

            if (!string.IsNullOrWhiteSpace(txtTakimAdi.Text))
            {
                takimListesi = takimListesi.FindAll(t =>
                    t.TakimAdi.ToLower().Contains(txtTakimAdi.Text.ToLower())
                );
            }

            if (!string.IsNullOrWhiteSpace(txtKisaAd.Text))
            {
                takimListesi = takimListesi.FindAll(t =>
                    t.KisaAd.ToLower().Contains(txtKisaAd.Text.ToLower())
                );
            }

            if (!string.IsNullOrWhiteSpace(cmbMerkezUlke.Text))
            {
                takimListesi = takimListesi.FindAll(t => t.MerkezUlke == cmbMerkezUlke.Text);
            }

            if (!string.IsNullOrWhiteSpace(txtKurulusYili.Text) && int.TryParse(txtKurulusYili.Text, out int arananYil))
            {
                takimListesi = takimListesi.FindAll(t => t.KurulusYili == arananYil);
            }

            dgvTakim.DataSource = takimListesi;
        }

        private void KutulariTemizle()
        {
            txtTakimId.Clear();
            txtTakimAdi.Clear();
            txtKisaAd.Clear();
            cmbMerkezUlke.SelectedIndex = -1;
            txtKurulusYili.Clear();
        }

        private void TxtTakimAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Takım Adı sadece metin içerebilir!");
            }
        }

        private void TxtKisaAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Kısa Ad sadece metin içerebilir!");
            }
        }

        private void TxtKurulusYili_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
                MessageBox.Show("Kuruluş Yılı sadece sayı girebilir!");
            }
        }
    }
}