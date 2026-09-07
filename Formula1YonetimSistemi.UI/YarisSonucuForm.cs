using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace Formula1YonetimSistemi.UI
{
    public partial class YarisSonucuForm : Form
    {
        public YarisSonucuForm()
        {
            InitializeComponent();
        }

        private void YarisSonucuForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new SYarisSonucu().SYarisSonuclariniGetir();
        }

        // EKLE
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(comboBox1.Text, out int pilotId) &&
                int.TryParse(comboBox2.Text, out int yarisId) &&
                int.TryParse(textBox1.Text, out int yarisPozisyon) &&
                decimal.TryParse(textBox2.Text, out decimal yarisPuani))
            {
                YarisSonucu yeniYarisSonucu = new YarisSonucu
                {
                    PilotId = pilotId,
                    YarisId = yarisId,
                    YarisPozisyon = yarisPozisyon,
                    YarisPuani = yarisPuani,
                    YarisEnHizliTurZamani = textBox3.Text
                };

                new SYarisSonucu().SYarisSonucuEkle(yeniYarisSonucu);

                dataGridView1.DataSource =
                    new SYarisSonucu().SYarisSonuclariniGetir();

                MessageBox.Show("Yarış sonucu başarıyla eklendi!");

                comboBox1.Text = "";
                comboBox2.Text = "";
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            else
            {
                MessageBox.Show(
                    "Lütfen Pilot ID, Yarış ID, Yarış Pozisyonu ve Yarış Puanı alanlarını doğru giriniz!"
                );
            }
        }

        // SİL
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DialogResult secim = MessageBox.Show(
                    "Bu yarış sonucunu silmek istediğinize emin misiniz?",
                    "Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (secim == DialogResult.Yes)
                {
                    int yarisSonucId = Convert.ToInt32(
                        dataGridView1.CurrentRow.Cells["YarisSonucId"].Value
                    );

                    new SYarisSonucu().SYarisSonucuSil(yarisSonucId);

                    dataGridView1.DataSource =
                        new SYarisSonucu().SYarisSonuclariniGetir();

                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();

                    MessageBox.Show("Yarış sonucu başarıyla silindi!");
                }
            }
            else
            {
                MessageBox.Show(
                    "Lütfen silmek istediğiniz yarış sonucunu tablodan seçiniz!"
                );
            }
        }

        // GÜNCELLE
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null &&
                int.TryParse(comboBox1.Text, out int pilotId) &&
                int.TryParse(comboBox2.Text, out int yarisId) &&
                int.TryParse(textBox1.Text, out int yarisPozisyon) &&
                decimal.TryParse(textBox2.Text, out decimal yarisPuani))
            {
                int yarisSonucId = Convert.ToInt32(
                    dataGridView1.CurrentRow.Cells["YarisSonucId"].Value
                );

                YarisSonucu guncellenecekYarisSonucu = new YarisSonucu
                {
                    YarisSonucId = yarisSonucId,
                    PilotId = pilotId,
                    YarisId = yarisId,
                    YarisPozisyon = yarisPozisyon,
                    YarisPuani = yarisPuani,
                    YarisEnHizliTurZamani = textBox3.Text
                };

                new SYarisSonucu().SYarisSonucuGuncelle(
                    guncellenecekYarisSonucu
                );

                dataGridView1.DataSource =
                    new SYarisSonucu().SYarisSonuclariniGetir();

                MessageBox.Show("Yarış sonucu başarıyla güncellendi!");
            }
            else
            {
                MessageBox.Show(
                    "Lütfen tablodan bir yarış sonucu seçtiğinizden ve alanları doğru doldurduğunuzdan emin olun!"
                );
            }
        }

        // TABLODAN SATIR SEÇİNCE ALANLARA AKTAR
        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                comboBox1.Text =
                    row.Cells["PilotId"].Value.ToString();

                comboBox2.Text =
                    row.Cells["YarisId"].Value.ToString();

                textBox1.Text =
                    row.Cells["YarisPozisyon"].Value.ToString();

                textBox2.Text =
                    row.Cells["YarisPuani"].Value.ToString();

                textBox3.Text =
                    row.Cells["YarisEnHizliTurZamani"].Value.ToString();
            }
        }
    }
}
