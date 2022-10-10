using DAL.MySqlDbContext;
using System.Linq.Expressions;

namespace Interfaces.Services
{
    public interface IProductImageService
    {
        public ProductImage Add(ProductImage entity);
        public bool Delete(ProductImage entity);
        public void Update(ProductImage entity);
        public ProductImage GetById(int id);
        public ProductImage Get(Expression<Func<ProductImage, bool>> predicate = null);
        public List<ProductImage> GetList(Expression<Func<ProductImage, bool>> filter = null);
    }
}
