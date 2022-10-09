using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public partial class ProvinceDO
    {
        public ProvinceDO()
        {
            Cities = new List<CityDO>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a province")]
        [MaxLength(25, ErrorMessage = "Max 25 char for province")]
        [MinLength(2, ErrorMessage = "Min 2 char for province")]
        [Display(Name = "Province Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;
        [Display(Name = "Order")]
        [DataType(DataType.Text)]
        public int? Order { get; set; }

        public virtual List<CityDO> Cities { get; set; }
    }
}
