using DAL.MySqlDbContext;
using System.Linq.Expressions;

namespace Interfaces.Services
{
    public interface ICategoryService
    {
        public Category Add(Category entity);
        public bool Delete(Category entity);
        public void Update(Category entity);
        public Category GetById(int id);
        public Category Get(Expression<Func<Category, bool>> predicate = null);
        public List<Category> GetList(Expression<Func<Category, bool>> filter = null);
    }
}
