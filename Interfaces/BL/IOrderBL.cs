using System.Linq.Expressions;
using DAL.MySqlDbContext;
using Entities;

namespace Interfaces.BL
{
    public interface IOrderBL
    {
        OrderDO Add(OrderDO model);
        OrderDO Update(OrderDO model);
        OrderDO GetById(int id);
        OrderDO Get(Expression<Func<Order, bool>> predicate = null);
        List<OrderDO> GetList(Expression<Func<OrderDO, bool>> filter = null);
        bool Delete(OrderDO model);
    }
}
