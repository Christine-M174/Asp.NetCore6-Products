using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public partial class User
    {
        public User()
        {
            ProductCreatedByNavigations = new HashSet<Product>();
            ProductModifiedByNavigations = new HashSet<Product>();
        }

        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Product> ProductCreatedByNavigations { get; set; }
        public virtual ICollection<Product> ProductModifiedByNavigations { get; set; }
    }
    //public class User
    //{

    //    [Key]
    //    public Guid UserId { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Password { get; set; }
    //    public string UserName { get; set; }
    //    public Guid RoleId { get; set; }

    //    [ForeignKey("RoleId")]
    //    public virtual Role role { get; set; }

    //}
}
