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
    public partial class FrmPilot : Form
    {
        public FrmPilot()
        {
            InitializeComponent();
        }

        private void PilotForm_Load(object sender, EventArgs e)
        {
            ComboBoxlariDoldur();
            ListeyiYenile();
            chkAktifMi.ThreeState = true;
            chkAktifMi.CheckState = CheckState.Indeterminate;

            txtPilotAdSoyad.KeyPress += TxtPilotAdi_KeyPress;
            txtPilotNo.KeyPress += TxtPilotNo_KeyPress;

            F1TemaMotoru.TemayiUygula(form: this);
        }

        private void ComboBoxlariDoldur()
        {
            cmbTakim.DataSource = new STakim().STakimlariGetir();
            cmbTakim.DisplayMember = "TakimAdi";
            cmbTakim.ValueMember = "TakimId";

            cmbTakim.SelectedIndex = -1;
        }

        private void ListeyiYenile()
        {
            dgvPilot.DataSource = new SPilot().SPilotlariGetir();

            if (dgvPilot.Columns["PilotId"] != null)
            {
                dgvPilot.Columns["PilotId"].Visible = false;
            }
            if (dgvPilot.Columns["TakimId"] != null)
                dgvPilot.Columns["TakimId"].Visible = false;

            if (dgvPilot.Columns["TakimAdi"] != null)
                dgvPilot.Columns["TakimAdi"].HeaderText = "Takım Adı";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPilotAdSoyad.Text))
            {
                MessageBox.Show("Lütfen Pilot Adı-Soyadı giriniz!");
                return;
            }

            if (txtPilotAdSoyad.Text.All(char.IsDigit))
            {
                MessageBox.Show("Lütfen Pilot Adı-Soyadı için bir metin giriniz!");
                return;
            }

            if (!int.TryParse(txtPilotNo.Text, out int pilotNo))
            {
                MessageBox.Show("Lütfen Pilot No için bir sayı giriniz!");
                return;
            }

            if (chkAktifMi.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("Lütfen Aktiflik Durumunu seçiniz!");
                return;
            }

            if (cmbTakim.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir Takım seçiniz!");
                return;
            }

            Pilot yeniPilot = new Pilot
            {
                PilotAdSoyad = txtPilotAdSoyad.Text,
                PilotNo = pilotNo,
                PilotAktifMi = chkAktifMi.Checked,
                TakimId = Convert.ToInt32(cmbTakim.SelectedValue)
            };

            new SPilot().SPilotEkle(yeniPilot);
            ListeyiYenile();
            Temizle();
            MessageBox.Show("Pilot başarıyla eklendi!");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPilotId.Text, out int pilotId))
            {
                MessageBox.Show("Lütfen güncellenecek pilotu tablodan seçiniz!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPilotAdSoyad.Text))
            {
                MessageBox.Show("Lütfen Pilot Adı-Soyadı giriniz!");
                return;
            }

            if (txtPilotAdSoyad.Text.All(char.IsDigit))
            {
                MessageBox.Show("Lütfen Pilot Adı-Soyadı için bir metin giriniz!");
                return;
            }

            if (!int.TryParse(txtPilotNo.Text, out int pilotNo))
            {
                MessageBox.Show("Lütfen Pilot No için bir sayı giriniz!");
                return;
            }

            if (chkAktifMi.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("Lütfen Aktiflik Durumunu seçiniz!");
                return;
            }

            if (cmbTakim.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir Takım seçiniz!");
                return;
            }

            Pilot guncellenecekPilot = new Pilot
            {
                PilotId = pilotId,
                PilotAdSoyad = txtPilotAdSoyad.Text,
                PilotNo = pilotNo,
                PilotAktifMi = chkAktifMi.Checked,
                TakimId = Convert.ToInt32(cmbTakim.SelectedValue)
            };

            new SPilot().SPilotGuncelle(guncellenecekPilot);
            ListeyiYenile();
            Temizle();
            MessageBox.Show("Pilot başarıyla güncellendi!");
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            int? arananTakimId = null;
            if (cmbTakim.SelectedIndex != -1 && cmbTakim.SelectedValue != null)
            {
                arananTakimId = Convert.ToInt32(cmbTakim.SelectedValue);
            }

            List<Pilot> pilotListesi = new SPilot().SPilotlariGetir(arananTakimId);

            if (!string.IsNullOrWhiteSpace(txtPilotAdSoyad.Text))
            {
                pilotListesi = pilotListesi.FindAll(p =>
                    p.PilotAdSoyad.ToLower().Contains(txtPilotAdSoyad.Text.ToLower())
                );
            }

            if (!string.IsNullOrWhiteSpace(txtPilotNo.Text) && int.TryParse(txtPilotNo.Text, out int arananNo))
            {
                pilotListesi = pilotListesi.FindAll(p => p.PilotNo == arananNo);
            }

            dgvPilot.DataSource = pilotListesi;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtPilotId.Text, out int silinecekId))
            {
                DialogResult secim = MessageBox.Show("Bu pilotu silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (secim == DialogResult.Yes)
                {
                    new SPilot().SPilotSil(silinecekId);
                    ListeyiYenile();
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz pilotu önce tablodan seçiniz!");
            }
        }

        private void dgvPilot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPilot.CurrentRow == null) return;

            DataGridViewRow row = dgvPilot.CurrentRow;

            txtPilotId.Text = row.Cells["PilotId"].Value.ToString();

            txtPilotAdSoyad.Text = row.Cells["PilotAdSoyad"].Value.ToString();
            txtPilotNo.Text = row.Cells["PilotNo"].Value.ToString();

            if (row.Cells["PilotAktifMi"].Value != DBNull.Value)
            {
                chkAktifMi.Checked = Convert.ToBoolean(row.Cells["PilotAktifMi"].Value);
            }

            if (row.Cells["TakimId"].Value != DBNull.Value)
            {
                cmbTakim.SelectedValue = row.Cells["TakimId"].Value;
            }
            else
            {
                cmbTakim.SelectedIndex = -1;
            }
        }

        private void Temizle()
        {
            txtPilotId.Clear();
            txtPilotAdSoyad.Clear();
            txtPilotNo.Clear();
            chkAktifMi.CheckState = CheckState.Indeterminate;
            cmbTakim.SelectedIndex = -1;
        }

        private void TxtPilotAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Pilot Adı-Soyadı sadece metin içerebilir!");
            }
        }

        private void TxtPilotNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
                MessageBox.Show("Pilot No sadece sayı girebilir!");
            }
        }
    }
}