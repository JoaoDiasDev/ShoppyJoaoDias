using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services
{
    public class WishlistService : IWishlistService
    {
        public Wishlist Add(Wishlist entity)
        {
            Wishlist? wishlist = null;
            using (var context = new DatabaseContext())
            {
                var addWishlist = context.Entry(entity);
                addWishlist.State = EntityState.Added;
                context.SaveChanges();
                wishlist = entity;
            }
            return wishlist;
        }

        public bool Delete(Wishlist entity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var deleteEntity = context.Entry(entity);
                    deleteEntity.State = EntityState.Deleted;
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Update(Wishlist entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateWishlist = context.Entry(entity);
                updateWishlist.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Wishlist GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Wishlist>()
                    .Where(wishlist => wishlist.Id == id)
                    .Include(iProduct => iProduct.Product)
                    .Include(iUser => iUser.User)
                    .FirstOrDefault();
            }
        }

        public Wishlist Get(Expression<Func<Wishlist, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Wishlist>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Wishlist> GetList(Expression<Func<Wishlist, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Wishlist>().ToList()
                    : context.Set<Wishlist>().Where(filter).ToList();
            }
        }
    }
}
