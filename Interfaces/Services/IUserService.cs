
using DAL.MySqlDbContext;
using System.Linq.Expressions;

namespace Interfaces.Services
{
    public interface IUserService
    {
        public User Add(User entity);
        public bool Delete(User entity);
        public void Update(User entity);
        public User GetById(int id);
        public User Get(Expression<Func<User, bool>> predicate = null);
        public List<User> GetList(Expression<Func<User, bool>> filter = null);
    }
}
