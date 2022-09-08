using Entities;
using System.Linq.Expressions;

namespace Interfaces.BL
{
    public interface IAdminBL
    {
        AdminDO Add(AdminDO model);
        AdminDO Update(AdminDO model);
        AdminDO GetById(int id);
        AdminDO Get(Expression<Func<AdminDO, bool>> predicate = null);
        List<AdminDO> GetList(Expression<Func<AdminDO, bool>> filter = null);
        bool Delete(AdminDO model);
        AdminDO Login(AdminDO model);
    }
}
