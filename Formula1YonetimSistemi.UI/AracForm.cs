using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Formula1YonetimSistemi.UI
{
    public partial class FrmArac : Form
    {
        public FrmArac()
        {
            InitializeComponent();
        }

        private void AracForm_Load(object sender, EventArgs e)
        {
            ComboBoxlariDoldur();
            dgvArac.DataSource = new SArac().SAraclariGetir();
            dgvArac.Columns["AracId"].Visible = false;
            dgvArac.Columns["TakimId"].Visible = false;
            cmbTakim.SelectedIndex = -1;

            txtMotor.KeyPress += TxtMotor_KeyPress;

            F1TemaMotoru.TemayiUygula(this);
        }

        private void ComboBoxlariDoldur()
        {
            cmbTakim.DataSource = new STakim().STakimlariGetir();

            cmbTakim.DisplayMember = "TakimAdi";

            cmbTakim.ValueMember = "TakimId";
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SArac aracServisi = new SArac();
            Arac aramaKriteri = new Arac();

            if (cmbTakim.SelectedIndex != -1 && cmbTakim.SelectedValue != null)
            {
                aramaKriteri.TakimId = (int)cmbTakim.SelectedValue;
            }

            List<Arac> aracListesi = aracServisi.SAraclariGetir(aramaKriteri);

            if (!string.IsNullOrWhiteSpace(txtSasiKodu.Text))
            {
                aracListesi = aracListesi.FindAll(a => a.AracSasiKodu.ToLower().Contains(txtSasiKodu.Text.ToLower()));
            }

            dgvArac.DataSource = aracListesi;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSasiKodu.Text))
            {
                MessageBox.Show("Lütfen Şasi Kodu giriniz!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotor.Text))
            {
                MessageBox.Show("Lütfen Motor Tedarikçisi giriniz!");
                return;
            }

            if (cmbTakim.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir Takım seçiniz!");
                return;
            }

            Arac yeniArac = new Arac
            {
                AracSasiKodu = txtSasiKodu.Text,
                AracMotorTedarikcisi = txtMotor.Text,
                TakimId = Convert.ToInt32(cmbTakim.SelectedValue)
            };

            new SArac().SAracEkle(yeniArac);

            dgvArac.DataSource = new SArac().SAraclariGetir();
            MessageBox.Show("Araç başarıyla eklendi!");
            Liste_Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtAracId.Text, out int id))
            {
                MessageBox.Show("Lütfen güncellenecek aracı tablodan seçiniz!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSasiKodu.Text))
            {
                MessageBox.Show("Lütfen Şasi Kodu giriniz!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotor.Text))
            {
                MessageBox.Show("Lütfen Motor Tedarikçisi giriniz!");
                return;
            }

            if (cmbTakim.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir Takım seçiniz!");
                return;
            }

            Arac guncellenecekArac = new Arac
            {
                AracId = id,
                AracSasiKodu = txtSasiKodu.Text,
                AracMotorTedarikcisi = txtMotor.Text,
                TakimId = Convert.ToInt32(cmbTakim.SelectedValue)
            };

            new SArac().SAracGuncelle(guncellenecekArac);

            dgvArac.DataSource = new SArac().SAraclariGetir();
            MessageBox.Show("Araç başarıyla güncellendi!");
            Liste_Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int silinecekId = int.Parse(txtAracId.Text);

            new SArac().SAracSil(silinecekId);

            dgvArac.DataSource = new SArac().SAraclariGetir();
        }

        private void dgvArac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvArac.Rows[e.RowIndex];

                txtAracId.Text = row.Cells["AracId"].Value.ToString();
                txtSasiKodu.Text = row.Cells["AracSasiKodu"].Value.ToString();
                txtMotor.Text = row.Cells["AracMotorTedarikcisi"].Value.ToString();

                cmbTakim.SelectedValue = row.Cells["TakimId"].Value;
            }
        }

        private void Liste_Temizle()
        {
            txtAracId.Clear();
            txtSasiKodu.Clear();
            txtMotor.Clear();
            cmbTakim.SelectedIndex = -1;
        }

        private void TxtMotor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Motor Tedarikçisi sadece metin içerebilir!");
            }
        }
    }
}
