using System;
using System.Collections.Generic;

namespace DAL.MySqlDbContext
{
    public partial class Unit
    {
        public Unit()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Shortname { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
