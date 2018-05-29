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
    
    public partial class FILTRATION_PERIODS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FILTRATION_PERIODS()
        {
            this.CMITS_FIL_PERD = new HashSet<CMITS_FIL_PERD>();
            this.FILT_PER_RANK = new HashSet<FILT_PER_RANK>();
            this.REQUESTS = new HashSet<REQUESTS>();
        }
    
        public long ID { get; set; }
        public string NAME { get; set; }
        public System.DateTime FROM_DATE { get; set; }
        public System.DateTime TO_DATE { get; set; }
        public System.DateTime FILT_DATE { get; set; }
        public string FROM_DATE_H { get; set; }
        public string TO_DATE_H { get; set; }
        public string FILT_DATE_H { get; set; }
        public Nullable<long> EXAM_STAT { get; set; }
        public Nullable<long> CREATION_USER_ID { get; set; }
        public Nullable<System.DateTime> CREATION_DATE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CMITS_FIL_PERD> CMITS_FIL_PERD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FILT_PER_RANK> FILT_PER_RANK { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REQUESTS> REQUESTS { get; set; }
    }
}