namespace Entities
{
    public class BankDO
    {
        public BankDO()
        {
            BankInstallments = new List<BankInstallmentDO>();
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

        public virtual List<BankInstallmentDO> BankInstallments { get; set; }
    }
}
