using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Public
{
    public partial class Cart : System.Web.UI.Page
    {
        const string imagesPath = "../Images/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null && Session["UserName"] != null)
            {
                // get cart element from Database
                List<Dal.Cart> cart = new BLL.Urunler().CartGetir(Convert.ToInt32(Session["UserID"]));
                if (cart.Count > 0)
                {
                    ListCartItems(cart);
                }
                else
                {
                    lbl_CartTotal.InnerText = "0.00 TL";
                    literalCartListeleme.Text = "<div class=\"row mx-0 py-4 g-0 border-bottom\">" +
                        "<div class=\"col-12 text-center\"><div>" +
                        "<h6 class=\"justify-content-between d-flex align-items-start mb-2\">Sepetinizde ürün bulunmamaktadır." +
                        "</h6></div></div></div>";

                }
            }
            else
            {
                // get cart element from session
                if (Session["Cart"] != null)
                {
                    List<Dal.Cart> cart = (List<Dal.Cart>)Session["Cart"];

                    ListCartItems(cart);
                }
                else
                {
                    lbl_CartTotal.InnerText = "0.00 TL";
                    literalCartListeleme.Text = "<div class=\"row mx-0 py-4 g-0 border-bottom\">" +
                        "<div class=\"col-12 text-center\"><div>" +
                        "<h6 class=\"justify-content-between d-flex align-items-start mb-2\">Sepetinizde ürün bulunmamaktadır." +
                        "</h6></div></div></div>";
                }
            }
        }

        private void ListCartItems(List<Dal.Cart> cart)
        {
            var GroupedCart = cart.GroupBy(x => x.UrunID).Select(y => new { UrunID = y.Key, Quantity = y.Count() });
            int total = 0;
            literalCartListeleme.Text = "";
            foreach (var cartItem in GroupedCart)
            {
                int Quantity = cartItem.Quantity;
                Dal.Urunler urun = new BLL.Urunler().UrunGetir(Convert.ToInt32(cartItem.UrunID));

                literalCartListeleme.Text += "<div class=\"row mx-0 py-4 g-0 border-bottom\">" +
                    "<div class=\"col-2 position-relative\">" +
                        "<picture class=\"d-block \">" +
                            "<img class=\"img-fluid\" src=" + imagesPath + urun.UrunResim + " alt=" + urun.UrunIsim + ">" +
                        "</picture>" +
                    "</div>" +
                    "<div class=\"col-9 offset-1\"><div>" +
                        "<h6 class=\"justify-content-between d-flex align-items-start mb-2\">" + urun.UrunIsim +
                        "</h6><span class=\"d-block text-muted fw-bolder text-uppercase fs-9\">Qty: " + Quantity + "</span></div>";
                if (urun.isOnSale == true)
                {
                    literalCartListeleme.Text += "<p class=\"fw-bolder text-end text-muted m-0\">" + urun.UrunIndirimFiyat + " TL</p></div></div>";
                    total += Convert.ToInt32(urun.UrunIndirimFiyat) * Quantity;
                }
                else
                {
                    literalCartListeleme.Text += "<p class=\"fw-bolder text-end text-muted m-0\">" + urun.UrunFiyat + " TL</p></div></div>";
                    total += Convert.ToInt32(urun.UrunFiyat) * Quantity;
                }
            }

            lbl_CartTotal.InnerText = total.ToString() + ".00 TL";
        }
    }
}