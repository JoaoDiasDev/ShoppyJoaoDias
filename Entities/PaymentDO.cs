namespace Entities
{
    public partial class PaymentDO
    {
        public PaymentDO()
        {
            Orders = new List<OrderDO>();
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

        public virtual ShippingDO? Shipping { get; set; }
        public virtual UserDO User { get; set; } = null!;
        public virtual ICollection<OrderDO> Orders { get; set; }
    }
}
