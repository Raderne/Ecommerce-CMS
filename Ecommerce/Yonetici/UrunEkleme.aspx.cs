using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Yonetici
{
    public partial class UrunEkleme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UrunKategoriListele();
                UrunMarkaListele();
            }
        }

        private void UrunMarkaListele()
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            var markalar = db.Markalars.ToList();
            foreach (var item in markalar)
            {
                literal_UrunMarka.Text += "<option value='" + item.MarkaID + "'>" + item.MarkaAd + "</option>";
            }
        }

        private void UrunKategoriListele()
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            var kategoriler = db.UrunlerKategoris.ToList();
            foreach (var item in kategoriler)
            {
                literal_urunKategori.Text += "<option value='" + item.UrunKategoriID + "'>" + item.UrunkategoriAd + "</option>";
            }
        }

    }
}