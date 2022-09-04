using System;
using System.Collections.Generic;

namespace DAL.MySqlDbContext
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
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

        public virtual ICollection<Product> Products { get; set; }
    }
}
