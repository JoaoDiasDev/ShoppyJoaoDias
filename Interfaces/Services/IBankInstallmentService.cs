using DAL.MySqlDbContext;
using System.Linq.Expressions;

namespace Interfaces.Services
{
    public interface IBankInstallmentService
    {
        public BankInstallment Add(BankInstallment entity);
        public bool Delete(BankInstallment entity);
        public void Update(BankInstallment entity);
        public BankInstallment GetById(int id);
        public BankInstallment Get(Expression<Func<BankInstallment, bool>> predicate = null);
        public List<BankInstallment> GetList(Expression<Func<BankInstallment, bool>> filter = null);
    }
}
