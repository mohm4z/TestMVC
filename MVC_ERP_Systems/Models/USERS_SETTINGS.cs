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
    
    public partial class USERS_SETTINGS
    {
        public long ID { get; set; }
        public long USERS_ID { get; set; }
        public string LANG { get; set; }
        public string CALENDAR { get; set; }
        public string FONT_FAMILY { get; set; }
        public Nullable<int> FONT_SIZE { get; set; }
        public string COLOR { get; set; }
        public string MAIN_MENUE_TYPE { get; set; }
        public Nullable<System.DateTime> START_DATE { get; set; }
        public Nullable<System.DateTime> EXPIRE_DATE { get; set; }
        public Nullable<System.DateTime> START_TIME { get; set; }
        public Nullable<int> END_TIME { get; set; }
        public Nullable<int> SESSIONS { get; set; }
        public Nullable<int> ACTIVE { get; set; }
        public Nullable<int> ACTIVATED_USER_ID { get; set; }
        public Nullable<System.DateTime> ACTIVATED_DATE { get; set; }
        public Nullable<int> STATUSES_ID { get; set; }
        public Nullable<int> SIDE_BAR_STAT { get; set; }
        public Nullable<int> TREE_MODE { get; set; }
    
        public virtual USERS USERS { get; set; }
    }
}
