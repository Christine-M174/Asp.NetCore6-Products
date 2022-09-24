using System;
using System.Collections.Generic;

namespace WebApp_Products.Models
{
    public partial class Category
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? StatusCode { get; set; }
        public Guid? ProductId { get; set; }
        public string Subcategory { get; set; }

        public virtual Product Product { get; set; }
    }
}
