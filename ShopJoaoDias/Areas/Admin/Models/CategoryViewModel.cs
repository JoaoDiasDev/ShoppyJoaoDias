using Entities;

namespace ShopJoaoDias.Areas.Admin.Models
{
    public class CategoryViewModel
    {
        public CategoryDO CategoryDO { get; set; } = new CategoryDO();
        public List<CategoryDO> CategoryDOList { get; set; } = new List<CategoryDO>();
    }
}
