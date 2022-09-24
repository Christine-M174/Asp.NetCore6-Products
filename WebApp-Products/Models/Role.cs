using System;
using System.Collections.Generic;

namespace WebApp_Products.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public Guid RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
