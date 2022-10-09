using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class CityDO
    {
        public CityDO()
        {
            Addresses = new List<AddressDO>();
            Users = new List<UserDO>();
        }

        public int Id { get; set; }
        public int Provinceid { get; set; }
        [Required(ErrorMessage = "Please enter a city name")]
        [MaxLength(15, ErrorMessage = "max 15 characters for city name")]
        [MinLength(2, ErrorMessage = "min 2 characters for city name")]
        [Display(Name = "City Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;
        [Display(Name = "Slug Name")]
        [DataType(DataType.Text)]
        public string Slug { get; set; }
        [Display(Name = "Order")]
        [DataType(DataType.Text)]
        public int? Order { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ProvinceDO Province { get; set; } = null!;
        public virtual List<AddressDO> Addresses { get; set; }
        public virtual List<UserDO> Users { get; set; }
    }
}
