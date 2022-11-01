using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services
{
    public class BasketService : IBasketService
    {
        public Basket Add(Basket entity)
        {
            Basket? basket = null;
            using (var context = new DatabaseContext())
            {
                var addBasket = context.Entry(entity);
                addBasket.State = EntityState.Added;
                context.SaveChanges();
                basket = entity;
            }
            return basket;
        }

        public bool Delete(Basket entity)
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

        public bool DeleteAll(int userId)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var baskets = context.Baskets.Where(x => x.Userid == userId);
                    context.Baskets.RemoveRange(baskets);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Update(Basket entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateBasket = context.Entry(entity);
                updateBasket.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Basket GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Basket>()
                    .Where(basket => basket.Id == id)
                    .Include(iProduct => iProduct.Product)
                    .Include(iUser => iUser.User)
                    .FirstOrDefault();
            }
        }

        public Basket Get(Expression<Func<Basket, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Basket>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Basket> GetList(Expression<Func<Basket, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Basket>().Include(x => x.Product).ThenInclude(x => x.Category).ToList()
                    : context.Set<Basket>().Include(x => x.Product).ThenInclude(x => x.Category).Where(filter).ToList();
            }
        }
    }
}
