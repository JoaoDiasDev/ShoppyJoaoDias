using Entities;
using System.Linq.Expressions;

namespace Interfaces.BL
{
    public interface IUnitBL
    {
        UnitDO Add(UnitDO model);
        UnitDO Update(UnitDO model);
        UnitDO GetById(int id);
        UnitDO Get(Expression<Func<UnitDO, bool>> predicate = null);
        List<UnitDO> GetList(Expression<Func<UnitDO, bool>> filter = null);
        bool Delete(UnitDO model);
    }
}
