using System;
using System.Collections.Generic;

namespace DAL.MySqlDbContext
{
    public partial class Order
    {
        public Order()
        {
            Orderitems = new HashSet<Orderitem>();
        }

        public int Id { get; set; }
        public int Userid { get; set; }
        public string Orderid { get; set; } = null!;
        public string Basketid { get; set; } = null!;
        public int Paymentid { get; set; }
        public int Status { get; set; }
        public int PaymentStatus { get; set; }
        public DateTime? ShippingDate { get; set; }
        public string? ShippingChaseNo { get; set; }
        public string? Description { get; set; }
        public decimal? Paid { get; set; }
        public decimal? Amount { get; set; }
        public string? Paypalid { get; set; }
        public int? CurrencyUnit { get; set; }
        public string Guid { get; set; } = null!;
        public int? InvoiceAddressId { get; set; }
        public int? DeliveryAddressId { get; set; }
        public int Installment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Address? DeliveryAddress { get; set; }
        public virtual Address? InvoiceAddress { get; set; }
        public virtual Payment Payment { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Orderitem> Orderitems { get; set; }
    }
}
