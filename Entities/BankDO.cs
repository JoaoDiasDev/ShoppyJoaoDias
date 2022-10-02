using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class BankDO
    {
        public BankDO()
        {
            BankInstallments = new List<BankInstallmentDO>();
        }

        public int Id { get; set; }
        [Display(Name = "Upload Image")]
        [DataType(DataType.Text)]
        public string? Logo { get; set; }
        [Required(ErrorMessage = "Please enter a bank name")]
        [MaxLength(25, ErrorMessage = "max 25 char for bank name")]
        [MinLength(2, ErrorMessage = "min 2 char for bank name")]
        [Display(Name = "Bank Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;
        [MaxLength(500, ErrorMessage = "max 500 char for bank description")]
        [Display(Name = "Description Name")]
        [DataType(DataType.Text)]
        public string Description { get; set; } = null!;
        [Display(Name = "Installment")]
        [DataType(DataType.Text)]
        public int? Installment { get; set; }
        [Display(Name = "Order")]
        [DataType(DataType.Text)]
        public int? Order { get; set; }
        [Display(Name = "Iban")]
        [DataType(DataType.Text)]
        public string Iban { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual List<BankInstallmentDO> BankInstallments { get; set; }
    }
}
