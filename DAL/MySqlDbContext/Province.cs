using System;
using System.Collections.Generic;

namespace DAL.MySqlDbContext
{
    public partial class Province
    {
        public Province()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Order { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
