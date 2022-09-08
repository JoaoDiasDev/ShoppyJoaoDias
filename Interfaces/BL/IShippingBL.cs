using Entities;
using System.Linq.Expressions;

namespace Interfaces.BL
{
    public interface IShippingBL
    {
        ShippingDO Add(ShippingDO model);
        ShippingDO Update(ShippingDO model);
        ShippingDO GetById(int id);
        ShippingDO Get(Expression<Func<ShippingDO, bool>> predicate = null);
        List<ShippingDO> GetList(Expression<Func<ShippingDO, bool>> filter = null);
        bool Delete(ShippingDO model);
    }
}
