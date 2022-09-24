using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
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



    //public class Product
    //{
    //    [Key]
    //    public Guid ProductId { get; set; }
    //    public string ProductName { get; set; }
    //    public string ProductNumberCode { get; set; }
    //    public Guid CreatedBy { get; set; }
    //    public Nullable<Guid> ModifiedBy { get; set; }
    //    public DateTime CreatedOn { get; set; }
    //    public DateTime ModifiedOn { get; set; }
    //    public Nullable<bool> StatusCode { get; set; }


    //    [ForeignKey("CreatedBy")]
    //    public virtual User Creator { get; set; }

    //    [ForeignKey("ModifiedBy")]
    //    public virtual User Modifier { get; set; }


    //}
}
