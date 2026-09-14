using Formula1YonetimSistemi.Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1YonetimSistemi.Service
{
    public class SRapor
    {
        public SRapor()
        {
            
        }

        public List<PilotSiralama> SSampiyonaSiralamasiGetir()
        {
            List<YarisSonucu> tumSonuclar = new SYarisSonucu().SYarisSonuclariniGetir(new YarisSonucu());

            List<PilotSiralama> siralama = tumSonuclar
                .GroupBy(y => y.PilotAdi)
                .Select(g => new PilotSiralama
                {
                    PilotAdi = g.Key,
                    ToplamPuan = (int)g.Sum(x => x.YarisPuani)
                })
                .OrderByDescending(p => p.ToplamPuan)
                .ToList();

            for (int i = 0; i < siralama.Count; i++)
            {
                siralama[i].Sira = i + 1;
            }

            return siralama;
        }
    }
}
