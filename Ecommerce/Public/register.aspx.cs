using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Public
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_registerAccount_Click(object sender, EventArgs e)
        {
            String email = txt_registerEmail.Value;
            String password = txt_registerPassword.Value;
            String name = txt_registerName.Value;
            String surname = txt_registerLastName.Value;

            if (email != "" && password != "" && name != "" && surname != "")
            {
                if (BLL.EcommerceUsers.EmailIsAvailable(email))
                {
                    Dal.EcommerceUser kullanici = new Dal.EcommerceUser();
                    kullanici.Name = name;
                    kullanici.Surname = surname;
                    kullanici.Email = email;
                    kullanici.Password = password;
                    kullanici.ActivityStatus = true;
                    kullanici.RegistrationDate = DateTime.Now;
                    if (BLL.EcommerceUsers.Register(kullanici))
                    {
                        Session["KullaniciID"] = kullanici.EcommerceUserID;
                        Session["KullaniciAdi"] = kullanici.Name + " " + kullanici.Surname;
                        Response.Redirect("./index.aspx");

                        Dal.UserLog log = new Dal.UserLog();
                        log.LogAciklama = "Kullanıcı girişi yapıldı";
                        log.LogTuruID = 3;
                        log.LogUserID = kullanici.EcommerceUserID;
                        new BLL.BLLUserLog().UserLog(log);
                    }
                    else
                    {
                        lbl_registerError.ForeColor = System.Drawing.Color.Red;
                        lbl_registerError.Text = "Kullanıcı eklenirken bir hata oluştu";
                        lbl_registerError.Visible = true;

                        Dal.UserLog log = new Dal.UserLog();
                        log.LogAciklama = "Kullanıcı girişi yapılamadı";
                        log.LogTuruID = 2;
                        log.LogUserID = kullanici.EcommerceUserID;
                        new BLL.BLLUserLog().UserLog(log);
                    }
                }
                else
                {
                    lbl_registerError.ForeColor = System.Drawing.Color.Red;
                    lbl_registerError.Text = "Kullanıcı Eposta adresi kullanılıyor";
                    lbl_registerError.Visible = true;
                }
            }
            else
            {
                lbl_registerError.ForeColor = System.Drawing.Color.Red;
                lbl_registerError.Text = "Kullanıcı adı veya şifre boş geçilemez";
                lbl_registerError.Visible = true;
            }
        }
    }
}