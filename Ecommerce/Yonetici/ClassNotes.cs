using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Yonetici
{
    public class ClassNotes
    {
    }

    // added a slider component and went to BLL to add a new method for the slider component
    /* 
     public List<Dal.slider> Listele ()
        {
            Dal.EcommerceEntities db = new Dal.EcommerceEntities();
            return db.slider.Where(x => x.AktifDurumu == true).ToList();
        }

    public bool Ekle(Dal.slider slider)
        {
            Dal.EcommerceEntities db = new Dal.EcommerceEntities();
            db.slider.Add(slider);
            db.SaveChanges();
            return true;
        }

    public bool Sil(Dal.slider slider)
        {
            Dal.EcommerceEntities db = new Dal.EcommerceEntities();
            var silinecek = db.slider.Where(x => x.Id == slider.Id).SingleOrDefault();
            silinecek.AktifDurumu = false;
            db.SaveChanges();
            return true;
        }
     
     */


    // made a form for the slider component in the admin panel
    // added a folder for the image upload in the admin panel
    // named picture upload using GUID 
}