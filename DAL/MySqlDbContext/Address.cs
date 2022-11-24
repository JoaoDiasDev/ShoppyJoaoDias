using System.Text.Json.Serialization;

namespace DAL.MySqlDbContext
{
    public partial class Address
    {
        public Address()
        {
            OrderDeliveryAddresses = new HashSet<Order>();
            OrderInvoiceAddresses = new HashSet<Order>();
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
        [JsonIgnore]

        public virtual City City { get; set; } = null!;
        [JsonIgnore]
        public virtual User User { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Order> OrderDeliveryAddresses { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> OrderInvoiceAddresses { get; set; }
    }
}
