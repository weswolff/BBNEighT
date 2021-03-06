﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBNEighT.Models.Item
{
    public class ItemListItem
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int CategoryID { get; set; }
        public int RoomID { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime AquiredDate { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}

