using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class BllKullanici
    {
        public bool KullaniciAdiKullaniyormu(string eposta)
        {
            Dal.EcommerceDBSitesiEntities vt = new Dal.EcommerceDBSitesiEntities();
            var sonuc = vt.Kullanicis.Where(p => p.Eposta == eposta).ToList();
            if (sonuc.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool KullaniciEkle(Dal.Kullanici kullanici)
        {
            Dal.EcommerceDBSitesiEntities vt = new Dal.EcommerceDBSitesiEntities();
            vt.Kullanicis.Add(kullanici);
            if (vt.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Dal.Kullanici> KullaniciKontrol(string eposta, string sifre)
        {
            Dal.EcommerceDBSitesiEntities vt = new Dal.EcommerceDBSitesiEntities();
            return vt.Kullanicis.Where(p => p.Eposta == eposta && p.Sifre == sifre && p.AktiflikDurumu == true).ToList();
        }

        public static List<Dal.Kullanici> KullaniciListele()
        {
            Dal.EcommerceDBSitesiEntities vt = new Dal.EcommerceDBSitesiEntities();
            return vt.Kullanicis.Where(u => u.AktiflikDurumu == true).ToList();
        }
    }
}