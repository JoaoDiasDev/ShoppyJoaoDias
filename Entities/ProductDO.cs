using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public partial class ProductDO
    {
        public ProductDO()
        {
            Baskets = new List<BasketDO>();
            Orderitems = new List<OrderitemDO>();
            ProductImages = new List<ProductImageDO>();
            Wishlists = new List<WishlistDO>();
        }

        public int Id { get; set; }
        [Display(Name = "Barcode")]
        [DataType(DataType.Text)]
        public string? Barcode { get; set; }
        [Required(ErrorMessage = "Please enter a product name")]
        [MaxLength(25, ErrorMessage = "max 25 char for product name")]
        [MinLength(2, ErrorMessage = "min 2 char for product name")]
        [Display(Name = "Product Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;
        [Display(Name = "Code")]
        [DataType(DataType.Text)]
        public string? Code { get; set; }
        [Display(Name = "Price")]
        public float? Price { get; set; }
        [Display(Name = "Discount")]
        public float? Discount { get; set; }
        [Display(Name = "Discount Last Date")]
        public DateTime? Discountlastdate { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please enter a category name")]
        public int? Categoryid { get; set; }
        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Please enter a brand name")]
        public int? Brandid { get; set; }
        [Display(Name = "Returnable")]
        public int? Returnable { get; set; }
        [Display(Name = "Returnable Delay")]
        [DataType(DataType.Text)]
        public string? Returnableday { get; set; }
        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        public string? Description { get; set; }
        [Display(Name = "Status")]
        [DataType(DataType.Text)]
        public int? Status { get; set; }
        public string? Image { get; set; }
        [Display(Name = "Stock")]
        public int? Stock { get; set; }
        [Display(Name = "Page Title")]
        [DataType(DataType.Text)]
        public string? Pagetitle { get; set; }
        [Display(Name = "Meta Description")]
        [DataType(DataType.Text)]
        public string? Metadescription { get; set; }
        [Display(Name = "Easy URL")]
        [DataType(DataType.Text)]
        public string? Easyurl { get; set; }
        [Display(Name = "Showcase")]
        public int? Showcase { get; set; }
        [Display(Name = "Homepage")]
        public int? Homepage { get; set; }
        [Display(Name = "Category Gold")]
        public int? Categorygold { get; set; }
        [Display(Name = "Hit")]
        public int? Hit { get; set; }
        [Display(Name = "Unitid")]
        public int? Unitid { get; set; }
        [Display(Name = "Brand")]
        public virtual BrandDO? Brand { get; set; }
        public virtual CategoryDO? Category { get; set; }
        public virtual UnitDO? Unit { get; set; }
        public virtual List<BasketDO> Baskets { get; set; }
        public virtual List<OrderitemDO> Orderitems { get; set; }
        public virtual List<ProductImageDO> ProductImages { get; set; }
        public virtual List<WishlistDO> Wishlists { get; set; }
    }
}
