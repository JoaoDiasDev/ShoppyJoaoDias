using DAL.MySqlDbContext;
using Entities;
using System.Linq.Expressions;

namespace Interfaces.BL
{
    public interface ICategoryBL
    {
        CategoryDO Add(CategoryDO model);
        CategoryDO Update(CategoryDO model);
        CategoryDO GetById(int id);
        CategoryDO Get(Expression<Func<Category, bool>> predicate = null);
        List<CategoryDO> GetList(Expression<Func<CategoryDO, bool>> filter = null);
        bool Delete(CategoryDO model);
    }
}
