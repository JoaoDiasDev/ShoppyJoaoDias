using System;
using System.Collections.Generic;

namespace DAL.MySqlDbContext
{
    public partial class Product
    {
        public Product()
        {
            Baskets = new HashSet<Basket>();
            Orderitems = new HashSet<Orderitem>();
            ProductImages = new HashSet<ProductImage>();
            Wishlists = new HashSet<Wishlist>();
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

        public virtual Brand? Brand { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Unit? Unit { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<Orderitem> Orderitems { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
