using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Service;

namespace Formula1YonetimSistemi.UI
{
    public partial class TakimForm : Form
    {
        public TakimForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.CurrentRow == null) return;

            textBox1.Text = dataGridView1.CurrentRow.Cells["TakimId"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["TakimAdi"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["KisaAd"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["MerkezUlke"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["KurulusYili"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox5.Text, out int kurulusYili))
            {
                Takim yeniTakim = new Takim
                {
                    // textBox1 (ID) otomatik artan olduğu için yeni kayıtta atlıyoruz
                    TakimAdi = textBox2.Text,
                    KisaAd = textBox3.Text,
                    MerkezUlke = textBox4.Text,
                    KurulusYili = kurulusYili
                };

                new STakim().STakimEkle(yeniTakim);

                // Tabloyu anında yenile
                dataGridView1.DataSource = new STakim().STakimlariGetir();
            }
            else
            {
                MessageBox.Show("Lütfen Kuruluş Yılı alanına sadece sayı giriniz!");
            }
        }

        private void TakimForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new STakim().STakimlariGetir();
            KolonBasliklariniTurkcelestir();
        }
        
        private void KolonBasliklariniTurkcelestir()
        {
            // Eğer DataGridView'de sütunlar otomatik oluşuyorsa isimleri şu şekilde değiştirebiliriz:
            if (dataGridView1.Columns["TakimId"] != null)
                dataGridView1.Columns["TakimId"].Visible = false;

            if (dataGridView1.Columns["TakimAdi"] != null)
                dataGridView1.Columns["TakimAdi"].HeaderText = "Takım Adı";

            if (dataGridView1.Columns["KisaAd"] != null)
                dataGridView1.Columns["KisaAd"].HeaderText = "Kısa Ad";

            if (dataGridView1.Columns["MerkezUlke"] != null)
                dataGridView1.Columns["MerkezUlke"].HeaderText = "Merkez Ülke";

            if (dataGridView1.Columns["KurulusYili"] != null)
                dataGridView1.Columns["KurulusYili"].HeaderText = "Kuruluş Yılı";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // textBox1'deki Takım ID'yi sayıya çeviriyoruz
            if (int.TryParse(textBox1.Text, out int silinecekId))
            {
                DialogResult secim = MessageBox.Show("Bu takımı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (secim == DialogResult.Yes)
                {
                    // Takımı sil
                    new STakim().STakimSil(silinecekId);

                    // Tabloyu yenile
                    dataGridView1.DataSource = new STakim().STakimlariGetir();

                    // Kutuları temizle
                    textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
                    textBox4.Clear(); textBox5.Clear();
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz takımı önce tablodan seçiniz!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Takım ID ve Kuruluş Yılı alanlarının sayı olduğundan emin oluyoruz
            if (int.TryParse(textBox1.Text, out int takimId) &&
                int.TryParse(textBox5.Text, out int kurulusYili))
            {
                Takim guncellenecekTakim = new Takim
                {
                    TakimId = takimId,
                    TakimAdi = textBox2.Text,
                    KisaAd = textBox3.Text,
                    MerkezUlke = textBox4.Text,
                    KurulusYili = kurulusYili
                };

                new STakim().STakimGuncelle(guncellenecekTakim);

                // Tabloyu anında güncelle
                dataGridView1.DataSource = new STakim().STakimlariGetir();

                MessageBox.Show("Takım başarıyla güncellendi!");
            }
            else
            {
                MessageBox.Show("Lütfen tablodan bir takım seçtiğinizden ve Kuruluş Yılı'nı doğru girdiğinizden emin olun!");
            }
        }

    }
}
