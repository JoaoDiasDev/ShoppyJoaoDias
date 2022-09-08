using DAL.MySqlDbContext;
using System.Linq.Expressions;

namespace Interfaces.Services
{
    public interface IOrderitemService
    {
        public Orderitem Add(Orderitem entity);
        public bool Delete(Orderitem entity);
        public void Update(Orderitem entity);
        public Orderitem GetById(int id);
        public Orderitem Get(Expression<Func<Orderitem, bool>> predicate = null);
        public List<Orderitem> GetList(Expression<Func<Orderitem, bool>> filter = null);
    }
}
