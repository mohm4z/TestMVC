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
    
    public partial class GROUPS_PERMISSIONS
    {
        public int ID { get; set; }
        public long GROUPS_ID { get; set; }
        public int MFP_ID { get; set; }
        public int CREATION_USER_ID { get; set; }
        public System.DateTime CREATION_DATE { get; set; }
    
        public virtual GROUPS GROUPS { get; set; }
    }
}
