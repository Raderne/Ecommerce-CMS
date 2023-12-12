using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Yonetici
{
    public partial class UrunEkleme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UrunKategoriListele();
                UrunMarkaListele();
            }
        }

        private void UrunMarkaListele()
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            var markalar = db.Markalars.ToList();
            foreach (var item in markalar)
            {
                select_UrunMarka.Items.Add(new ListItem(item.MarkaAd, item.MarkaID.ToString()));
            }
        }

        private void UrunKategoriListele()
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            var kategoriler = db.UrunlerKategoris.ToList();
            foreach (var item in kategoriler)
            {
                select_Urunkategori.Items.Add(new ListItem(item.UrunkategoriAd, item.UrunKategoriID.ToString()));
            }
        }

        protected void btn_UrunEkle_Click(object sender, EventArgs e)
        {
            int kullaniciID = int.Parse(Session["KullaniciID"].ToString());
            string urunIsim = txt_UrunIsim.Value;
            string urunAciklama = txt_UrunAciklama.Value;
            string urunFiyat = (txt_UrunFiyat.Value);
            string urunMiktar = (txt_UrunMiktar.Value);
            int urunkategori = select_Urunkategori.SelectedIndex;
            int urunMarka = select_UrunMarka.SelectedIndex;
            bool yeniUrun = checkbox_UrunIsNew.Checked;
            bool indirimliUrun = checkbox_UrunIsOnSale.Checked;
            int urunIndirimFiyat = int.Parse(txt_UrunIndirimFiyat.Value);
            string cinsiyet = select_cinsiyet.Items[select_cinsiyet.SelectedIndex].Value;

            if (File_UrunResim.HasFile)
            {
                string dosyaAdi = File_UrunResim.FileName;
                string resimUzanti = System.IO.Path.GetExtension(dosyaAdi);

                if (resimUzanti == ".jpg" || resimUzanti == ".png" || resimUzanti == ".jpeg")
                {
                    string resimYolu = Server.MapPath("~/Images/" + dosyaAdi);
                    File_UrunResim.SaveAs(resimYolu);
                }

                Dal.Urunler urun = new Dal.Urunler();
                Dal.UrunDetaylar urunDetaylar = new Dal.UrunDetaylar();
                urun.UrunIsim = urunIsim;
                urun.UrunAciklama = urunAciklama;
                urun.UrunFiyat = int.Parse(urunFiyat);
                urun.miktar = int.Parse(urunMiktar);
                urun.UrunKategoriID = urunkategori;
                urun.MarkaID = urunMarka;
                urun.UrunResim = dosyaAdi;
                urun.isNew = yeniUrun;
                urun.isOnSale = indirimliUrun;
                urun.UrunIndirimFiyat = urunIndirimFiyat;
                urun.Cinsiyet = cinsiyet;
                urun.AktifllikDurumu = true;
                urun.UserID = kullaniciID;


                bool urunDetayElemeSonuc = UploadImages(urunDetaylar);

                if (urunDetayElemeSonuc)
                {
                    urun.UrunDetayID = urunDetaylar.UrunDetayID;
                    new BLL.Urunler().UrunEkle(urun);
                    Response.Redirect("UrunYonetim.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Ürün eklenemedi.')</script>");
                }

            }
        }

        private bool UploadImages(Dal.UrunDetaylar urunDetaylar)
        {
            int kullaniciID = int.Parse(Session["KullaniciID"].ToString());
            string urunRenk = select_UrunRenk.Items[select_UrunRenk.SelectedIndex].Value;
            string urunBoyut = select_UrunBoyut.Items[select_UrunBoyut.SelectedIndex].Value;

            if (File_UrunResim1.HasFile && File_UrunResim2.HasFile && File_UrunResim3.HasFile && File_UrunResim4.HasFile)
            {
                string dosyaAdi1 = File_UrunResim1.FileName;
                string resimUzanti1 = System.IO.Path.GetExtension(dosyaAdi1);
                string dosyaAdi2 = File_UrunResim2.FileName;
                string resimUzanti2 = System.IO.Path.GetExtension(dosyaAdi2);
                string dosyaAdi3 = File_UrunResim3.FileName;
                string resimUzanti3 = System.IO.Path.GetExtension(dosyaAdi3);
                string dosyaAdi4 = File_UrunResim4.FileName;
                string resimUzanti4 = System.IO.Path.GetExtension(dosyaAdi4);

                if (resimUzanti1 == ".jpg" || resimUzanti1 == ".png" || resimUzanti1 == ".jpeg"
                    || resimUzanti2 == ".jpg" || resimUzanti2 == ".png" || resimUzanti2 == ".jpeg"
                    || resimUzanti3 == ".jpg" || resimUzanti3 == ".png" || resimUzanti3 == ".jpeg"
                    || resimUzanti4 == ".jpg" || resimUzanti4 == ".png" || resimUzanti4 == ".jpeg")
                {
                    string resimYolu1 = Server.MapPath("~/Images/" + dosyaAdi1);
                    string resimYolu2 = Server.MapPath("~/Images/" + dosyaAdi2);
                    string resimYolu3 = Server.MapPath("~/Images/" + dosyaAdi3);
                    string resimYolu4 = Server.MapPath("~/Images/" + dosyaAdi4);
                    File_UrunResim1.SaveAs(resimYolu1);
                    File_UrunResim2.SaveAs(resimYolu2);
                    File_UrunResim3.SaveAs(resimYolu3);
                    File_UrunResim4.SaveAs(resimYolu4);

                    urunDetaylar.UrunImage1 = dosyaAdi1;
                    urunDetaylar.UrunImage2 = dosyaAdi2;
                    urunDetaylar.UrunImage3 = dosyaAdi3;
                    urunDetaylar.UrunImage4 = dosyaAdi4;
                    urunDetaylar.KullaniciID = kullaniciID;
                    urunDetaylar.UrunRenk = urunRenk;
                    urunDetaylar.UrunBoyut = urunBoyut;

                    var sonuc = new BLL.Urunler().UrunDetayEkle(urunDetaylar);
                    if (sonuc)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    Response.Write("<script>alert('Resimler jpg, png veya jpeg formatında olmalıdır.')</script>");
                    return false;
                }
            }
            else
            {
                Response.Write("<script>alert('Lütfen 4 adet resim seçiniz.')</script>");
                return false;
            }
        }
    }
}