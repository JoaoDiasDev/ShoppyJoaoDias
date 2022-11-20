using System.Linq.Expressions;
using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class PaymentService : IPaymentService
    {
        public Payment Add(Payment entity)
        {
            Payment? payment = null;
            using (var context = new DatabaseContext())
            {
                var addPayment = context.Entry(entity);
                addPayment.State = EntityState.Added;
                context.SaveChanges();
                payment = entity;
            }
            return payment;
        }

        public bool Delete(Payment entity)
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

        public void Update(Payment entity)
        {
            using (var context = new DatabaseContext())
            {
                var updatePayment = context.Entry(entity);
                updatePayment.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Payment GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Payment>()
                    .Where(payment => payment.Id == id)
                    .Include(iShipping => iShipping.Shipping)
                    .Include(iUser => iUser.User)
                    .Include(iOrders => iOrders.Orders)
                    .FirstOrDefault();
            }
        }

        public Payment Get(Expression<Func<Payment, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Payment>()
                    .Include(x => x.Orders)
                    .ThenInclude(x => x.Orderitems)
                    .ThenInclude(x => x.Product)
                    .Include(x => x.User)
                    .Include(x => x.Shipping)
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Payment> GetList(Expression<Func<Payment, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Payment>().Include(x => x.Orders).ThenInclude(x => x.Orderitems).ThenInclude(x => x.Product).Include(x => x.User).Include(x => x.Shipping).ToList()
                    : context.Set<Payment>().Include(x => x.Orders).ThenInclude(x => x.Orderitems).ThenInclude(x => x.Product).Include(x => x.User).Include(x => x.Shipping).Where(filter).ToList();
            }
        }
    }
}
