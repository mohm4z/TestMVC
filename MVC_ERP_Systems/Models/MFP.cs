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
    
    public partial class MFP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MFP()
        {
            this.MFP1 = new HashSet<MFP>();
        }
    
        public int ID { get; set; }
        public Nullable<int> PARENT_ID { get; set; }
        public int LT_MFP_TYPES_ID { get; set; }
        public Nullable<int> STATUSES_ID { get; set; }
        public string NAME_A { get; set; }
        public string NAME_L { get; set; }
        public string PROG_NAME { get; set; }
        public string LINK { get; set; }
        public string DESCRIPTION { get; set; }
        public int CREATION_USER_ID { get; set; }
        public Nullable<System.DateTime> CREATION_DATE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MFP> MFP1 { get; set; }
        public virtual MFP MFP2 { get; set; }
    }
}