
using DAL.MySqlDbContext;
using System.Linq.Expressions;

namespace Interfaces.Services
{
    public interface IPageService
    {
        public Page Add(Page entity);
        public bool Delete(Page entity);
        public void Update(Page entity);
        public Page GetById(int id);
        public Page Get(Expression<Func<Page, bool>> predicate = null);
        public List<Page> GetList(Expression<Func<Page, bool>> filter = null);
    }
}
