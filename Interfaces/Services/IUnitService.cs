
using DAL.MySqlDbContext;
using System.Linq.Expressions;

namespace Interfaces.Services
{
    public interface IUnitService
    {
        public Unit Add(Unit entity);
        public bool Delete(Unit entity);
        public void Update(Unit entity);
        public Unit GetById(int id);
        public Unit Get(Expression<Func<Unit, bool>> predicate = null);
        public List<Unit> GetList(Expression<Func<Unit, bool>> filter = null);
    }
}
