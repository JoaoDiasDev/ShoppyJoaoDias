using Entities;
using System.Linq.Expressions;

namespace Interfaces.BL
{
    public interface IBrandBL
    {
        BrandDO Add(BrandDO model);
        BrandDO Update(BrandDO model);
        BrandDO GetById(int id);
        BrandDO Get(Expression<Func<BrandDO, bool>> predicate = null);
        List<BrandDO> GetList(Expression<Func<BrandDO, bool>> filter = null);
        bool Delete(BrandDO model);
    }
}
