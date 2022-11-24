using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public partial class UserDO
    {
        public UserDO()
        {
            Addresses = new List<AddressDO>();
            Baskets = new List<BasketDO>();
            Orderitems = new List<OrderitemDO>();
            Orders = new List<OrderDO>();
            Payments = new List<PaymentDO>();
            Resetpasswords = new List<ResetPasswordDO>();
            Wishlists = new List<WishlistDO>();
        }
        [JsonIgnore]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        [MaxLength(15, ErrorMessage = "max 15 characters for name")]
        [MinLength(4, ErrorMessage = "min 4 characters for name")]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter a surname")]
        [MaxLength(15, ErrorMessage = "max 15 characters for surname")]
        [MinLength(4, ErrorMessage = "min 4 characters for surname")]
        [Display(Name = "Surname")]
        [DataType(DataType.Text)]
        [JsonIgnore]
        public string? Surname { get; set; }
        [Required(ErrorMessage = "Please enter a email")]
        [MaxLength(55, ErrorMessage = "max 55 characters for email")]
        [MinLength(4, ErrorMessage = "min 4 characters for email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [JsonIgnore]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Please enter a password")]
        [MaxLength(15, ErrorMessage = "max 15 characters for password")]
        [MinLength(4, ErrorMessage = "min 4 characters for password")]
        [Display(Name = "Password")]
        [DataType(DataType.Text)]
        [JsonIgnore]
        public string Password { get; set; } = null!;
        [JsonIgnore]
        public int? Maillist { get; set; }
        [JsonIgnore]
        public DateOnly? Birthday { get; set; }
        [JsonIgnore]
        public int Gender { get; set; }
        [JsonIgnore]
        public string? Phone { get; set; }
        [JsonIgnore]
        public string? Address { get; set; }
        [JsonIgnore]
        public int? Country { get; set; }
        [JsonIgnore]
        public int? Cityid { get; set; }
        [JsonIgnore]
        public string? Citytext { get; set; }
        [JsonIgnore]
        public int? District { get; set; }
        [JsonIgnore]
        public string? Zipcode { get; set; }
        [JsonIgnore]
        public string? Valid { get; set; }
        [JsonIgnore]
        public int? Customertype { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }
        [JsonIgnore]
        public virtual CityDO? City { get; set; }
        [JsonIgnore]
        public virtual List<AddressDO> Addresses { get; set; }
        [JsonIgnore]
        public virtual List<BasketDO> Baskets { get; set; }
        [JsonIgnore]
        public virtual List<OrderitemDO> Orderitems { get; set; }
        [JsonIgnore]
        public virtual List<OrderDO> Orders { get; set; }
        [JsonIgnore]
        public virtual List<PaymentDO> Payments { get; set; }
        [JsonIgnore]
        public virtual List<ResetPasswordDO> Resetpasswords { get; set; }
        [JsonIgnore]
        public virtual List<WishlistDO> Wishlists { get; set; }
    }
}
