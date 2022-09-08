using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services
{
    public class OrderService : IOrderService
    {
        public Order Add(Order entity)
        {
            Order? order = null;
            using (var context = new DatabaseContext())
            {
                var addOrder = context.Entry(entity);
                addOrder.State = EntityState.Added;
                context.SaveChanges();
                order = entity;
            }
            return order;
        }

        public bool Delete(Order entity)
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

        public void Update(Order entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateOrder = context.Entry(entity);
                updateOrder.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Order GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Order>()
                    .Where(order => order.Id == id)
                    .Include(iDeliveryAddress => iDeliveryAddress.DeliveryAddress)
                    .Include(iInvoiceAddress => iInvoiceAddress.InvoiceAddress)
                    .Include(iUser => iUser.User)
                    .Include(iPayment => iPayment.Payment)
                    .Include(iOrderItems => iOrderItems.Orderitems)
                    .FirstOrDefault();
            }
        }

        public Order Get(Expression<Func<Order, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Order>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Order> GetList(Expression<Func<Order, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Order>().ToList()
                    : context.Set<Order>().Where(filter).ToList();
            }
        }
    }
}
