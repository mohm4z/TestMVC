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
    
    public partial class COMM_MEM_RANKS
    {
        public long ID { get; set; }
        public Nullable<long> COM_MEM_ID { get; set; }
        public Nullable<long> RANK_ID { get; set; }
        public Nullable<long> CREATION_USER_ID { get; set; }
        public Nullable<System.DateTime> CREATION_DATE { get; set; }
    
        public virtual COMMITTEES_MEMBERS COMMITTEES_MEMBERS { get; set; }
        public virtual ST_MRANK ST_MRANK { get; set; }
    }
}
