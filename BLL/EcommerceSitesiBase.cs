using System;
using System.Collections.Generic;
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
    }
}