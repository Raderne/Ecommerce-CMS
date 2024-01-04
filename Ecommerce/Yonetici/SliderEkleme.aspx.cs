using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Yonetici
{
    public partial class SliderEkleme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_SliderEkle_Click(object sender, EventArgs e)
        {
            string sliderIsim = txt_SliderIsim.Value;
            string sliderAciklama = txt_SliderAciklama.Value;
            string sliderURL = txt_SliderUrl.Value;
            string sliderURLAciklama = txt_SliderUrlAciklama.Value;

            if (File_SliderResim.HasFile)
            {
                string dosyaAdi = File_SliderResim.FileName;
                string resimUzanti = System.IO.Path.GetExtension(dosyaAdi);

                if (resimUzanti == ".jpg" || resimUzanti == ".png" || resimUzanti == ".jpeg")
                {
                    string resimYolu = Server.MapPath("../Public/assets/images/banners/" + dosyaAdi);
                    File_SliderResim.SaveAs(resimYolu);

                    Dal.EcommerceDBSitesiEntities db = new Dal.EcommerceDBSitesiEntities();
                    Dal.Slider slider = new Dal.Slider();
                    slider.SliderIsim = sliderIsim;
                    slider.SliderAciklama = sliderAciklama;
                    slider.SliderURL = sliderURL;
                    slider.SliderURLAciklama = sliderURLAciklama;
                    slider.SliderResim = dosyaAdi;
                    slider.SliderAktiflikDurumu = true;
                    db.Sliders.Add(slider);
                    db.SaveChanges();
                    Response.Redirect("SliderYonetim.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Slider eklenemedi.')</script>");
                }
            } else
            {
                Response.Write("<script>alert('Slider Resim eklenemedi.')</script>");
            }
        }
    }
}