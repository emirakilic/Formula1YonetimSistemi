using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1YonetimSistemi.Common.DTO
{
    public class Pilot
    {
        public int PilotId { get; set; }
        public string PilotAdSoyad { get; set; }
        public int PilotNo { get; set; }
        public bool PilotAktifMi { get; set; }
        public int TakimId { get; set; }
        public string TakimAdi { get; set; }
    }
}
