using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class Urunler
    {
        public List<Dal.Urunler> UrunListele()
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            return db.Urunlers.Where(x => x.AktifllikDurumu == true).ToList();
        }

        public bool UrunEkle(Dal.Urunler urun)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            db.Urunlers.Add(urun);
            db.SaveChanges();
            return true;
        }

        public bool UrunSil(Dal.Urunler urun)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            var silinecek = db.Urunlers.Where(x => x.UrunID == urun.UrunID).SingleOrDefault();
            silinecek.AktifllikDurumu = false;
            db.SaveChanges();
            return true;
        }

        public bool UrunGuncelle(Dal.Urunler urun)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            var guncellenecek = db.Urunlers.Where(x => x.UrunID == urun.UrunID).SingleOrDefault();
            guncellenecek.UrunIsim = urun.UrunIsim;
            guncellenecek.UrunAciklama = urun.UrunAciklama;
            guncellenecek.UrunFiyat = urun.UrunFiyat;
            guncellenecek.UrunIsim = urun.UrunIsim;
            guncellenecek.UrunResim = urun.UrunResim;
            guncellenecek.miktar = urun.miktar;
            guncellenecek.UrunKategoriID = urun.UrunKategoriID;
            guncellenecek.MarkaID = urun.MarkaID;
            //guncellenecek.AktifllikDurumu = urun.AktifllikDurumu;
            guncellenecek.Renk = urun.Renk;
            guncellenecek.isNew = urun.isNew;
            guncellenecek.isOnSale = urun.isOnSale;
            guncellenecek.UrunIndirimFiyat = urun.UrunIndirimFiyat;
            guncellenecek.UserID = urun.UserID;
            db.SaveChanges();
            return true;
        }

        public Dal.Urunler UrunGetir(int id)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            return db.Urunlers.Where(x => x.UrunID == id).SingleOrDefault();
        }

        public List<Dal.Urunler> UrunListeleByKategoriId(int id)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            return db.Urunlers.Where(x => x.UrunKategoriID == id && x.AktifllikDurumu == true).ToList();
        }

    }
}