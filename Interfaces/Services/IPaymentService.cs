using DAL.MySqlDbContext;
using System.Linq.Expressions;

namespace Interfaces.Services
{
    public interface IPaymentService
    {
        public Payment Add(Payment entity);
        public bool Delete(Payment entity);
        public void Update(Payment entity);
        public Payment GetById(int id);
        public Payment Get(Expression<Func<Payment, bool>> predicate = null);
        public List<Payment> GetList(Expression<Func<Payment, bool>> filter = null);
    }
}
