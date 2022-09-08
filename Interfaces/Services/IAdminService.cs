using DAL.MySqlDbContext;
using System.Linq.Expressions;

namespace Interfaces.Services
{
    public interface IAdminService
    {
        public Admin Add(Admin entity);
        public bool Delete(Admin entity);
        public void Update(Admin entity);
        public Admin GetById(int id);
        public Admin Get(Expression<Func<Admin, bool>> predicate = null);
        public List<Admin> GetList(Expression<Func<Admin, bool>> filter = null);

    }
}
