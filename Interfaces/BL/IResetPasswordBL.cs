using System.Linq.Expressions;
using DAL.MySqlDbContext;
using Entities;

namespace Interfaces.BL
{
    public interface IResetPasswordBL
    {
        ResetPasswordDO Add(ResetPasswordDO model);
        ResetPasswordDO Update(ResetPasswordDO model);
        ResetPasswordDO GetById(int id);
        ResetPasswordDO Get(Expression<Func<ResetPassword, bool>> predicate = null);
        List<ResetPasswordDO> GetList(Expression<Func<ResetPasswordDO, bool>> filter = null);
        bool Delete(ResetPasswordDO model);
    }
}