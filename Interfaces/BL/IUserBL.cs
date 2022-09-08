using Entities;
using System.Linq.Expressions;

namespace Interfaces.BL
{
    public interface IUserBL
    {
        UserDO Add(UserDO model);
        UserDO Update(UserDO model);
        UserDO GetById(int id);
        UserDO Get(Expression<Func<UserDO, bool>> predicate = null);
        List<UserDO> GetList(Expression<Func<UserDO, bool>> filter = null);
        bool Delete(UserDO model);
    }
}
