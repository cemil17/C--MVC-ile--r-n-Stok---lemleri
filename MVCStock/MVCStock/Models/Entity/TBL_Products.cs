//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCStock.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_Products()
        {
            this.TBL_Sales = new HashSet<TBL_Sales>();
        }
    
        public int Product_Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public Nullable<short> Category { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<byte> Stock { get; set; }
    
        public virtual TBL_Category TBL_Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_Sales> TBL_Sales { get; set; }
    }
}