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
    
    public partial class USERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USERS()
        {
            this.COMMITTEES_MEMBERS = new HashSet<COMMITTEES_MEMBERS>();
            this.USERS_GROUPS = new HashSet<USERS_GROUPS>();
            this.USERS_PERMISSIONS = new HashSet<USERS_PERMISSIONS>();
            this.USERS_SETTINGS = new HashSet<USERS_SETTINGS>();
        }
    
        public long ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string MIDEL_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string FULL_NAME { get; set; }
        public string LOGIN_NAME { get; set; }
        public string PASSWORD { get; set; }
        public long NAT_ID { get; set; }
        public Nullable<long> PHONE { get; set; }
        public string EMAIL { get; set; }
        public Nullable<long> GENDER { get; set; }
        public string ADDRESS { get; set; }
        public string IMG_PATH { get; set; }
        public Nullable<long> EMP_NO { get; set; }
        public long CREATION_USER_ID { get; set; }
        public System.DateTime CREATION_DATE { get; set; }
        public string SIGNATURE_PATH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMITTEES_MEMBERS> COMMITTEES_MEMBERS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERS_GROUPS> USERS_GROUPS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERS_PERMISSIONS> USERS_PERMISSIONS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERS_SETTINGS> USERS_SETTINGS { get; set; }
    }
}
