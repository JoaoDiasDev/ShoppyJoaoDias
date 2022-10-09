using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Entities
{
    public partial class UnitDO
    {
        public UnitDO()
        {
            Products = new List<ProductDO>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a unit name")]
        [MaxLength(15, ErrorMessage = "max 15 characters for unit name")]
        [MinLength(2, ErrorMessage = "min 2 characters for unit name")]
        [Display(Name = "Unit Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;
        [Display(Name = "ShortName")]
        [DataType(DataType.Text)]
        public string? Shortname { get; set; }

        public virtual List<ProductDO> Products { get; set; }
    }
}
