using Entities;
using System.Linq.Expressions;

namespace Interfaces.BL
{
    public interface IProductBL
    {
        ProductDO Add(ProductDO model);
        ProductDO Update(ProductDO model);
        bool Delete(ProductDO model);
        ProductDO GetById(int id);
        ProductDO Get(Expression<Func<ProductDO, bool>> predicate = null);
        List<ProductDO> GetList(Expression<Func<ProductDO, bool>> filter = null);
        List<ProductDO> GetProductPerPage(int categoryId, int page, bool isParentCategory);
    }
}
