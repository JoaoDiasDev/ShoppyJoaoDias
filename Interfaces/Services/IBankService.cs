using DAL.MySqlDbContext;
using System.Linq.Expressions;

namespace Interfaces.Services
{
    public interface IBankService
    {
        public Bank Add(Bank entity);
        public bool Delete(Bank entity);
        public void Update(Bank entity);
        public Bank GetById(int id);
        public Bank Get(Expression<Func<Bank, bool>> predicate = null);
        public List<Bank> GetList(Expression<Func<Bank, bool>> filter = null);
    }
}
