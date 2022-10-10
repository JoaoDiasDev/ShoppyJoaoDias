using Entities;
using System.Linq.Expressions;

namespace Interfaces.BL
{
    public interface IProductImageBL
    {
        ProductImageDO Add(ProductImageDO model);
        ProductImageDO Update(ProductImageDO model);
        ProductImageDO GetById(int id);
        ProductImageDO Get(Expression<Func<ProductImageDO, bool>> predicate = null);
        List<ProductImageDO> GetList(Expression<Func<ProductImageDO, bool>> filter = null);
        bool Delete(ProductImageDO model);
    }
}
