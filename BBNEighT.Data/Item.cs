using BBNEighT.Data.RoomData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBNEighT.Data
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        [Required]
        public string ItemName { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey(nameof(Room))]
        public int RoomID { get; set; }
        public virtual Room Room { get; set; }

        public Guid OwnerID { get; set; }

        public string Description { get; set; }
        [Required]
        public decimal Value { get; set; }
        [Display(Name = "Date Aquired")]
        public DateTime AquiredDate { get; set; }
        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Date Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }


    }
}
