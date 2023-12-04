using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class BllKullanici
    {
        public static bool KullaniciAdiKullaniyormu(string eposta)
        {
            Dal.EcommerceSitesiEntities vt = new Dal.EcommerceSitesiEntities();
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
            Dal.EcommerceSitesiEntities vt = new Dal.EcommerceSitesiEntities();
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
            Dal.EcommerceSitesiEntities vt = new Dal.EcommerceSitesiEntities();
            return vt.Kullanicis.Where(p => p.Eposta == eposta && p.Sifre == sifre && p.AktiflikDurumu == true).ToList();
        }

        public static List<Dal.Kullanici> KullaniciListele()
        {
            Dal.EcommerceSitesiEntities vt = new Dal.EcommerceSitesiEntities();
            return vt.Kullanicis.Where(u => u.AktiflikDurumu == true).ToList();
        }
    }
}