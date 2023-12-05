using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Yonetici
{
    public partial class KullaniciEkleme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_KullaniciEkleme_Click(object sender, EventArgs e)
        {
            String eposta = txt_eposta.Text;
            String sifre = txt_sifre.Text;
            String adi = txt_kullaniciAdi.Text;
            String soyadi = txt_kullaniciSoyad.Text;

            var sonuc = new BLL.BllKullanici().KullaniciAdiKullaniyormu(eposta);
            if (sonuc)
            {
                if (eposta != "" && sifre != "" && adi != "" && soyadi != "")
                {
                    Dal.Kullanici kullanici = new Dal.Kullanici();
                    kullanici.Adi = adi;
                    kullanici.Soyadi = soyadi;
                    kullanici.Eposta = eposta;
                    kullanici.Sifre = sifre;
                    kullanici.AktiflikDurumu = true;
                    kullanici.KayitTarihi = DateTime.Now;
                    if(cb_isAdmin.Checked)
                    {
                        kullanici.YetkiTuruID = 1;
                    }
                    else
                    {
                        kullanici.YetkiTuruID = 2;
                    }

                    if(BLL.BllKullanici.KullaniciEkle(kullanici))
                    {
                        lbl_EklemeSonuc.Text = "Kullanıcı başarıyla eklendi";
                        lbl_EklemeSonuc.ForeColor = System.Drawing.Color.Green;

                        Dal.UserLog log = new Dal.UserLog();
                        log.LogAciklama = "Kullanıcı eklendi";
                        log.LogTuruID = 3;
                        log.LogUserID = Convert.ToInt32(Session["KullaniciID"]);
                        new BLL.BLLUserLog().UserLog(log);
                    }
                    else
                    {
                        lbl_EklemeSonuc.Text = "Kullanıcı eklenirken bir hata oluştu";
                        lbl_EklemeSonuc.ForeColor = System.Drawing.Color.Red;
                    }

                }
            }
        }
    }
}