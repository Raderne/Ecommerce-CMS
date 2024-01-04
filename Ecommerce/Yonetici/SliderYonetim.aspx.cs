using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Yonetici
{
    public partial class SliderYonetim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new BLL.EcommerceSitesiBase().SliderListele();
                String htmlTable = "";
                foreach (DataRow item in dt.Rows)
                {
                    htmlTable += "<tr>";
                    htmlTable += "<td><img src='../Public/assets/images/banners/" + item["Slider Resim"] + "' width='100' height='100' /></td>";
                    htmlTable += "<td>" + item["Slider Baslik"] + "</td>";
                    htmlTable += "<td>" + item["Slider Aciklama"] + "</td>";
                    htmlTable += "<td>" + item["Slider URL"] + "</td>";
                    htmlTable += "<td>" + item["Slider URL Aciklamasi"] + "</td>";
                    htmlTable += "<td><button type='button' onclick='SliderSil(" + item["Slider Sil"] + ");' class='btn btn-outline-danger'>Slider Sil</button></td>";
                    htmlTable += "</tr>";
                }

                Literal_SliderListele.Text = htmlTable;
            }
        }

        [System.Web.Services.WebMethod]
        public static void RemoveItem(int sliderID)
        {
            new BLL.EcommerceSitesiBase().SliderSil(sliderID);
        }
    }
}