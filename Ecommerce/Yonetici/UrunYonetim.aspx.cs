using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Yonetici
{
    public partial class UrunYonetim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                int id = Convert.ToInt32(Session["KullaniciID"]);
                DataTable dt = new BLL.Urunler().UrunlerList(id);
                String htmlTable = "";
                foreach (DataRow item in dt.Rows)
                {
                    htmlTable += "<tr>";
                    htmlTable += "<td><img src='../Images/" + item["Urun Resim"] + "' width='100' height='100' /></td>";
                    htmlTable += "<td>" + item["Urun Isim"] + "</td>";
                    htmlTable += "<td>" + item["Urun Kategori"] + "</td>";
                    htmlTable += "<td>" + item["Urun Fiyat"] + "</td>";
                    htmlTable += "<td>" + item["miktar"] + "</td>";
                    htmlTable += "<td><button type='button' onclick='location.href=\"UrunDuzenle.aspx?UrunID=" + item["Urun Detaylar"] + "\"' class='btn btn-outline-primary'>Ürün Detaylar</button></td>";
                    htmlTable += "<td><button type='button' onclick='UrunSil(" + item["Urun Sil"] + ");' class='btn btn-outline-danger'>Ürün Sil</button></td>";
                    htmlTable += "</tr>";
                }

                Literal_UrunlerListele.Text = htmlTable;
            }
        }

        [System.Web.Services.WebMethod]
        public static void RemoveItem(int urunID)
        {
            new BLL.Urunler().UrunSil(urunID);
        }
    }
}