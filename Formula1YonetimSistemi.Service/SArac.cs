using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Entity;
using System.Collections.Generic;

namespace Formula1YonetimSistemi.Service
{
    public class SArac
    {
        public SArac()
        {
            
        }

        public Arac SGetirAracById(Arac sorgulanacakArac)
        {
            return new EArac().GetirAracById(sorgulanacakArac);
        }

        public bool SAracEkle(Arac arac)
        {
            return new EArac().AracEkle(arac);
        }

        public bool SAracGuncelle(Arac arac)
        {
            return new EArac().AracGuncelle(arac);
        }

        public bool SAracSil(int aracId)
        {
            return new EArac().AracSil(aracId);
        }

        public List<Arac> SAraclariGetir(int? takimId = null, string aracMotorTedarikcisi = null)
        {
            return new EArac().AraclariGetir(takimId, aracMotorTedarikcisi);
        }
    }
}
