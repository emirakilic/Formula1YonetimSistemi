using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1YonetimSistemi.Service
{
    public class SArac
    {
        public SArac()
        {
            
        }

        public Arac SGetirAracById(Arac sorgulanacakArac)
        {
            EArac aracEntity = new EArac();
            return aracEntity.GetirAracById(sorgulanacakArac.AracId);
        }
    }
}
