using System;
using System.Collections.Generic;

namespace DAL.MySqlDbContext
{
    public partial class Payment
    {
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? Guid { get; set; }
        public int Userid { get; set; }
        public int? Type { get; set; }
        public string? Email { get; set; }
        public string? CreditCard { get; set; }
        public string? Lastdate { get; set; }
        public string? Ccsecurity { get; set; }
        public string? Name { get; set; }
        public int? Shippingid { get; set; }
        public int? Bankid { get; set; }
        public int Paymentstatus { get; set; }
        public decimal? Totalprice { get; set; }
        public int Status { get; set; }
        public decimal Productprice { get; set; }
        public decimal Shippingprice { get; set; }
        public string Token { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Shipping? Shipping { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
