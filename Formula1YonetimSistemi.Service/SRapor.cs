using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Common.Helpers;
using Formula1YonetimSistemi.Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq; // LINQ metotlarının (Any, Average vb.) çalışması için eklendi
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

        public Kiyaslama IkiPilotuKiyasla(int pilot1Id, int pilot2Id, int sezon)
        {
            // DEĞİŞECEK KISIM: "sezon == 0 ||" şartını ekledik ki 0 gelirse tüm yarışları alsın
            var sezonYarislari = new SYaris().SYarislariGetir()
                                .Where(y => sezon == 0 || y.Sezon == sezon)
                                .Select(y => y.YarisId).ToList();

            // 2. Pilot 1'in SADECE bu sezondaki yarış sonuçlarını al
            var p1Sorgu = new YarisSonucu { PilotId = pilot1Id };
            var p1Sonuclar = new SYarisSonucu().SYarisSonuclariniGetir(p1Sorgu)
                                .Where(s => sezonYarislari.Contains(s.YarisId)).ToList();

            // 3. Pilot 2'nin SADECE bu sezondaki yarış sonuçlarını al
            var p2Sorgu = new YarisSonucu { PilotId = pilot2Id };
            var p2Sonuclar = new SYarisSonucu().SYarisSonuclariniGetir(p2Sorgu)
                                .Where(s => sezonYarislari.Contains(s.YarisId)).ToList();

            // 4. Ortalama Puanları Hesapla (O sezon hiç yarışmadılarsa 0 döndür)
            double p1Ortalama = p1Sonuclar.Any() ? Convert.ToDouble(p1Sonuclar.Average(x => x.YarisPuani)) : 0;
            double p2Ortalama = p2Sonuclar.Any() ? Convert.ToDouble(p2Sonuclar.Average(x => x.YarisPuani)) : 0;

            // 5. Ortak Yarışları Bul ve Kafa Kafaya Çarpıştır (H2H)
            int p1Ustunluk = 0;
            int p2Ustunluk = 0;

            var ortakYarislar = from r1 in p1Sonuclar
                                join r2 in p2Sonuclar on r1.YarisId equals r2.YarisId
                                select new { P1Pozisyon = r1.YarisPozisyon, P2Pozisyon = r2.YarisPozisyon };

            foreach (var yaris in ortakYarislar)
            {
                if (yaris.P1Pozisyon < yaris.P2Pozisyon)
                    p1Ustunluk++;
                else if (yaris.P2Pozisyon < yaris.P1Pozisyon)
                    p2Ustunluk++;
            }

            // İsimleri boş kalmasın diye ilk bulduğu sonuçtan veya varsayılan değerden alıyoruz
            string p1Adi = p1Sonuclar.FirstOrDefault()?.PilotAdi ?? "Pilot 1";
            string p2Adi = p2Sonuclar.FirstOrDefault()?.PilotAdi ?? "Pilot 2";

            // 6. Sonuçları DTO'ya doldur ve yolla
            return new Kiyaslama()
            {
                Pilot1Adi = p1Adi,
                Pilot2Adi = p2Adi,
                Pilot1OrtalamaPuan = p1Ortalama,
                Pilot2OrtalamaPuan = p2Ortalama,
                Pilot1UstunlukSayisi = p1Ustunluk,
                Pilot2UstunlukSayisi = p2Ustunluk
            };
        }

        public List<Istikrar> PilotIstikrariGetir(int pilotId, int sezon)
        {
            return new ERapor().PilotIstikrariGetir(pilotId, sezon);
        }

        public List<TakimSiralama> STakimSampiyonasiSiralamasiGetir(int sezon)
        {
            return new ERapor().TakimSampiyonasiSiralamasiGetir(sezon);
        }

        public List<PilotSiralama> SPilotSampiyonasiSiralamasiGetir(int sezon)
        {
            return new ERapor().PilotSampiyonasiSiralamasiGetir(sezon);
        }
    }
}