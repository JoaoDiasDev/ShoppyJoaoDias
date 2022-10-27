using System.ComponentModel.DataAnnotations;

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
            Resetpasswords = new List<ResetpasswordDO>();
            Wishlists = new List<WishlistDO>();
        }

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
        public string? Surname { get; set; }
        [Required(ErrorMessage = "Please enter a email")]
        [MaxLength(55, ErrorMessage = "max 55 characters for email")]
        [MinLength(4, ErrorMessage = "min 4 characters for email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Please enter a password")]
        [MaxLength(15, ErrorMessage = "max 15 characters for password")]
        [MinLength(4, ErrorMessage = "min 4 characters for password")]
        [Display(Name = "Password")]
        [DataType(DataType.Text)]
        public string Password { get; set; } = null!;
        public int? Maillist { get; set; }
        public DateOnly? Birthday { get; set; }
        public int Gender { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? Country { get; set; }
        public int? Cityid { get; set; }
        public string? Citytext { get; set; }
        public int? District { get; set; }
        public string? Zipcode { get; set; }
        public string? Valid { get; set; }
        public int? Customertype { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual CityDO? City { get; set; }
        public virtual List<AddressDO> Addresses { get; set; }
        public virtual List<BasketDO> Baskets { get; set; }
        public virtual List<OrderitemDO> Orderitems { get; set; }
        public virtual List<OrderDO> Orders { get; set; }
        public virtual List<PaymentDO> Payments { get; set; }
        public virtual List<ResetpasswordDO> Resetpasswords { get; set; }
        public virtual List<WishlistDO> Wishlists { get; set; }
    }
}
