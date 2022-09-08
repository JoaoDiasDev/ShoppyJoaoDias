using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services
{
    public class UserService : IUserService
    {
        public User Add(User entity)
        {
            User? user = null;
            using (var context = new DatabaseContext())
            {
                var addUser = context.Entry(entity);
                addUser.State = EntityState.Added;
                context.SaveChanges();
                user = entity;
            }
            return user;
        }

        public bool Delete(User entity)
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

        public void Update(User entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateUser = context.Entry(entity);
                updateUser.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public User GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<User>()
                    .Where(user => user.Id == id)
                    .Include(iCity => iCity.City)
                    .Include(iAddresses => iAddresses.Addresses)
                    .Include(iBaskets => iBaskets.Baskets)
                    .Include(iOrderitems => iOrderitems.Orderitems)
                    .Include(iOrders => iOrders.Orders)
                    .Include(iPayments => iPayments.Payments)
                    .Include(iResetpasswords => iResetpasswords.Resetpasswords)
                    .Include(iWishlists => iWishlists.Wishlists)
                    .FirstOrDefault();
            }
        }

        public User Get(Expression<Func<User, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<User>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<User> GetList(Expression<Func<User, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<User>().ToList()
                    : context.Set<User>().Where(filter).ToList();
            }
        }
    }
}
