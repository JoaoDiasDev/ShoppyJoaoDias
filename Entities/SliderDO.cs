using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public partial class SliderDO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter an Title")]
        [MaxLength(255, ErrorMessage = "max 255 char for Title")]
        [MinLength(2, ErrorMessage = "min 2 char for Title")]
        [Display(Name = "Title")]
        [DataType(DataType.Text)]
        public string Title1 { get; set; } = null!;
        [Required(ErrorMessage = "Please enter an Subtitle")]
        [MaxLength(255, ErrorMessage = "max 255 char for Subtitle")]
        [MinLength(2, ErrorMessage = "min 2 char for Subtitle")]
        [Display(Name = "Subtitle")]
        [DataType(DataType.Text)]
        public string Title2 { get; set; } = null!;
        [Required(ErrorMessage = "Please enter an Description")]
        [MaxLength(2000, ErrorMessage = "max 2000 char for Description")]
        [MinLength(2, ErrorMessage = "min 2 char for Description")]
        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "Please enter an Url")]
        [MaxLength(1000, ErrorMessage = "max 1000 char for Url")]
        [MinLength(2, ErrorMessage = "min 2 char for Url")]
        [Display(Name = "Url")]
        [DataType(DataType.Url)]
        public string Url { get; set; } = null!;
        [Required(ErrorMessage = "Please enter an Image")]
        [MaxLength(255, ErrorMessage = "max 255 char for Image")]
        [MinLength(2, ErrorMessage = "min 2 char for Image")]
        [Display(Name = "Image")]
        [DataType(DataType.Text)]
        public string Image { get; set; } = null!;
    }
}
