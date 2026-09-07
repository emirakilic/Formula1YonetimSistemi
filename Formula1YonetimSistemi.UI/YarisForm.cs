using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Service;

namespace Formula1YonetimSistemi.UI
{
    public partial class YarisForm : Form
    {
        public YarisForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void YarisForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new SYaris().SYarislariGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TextBox isimlerini (textBox3, textBox4, vb.) kendi formundaki isimlendirmene göre kontrol etmeyi unutma
            if (int.TryParse(textBox3.Text, out int turSayisi) &&
                int.TryParse(textBox5.Text, out int sezon) &&
                int.TryParse(textBox4.Text, out int sezonAyagi))
            {
                Yaris yeniYaris = new Yaris
                {
                    // YarisId atlanıyor (SQL otomatik verecek)
                    PistAdi = textBox2.Text,

                    // Takvimden seçilen tarihi .Value ile doğrudan DateTime formatında alıyoruz
                    YarisTarihi = dateTimePicker1.Value,

                    TurSayisi = turSayisi,
                    Sezon = sezon,
                    SezonAyagi = sezonAyagi
                };

                new SYaris().SYarisEkle(yeniYaris);

                // Tabloyu yenile
                dataGridView1.DataSource = new SYaris().SYarislariGetir();
            }
            else
            {
                MessageBox.Show("Lütfen Tur Sayısı, Sezon ve Sezon Ayağı alanlarına sadece sayı giriniz!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int silinecekId))
            {
                DialogResult secim = MessageBox.Show("Bu yarışı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (secim == DialogResult.Yes)
                {
                    new SYaris().SYarisSil(silinecekId);

                    // Tabloyu yenile
                    dataGridView1.DataSource = new SYaris().SYarislariGetir();

                    // Kutuları temizle
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz yarışı önce tablodan seçiniz!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int yarisId) &&
    int.TryParse(textBox3.Text, out int turSayisi) &&
    int.TryParse(textBox4.Text, out int sezon) &&
    int.TryParse(textBox5.Text, out int sezonAyagi))
            {
                Yaris guncellenecekYaris = new Yaris
                {
                    YarisId = yarisId,
                    PistAdi = textBox2.Text,
                    YarisTarihi = dateTimePicker1.Value,
                    TurSayisi = turSayisi,
                    Sezon = sezon,
                    SezonAyagi = sezonAyagi
                };

                new SYaris().SYarisGuncelle(guncellenecekYaris);          
                dataGridView1.DataSource = new SYaris().SYarislariGetir();

                MessageBox.Show("Yarış başarıyla güncellendi!");
            }
            else
            {
                MessageBox.Show("Lütfen tablodan bir yarış seçtiğinizden ve sayısal alanları doğru girdiğinizden emin olun!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Başlık satırına tıklandığında hata vermemesi için kontrol
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // ID, Pist Adı, Tur Sayısı, Sezon ve Sezon Ayağını kutulara aktarıyoruz
                // (TextBox sıralamanı kendi formuna göre kontrol etmeyi unutma)
                textBox1.Text = row.Cells["YarisId"].Value.ToString();
                textBox2.Text = row.Cells["PistAdi"].Value.ToString();
                // Tarih alanını DateTimePicker'a aktarma
                if (row.Cells["YarisTarihi"].Value != DBNull.Value)
                {
                    dateTimePicker1.Value = Convert.ToDateTime(row.Cells["YarisTarihi"].Value);
                }

                textBox3.Text = row.Cells["TurSayisi"].Value.ToString();
                textBox4.Text = row.Cells["Sezon"].Value.ToString();
                textBox5.Text = row.Cells["SezonAyagi"].Value.ToString();
            }
        }
    }
}
