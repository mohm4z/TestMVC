//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_ERP_Systems.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PROMOTION_TESTS
    {
        public long ID { get; set; }
        public long REQ_ID { get; set; }
        public Nullable<long> PROMO_POINTS { get; set; }
        public Nullable<long> OLD_PROMO_POINTS { get; set; }
        public Nullable<long> CREATION_USER_ID { get; set; }
        public Nullable<System.DateTime> CREATION_DATE { get; set; }
    
        public virtual REQUESTS REQUESTS { get; set; }
    }
}