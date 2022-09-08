using Entities;
using System.Linq.Expressions;

namespace Interfaces.BL
{
    public interface IOrderitemBL
    {
        OrderitemDO Add(OrderitemDO model);
        OrderitemDO Update(OrderitemDO model);
        OrderitemDO GetById(int id);
        OrderitemDO Get(Expression<Func<OrderitemDO, bool>> predicate = null);
        List<OrderitemDO> GetList(Expression<Func<OrderitemDO, bool>> filter = null);
        bool Delete(OrderitemDO model);
    }
}
