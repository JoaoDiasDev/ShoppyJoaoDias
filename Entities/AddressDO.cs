using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [Required(ErrorMessage = "Please enter a address name")]
        [MaxLength(25, ErrorMessage = "max 25 characters for address name")]
        [MinLength(2, ErrorMessage = "min 2 characters for address name")]
        [Display(Name = "Address Name")]
        [DataType(DataType.Text)]
        public string? Addresname { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        [MaxLength(25, ErrorMessage = "max 25 characters for name")]
        [MinLength(2, ErrorMessage = "min 2 characters for name")]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Please enter a address surname")]
        [MaxLength(25, ErrorMessage = "max 25 characters for address surname")]
        [MinLength(2, ErrorMessage = "min 2 characters for address surname")]
        [Display(Name = "Surname")]
        [DataType(DataType.Text)]
        public string Surname { get; set; } = null!;
        [Required(ErrorMessage = "Please enter a address")]
        [MaxLength(255, ErrorMessage = "max 25 characters for address")]
        [MinLength(2, ErrorMessage = "min 2 characters for address")]
        [Display(Name = "Address")]
        [DataType(DataType.Text)]
        public string Address1 { get; set; } = null!;
        public string? Zipcode { get; set; }
        [Required(ErrorMessage = "Please enter a country")]
        public int? Country { get; set; }
        [Required(ErrorMessage = "Please enter a city")]
        public int Cityid { get; set; }
        public string? Phone { get; set; }
        public int? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public virtual CityDO City { get; set; } = null!;
        [JsonIgnore]
        public virtual UserDO User { get; set; } = null!;
        [JsonIgnore]
        public virtual List<OrderDO> OrderDeliveryAddresses { get; set; }
        [JsonIgnore]
        public virtual List<OrderDO> OrderInvoiceAddresses { get; set; }
    }
}
