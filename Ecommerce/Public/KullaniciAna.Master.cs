using Dal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Public.Ecommerce
{
    public partial class KullaniciAna : System.Web.UI.MasterPage
    {
        const string imagesPath = "../Images/";

        protected void Page_Load(object sender, EventArgs e)
        {
            btn_removeAllCartItems.Style.Add("text-decoration", "none");
            btn_removeAllCartItems.PostBackUrl = null;


            if (Session["UserID"] != null && Session["UserName"] != null)
            {
                lbl_MenuAcount.Visible = false;
                lbl_MenuAcount.Style.Add("display", "none");

                lBtn_logout.Visible = true;
                lBtn_logout.Text = Session["UserName"].ToString();

                // get cart element from Database
                List<Dal.Cart> cart = new BLL.Urunler().CartGetir(Convert.ToInt32(Session["UserID"]));
                if (cart.Count > 0)
                {
                    lbl_bagItemsCount1.Text = "( " + cart.Count.ToString() + " )";
                    lbl_bagItemsCount2.Text = "(" + cart.Count.ToString() + " items)";

                    ListCartItems(cart);

                }
                else
                {
                    lbl_bagItemsCount1.Text = "";
                    lbl_bagItemsCount2.Text = "(0 items)";
                    lbl_BagTotal.Style.Add("display", "none");
                }
            }
            else
            {
                lbl_MenuAcount.Visible = true;

                lBtn_logout.Visible = false;
                lBtn_logout.Style.Add("display", "none");

                // get cart element from session
                if (Session["Cart"] != null)
                {
                    lbl_BagTotal.Style.Add("display", "block");

                    List<Dal.Cart> cart = (List<Dal.Cart>)Session["Cart"];
                    lbl_bagItemsCount1.Text = "( " + cart.Count.ToString() + " )";
                    lbl_bagItemsCount2.Text = "(" + cart.Count.ToString() + " items)";

                    ListCartItems(cart);
                }
                else
                {
                    lbl_bagItemsCount1.Text = "";
                    lbl_bagItemsCount2.Text = "(0 items)";
                    lbl_BagTotal.Style.Add("display", "none");
                }
            }
        }

        protected void lBtn_logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("./login.aspx");
        }

        protected void btn_removeAllCartItems_Click(object sender, EventArgs e)
        {
            if (Session["Cart"] != null)
            {
                Session["Cart"] = null;
                Literal_CartListele.Text = "";
            }
            else if (Session["UserID"] != null)
            {
                new BLL.Urunler().CartUrunlerSil(Convert.ToInt32(Session["UserID"]));
                Literal_CartListele.Text = "";
                Session["Cart"] = null;

                lbl_bagItemsCount1.Text = "";
                lbl_bagItemsCount2.Text = "(0 items)";
                lbl_BagTotal.Style.Add("display", "none");
            }
        }

        private void ListCartItems(List<Dal.Cart> cart)
        {
            var GroupedCart = cart.GroupBy(x => x.UrunID).Select(y => new { UrunID = y.Key, Quantity = y.Count() });
            int total = 0;
            Literal_CartListele.Text = "";
            foreach (var cartItem in GroupedCart)
            {
                int Quantity = cartItem.Quantity;
                Dal.Urunler urun = new BLL.Urunler().UrunGetir(Convert.ToInt32(cartItem.UrunID));

                Literal_CartListele.Text += "<div class=\"row mx-0 py-4 g-0 border-bottom\">" +
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
                    Literal_CartListele.Text += "<p class=\"fw-bolder text-end text-muted m-0\">" + urun.UrunIndirimFiyat + " TL</p></div></div>";
                    total += Convert.ToInt32(urun.UrunIndirimFiyat) * Quantity;
                }
                else
                {
                    Literal_CartListele.Text += "<p class=\"fw-bolder text-end text-muted m-0\">" + urun.UrunFiyat + " TL</p></div></div>";
                    total += Convert.ToInt32(urun.UrunFiyat) * Quantity;
                }
            }

            lbl_BagTotal.InnerText = total.ToString() + ".00 TL";
        }
    }
}