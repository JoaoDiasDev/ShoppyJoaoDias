using DAL.MySqlDbContext;
using Entities;
using System.Linq.Expressions;

namespace Interfaces.BL
{
    public interface IBasketBL
    {
        BasketDO Add(BasketDO model);
        BasketDO Update(BasketDO model);
        BasketDO GetById(int id);
        BasketDO Get(Expression<Func<Basket, bool>> predicate = null);
        List<BasketDO> GetList(Expression<Func<BasketDO, bool>> filter = null);
        bool Delete(BasketDO model);
        bool DeleteAll(int userId);
        bool DeleteID(int basketId);
    }
}
