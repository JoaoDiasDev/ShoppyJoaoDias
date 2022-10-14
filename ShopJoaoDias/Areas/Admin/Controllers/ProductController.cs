using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Admin.Models;
using ShopJoaoDias.Extensions;
using ShopJoaoDias.Helpers;

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
        private IUnitBL _unitBL;
        private IWebHostEnvironment _hosting;

        public ProductController(IServiceProvider serviceProvider)
        {
            _productBL = serviceProvider.GetRequiredService<IProductBL>();
            _categoryBL = serviceProvider.GetRequiredService<ICategoryBL>();
            _brandBL = serviceProvider.GetRequiredService<IBrandBL>();
            _productImageBL = serviceProvider.GetRequiredService<IProductImageBL>();
            _unitBL = serviceProvider.GetRequiredService<IUnitBL>();
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
            var units = _unitBL.GetList();

            var model = new ProductViewModel
            {
                CategoryList = categories,
                BrandList = brands,
                UnitList = units
            };

            return View(model);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Create(ProductViewModel model)
        {
            try
            {
                var productDO = model.ProductDO;
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(productDO.Easyurl))
                    {
                        var slug = Functions.FriendlyUrl(productDO.Easyurl);
                        productDO.Easyurl = slug;
                    }
                    else
                    {
                        var slug = Functions.FriendlyUrl(productDO.Name);
                        productDO.Easyurl = slug;
                    }

                    if (productDO.Description == null)
                    {
                        var desc = "All products with best price from " + productDO.Name;
                        productDO.Description = desc;
                    }

                    if (productDO.Pagetitle == null)
                    {
                        productDO.Pagetitle = productDO.Name + "page title for";
                    }

                    if (productDO.Metadescription == null)
                    {
                        productDO.Metadescription = productDO.Name + "page meta description for";
                    }

                    var addProduct = _productBL.Add(productDO);
                    return RedirectToAction("Index");
                }
                else
                {
                    var errors = ModelState.Values.Where(x => x.Errors.Count > 0)
                        .SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage)
                        .ToList();

                    foreach (var item in errors)
                    {
                        ViewBag.error += "* " + item.ToString() + "<br>";
                    }
                    var categories = _categoryBL.GetList().Where(w => w.Parentid == 0).ToList();
                    var brands = _brandBL.GetList();
                    var units = _unitBL.GetList();
                    model.CategoryList = categories;
                    model.BrandList = brands;
                    model.UnitList = units;
                    return View(model);
                }
            }
            catch (Exception ex)
            {

                var categories = _categoryBL.GetList().Where(w => w.Parentid == 0).ToList();
                var brands = _brandBL.GetList();
                var units = _unitBL.GetList();
                model.CategoryList = categories;
                model.BrandList = brands;
                model.UnitList = units;
                ViewBag.error += ex.Message;
                return View(model);
            }
        }

        public IActionResult SubCategories(int id)
        {
            var categoryList = _categoryBL.GetList(w => w.Parentid == id).ToList();
            return Json(categoryList);
        }

        public async Task<IActionResult> SingleUpload(IFormFile file)
        {
            if (file.Length > 0)
            {
                var uploadHelpers = new UploadHelper(_hosting);
                var fileName = await uploadHelpers.Upload(file, "products/0");
                return Ok("/upload/products/0" + fileName);
            }
            else
            {
                return Ok();
            }
        }
    }
}
