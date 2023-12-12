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

        public List<Dal.Urunler> UrunListele(string marka = null, string isNew = null, string onSale = null, string kategoriName = null, string cinsiyet = null)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();

            // Filter by Marka
            int? markaID = null;
            if (!string.IsNullOrEmpty(marka))
            {
                markaID = db.Markalars
                    .Where(x => x.MarkaAd == marka)
                    .Select(x => (int?)x.MarkaID)
                    .SingleOrDefault();
            }

            // Filter by isNew
            bool? isNewBool = null;
            if (!string.IsNullOrEmpty(isNew))
            {
                isNewBool = Convert.ToBoolean(isNew);
            }

            // Filter by onSale
            bool? onSaleBool = null;
            if (!string.IsNullOrEmpty(onSale))
            {
                onSaleBool = Convert.ToBoolean(onSale);
            }

            // Filter by kategoriName
            int? kategoriID = null;
            if (!string.IsNullOrEmpty(kategoriName))
            {
                kategoriID = db.UrunlerKategoris
                    .Where(x => x.UrunkategoriAd == kategoriName)
                    .Select(x => (int?)x.UrunKategoriID)
                    .SingleOrDefault();
            }


            // Combine all filters
            return db.Urunlers
                .Where(x =>
                    (markaID == null || x.MarkaID == markaID) &&
                    (isNewBool == null || x.isNew == isNewBool) &&
                    (onSaleBool == null || x.isOnSale == onSaleBool) &&
                    (kategoriID == null || x.UrunKategoriID == kategoriID) &&
                    (cinsiyet == null || x.Cinsiyet == cinsiyet) &&
                    x.AktifllikDurumu == true
                )
                .ToList();
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
            var sonuc = db.SaveChanges();
            if (sonuc > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UrunDetayEkle(Dal.UrunDetaylar urunDetay)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            db.UrunDetaylars.Add(urunDetay);
            var sonuc = db.SaveChanges();
            if (sonuc > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            guncellenecek.UrunResim = urun.UrunResim;
            guncellenecek.miktar = urun.miktar;
            guncellenecek.UrunKategoriID = urun.UrunKategoriID;
            guncellenecek.MarkaID = urun.MarkaID;
            guncellenecek.isNew = urun.isNew;
            guncellenecek.isOnSale = urun.isOnSale;
            guncellenecek.UrunIndirimFiyat = urun.UrunIndirimFiyat;
            guncellenecek.isOnSale = urun.isOnSale;

            var sonuc = db.SaveChanges();
            if (sonuc > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UrunDetayGuncelle(Dal.UrunDetaylar urunDetay)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            var guncellenecek = db.UrunDetaylars.Where(x => x.UrunDetayID == urunDetay.UrunDetayID).SingleOrDefault();
            guncellenecek.UrunBoyut = urunDetay.UrunBoyut;
            guncellenecek.UrunRenk = urunDetay.UrunRenk;
            guncellenecek.UrunImage1 = urunDetay.UrunImage1;
            guncellenecek.UrunImage2 = urunDetay.UrunImage2;
            guncellenecek.UrunImage3 = urunDetay.UrunImage3;
            guncellenecek.UrunImage4 = urunDetay.UrunImage4;

            var sonuc = db.SaveChanges();
            if (sonuc > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Dal.Urunler UrunGetir(int id)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            return db.Urunlers.Where(x => x.UrunID == id).SingleOrDefault();
        }

        public Dal.UrunDetaylar UrunDetayGetir(int id)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            return db.UrunDetaylars.Where(x => x.UrunDetayID == id).SingleOrDefault();
        }

        public bool CartUrunEkle(Dal.Cart cart)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            db.Carts.Add(cart);
            var sonuc = db.SaveChanges();
            return sonuc > 0;
        }

        public List<Dal.Cart> CartGetir(int id)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            return db.Carts.Where(x => x.UserID == id).ToList();
        }

        public bool CartUrunlerSil(int id)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            var silinecek = db.Carts.Where(x => x.UserID == id).ToList();
            foreach (var item in silinecek)
            {
                db.Carts.Remove(item);
            }
            var sonuc = db.SaveChanges();
            return sonuc > 0;
        }

        //public List<Dal.Urunler> UrunListeleByKategoriId(int id)
        //{
        //    Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
        //    return db.Urunlers.Where(x => x.UrunKategoriID == id && x.AktifllikDurumu == true).ToList();
        //}

 
        public List<Dal.Urunler> UrunListeleByMarka(string marka)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            int markaID = db.Markalars.Where(x => x.MarkaAd == marka).SingleOrDefault().MarkaID;
            return db.Urunlers.Where(x => x.MarkaID == markaID && x.AktifllikDurumu == true).ToList();
        }

        public List<Dal.Urunler> UrunListeleByNew(string isNew)
        {
            bool isNewBool = Convert.ToBoolean(isNew);
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            return db.Urunlers.Where(x => x.isNew == isNewBool && x.AktifllikDurumu == true).ToList();
        }

        public List<Dal.Urunler> UrunListeleByOnSale(string onSale)
        {
            bool onSaleBool = Convert.ToBoolean(onSale);
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            return db.Urunlers.Where(x => x.isOnSale == onSaleBool && x.AktifllikDurumu == true).ToList();
        }


    }
}