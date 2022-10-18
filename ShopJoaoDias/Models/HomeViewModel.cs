using Entities;

namespace ShopJoaoDias.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            CategoryList = new List<CategoryDO>();
            ProductList = new List<ProductDO>();
            BrandList = new List<BrandDO>();
        }
        public List<CategoryDO> CategoryList { get; set; }
        public List<ProductDO> ProductList { get; set; }
        public List<BrandDO> BrandList { get; set; }
    }
}
