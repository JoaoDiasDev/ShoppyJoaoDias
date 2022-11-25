using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;

namespace ShopJoaoDias.Controllers
{
    public class PageController : Controller
    {
        private IPageBL _pageBL;

        public PageController(IServiceProvider serviceProvider)
        {
            _pageBL = serviceProvider.GetRequiredService<IPageBL>();
        }

        [Route("/Page/{slug}")]
        public IActionResult Index(string slug)
        {
            var page = _pageBL.Get(x => x.Slug == slug);
            return View(page);
        }
    }
}
