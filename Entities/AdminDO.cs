using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class AdminDO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a username")]
        [MaxLength(15, ErrorMessage = "max 15 characters for username")]
        [MinLength(4, ErrorMessage = "min 4 characters for username")]
        [Display(Name = "Admin username")]
        [DataType(DataType.Text)]
        public string Username { get; set; } = null!;
        [Required(ErrorMessage = "Please enter a password")]
        [MaxLength(15, ErrorMessage = "max 15 characters for password")]
        [MinLength(4, ErrorMessage = "min 4 characters for password")]
        [Display(Name = "Admin password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Display(Name = "Authority")]
        public int? Authority { get; set; }
        [Display(Name = "Active")]
        public int? Confirmation { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        [MaxLength(15, ErrorMessage = "max 15 characters for name")]
        [MinLength(4, ErrorMessage = "min 4 characters for name")]
        [Display(Name = "Admin name")]
        [DataType(DataType.Text)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter a surname")]
        [MaxLength(15, ErrorMessage = "max 15 characters for surname")]
        [MinLength(4, ErrorMessage = "min 4 characters for surname")]
        [Display(Name = "Admin surname")]
        [DataType(DataType.Text)]
        public string? Surname { get; set; }
        [Required(ErrorMessage = "Please enter a valid email")]
        [MaxLength(25, ErrorMessage = "max 25 characters for email")]
        [MinLength(8, ErrorMessage = "min 10 characters for email")]
        [Display(Name = "Admin email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
