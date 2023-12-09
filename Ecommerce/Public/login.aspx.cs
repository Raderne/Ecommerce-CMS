using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Public
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            String email = txt_loginEmail.Value;
            String password = txt_LoginPassword.Value;

            if (email != "" && password != "")
            {
                var sonuc = BLL.EcommerceUsers.Login(email, password);
                if (sonuc != null)
                {
                    Dal.UserLog log = new Dal.UserLog();
                    log.LogAciklama = "Kullanıcı girişi yapıldı";
                    log.LogTuruID = 1;
                    log.LogUserID = sonuc.EcommerceUserID;
                    new BLL.BLLUserLog().UserLog(log);
                }
                else
                {
                    Dal.UserLog log = new Dal.UserLog();
                    log.LogAciklama = "Kullanıcı adı veya şifre hatalı (KullaniciAdi: " + email + " Şifre: " + password + ")";
                    log.LogTuruID = 2;
                    log.LogUserID = 9999;
                    new BLL.BLLUserLog().UserLog(log);

                    lbl_LoginError.ForeColor = System.Drawing.Color.Red;
                    lbl_LoginError.Text = "Kullanıcı adı veya şifre hatalı";
                    lbl_LoginError.Visible = true;
                }
            }
            else
            {
                lbl_LoginError.ForeColor = System.Drawing.Color.Red;
                lbl_LoginError.Text = "Kullanıcı adı veya şifre boş geçilemez";
                lbl_LoginError.Visible = true;
            }

        }
    }
}