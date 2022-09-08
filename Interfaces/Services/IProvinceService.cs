
using DAL.MySqlDbContext;
using System.Linq.Expressions;

namespace Interfaces.Services
{
    public interface IProvinceService
    {
        public Province Add(Province entity);
        public bool Delete(Province entity);
        public void Update(Province entity);
        public Province GetById(int id);
        public Province Get(Expression<Func<Province, bool>> predicate = null);
        public List<Province> GetList(Expression<Func<Province, bool>> filter = null);
    }
}
