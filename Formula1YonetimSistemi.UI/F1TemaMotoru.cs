using System;
using System.Drawing;
using System.Windows.Forms;

namespace Formula1YonetimSistemi.UI // Kendi namespace'in ile aynı olsun
{
    public static class F1TemaMotoru
    {
        public static void TemayiUygula(Form form)
        {
            // Formun ana arka planı (Karbon Siyahı)
            form.BackColor = Color.FromArgb(21, 21, 30);

            // Form içindeki tüm kontrolleri tarayıp temayı uygula
            KontrolleriRenklendir(form.Controls);
        }

        private static void KontrolleriRenklendir(Control.ControlCollection kontroller)
        {
            foreach (Control kontrol in kontroller)
            {
                // Etiketler (Beyaz ve Kalın)
                if (kontrol is Label)
                {
                    Label lbl = (Label)kontrol;
                    lbl.ForeColor = Color.White;
                    lbl.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
                // Metin Kutuları ve Seçim Kutuları (Koyu Gri)
                else if (kontrol is TextBox || kontrol is ComboBox)
                {
                    kontrol.BackColor = Color.FromArgb(35, 35, 45);
                    kontrol.ForeColor = Color.White;

                    if (kontrol is TextBox txt)
                        txt.BorderStyle = BorderStyle.FixedSingle;
                    if (kontrol is ComboBox cmb)
                        cmb.FlatStyle = FlatStyle.Flat;
                }
                // Butonlar
                else if (kontrol is Button)
                {
                    Button btn = (Button)kontrol;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
                    btn.ForeColor = Color.White;

                    // Eğer butonun adı "Ekle" ise kırmızı yap, değilse koyu gri yap
                    if (btn.Text.Contains("Ekle"))
                        btn.BackColor = Color.FromArgb(225, 6, 0); // F1 Kırmızısı
                    else if (btn.Text.Contains("Sil"))
                        btn.BackColor = Color.FromArgb(45, 45, 55);
                    else
                        btn.BackColor = Color.FromArgb(30, 30, 40);
                }
                // Tablolar (Zebra F1 Tasarımı)
                else if (kontrol is DataGridView)
                {
                    DataGridView grid = (DataGridView)kontrol;
                    grid.BackgroundColor = Color.FromArgb(245, 246, 248);
                    grid.BorderStyle = BorderStyle.None;
                    grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                    grid.EnableHeadersVisualStyles = false;

                    // Üst Başlıklar
                    grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(21, 21, 30);
                    grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    grid.ColumnHeadersHeight = 38;

                    // Satırlar
                    grid.DefaultCellStyle.BackColor = Color.White;
                    grid.DefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);
                    grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
                    grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 6, 0);
                    grid.DefaultCellStyle.SelectionForeColor = Color.White;

                    grid.RowHeadersVisible = false;
                    grid.RowTemplate.Height = 32;
                    grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    grid.MultiSelect = false;
                }

                // Eğer Panel veya GroupBox varsa içindekileri de tara (Recursive)
                if (kontrol.HasChildren)
                {
                    KontrolleriRenklendir(kontrol.Controls);
                }
            }
        }
    }
}