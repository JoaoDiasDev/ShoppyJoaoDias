using Entities;
using System.Linq.Expressions;

namespace Interfaces.BL
{
    public interface ICityBL
    {
        CityDO Add(CityDO model);
        CityDO Update(CityDO model);
        CityDO GetById(int id);
        CityDO Get(Expression<Func<CityDO, bool>> predicate = null);
        List<CityDO> GetList(Expression<Func<CityDO, bool>> filter = null);
        bool Delete(CityDO model);
    }
}
