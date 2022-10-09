using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class BrandDO
    {
        public BrandDO()
        {
            Products = new List<ProductDO>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a brand name")]
        [MaxLength(25, ErrorMessage = "max 25 char for brand name")]
        [MinLength(2, ErrorMessage = "min 2 char for brand name")]
        [Display(Name = "Brand Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;
        [MaxLength(25, ErrorMessage = "max 25 char for slug name")]
        [MinLength(2, ErrorMessage = "min 2 char for slug name")]
        [Display(Name = "Slug Name")]
        [DataType(DataType.Text)]
        public string Slug { get; set; } = null!;
        [Display(Name = "Display Order")]
        [DataType(DataType.Text)]
        public int? Displayorder { get; set; }
        [Display(Name = "Title")]
        [DataType(DataType.Text)]
        public string? Title { get; set; }
        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual List<ProductDO> Products { get; set; }
    }
}
