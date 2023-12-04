using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Yonetici
{
    public partial class KullaniciUye : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            string eposta = txt_registerEmail.Value;
            string sifre = txt_registerPassword.Value;
            string ad = txt_KullaniciAd.Value;
            string soyad = txt_kullaniciSoyadi.Value;

            if (eposta != "" && sifre != "")
            {
                if (BLL.BllKullanici.KullaniciAdiKullaniyormu(eposta))
                {
                    Dal.Kullanici kullanici = new Dal.Kullanici();
                    kullanici.Eposta = eposta;
                    kullanici.Sifre = sifre;
                    kullanici.Adi = ad;
                    kullanici.Soyadi = soyad;
                    kullanici.AktiflikDurumu = true;
                    kullanici.KayitTarihi = DateTime.Now;
                    kullanici.YetkiTuruID = 2;
                    if (BLL.BllKullanici.KullaniciEkle(kullanici))
                    {
                        lbl_KayitSonuc.BackColor = System.Drawing.Color.Green;
                        lbl_KayitSonuc.Text = "Kullanıcı başarıyla eklendi";
                    }
                    else
                    {
                        lbl_KayitSonuc.BackColor = System.Drawing.Color.Red;
                        lbl_KayitSonuc.Text = "Kullanıcı eklenirken bir hata oluştu";
                    }
                }
                else
                {
                    lbl_KayitSonuc.BackColor = System.Drawing.Color.Red;
                    lbl_KayitSonuc.Text = "Kullanıcı Eposta adresi kullanılıyor";
                }
            }
            else
            {
                lbl_KayitSonuc.BackColor = System.Drawing.Color.Red;
                lbl_KayitSonuc.Text = "Kullanıcı adı veya şifre boş geçilemez";
            }
        }
    }
}