
using DAL.MySqlDbContext;
using System.Linq.Expressions;

namespace Interfaces.Services
{
    public interface IProductService
    {
        public Product Add(Product entity);
        public bool Delete(Product entity);
        public void Update(Product entity);
        public Product GetById(int id);
        public Product Get(Expression<Func<Product, bool>> predicate = null);
        public List<Product> GetList(Expression<Func<Product, bool>> filter = null);
        public List<Product> GetProductPerPage(int categoryId, int page, bool isParentCategory);
    }
}
