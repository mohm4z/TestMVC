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
    
    public partial class CMITS_FIL_PERD
    {
        public long ID { get; set; }
        public long COMMITTEES_ID { get; set; }
        public long FILTRATION_PERIODS_ID { get; set; }
        public long CREATION_USER_ID { get; set; }
        public System.DateTime CREATION_DATE { get; set; }
    
        public virtual COMMITTEES COMMITTEES { get; set; }
        public virtual FILTRATION_PERIODS FILTRATION_PERIODS { get; set; }
    }
}
