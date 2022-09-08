using DAL.MySqlDbContext;
using System.Linq.Expressions;

namespace Interfaces.Services
{
    public interface ICityService
    {
        public City Add(City entity);
        public bool Delete(City entity);
        public void Update(City entity);
        public City GetById(int id);
        public City Get(Expression<Func<City, bool>> predicate = null);
        public List<City> GetList(Expression<Func<City, bool>> filter = null);
    }
}
