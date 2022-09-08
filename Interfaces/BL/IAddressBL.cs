using Entities;
using System.Linq.Expressions;

namespace Interfaces.BL
{
    public interface IAddressBL
    {
        AddressDO Add(AddressDO model);
        AddressDO Update(AddressDO model);
        AddressDO GetById(int id);
        AddressDO Get(Expression<Func<AddressDO, bool>> predicate = null);
        List<AddressDO> GetList(Expression<Func<AddressDO, bool>> filter = null);
        bool Delete(AddressDO model);
    }
}
