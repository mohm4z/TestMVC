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
    
    public partial class DEPARTMENTS
    {
        public long ID { get; set; }
        public Nullable<long> DEPARTMENT_NO { get; set; }
        public string DEPARTMENT_NAME_ARB { get; set; }
        public string DEPARTMENT_NAME_ENG { get; set; }
        public Nullable<long> DEPARTMENT_MANAGER { get; set; }
        public Nullable<long> CREATION_USER_ID { get; set; }
        public Nullable<System.DateTime> CREATION_DATE { get; set; }
    }
}
