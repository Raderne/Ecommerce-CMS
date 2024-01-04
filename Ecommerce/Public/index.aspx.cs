using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Public
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dal.EcommerceDBSitesiEntities db = new Dal.EcommerceDBSitesiEntities();
            var slides = db.Sliders.ToList();

            string html = "";
            foreach (var item in slides)
            {
                string sliderBaslik = item.SliderIsim.Split(' ')[0];

                html += "<div class=\"swiper-slide position-relative h-100 w-100\">";
                html += "<div class=\"w-100 h-100 overflow-hidden position-absolute z-index-1 top-0 start-0 end-0 bottom-0\">";
                html += "<div class=\"w-100 h-100 bg-img-cover bg-pos-center-center overflow-hidden\" data-swiper-parallax=\"-100\"";
                html += "style='will-change: transform; background-image: url(./assets/images/banners/"+ item.SliderResim + ")'></div>";
                html += "</div>";
                html += "<div class=\"container position-relative z-index-10 d-flex h-100 align-items-start flex-column justify-content-center\">";
                html += "<p class=\"title-small text-white opacity-75 mb-0\" data-swiper-parallax=\"-100\">"+ item.SliderAciklama + "</p>";
                html += "<h2 class=\"display-3 tracking-wide fw-bold text-uppercase tracking-wide text-white\" data-swiper-parallax=\"100\">" +
                    "<span class=\"text-outline-light\">" + sliderBaslik +"</span> " + item.SliderIsim.Substring(sliderBaslik.Length) + "</h2>";
                html += "<div data-swiper-parallax-y=\"-25\">";
                html += "<a href='" + item.SliderURL + "' class=\"btn btn-psuedo text-white\" role=\"button\">" + item.SliderURLAciklama + "</a>";
                html += "</div></div></div>";
            }

            Literal_Sliders.Text = html;
        }
    }
}