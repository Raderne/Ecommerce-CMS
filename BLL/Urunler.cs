using System;
using System.Collections.Generic;
using System.Data;
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

        public DataTable UrunlerList(int id)
        {   
            DataTable dt = new DataTable();
            dt.Columns.Add("Urun Resim");
            dt.Columns.Add("Urun Isim");
            dt.Columns.Add("Urun Kategori");
            dt.Columns.Add("Urun Fiyat");
            dt.Columns.Add("miktar");
            dt.Columns.Add("Urun Detaylar");

            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            var urunler = db.Urunlers.Where(x => x.AktifllikDurumu == true && x.UserID == id).ToList();
            foreach (var item in urunler)
            {
                var urunKategori = db.UrunlerKategoris.Where(x => x.UrunKategoriID == item.UrunKategoriID).SingleOrDefault();
                dt.Rows.Add(item.UrunResim, item.UrunIsim, urunKategori.UrunkategoriAd, 
                    item.UrunFiyat, item.miktar, item.UrunID);
            }
            return dt;
        }

        public bool UrunEkle(Dal.Urunler urun)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            db.Urunlers.Add(urun);
            db.SaveChanges();
            return true;
        }

        public bool UrunDetayEkle(Dal.UrunDetaylar urunDetay)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            db.UrunDetaylars.Add(urunDetay);
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

        public bool UrunGuncelle(Dal.Urunler urun, Dal.UrunDetaylar urunDetaylar)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            var guncellenecek = db.Urunlers.Where(x => x.UrunID == urun.UrunID).SingleOrDefault();
            var guncellenecekDetay = db.UrunDetaylars.Where(x => x.UrunDetayID == urun.UrunDetayID).SingleOrDefault();
            guncellenecek.UrunIsim = urun.UrunIsim;
            guncellenecek.UrunAciklama = urun.UrunAciklama;
            guncellenecek.UrunFiyat = urun.UrunFiyat;
            guncellenecek.UrunResim = urun.UrunResim;
            guncellenecek.miktar = urun.miktar;
            guncellenecek.UrunKategoriID = urun.UrunKategoriID;
            guncellenecek.MarkaID = urun.MarkaID;
            guncellenecek.isNew = urun.isNew;
            guncellenecek.isOnSale = urun.isOnSale;
            guncellenecek.UrunIndirimFiyat = urun.UrunIndirimFiyat;
            guncellenecekDetay.UrunRenk = urunDetaylar.UrunRenk;
            guncellenecekDetay.UrunBoyut = urunDetaylar.UrunBoyut;
            db.SaveChanges();
            return true;
        }

        public Dal.Urunler UrunGetir(int id)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            return db.Urunlers.Where(x => x.UrunID == id).SingleOrDefault();
        }

        public Dal.UrunDetaylar UrunDetayGetir(int id)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            return db.UrunDetaylars.Where(x => x.KullaniciID == id).SingleOrDefault();
        }

        public List<Dal.Urunler> UrunListeleByKategoriId(int id)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            return db.Urunlers.Where(x => x.UrunKategoriID == id && x.AktifllikDurumu == true).ToList();
        }

        public List<Dal.Urunler> UrunListeleByMarkaId(int id)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            return db.Urunlers.Where(x => x.MarkaID == id && x.AktifllikDurumu == true).ToList();
        }

        public List<Dal.Urunler> UrunListeleByKategoriIdAndMarkaId(int kategoriId, int markaId)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            return db.Urunlers.Where(x => x.UrunKategoriID == kategoriId && x.MarkaID == markaId && x.AktifllikDurumu == true).ToList();
        }



    }
}