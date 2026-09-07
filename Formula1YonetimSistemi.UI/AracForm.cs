using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Formula1YonetimSistemi.Service;
using Formula1YonetimSistemi.Common.DTO;

namespace Formula1YonetimSistemi.UI
{
    public partial class AracForm : Form
    {
        public AracForm()
        {
            InitializeComponent();
        }

        private void AracForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new SArac().SAraclariGetir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int id) && int.TryParse(textBox4.Text, out int takimId))
            {
                Arac guncellenecekArac = new Arac
                {
                    AracId = id,
                    AracSasiKodu = textBox2.Text,
                    AracMotorTedarikcisi = textBox3.Text,
                    TakimId = takimId
                };

                new SArac().SAracGuncelle(guncellenecekArac);

                // Tabloyu güncelle
                dataGridView1.DataSource = new SArac().SAraclariGetir();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir ID ve Takım ID girdiğinizden emin olun!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Butona basıldı, kutudaki değer: " + textBox2.Text);

            Arac yeniArac = new Arac
            {
                // Araç ID kutusunu (textBox1) atlıyoruz çünkü veritabanı ID'yi otomatik veriyor

                AracSasiKodu = textBox2.Text,
                AracMotorTedarikcisi = textBox3.Text,
                TakimId = int.Parse(textBox4.Text) // 4. kutudaki metni tam sayıya çeviriyoruz
            };

            new SArac().SAracEkle(yeniArac);

            // Kayıt eklendikten sonra tabloyu anında yenilemek için listeleme kodunu tekrar çağırıyoruz:
            dataGridView1.DataSource = new SArac().SAraclariGetir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int silinecekId = int.Parse(textBox1.Text); // Araç ID kutusuna yazılan numarayı alıyoruz

            new SArac().SAracSil(silinecekId);

            // Silme bittikten sonra tabloyu güncelliyoruz
            dataGridView1.DataSource = new SArac().SAraclariGetir();
        }

    }
}
