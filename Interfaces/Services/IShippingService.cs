
using DAL.MySqlDbContext;
using System.Linq.Expressions;

namespace Interfaces.Services
{
    public interface IShippingService
    {
        public Shipping Add(Shipping entity);
        public bool Delete(Shipping entity);
        public void Update(Shipping entity);
        public Shipping GetById(int id);
        public Shipping Get(Expression<Func<Shipping, bool>> predicate = null);
        public List<Shipping> GetList(Expression<Func<Shipping, bool>> filter = null);
    }
}
