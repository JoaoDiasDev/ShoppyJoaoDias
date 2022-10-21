using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Models;

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
            var categories = _categoryBL.GetList();
            var products = _productBL.GetList();
            var brands = _brandBL.GetList();

            var model = new HomeViewModel
            {
                BrandList = brands,
                ProductList = products,
                CategoryList = categories
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
