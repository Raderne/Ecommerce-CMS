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
    
    public partial class Urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urunler()
        {
            this.Carts = new HashSet<Cart>();
        }
    
        public int UrunID { get; set; }
        public string UrunIsim { get; set; }
        public Nullable<int> UrunFiyat { get; set; }
        public Nullable<int> UrunIndirimFiyat { get; set; }
        public Nullable<bool> isOnSale { get; set; }
        public Nullable<int> UrunReview { get; set; }
        public string UrunAciklama { get; set; }
        public Nullable<int> miktar { get; set; }
        public Nullable<bool> isNew { get; set; }
        public string Cinsiyet { get; set; }
        public string UrunResim { get; set; }
        public Nullable<int> UrunDetayID { get; set; }
        public Nullable<int> UrunKategoriID { get; set; }
        public Nullable<int> MarkaID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<bool> AktifllikDurumu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public virtual Markalar Markalar { get; set; }
        public virtual UrunDetaylar UrunDetaylar { get; set; }
        public virtual UrunlerKategori UrunlerKategori { get; set; }
    }
}
