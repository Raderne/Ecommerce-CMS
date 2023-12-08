using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Yonetici
{
    public partial class UrunDuzenle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UrunKategoriListele();
                UrunMarkaListele();

                if (Request.QueryString["UrunID"] != null)
                {
                    int urunID = Convert.ToInt32(Request.QueryString["UrunID"]);
                    UrunDetayListele(urunID);
                }
            }
        }

        private void UrunDetayListele(int urunID)
        {
            string imagesDirectory = "../Images/";

            Dal.Urunler urun = new BLL.Urunler().UrunGetir(urunID);
            txt_UrunIsim.Value = urun.UrunIsim;
            txt_UrunFiyat.Value = urun.UrunFiyat.ToString();
            txt_UrunMiktar.Value = urun.miktar.ToString();
            txt_UrunAciklama.Value = urun.UrunAciklama;
            txt_UrunIndirimFiyat.Value = urun.UrunIndirimFiyat.ToString();
            select_Urunkategori.SelectedIndex = (int)urun.UrunKategoriID;
            select_UrunMarka.SelectedIndex = (int)urun.MarkaID;
            img_UrunResim.Src = imagesDirectory + urun.UrunResim;
            checkbox_UrunIsNew.Checked = (bool)urun.isNew;
            checkbox_UrunIsOnSale.Checked = (bool)urun.isOnSale;

            Dal.UrunDetaylar urunDetay = new BLL.Urunler().UrunDetayGetir((int)urun.UrunDetayID);
            foreach (var item in select_UrunBoyut.Items)
            {
                if (item.ToString() == urunDetay.UrunBoyut)
                {
                    select_UrunBoyut.SelectedIndex = select_UrunBoyut.Items.IndexOf((ListItem)item);
                }
            }

            foreach (var item in select_UrunRenk.Items)
            {
                if (item.ToString() == urunDetay.UrunRenk)
                {
                    select_UrunRenk.SelectedIndex = select_UrunRenk.Items.IndexOf((ListItem)item);
                }
            }

            img_UrunResim1.Src = imagesDirectory + urunDetay.UrunImage1;
            img_UrunResim2.Src = imagesDirectory + urunDetay.UrunImage2;
            img_UrunResim3.Src = imagesDirectory + urunDetay.UrunImage3;
            img_UrunResim4.Src = imagesDirectory + urunDetay.UrunImage4;

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

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UrunYonetim.aspx");
        }

        protected void btn_resimlerGuncelle_Click(object sender, EventArgs e)
        {
            string imagesDirectory = "../Images/";
            string resim1 = "";
            string resim2 = "";
            string resim3 = "";
            string resim4 = "";

            if (File_UrunResim1.HasFile && File_UrunResim2.HasFile && File_UrunResim3.HasFile && File_UrunResim4.HasFile)
            {
                resim1 = File_UrunResim1.FileName;
                File_UrunResim1.SaveAs(Server.MapPath(imagesDirectory + resim1));
                
                resim2 = File_UrunResim2.FileName;
                File_UrunResim2.SaveAs(Server.MapPath(imagesDirectory + resim2));
                
                resim3 = File_UrunResim3.FileName;
                File_UrunResim3.SaveAs(Server.MapPath(imagesDirectory + resim3));
                
                resim4 = File_UrunResim4.FileName;
                File_UrunResim4.SaveAs(Server.MapPath(imagesDirectory + resim4));

                Dal.Urunler urun = new BLL.Urunler().UrunGetir(Convert.ToInt32(Request.QueryString["UrunID"]));
                Dal.UrunDetaylar urunDetay = new BLL.Urunler().UrunDetayGetir((int)urun.UrunDetayID);
                urunDetay.UrunImage1 = resim1;
                urunDetay.UrunImage2 = resim2;
                urunDetay.UrunImage3 = resim3;
                urunDetay.UrunImage4 = resim4;

                bool sonuc = new BLL.Urunler().UrunDetayGuncelle(urunDetay);
                if (sonuc)
                {
                    Response.Write("<script>alert('Ürün Resimleri güncelleme başarılı.')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Ürün Resimleri güncellenemedi.')</script>");
                }
            }

        }

        protected void btn_UrunGuncelle_Click(object sender, EventArgs e)
        {
            string imagesDirectory = "../Images/";
            string resim = "";
            string urunIsim = txt_UrunIsim.Value;
            string urunAciklama = txt_UrunAciklama.Value;
            int urunFiyat = Convert.ToInt32(txt_UrunFiyat.Value);
            int urunMiktar = Convert.ToInt32(txt_UrunMiktar.Value);
            int urunIndirimFiyat = Convert.ToInt32(txt_UrunIndirimFiyat.Value);
            int urunKategoriID = select_Urunkategori.SelectedIndex;
            int urunMarkaID = select_UrunMarka.SelectedIndex;
            bool urunIsNew = checkbox_UrunIsNew.Checked;
            bool urunIsOnSale = checkbox_UrunIsOnSale.Checked;
            string urunBoyut = select_UrunBoyut.Items[select_UrunBoyut.SelectedIndex].Value;
            string urunRenk = select_UrunRenk.Items[select_UrunRenk.SelectedIndex].Value;

            if (File_UrunResim.HasFile)
            {
                resim = File_UrunResim.FileName;
                File_UrunResim.SaveAs(Server.MapPath(imagesDirectory + resim));
            }

            Dal.Urunler urun = new Dal.Urunler();
            urun.UrunID = Convert.ToInt32(Request.QueryString["UrunID"]);
            urun.UrunIsim = urunIsim;
            urun.UrunAciklama = urunAciklama;
            urun.UrunFiyat = urunFiyat;
            urun.UrunResim = resim;
            urun.miktar = urunMiktar;
            urun.UrunKategoriID = urunKategoriID;
            urun.MarkaID = urunMarkaID;
            urun.isNew = urunIsNew;
            urun.isOnSale = urunIsOnSale;
            urun.UrunIndirimFiyat = urunIndirimFiyat;

            Dal.UrunDetaylar urunDetay = new BLL.Urunler().UrunDetayGetir((int)urun.UrunDetayID);
            urunDetay.UrunBoyut = urunBoyut;
            urunDetay.UrunRenk = urunRenk;

            bool sonuc = new BLL.Urunler().UrunGuncelle(urun);
            bool sonuc2 = new BLL.Urunler().UrunDetayGuncelle(urunDetay);
            if (sonuc && sonuc2)
            {
                Response.RedirectToRoute("UrunYonetim");
            }
            else
            {
                Response.Write("<script>alert('Ürün güncellenemedi.')</script>");
            }

        }
    }
}