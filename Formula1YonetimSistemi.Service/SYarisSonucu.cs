using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Entity;
using System.Collections.Generic;

namespace Formula1YonetimSistemi.Service
{
    public class SYarisSonucu
    {
        public SYarisSonucu()
        {

        }
        public YarisSonucu SGetirYarisSonucuById(YarisSonucu sorgulanacakSonuc)
        {
            return new EYarisSonucu().GetirYarisSonucuById(sorgulanacakSonuc);
        }

        public bool SYarisSonucuEkle(YarisSonucu sonuc)
        {
            return new EYarisSonucu().YarisSonucuEkle(sonuc);
        }

        public bool SYarisSonucuGuncelle(YarisSonucu sonuc)
        {
            return new EYarisSonucu().YarisSonucuGuncelle(sonuc);
        }

        public bool SYarisSonucuSil(int yarisSonucuId)
        {
            return new EYarisSonucu().YarisSonucuSil(yarisSonucuId);
        }

        public List<YarisSonucu> SYarisSonuclariniGetir(YarisSonucu sonuc)
        {
            return new EYarisSonucu().YarisSonuclariniGetir(sonuc);
        }
    }
}