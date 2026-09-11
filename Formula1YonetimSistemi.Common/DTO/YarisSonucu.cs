using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1YonetimSistemi.Common.DTO
{
    public class YarisSonucu
    {
        public int YarisSonucId { get; set; }
        public int YarisPozisyon { get; set; }
        public decimal YarisPuani { get; set; }
        public string YarisEnHizliTurZamani { get; set; }
        public int YarisId { get; set; }
        public int PilotId { get; set; }
        public string PistAdi { get; set; }
        public string PilotAdi { get; set; }
        public int PilotNumarasi { get; set; }
        public string TakimAdi { get; set; }
    }
}
