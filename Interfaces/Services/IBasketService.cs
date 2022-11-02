using DAL.MySqlDbContext;
using System.Linq.Expressions;

namespace Interfaces.Services
{
    public interface IBasketService
    {
        public Basket Add(Basket entity);
        public bool Delete(Basket entity);
        public bool DeleteID(int basketId);
        public void Update(Basket entity);
        public Basket GetById(int id);
        public Basket Get(Expression<Func<Basket, bool>> predicate = null);
        public List<Basket> GetList(Expression<Func<Basket, bool>> filter = null);
        bool DeleteAll(int userId);
    }
}
