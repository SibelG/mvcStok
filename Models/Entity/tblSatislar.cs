//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSatislar
    {
        public int satisId { get; set; }
        public Nullable<int> urun { get; set; }
        public Nullable<int> musteri { get; set; }
        public Nullable<int> adet { get; set; }
        public Nullable<decimal> fiyat { get; set; }
    
        public virtual tblMusteriler tblMusteriler { get; set; }
        public virtual tblUrun tblUrun { get; set; }
    }
}
