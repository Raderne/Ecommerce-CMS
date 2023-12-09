using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class EcommerceUsers
    {
        public static bool EmailIsAvailable(string email)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            var result = db.EcommerceUsers.Where(x => x.Email == email).SingleOrDefault();
            if (result == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Dal.EcommerceUser Login(string email, string password)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            var result = db.EcommerceUsers.Where(x => x.Email == email && x.Password == password).SingleOrDefault();
            if (result == null)
            {
                return null;
            }
            else
            {
                HttpContext.Current.Session["UserID"] = result.EcommerceUserID;
                HttpContext.Current.Session["UserName"] = result.Name + " " + result.Surname;
                HttpContext.Current.Response.Redirect("./index.aspx");
                return result;
            }
        }

        public static bool Register(Dal.EcommerceUser user)
        {
            Dal.EcommerceSitesiEntities db = new Dal.EcommerceSitesiEntities();
            db.EcommerceUsers.Add(user);
            var result = db.SaveChanges();
            if (result > 0)
            {
                HttpContext.Current.Session["UserID"] = user.EcommerceUserID;
                HttpContext.Current.Session["UserName"] = user.Name + " " + user.Surname;
                HttpContext.Current.Response.Redirect("./index.aspx");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}