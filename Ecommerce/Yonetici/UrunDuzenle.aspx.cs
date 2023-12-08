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

            Dal.UrunDetaylar urunDetay = new BLL.Urunler().UrunDetayGetir((int)urun.UserID);
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
    }
}