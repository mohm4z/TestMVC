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
    
    public partial class SECTIONS
    {
        public long ID { get; set; }
        public string NAME { get; set; }
        public Nullable<long> SECTION_MGR { get; set; }
        public string SECTION_MGR_POSITION { get; set; }
        public Nullable<long> DIV_ID { get; set; }
        public Nullable<long> CREATION_USER_ID { get; set; }
        public Nullable<System.DateTime> CREATION_DATE { get; set; }
    
        public virtual DIVISIONS DIVISIONS { get; set; }
    }
}
