using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class PageDO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a Title")]
        [MaxLength(255, ErrorMessage = "max 255 characters for Title")]
        [MinLength(2, ErrorMessage = "min 2 characters for Title")]
        [Display(Name = "Title")]
        [DataType(DataType.Text)]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "Please enter a Slug")]
        [MaxLength(255, ErrorMessage = "max 255 characters for Slug")]
        [MinLength(2, ErrorMessage = "min 2 characters for Slug")]
        [Display(Name = "Slug")]
        [DataType(DataType.Text)]
        public string? Slug { get; set; }
        [Required(ErrorMessage = "Please enter a Text")]
        [MinLength(2, ErrorMessage = "min 2 characters for Text")]
        [Display(Name = "Text")]
        public string? Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
