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
    
    public partial class SENIORITY
    {
        public long ID { get; set; }
        public long REQ_ID { get; set; }
        public Nullable<int> DAYS { get; set; }
        public Nullable<int> MONTHS { get; set; }
        public Nullable<int> YEARS { get; set; }
        public Nullable<double> DESERVES_POINTS { get; set; }
        public Nullable<int> DEDUCTION_DAYS { get; set; }
        public Nullable<int> DEDUCTION_MONTHS { get; set; }
        public Nullable<int> DEDUCTION_YEARS { get; set; }
        public Nullable<int> DEDUCTION_POINTS { get; set; }
        public Nullable<double> ACTUAL_POINTS { get; set; }
        public string SENIORITY_FILE_NAME { get; set; }
        public string SENIORITY_FILE_PATH { get; set; }
        public Nullable<long> CREATION_USER_ID { get; set; }
        public Nullable<System.DateTime> CREATION_DATE { get; set; }
        public Nullable<long> UPDATED_USER_ID { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
    
        public virtual REQUESTS REQUESTS { get; set; }
    }
}