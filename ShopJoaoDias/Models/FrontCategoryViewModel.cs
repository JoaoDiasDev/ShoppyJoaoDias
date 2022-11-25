using Entities;

namespace ShopJoaoDias.Models
{
    public class FrontCategoryViewModel
    {
        public CategoryDO CategoryDO { get; set; } = new CategoryDO();
        public List<CategoryDO> CategoryList { get; set; } = new List<CategoryDO>();
        public CategoryProduct CategoryProduct { get; set; } = new CategoryProduct();
        public List<BrandDO> BrandList { get; set; } = new List<BrandDO>();
        public int Page { get; set; } = 1;
        public string SearchQuery { get; set; } = "";
    }
}
