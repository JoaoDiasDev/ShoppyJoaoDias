
using System.Linq.Expressions;
using DAL.MySqlDbContext;

namespace Interfaces.Services
{
    public interface IResetPasswordService
    {
        public ResetPassword Add(ResetPassword entity);
        public bool Delete(ResetPassword entity);
        public void Update(ResetPassword entity);
        public ResetPassword GetById(int id);
        public ResetPassword Get(Expression<Func<ResetPassword, bool>> predicate = null);
        public List<ResetPassword> GetList(Expression<Func<ResetPassword, bool>> filter = null);
    }
}
