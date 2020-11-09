using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBNEighT.Models.Item
{
    public class ItemCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string ItemName { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public int RoomID { get; set; }
        [MaxLength(8000)]
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime AquiredDate { get; set; }
    }
}
