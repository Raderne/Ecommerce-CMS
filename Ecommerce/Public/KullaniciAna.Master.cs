using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Public.Ecommerce
{
    public partial class KullaniciAna : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                if (Session["KullaniciID"] != null)
                {
                    lbl_MenuAcount.Visible = false;
                    lbl_MenuAcount.Style.Add("display", "none");

                    lBtn_logout.Visible = true;
                    lBtn_logout.Text = Session["KullaniciAdi"].ToString();
                }
                else
                {
                    lbl_MenuAcount.Visible = true;

                    lBtn_logout.Visible = false;
                    lBtn_logout.Style.Add("display", "none");
                }
            }
        }

        protected void lBtn_logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("./login.aspx");
        }
    }
}