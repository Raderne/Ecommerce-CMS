using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Public
{
    public partial class UrunlerListe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_PageSubtitle.InnerText = "";
            lbl_PageTitle.InnerText = "Tüm Ürünler";

            string marka = Request.QueryString["markaAd"];
            string isNew = Request.QueryString["isNew"];
            string isOnSale = Request.QueryString["isOnSale"];
            string kategoriName = Request.QueryString["kategoriName"];
            string cinsiyet = Request.QueryString["cinsiyet"];

            List<Dal.Urunler> urunler = new BLL.Urunler().UrunListele(marka, isNew, isOnSale, kategoriName, cinsiyet);
            UrunleriGetir(urunler);

            if (urunler.Count == 0)
            {
                Literal_ListProducts.Text = "<div class=\"col-12\"><div class=\"alert alert-danger\" role=\"alert\">Ürün bulunamadı.</div></div>";
            }

            lbl_PageSubtitle.InnerText = urunler.Count + " gösteriliyor";

            if (marka != null)
            {
                lbl_PageTitle.InnerText = marka + " Ürünleri";
            }else if (isNew != null)
            {
                lbl_PageTitle.InnerText = "Yeni Ürünler";
            }else if (isOnSale != null)
            {
                lbl_PageTitle.InnerText = "İndirimli Ürünler";
            }else if (kategoriName != null)
            {
                lbl_PageTitle.InnerText = kategoriName + " Ürünleri";
            }

        }

        private void UrunleriGetir(List<Dal.Urunler> urunler)
        {
            Literal_ListProducts.Text = "";
            foreach (var item in urunler)
            {
                Literal_ListProducts.Text += "<div class=\"col-12 col-sm-6 col-lg-4\">";
                Literal_ListProducts.Text += "<div class=\"card border border-transparent position-relative overflow-hidden h-100 transparent\">";
                Literal_ListProducts.Text += "<div class=\"card-img position-relative\">";
                if(item.isOnSale == true)
                {
                    Literal_ListProducts.Text += "<div class=\"card-badges\">\r\n" +
                        "<span class=\"badge badge-card\">" +
                        "<span class=\"f-w-2 f-h-2 bg-danger rounded-circle d-block me-1\"></span>İndirim</span>\r\n</div>";
                }
                Literal_ListProducts.Text += "<span class=\"position-absolute top-0 end-0 p-2 z-index-20 text-muted\"><i class=\"ri-heart-line\"></i></span>";
                Literal_ListProducts.Text += "<picture class=\"position-relative overflow-hidden d-block bg-light\">\r\n" +
                    "<img class=\"w-100 img-fluid position-relative z-index-10\" title=\"\" src='../Images/" + item.UrunResim +
                    "' alt=\"\">\r\n" +
                    "</picture>";
                Literal_ListProducts.Text += "<div class=\"position-absolute start-0 bottom-0 end-0 z-index-50 p-2\">\r\n" +
                    "<button class='btn btn-quick-add' onclick='QuickAddClick(event, " + item.UrunID + ");'><i class=\"ri-add-line me-2\"></i>Hızlı Ekle</button>" +
                    "\r\n</div>";
                Literal_ListProducts.Text += "</div>";
                Literal_ListProducts.Text += "<div class=\"card-body px-0\">\r\n" +
                    "<a class=\"text-decoration-none link-cover\" href=\"./product.aspx?ID=" + item.UrunID +
                    "\">" + item.UrunIsim + "</a>\r\n" +
                    "<small class=\"text-muted d-block\"></small>\r\n";
                if(item.isOnSale == true)
                {
                    Literal_ListProducts.Text += "<p class=\"mt-2 mb-0 small\"><s class=\"text-muted\">" + item.UrunFiyat + " TL</s> <span class=\"text-danger\">$" + item.UrunIndirimFiyat + "</span></p>\r\n";
                }
                else
                {
                    Literal_ListProducts.Text += "<p class=\"mt-2 mb-0 small\">"+ item.UrunFiyat +" TL</p>\r\n";
                }
                Literal_ListProducts.Text += "</div></div></div>";
            }
        }

        [System.Web.Services.WebMethod]
        public static string AddToCart(string urunID)
        {
            Dal.Cart cart = new Dal.Cart
            {
                UrunID = Convert.ToInt32(urunID),
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
                    return "Success";
                }
                else
                {
                    return "Error";
                }
            }
    
            return "Success";
        }
    }
}