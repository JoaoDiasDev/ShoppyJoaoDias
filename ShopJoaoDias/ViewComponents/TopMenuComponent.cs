using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;

namespace ShopJoaoDias.ViewComponents
{
    public class TopMenuComponent : ViewComponent
    {
        private ICategoryBL _categoryBL;

        public TopMenuComponent(IServiceProvider serviceProvider)
        {
            _categoryBL = serviceProvider.GetRequiredService<ICategoryBL>();
        }

        public IViewComponentResult Invoke()
        {
            var categoryList = _categoryBL.GetList(x => x.IncludeInTopMenu == 1).ToList();
            return View(categoryList);
        }
    }
}
