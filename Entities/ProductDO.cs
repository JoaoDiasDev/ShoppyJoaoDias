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
        public string? Barcode { get; set; }
        public string Name { get; set; } = null!;
        public string? Code { get; set; }
        public float? Price { get; set; }
        public float? Discount { get; set; }
        public DateTime? Discountlastdate { get; set; }
        public int? Categoryid { get; set; }
        public int? Brandid { get; set; }
        public int? Returnable { get; set; }
        public string? Returnableday { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public string? Image { get; set; }
        public int? Stock { get; set; }
        public string? Pagetitle { get; set; }
        public string? Metadescription { get; set; }
        public string? Easyurl { get; set; }
        public int? Showcase { get; set; }
        public int? Homepage { get; set; }
        public int? Categorygold { get; set; }
        public int? Hit { get; set; }
        public int? Unitid { get; set; }

        public virtual BrandDO? Brand { get; set; }
        public virtual CategoryDO? Category { get; set; }
        public virtual UnitDO? Unit { get; set; }
        public virtual List<BasketDO> Baskets { get; set; }
        public virtual List<OrderitemDO> Orderitems { get; set; }
        public virtual List<ProductImageDO> ProductImages { get; set; }
        public virtual List<WishlistDO> Wishlists { get; set; }
    }
}
