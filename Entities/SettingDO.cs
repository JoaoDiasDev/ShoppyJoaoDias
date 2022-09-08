using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class SettingDO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Keywords { get; set; }
        public string? Description { get; set; }
        public string? Analytics { get; set; }
        public int? Homeproductcount { get; set; }
        public int? Categoryproduct { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public decimal? Freeshippingprice { get; set; }
    }
}
