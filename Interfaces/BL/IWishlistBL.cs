using System.Linq.Expressions;
using DAL.MySqlDbContext;
using Entities;

namespace Interfaces.BL
{
    public interface IWishlistBL
    {
        WishlistDO Add(WishlistDO model);
        WishlistDO Update(WishlistDO model);
        WishlistDO GetById(int id);
        WishlistDO Get(Expression<Func<Wishlist, bool>> predicate = null);
        List<WishlistDO> GetList(Expression<Func<WishlistDO, bool>> filter = null);
        bool Delete(WishlistDO model);
    }
}
