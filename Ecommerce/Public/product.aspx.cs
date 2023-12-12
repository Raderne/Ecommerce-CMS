using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Public
{
    public partial class product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int UrunID = Convert.ToInt32(Request.QueryString["UrunID"]);

            Dal.Urunler urun = new BLL.Urunler().UrunGetir(UrunID);
            if (urun == null)
            {
                Response.Redirect("/Public/404.aspx");
            }
            else
            {
                initializeValues(urun);
            }
        }

        private void initializeValues(Dal.Urunler urun)
        {
            string imagesDirectory = "../Images/";
            Dal.UrunDetaylar urunDetaylar = new BLL.Urunler().UrunDetayGetir((int)urun.UrunDetayID);

            string KategoriAd = new BLL.Urunler().UrunKategoriGetir((int)urun.UrunKategoriID).UrunkategoriAd;
            string markaAd = new BLL.Urunler().MarkaGetir((int)urun.MarkaID).MarkaAd;

            lbl_productName.InnerText = urun.UrunIsim;
            link_CategoryName.InnerText = KategoriAd;
            link_CategoryName.HRef = "/Public/UrunlerListe.aspx?kategoriName=" + KategoriAd;

            img_ProductImage1.Src = imagesDirectory + urunDetaylar.UrunImage1;
            img_ProductImage2.Src = imagesDirectory + urunDetaylar.UrunImage2;
            img_ProductImage3.Src = imagesDirectory + urunDetaylar.UrunImage3;
            img_ProductImage4.Src = imagesDirectory + urunDetaylar.UrunImage4;

            lbl_ProductMarka.InnerText = markaAd;
            lbl_ProductTitle.InnerText = markaAd + " " + urun.UrunIsim + " " + urun.Cinsiyet + " " + KategoriAd;
            lbl_ProductPrice.InnerText = urun.UrunFiyat + " TL";
            lbl_ProductsDetails.InnerText = urun.UrunAciklama;
        }

        protected void btn_AddToShoppingCart_Click(object sender, EventArgs e)
        {
            int UrunID = Convert.ToInt32(Request.QueryString["UrunID"]);
            Dal.Cart cart = new Dal.Cart
            {
                UrunID = UrunID,
            };

            if (HttpContext.Current.Session["Cart"] == null)
            {
                List<Dal.Cart> cartList = new List<Dal.Cart>();
                cartList.Add(cart);
                HttpContext.Current.Session["Cart"] = cartList;
            }
            else
            {
                List<Dal.Cart> cartList = (List<Dal.Cart>)HttpContext.Current.Session["Cart"];
                cartList.Add(cart);
                HttpContext.Current.Session["Cart"] = cartList;
            }

            if (HttpContext.Current.Session["UserID"] != null)
            {
                cart.UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                var sonuc = new BLL.Urunler().CartUrunEkle(cart);
                if (sonuc == true)
                {
                    Response.Redirect(Request.RawUrl);
                    Response.Write("<script>alert('Ürün sepete eklendi.')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Ürün sepete eklenemedi.')</script>");
                }
            }
            else
            {
                Response.Redirect(Request.RawUrl);
                Response.Write("<script>alert('Ürün sepete eklendi.')</script>");
            }
        }
    }
}