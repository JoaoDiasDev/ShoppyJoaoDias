using System.Linq.Expressions;
using DAL.MySqlDbContext;
using Entities;

namespace Interfaces.BL
{
    public interface IProductBL
    {
        ProductDO Add(ProductDO model);
        ProductDO Update(ProductDO model);
        bool Delete(ProductDO model);
        ProductDO GetById(int id);
        ProductDO Get(Expression<Func<Product, bool>> predicate = null);
        List<ProductDO> GetList(Expression<Func<Product, bool>> filter = null);
        List<ProductDO> GetProductPerPage(int categoryId, int page, bool isParentCategory);
    }
}
