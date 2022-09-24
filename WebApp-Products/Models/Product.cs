using System;
using System.Collections.Generic;

namespace WebApp_Products.Models
{
    public partial class Product
    {
        public Product()
        {
            Categories = new HashSet<Category>();
        }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductNumberCode { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? StatusCode { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
