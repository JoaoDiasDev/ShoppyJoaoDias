using System;
using System.Collections.Generic;

namespace DAL.MySqlDbContext
{
    public partial class Shipping
    {
        public Shipping()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Note { get; set; }
        public string? Logo { get; set; }
        public decimal Desiprice { get; set; }
        public int Status { get; set; }
        public int Order { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
