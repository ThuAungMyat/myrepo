using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbRolePermission
    {
        public int ID { get; set; }
        public Nullable<int> RoleID { get; set; }
        public string RoleTitle { get; set; }
        public string PermissionRule { get; set; }
        public Nullable<bool> IsReadable { get; set; }
        public Nullable<bool> IsEditable { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
        public Nullable<int> PermissionID { get; set; }
        public Nullable<int> GroupID { get; set; }
        public string GroupName { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.Guid> UniqueID { get; set; }
        public Nullable<System.Guid> RoleGUID { get; set; }
        public Nullable<System.Guid> PermissionGUID { get; set; }
    }
}
