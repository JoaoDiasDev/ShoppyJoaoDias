
using DAL.MySqlDbContext;
using System.Linq.Expressions;

namespace Interfaces.Services
{
    public interface ISettingService
    {
        public Setting Add(Setting entity);
        public bool Delete(Setting entity);
        public void Update(Setting entity);
        public Setting GetById(int id);
        public Setting Get(Expression<Func<Setting, bool>> predicate = null);
        public List<Setting> GetList(Expression<Func<Setting, bool>> filter = null);
    }
}
