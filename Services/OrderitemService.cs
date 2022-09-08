using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services
{
    public class OrderitemService : IOrderitemService
    {
        public Orderitem Add(Orderitem entity)
        {
            Orderitem? orderItem = null;
            using (var context = new DatabaseContext())
            {
                var addOrderitem = context.Entry(entity);
                addOrderitem.State = EntityState.Added;
                context.SaveChanges();
                orderItem = entity;
            }
            return orderItem;
        }

        public bool Delete(Orderitem entity)
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

        public void Update(Orderitem entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateOrderitem = context.Entry(entity);
                updateOrderitem.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Orderitem GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Orderitem>()
                    .Where(orderItem => orderItem.Id == id)
                    .Include(iOrder => iOrder.Order)
                    .Include(iProduct => iProduct.Product)
                    .FirstOrDefault();
            }
        }

        public Orderitem Get(Expression<Func<Orderitem, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Orderitem>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Orderitem> GetList(Expression<Func<Orderitem, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Orderitem>().ToList()
                    : context.Set<Orderitem>().Where(filter).ToList();
            }
        }
    }
}
