﻿using System;
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
            if (!IsPostBack)
            {
                UrunleriGetir();
            }
        }

        private void UrunleriGetir()
        {
            var urunler = new BLL.Urunler().UrunListele();
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
                        "<span class=\"f-w-2 f-h-2 bg-danger rounded-circle d-block me-1\"></span>Sale</span>\r\n</div>";
                }
                Literal_ListProducts.Text += "<span class=\"position-absolute top-0 end-0 p-2 z-index-20 text-muted\"><i class=\"ri-heart-line\"></i></span>";
                Literal_ListProducts.Text += "<picture class=\"position-relative overflow-hidden d-block bg-light\">\r\n" +
                    "<img class=\"w-100 img-fluid position-relative z-index-10\" title=\"\" src='../Images/" + item.UrunResim +
                    "' alt=\"\">\r\n" +
                    "</picture>";
                Literal_ListProducts.Text += "<div class=\"position-absolute start-0 bottom-0 end-0 z-index-20 p-2\">\r\n" +
                    "<button class=\"btn btn-quick-add\"><i class=\"ri-add-line me-2\"></i>Quick Add</button>\r\n</div>";
                Literal_ListProducts.Text += "</div>";
                Literal_ListProducts.Text += "<div class=\"card-body px-0\">\r\n" +
                    "<a class=\"text-decoration-none link-cover\" href=\"./product.aspx?ID=" + item.UrunID +
                    "\">Nike Air VaporMax 2021</a>\r\n" +
                    "<small class=\"text-muted d-block\">4 colours, 10 sizes</small>\r\n" +
                    "<p class=\"mt-2 mb-0 small\"><s class=\"text-muted\">$329.99</s> <span class=\"text-danger\">$198.66</span></p>\r\n" +
                    "</div>";
                Literal_ListProducts.Text += "</div>";
                Literal_ListProducts.Text += "</div>";
            }
        }
    }
}