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
    
    public partial class ULP_EMPLOYEES
    {
        public long ID { get; set; }
        public long EMP_NO { get; set; }
        public string EMP_FIRST_NAME { get; set; }
        public string EMP_FATHER_NAME { get; set; }
        public string EMP_GRAND_NAME { get; set; }
        public string EMP_FAMILY_NAME { get; set; }
        public Nullable<int> DEPT_NO { get; set; }
        public Nullable<long> CREATION_USER_ID { get; set; }
        public Nullable<System.DateTime> CREATION_DATE { get; set; }
    }
}