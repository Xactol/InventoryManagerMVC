using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
        public string? ItemType { get; set; }
        public DateTime? ItemExpiryDate { get; set; }
        public decimal? ItemPrice { get; set; }
        public double? ItemWeight { get; set; }
        public string? ItemOwnerEmail { get; set; }
    }
}
