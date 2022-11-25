using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;

namespace ShopJoaoDias.ViewComponents
{
    public class FooterMenuComponent : ViewComponent
    {
        private IPageBL _pageBL;

        public FooterMenuComponent(IServiceProvider serviceProvider)
        {
            _pageBL = serviceProvider.GetRequiredService<IPageBL>();
        }

        public IViewComponentResult Invoke()
        {
            var pageList = _pageBL.GetList();
            return View(pageList);
        }
    }
}
