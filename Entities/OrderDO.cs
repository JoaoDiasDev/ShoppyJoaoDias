namespace Entities
{
    public class OrderDO
    {
        public OrderDO()
        {
            Orderitems = new List<OrderitemDO>();
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

        public virtual AddressDO? DeliveryAddress { get; set; }
        public virtual AddressDO? InvoiceAddress { get; set; }
        public virtual PaymentDO Payment { get; set; } = null!;
        public virtual UserDO User { get; set; } = null!;
        public virtual List<OrderitemDO> Orderitems { get; set; }
    }
}
