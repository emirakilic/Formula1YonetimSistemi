using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1YonetimSistemi.Common.DTO
{
    public class Arac
    {
        public int AracId { get; set; }
        public string AracSasiKodu { get; set; }
        public string AracMotorTedarikcisi { get; set; }
        public int TakimId { get; set; }
        public string TakimAdi { get; set; }
    }
}
