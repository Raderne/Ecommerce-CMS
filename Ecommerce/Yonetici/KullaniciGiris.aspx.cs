using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Yonetici
{
    public partial class KullaniciGiriss : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string eposta = txt_email.Value;
            string sifre = txt_password.Value;

            if (eposta != "" && sifre != "")
            {
                List<Dal.Kullanici> kullanici = BLL.BllKullanici.KullaniciKontrol(eposta, sifre);
                if (kullanici.Count > 0)
                {
                    Dal.UserLog log = new Dal.UserLog();
                    log.LogAciklama = "Kullanıcı girişi yapıldı";
                    log.LogTuruID = 1;
                    log.LogUserID = kullanici[0].KullaniciID;
                    new BLL.BLLUserLog().UserLog(log);

                    Session["KullaniciID"] = kullanici[0].KullaniciID;
                    Session["KullaniciAdi"] = kullanici[0].Adi + " " + kullanici[0].Soyadi;
                    Session["YetkiTuruID"] = kullanici[0].YetkiTuruID;
                    Response.Redirect("index.aspx");
                }
                else
                {
                    Dal.UserLog log = new Dal.UserLog();
                    log.LogAciklama = "Kullanıcı adı veya şifre hatalı (KullaniciAdi: "+eposta+" Şifre: "+sifre+")";
                    log.LogTuruID = 2;
                    log.LogUserID = 9999;
                    new BLL.BLLUserLog().UserLog(log);

                    lbl_sonuc.ForeColor = System.Drawing.Color.Red;
                    lbl_sonuc.Text = "Kullanıcı adı veya şifre hatalı";
                }
            }
            else
            {
                lbl_sonuc.ForeColor = System.Drawing.Color.Red;
                lbl_sonuc.Text = "Kullanıcı adı veya şifre boş geçilemez";
            }
        }
    }
}