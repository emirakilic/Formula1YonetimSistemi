using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Formula1YonetimSistemi.UI
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
            F1TemaMotoru.TemayiUygula(this);
        }

        private void btnPilot_Click(object sender, EventArgs e)
        {
            FrmPilot pilotFormu = new FrmPilot();
            pilotFormu.Show();
        }

        private void btnArac_Click(object sender, EventArgs e)
        {
            FrmArac aracFormu = new FrmArac();
            aracFormu.Show();
        }

        private void btnTakim_Click(object sender, EventArgs e)
        {
            FrmTakim takimFormu = new FrmTakim();
            takimFormu.Show();
        }

        private void btnYaris_Click(object sender, EventArgs e)
        {
            FrmYaris yarisFormu = new FrmYaris();
            yarisFormu.Show();
        }

        private void btnYarisSonucu_Click(object sender, EventArgs e)
        {
            FrmYarisSonucu yarisSonucuFormu = new FrmYarisSonucu();
            yarisSonucuFormu.Show();
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            FrmRapor raporFormu = new FrmRapor();
            raporFormu.Show();
        }
    }
}
