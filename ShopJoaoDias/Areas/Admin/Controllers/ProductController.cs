using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Admin.Models;

namespace ShopJoaoDias.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuth]
    public class ProductController : Controller
    {
        private IProductBL _productBL;
        private ICategoryBL _categoryBL;
        private IBrandBL _brandBL;
        private IProductImageBL _productImageBL;
        private IWebHostEnvironment _hosting;

        public ProductController(IServiceProvider serviceProvider)
        {
            _productBL = serviceProvider.GetRequiredService<IProductBL>();
            _categoryBL = serviceProvider.GetRequiredService<ICategoryBL>();
            _brandBL = serviceProvider.GetRequiredService<IBrandBL>();
            _productImageBL = serviceProvider.GetRequiredService<IProductImageBL>();
            _hosting = serviceProvider.GetRequiredService<IWebHostEnvironment>();
        }

        public IActionResult Index()
        {
            var productDOList = _productBL.GetList();
            var model = new ProductViewModel
            {
                ProductList = productDOList
            };


            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoryBL.GetList().Where(w => w.Parentid == 0).ToList();
            var brands = _brandBL.GetList();

            var model = new ProductViewModel
            {
                CategoryList = categories,
                BrandList = brands
            };

            return View(model);
        }

        public IActionResult SubCategories(int id)
        {
            var categoryList = _categoryBL.GetList(w => w.Parentid == id).ToList();
            return Json(categoryList);
        }
    }
}
