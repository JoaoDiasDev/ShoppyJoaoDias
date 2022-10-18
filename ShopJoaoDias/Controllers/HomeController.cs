using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;

namespace ShopJoaoDias.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryBL _categoryBL;
        private IProductBL _productBL;
        private IBrandBL _brandBL;

        public HomeController(IServiceProvider serviceProvider)
        {
            _categoryBL = serviceProvider.GetRequiredService<ICategoryBL>();
            _productBL = serviceProvider.GetRequiredService<IProductBL>();
            _brandBL = serviceProvider.GetRequiredService<IBrandBL>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
