using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
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

    //public  class Category
    //{
    //    public Guid CategoryId { get; set; }
    //    public string CategoryName { get; set; }
    //    public Guid? CreatedBy { get; set; }
    //    public Guid? ModifiedBy { get; set; }
    //    public DateTime? CreatedOn { get; set; }
    //    public DateTime? ModifiedOn { get; set; }
    //    public bool? StatusCode { get; set; }
    //    public Guid? ProductId { get; set; }
    //    public string Subcategory { get; set; }

    //    public virtual Product Product { get; set; }
    //}
}