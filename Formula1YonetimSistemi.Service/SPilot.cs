using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Entity;
using System;
using System.Collections.Generic;

namespace Formula1YonetimSistemi.Service
{
    public class SPilot
    {
        public SPilot()
        {

        }
        public Pilot SGetirPilotById(Pilot sorgulanacakPilot)
        {
            return new EPilot().GetirPilotById(sorgulanacakPilot);
        }

        public bool SPilotEkle(Pilot pilot)
        {
            return new EPilot().PilotEkle(pilot);
        }

        public bool SPilotGuncelle(Pilot pilot)
        {
            return new EPilot().PilotGuncelle(pilot);
        }

        public bool SPilotSil(int pilotId)
        {
            return new EPilot().PilotSil(pilotId);
        }

        public List<Pilot> SPilotlariGetir(int? takimId = null, string pilotAdSoyad = null)
        {
            return new EPilot().PilotlariGetir(takimId, pilotAdSoyad);
        }

        public bool SPilotPasifeAl(int pilotId)
        {
            return new EPilot().PilotPasifeAl(pilotId);
        }

        public List<Pilot> STakiminPilotlariniGetir(int takimId)
        {
            return new EPilot().TakiminPilotlariniGetir(takimId);
        }

    }
}