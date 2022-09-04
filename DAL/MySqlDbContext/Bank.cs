using System;
using System.Collections.Generic;

namespace DAL.MySqlDbContext
{
    public partial class Bank
    {
        public Bank()
        {
            BankInstallments = new HashSet<BankInstallment>();
        }

        public int Id { get; set; }
        public string? Logo { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? Installment { get; set; }
        public int? Order { get; set; }
        public string Iban { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<BankInstallment> BankInstallments { get; set; }
    }
}
