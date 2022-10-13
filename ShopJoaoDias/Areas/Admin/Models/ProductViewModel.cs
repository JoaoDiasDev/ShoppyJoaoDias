using Entities;

namespace ShopJoaoDias.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public ProductDO ProductDO { get; set; }
        public List<ProductDO> ProductList { get; set; }
        public List<CategoryDO> CategoryList { get; set; }
        public List<BrandDO> BrandList { get; set; }
        public List<ProductImageDO> ProductImageDOList { get; set; }
    }
}
