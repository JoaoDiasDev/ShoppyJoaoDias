using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class CategoryDO
    {
        public CategoryDO()
        {
            Products = new List<ProductDO>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a category name")]
        [MaxLength(25, ErrorMessage = "max 25 char for category name")]
        [MinLength(4, ErrorMessage = "min 4 char for category name")]
        [Display(Name = "Category Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;
        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        public string? Description { get; set; }
        public int? Parentid { get; set; }
        [Display(Name = "Status")]
        [DataType(DataType.Text)]
        public int? Status { get; set; }
        [Display(Name = "Page Title")]
        [DataType(DataType.Text)]
        public string? Pagetitle { get; set; }
        [Display(Name = "Meta Description")]
        [DataType(DataType.Text)]
        public string? Metadescription { get; set; }
        [Display(Name = "Slug")]
        [DataType(DataType.Text)]
        public string? Slug { get; set; }
        [Display(Name = "Display Order")]
        [DataType(DataType.Text)]
        public int? Displayorder { get; set; }
        [Display(Name = "Include In Top Menu")]
        public int? IncludeInTopMenu { get; set; }
        [Display(Name = "Deleted")]
        public int? Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Display(Name = "Home Category")]
        public int? Homecategory { get; set; }
        [Display(Name = "Image")]
        public string? Image { get; set; }

        public virtual List<ProductDO> Products { get; set; }
    }
}
