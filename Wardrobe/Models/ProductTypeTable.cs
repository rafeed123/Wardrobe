//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wardrobe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductTypeTable
    {
        public ProductTypeTable()
        {
            this.ProductsTables = new HashSet<ProductsTable>();
        }
    
        public int ProductTypeID { get; set; }
        public string ProductType { get; set; }
    
        public virtual ICollection<ProductsTable> ProductsTables { get; set; }
    }
}