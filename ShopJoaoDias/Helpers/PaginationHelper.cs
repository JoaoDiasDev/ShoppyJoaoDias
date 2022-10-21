using Entities;
using ShopJoaoDias.Models;

namespace ShopJoaoDias.Helpers
{
    public class PaginationHelper
    {
        public CategoryProduct CategoryProduct(int totalProduct, int page, CategoryDO category, List<ProductDO> productDOs, int perPage = 12, int sort = 1)
        {
            var categoryProduct = new CategoryProduct();
            return categoryProduct;
        }
    }
}
