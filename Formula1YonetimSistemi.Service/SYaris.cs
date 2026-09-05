using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Entity;
using System.Collections.Generic;

namespace Formula1YonetimSistemi.Service
{
    public class SYaris
    {
        public Yaris SGetirYarisById(Yaris sorgulanacakYaris)
        {
            return new EYaris().GetirYarisById(sorgulanacakYaris);
        }

        public bool SYarisEkle(Yaris yaris)
        {
            return new EYaris().YarisEkle(yaris);
        }

        public bool SYarisGuncelle(Yaris yaris)
        {
            return new EYaris().YarisGuncelle(yaris);
        }

        public bool SYarisSil(int yarisId)
        {
            return new EYaris().YarisSil(yarisId);
        }

        public List<Yaris> SYarislariGetir(string? sezon = null)
        {
            return new EYaris().YarislariGetir(sezon);
        }
    }
}
