//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            this.Urunlers = new HashSet<Urunler>();
        }
    
        public int KullaniciID { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public Nullable<System.DateTime> KayitTarihi { get; set; }
        public Nullable<bool> AktiflikDurumu { get; set; }
        public Nullable<int> YetkiTuruID { get; set; }
    
        public virtual KullaniciYetki KullaniciYetki { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Urunler> Urunlers { get; set; }
    }
}
