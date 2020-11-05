using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBNEighT.Data.RoomData
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field." )]
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
    }
}
