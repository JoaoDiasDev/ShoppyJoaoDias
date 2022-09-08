using DAL.MySqlDbContext;
using System.Linq.Expressions;

namespace Interfaces.Services
{
    public interface IAddressService
    {
        public Address Add(Address entity);
        public bool Delete(Address entity);
        public void Update(Address entity);
        public Address GetById(int id);
        public Address Get(Expression<Func<Address, bool>> predicate = null);
        public List<Address> GetList(Expression<Func<Address, bool>> filter = null);
    }
}
