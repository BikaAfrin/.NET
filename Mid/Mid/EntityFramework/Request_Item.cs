//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mid.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Request_Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public System.DateTime Expiredate { get; set; }
        public string Status { get; set; }
        public Nullable<int> RID { get; set; }
        public Nullable<int> EID { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Resturant Resturant { get; set; }
    }
}
