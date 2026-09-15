using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1YonetimSistemi.Common.DTO
{
    public class Kiyaslama
    {
        public string Pilot1Adi { get; set; }
        public string Pilot2Adi { get; set; }
        public double Pilot1OrtalamaPuan { get; set; }
        public double Pilot2OrtalamaPuan { get; set; }
        public int Pilot1UstunlukSayisi { get; set; }
        public int Pilot2UstunlukSayisi { get; set; }

    }
}
