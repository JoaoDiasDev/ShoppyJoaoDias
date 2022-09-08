using Entities;
using System.Linq.Expressions;

namespace Interfaces.BL
{
    public interface IWishlistBL
    {
        WishlistDO Add(WishlistDO model);
        WishlistDO Update(WishlistDO model);
        WishlistDO GetById(int id);
        WishlistDO Get(Expression<Func<WishlistDO, bool>> predicate = null);
        List<WishlistDO> GetList(Expression<Func<WishlistDO, bool>> filter = null);
        bool Delete(WishlistDO model);
    }
}
