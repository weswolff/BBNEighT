using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBNEighT.Models.Owner
{
    public class OwnerDetail
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset DateCreated { get; set; }
    }
}
