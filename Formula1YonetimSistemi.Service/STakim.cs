using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1YonetimSistemi.Service
{
    public class STakim
    {
        public STakim()
        {

        }
        public Takim SGetirTakimById(Takim sorgulanacakTakim)
        {
            return new ETakim().GetirTakimById(sorgulanacakTakim);
        }
        
        public bool STakimEkle(Takim takim)
        {
            return new ETakim().TakimEkle(takim);
        }

        public bool STakimGuncelle(Takim takim)
        {
            return new ETakim().TakimGuncelle(takim);
        }

        public bool STakimSil(int takimId)
        {
            return new ETakim().TakimSil(takimId);
        }

        public List<Takim> STakimlariGetir(string? takimAdi = null)
        {
            return new ETakim().TakimlariGetir(takimAdi);
        }
    }
}
