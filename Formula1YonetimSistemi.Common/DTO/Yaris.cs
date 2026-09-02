using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1YonetimSistemi.Common.DTO
{
    public class Yaris
    {
        public int YarisId { get; set; }
        public string PistAdi { get; set; }
        public DateTime YarisTarihi { get; set; }
        public int TurSayisi { get; set; }
        public int Sezon { get; set; }
        public int SezonAyagi { get; set; }
    }
}
