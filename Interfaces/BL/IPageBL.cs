using System.Linq.Expressions;
using DAL.MySqlDbContext;
using Entities;

namespace Interfaces.BL
{
    public interface IPageBL
    {
        PageDO Add(PageDO model);
        PageDO Update(PageDO model);
        PageDO GetById(int id);
        PageDO Get(Expression<Func<Page, bool>> predicate = null);
        List<PageDO> GetList(Expression<Func<PageDO, bool>> filter = null);
        bool Delete(PageDO model);
    }
}
