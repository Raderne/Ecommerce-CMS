using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class BLLUserLog
    {
        public bool UserLog(Dal.UserLog LogKayitlari)
        {
            using (Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities())
            {
                LogKayitlari.BilgisayarIP = GetIPAddress();
                LogKayitlari.KayitTarihi = DateTime.Now;
                db.UserLogs.Add(LogKayitlari);
                db.SaveChanges();
                return true;
            }
        }

        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}