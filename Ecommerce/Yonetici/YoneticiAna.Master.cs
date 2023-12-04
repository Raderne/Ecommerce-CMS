using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Yonetici
{
    public partial class YoneticiAna : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KullaniciID"] == null)
            {
                Response.Redirect("KullaniciGiris.aspx");
            }
            else
            {
                string kullaniciAdi = Session["KullaniciAdi"].ToString();
                string name = kullaniciAdi.Split(' ')[0];

                lbl_KullaniciAdi.Text = kullaniciAdi;
                lbl_MainContent_Name.Text = name;
            }
        }

        protected void Sidebar_Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("KullaniciGiris.aspx");
        }
    }
}