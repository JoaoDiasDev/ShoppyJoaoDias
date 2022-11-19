using System.Linq.Expressions;

using DAL.MySqlDbContext;

using Entities;

namespace Interfaces.BL
{
    public interface IAddressBL
    {
        AddressDO Add(AddressDO model);
        AddressDO Update(AddressDO model);
        AddressDO GetById(int id);
        AddressDO Get(Expression<Func<Address, bool>> predicate = null);
        List<AddressDO> GetList(Expression<Func<AddressDO, bool>> filter = null);
        bool Delete(AddressDO model);
    }
}
