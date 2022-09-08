
using DAL.MySqlDbContext;
using System.Linq.Expressions;

namespace Interfaces.Services
{
    public interface IWishlistService
    {
        public Wishlist Add(Wishlist entity);
        public bool Delete(Wishlist entity);
        public void Update(Wishlist entity);
        public Wishlist GetById(int id);
        public Wishlist Get(Expression<Func<Wishlist, bool>> predicate = null);
        public List<Wishlist> GetList(Expression<Func<Wishlist, bool>> filter = null);
    }
}
