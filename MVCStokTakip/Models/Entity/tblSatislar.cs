//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCStokTakip.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSatislar
    {
        public int satisId { get; set; }
        public Nullable<int> satisUrun { get; set; }
        public Nullable<int> satisPersonel { get; set; }
        public Nullable<int> satisMusteri { get; set; }
        public Nullable<decimal> satisFiyat { get; set; }
        public Nullable<System.DateTime> satisTarih { get; set; }
    
        public virtual tblMusteri tblMusteri { get; set; }
        public virtual tblPersonel tblPersonel { get; set; }
        public virtual tblUrunler tblUrunler { get; set; }
    }
}
