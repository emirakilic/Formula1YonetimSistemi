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
    public partial class PilotForm : Form
    {
        public PilotForm()
        {
            InitializeComponent();
        }

        private void PilotForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new SPilot().SPilotlariGetir();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Pilot No ve Takım ID alanlarının sayı olduğundan emin oluyoruz
            if (int.TryParse(textBox1.Text, out int pilotId) &&
                int.TryParse(textBox3.Text, out int pilotNo) &&
                int.TryParse(textBox5.Text, out int takimId))
            {
                Pilot guncellenecekPilot = new Pilot
                {
                    PilotId = pilotId,
                    PilotAdSoyad = textBox2.Text,
                    PilotNo = pilotNo,
                    PilotAktifMi = textBox4.Text.ToLower() == "true",
                    TakimId = takimId
                };

                new SPilot().SPilotGuncelle(guncellenecekPilot);

                // Tabloyu anında güncelle
                dataGridView1.DataSource = new SPilot().SPilotlariGetir();

                MessageBox.Show("Pilot başarıyla güncellendi!");
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir Pilot ID, Pilot No ve Takım ID girdiğinizden emin olun!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Pilot No ve Takım ID kutularının sayı olduğundan emin oluyoruz
            if (int.TryParse(textBox3.Text, out int pilotNo) && int.TryParse(textBox5.Text, out int takimId))
            {
                Pilot yeniPilot = new Pilot
                {
                    // ID kutusunu (textBox1) yeni kayıtta atlıyoruz
                    PilotAdSoyad = textBox2.Text,
                    PilotNo = pilotNo,
                    TakimId = takimId,

                    // Aktif Mi? kutusuna "true" veya "false" yazılacağını varsayıyoruz
                    // Eğer veritabanında bu alan string ise direkt textBox4.Text olarak bırakabilirsin
                    PilotAktifMi = textBox4.Text.ToLower() == "true"
                };

                new SPilot().SPilotEkle(yeniPilot);

                // Tabloyu anında yenile
                dataGridView1.DataSource = new SPilot().SPilotlariGetir();
            }
            else
            {
                MessageBox.Show("Lütfen Pilot No ve Takım ID alanlarına sadece sayı giriniz!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Eğer boş bir satıra tıklanırsa programın çökmesini engelliyoruz
            if (dataGridView1.CurrentRow == null) return;

            textBox1.Text = dataGridView1.CurrentRow.Cells["PilotId"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["PilotAdSoyad"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["PilotNo"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["PilotAktifMi"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["TakimId"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Önce textBox1'de (Pilot ID) geçerli bir sayı var mı diye kontrol ediyoruz
            if (int.TryParse(textBox1.Text, out int silinecekId))
            {
                // Kullanıcıya silme onayı soruyoruz
                DialogResult secim = MessageBox.Show("Bu pilotu silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (secim == DialogResult.Yes)
                {
                    // Onay verildiyse servis üzerinden silme işlemini yapıyoruz
                    new SPilot().SPilotSil(silinecekId);

                    // Tabloyu güncelliyoruz
                    dataGridView1.DataSource = new SPilot().SPilotlariGetir();

                    // Kutuların içini temizlemek istersen (opsiyonel):
                    textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
                    textBox4.Clear(); textBox5.Clear();
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz pilotu önce tablodan seçiniz!");
            }
        }
    }
}
