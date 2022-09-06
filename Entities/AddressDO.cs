namespace Entities
{
    public class AddressDO
    {
        public AddressDO()
        {
            OrderDeliveryAddresses = new List<OrderDO>();
            OrderInvoiceAddresses = new List<OrderDO>();
        }

        public int Id { get; set; }
        public int Userid { get; set; }
        public string? Addresname { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Address1 { get; set; } = null!;
        public string? Zipcode { get; set; }
        public int? Country { get; set; }
        public int Cityid { get; set; }
        public string? Phone { get; set; }
        public int? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual CityDO City { get; set; } = null!;
        public virtual UserDO User { get; set; } = null!;
        public virtual List<OrderDO> OrderDeliveryAddresses { get; set; }
        public virtual List<OrderDO> OrderInvoiceAddresses { get; set; }
    }
}
