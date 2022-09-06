namespace Entities
{
    public class BrandDO
    {
        public BrandDO()
        {
            Products = new List<ProductDO>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public int? Displayorder { get; set; }
        public string? Title { get; set; }
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual List<ProductDO> Products { get; set; }
    }
}
