using Entities;
using System.Linq.Expressions;

namespace Interfaces.BL
{
    public interface IBankBL
    {
        BankDO Add(BankDO model);
        BankDO Update(BankDO model);
        BankDO GetById(int id);
        BankDO Get(Expression<Func<BankDO, bool>> predicate = null);
        List<BankDO> GetList(Expression<Func<BankDO, bool>> filter = null);
        bool Delete(BankDO model);
    }
}
