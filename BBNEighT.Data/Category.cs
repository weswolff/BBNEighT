using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBNEighT.Data
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }

        //[ForeignKey(nameof(OwnerID))]
        //public Guid OwnerID { get; set; }
        //public virtual ApplicationUser OwnerGuid { get; set; }
    }
}
