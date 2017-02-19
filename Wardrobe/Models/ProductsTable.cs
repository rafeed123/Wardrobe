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
    
    public partial class ProductsTable
    {
        public int ProductID { get; set; }
        public int ProductTypeID { get; set; }
        public Nullable<int> TopID { get; set; }
        public Nullable<int> BottomID { get; set; }
        public Nullable<int> ShoeID { get; set; }
        public Nullable<int> AccesoryID { get; set; }
        public string PhotoLink { get; set; }
    
        public virtual AccessoriesTable AccessoriesTable { get; set; }
        public virtual BottomsTable BottomsTable { get; set; }
        public virtual ProductTypeTable ProductTypeTable { get; set; }
        public virtual ShoesTable ShoesTable { get; set; }
        public virtual TopsTable TopsTable { get; set; }
    }
}