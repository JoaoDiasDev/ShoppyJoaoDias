using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services
{
    public class ShippingService : IShippingService
    {
        public Shipping Add(Shipping entity)
        {
            Shipping? shipping = null;
            using (var context = new DatabaseContext())
            {
                var addShipping = context.Entry(entity);
                addShipping.State = EntityState.Added;
                context.SaveChanges();
                shipping = entity;
            }
            return shipping;
        }

        public bool Delete(Shipping entity)
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

        public void Update(Shipping entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateShipping = context.Entry(entity);
                updateShipping.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Shipping GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Shipping>()
                    .Where(shipping => shipping.Id == id)
                    .Include(iPayments => iPayments.Payments)
                    .FirstOrDefault();
            }
        }

        public Shipping Get(Expression<Func<Shipping, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Shipping>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Shipping> GetList(Expression<Func<Shipping, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Shipping>().ToList()
                    : context.Set<Shipping>().Where(filter).ToList();
            }
        }
    }
}
