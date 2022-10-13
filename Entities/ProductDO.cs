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
        [DataType(DataType.Text)]
        public float? Price { get; set; }
        [Display(Name = "Discount")]
        [DataType(DataType.Text)]
        public float? Discount { get; set; }
        [Display(Name = "Discount Last Date")]
        [DataType(DataType.Text)]
        public DateTime? Discountlastdate { get; set; }
        [Display(Name = "Category")]
        [DataType(DataType.Text)]
        public int? Categoryid { get; set; }
        [Display(Name = "Brand")]
        [DataType(DataType.Text)]
        public int? Brandid { get; set; }
        [Display(Name = "Returnable")]
        [DataType(DataType.Text)]
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
        [DataType(DataType.Text)]
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
        [DataType(DataType.Text)]
        public int? Showcase { get; set; }
        [Display(Name = "Homepage")]
        [DataType(DataType.Text)]
        public int? Homepage { get; set; }
        [Display(Name = "Category Gold")]
        [DataType(DataType.Text)]
        public int? Categorygold { get; set; }
        [Display(Name = "Hit")]
        [DataType(DataType.Text)]
        public int? Hit { get; set; }
        [Display(Name = "Unitid")]
        [DataType(DataType.Text)]
        public int? Unitid { get; set; }
        [Display(Name = "Brand")]
        [DataType(DataType.Text)]
        public virtual BrandDO? Brand { get; set; }
        [Display(Name = "Category")]
        [DataType(DataType.Text)]
        public virtual CategoryDO? Category { get; set; }
        public virtual UnitDO? Unit { get; set; }
        public virtual List<BasketDO> Baskets { get; set; }
        public virtual List<OrderitemDO> Orderitems { get; set; }
        public virtual List<ProductImageDO> ProductImages { get; set; }
        public virtual List<WishlistDO> Wishlists { get; set; }
    }
}
