using Entities;

namespace ShopJoaoDias.Models
{
    public class FrontProductViewModel
    {
        public ProductDO ProductDO { get; set; } = new ProductDO();
        public List<ProductDO> ProductList { get; set; } = new List<ProductDO>();
        public CategoryDO ParentCategory { get; set; } = new CategoryDO();
    }
}
