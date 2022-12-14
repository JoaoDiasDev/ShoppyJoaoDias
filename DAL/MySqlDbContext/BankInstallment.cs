using System;
using System.Collections.Generic;

namespace DAL.MySqlDbContext
{
    public partial class BankInstallment
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Bankid { get; set; }
        public int Installmentcount { get; set; }
        public decimal Rate { get; set; }
        public int Order { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Bank Bank { get; set; } = null!;
    }
}
