using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BLL
{
    public class EcommerceSitesiBase
    {
        public static bool KullaniciKontrol()
        {
            if (HttpContext.Current.Session["KullaniciID"] == null)
            {
                HttpContext.Current.Response.Redirect("KullaniciGiris.aspx");
                return false;
            }
            else
            {
                return true;
            }
        }

        public DataTable SliderListele()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Slider Resim");
            dt.Columns.Add("Slider Baslik");
            dt.Columns.Add("Slider Aciklama");
            dt.Columns.Add("Slider URL");
            dt.Columns.Add("Slider URL Aciklamasi");
            dt.Columns.Add("Slider Sil");

            Dal.EcommerceDBSitesiEntities db = new Dal.EcommerceDBSitesiEntities();
            var sliderList = db.Sliders.Where(x => x.SliderAktiflikDurumu == true).ToList();
            foreach ( var slider in sliderList )
            {
                DataRow dr = dt.NewRow();
                dr["Slider Resim"] = slider.SliderResim;
                dr["Slider Baslik"] = slider.SliderIsim;
                dr["Slider Aciklama"] = slider.SliderAciklama;
                dr["Slider URL"] = slider.SliderURL;
                dr["Slider URL Aciklamasi"] = slider.SliderURLAciklama;
                dr["Slider Sil"] = slider.SliderID;
                dt.Rows.Add(dr);
            }

            return dt;
        }

        public void SliderSil(int sliderID)
        {
            Dal.EcommerceDBSitesiEntities db = new Dal.EcommerceDBSitesiEntities();
            var slider = db.Sliders.Where(x => x.SliderID == sliderID).SingleOrDefault();
            slider.SliderAktiflikDurumu = false;
            db.SaveChanges();
        }
    }
}