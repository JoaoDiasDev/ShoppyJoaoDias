namespace Entities
{
    public class CategoryDO
    {
        public CategoryDO()
        {
            Products = new List<ProductDO>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? Parentid { get; set; }
        public int? Status { get; set; }
        public string? Pagetitle { get; set; }
        public string? Metadescription { get; set; }
        public string? Slug { get; set; }
        public int? Displayorder { get; set; }
        public int? Includeintopmenu { get; set; }
        public int? Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? Homecategory { get; set; }
        public string? Image { get; set; }

        public virtual List<ProductDO> Products { get; set; }
    }
}
