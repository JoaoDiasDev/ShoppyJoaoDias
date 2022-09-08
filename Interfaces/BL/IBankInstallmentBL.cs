using Entities;
using System.Linq.Expressions;

namespace Interfaces.BL
{
    public interface IBankInstallmentBL
    {
        BankInstallmentDO Add(BankInstallmentDO model);
        BankInstallmentDO Update(BankInstallmentDO model);
        BankInstallmentDO GetById(int id);
        BankInstallmentDO Get(Expression<Func<BankInstallmentDO, bool>> predicate = null);
        List<BankInstallmentDO> GetList(Expression<Func<BankInstallmentDO, bool>> filter = null);
        bool Delete(BankInstallmentDO model);
    }
}
