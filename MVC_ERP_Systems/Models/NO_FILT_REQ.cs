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
    
    public partial class NO_FILT_REQ
    {
        public long ID { get; set; }
        public Nullable<long> REQ_ID { get; set; }
        public Nullable<int> LT_NO_FILT_REASON_ID { get; set; }
        public string TEXT_REASON { get; set; }
        public string NO_FILT_FILE_NAME { get; set; }
        public string NO_FILT_FILE_PATH { get; set; }
    
        public virtual REQUESTS REQUESTS { get; set; }
    }
}