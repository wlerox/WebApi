using System;
using System.Collections.Generic;

namespace UserInfo.Entities.Model
{
    public class Role
    {
        public int RoleId { get; set; }
        public String RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
