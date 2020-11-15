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

        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; } = DateTimeOffset.UtcNow;

        [Display(Name = "Date Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
