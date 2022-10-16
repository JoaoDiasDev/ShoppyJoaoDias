using Entities;
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

        public IActionResult Edit(int id)
        {
            var productDO = _productBL.GetById(id);
            var categories = _categoryBL.GetList().Where(w => w.Parentid == 0).ToList();
            var brands = _brandBL.GetList();
            var units = _unitBL.GetList();

            var model = new ProductViewModel
            {
                ProductDO = productDO,
                CategoryList = categories,
                BrandList = brands,
                UnitList = units
            };

            return View(model);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, ProductViewModel model)
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

                    var updateProduct = _productBL.Update(productDO);
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

        public IActionResult Delete(int id)
        {
            try
            {
                var productDO = _productBL.GetById(id);
                return View(productDO);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Delete(int id, BankDO productDO)
        {
            var product = _productBL.GetById(id);
            try
            {
                bool value = _productBL.Delete(product);
                if (value)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try it again!";
                    return View(product);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong please try it again!";
                return View(product);
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

        public IActionResult Image(int id)
        {
            var productDO = _productBL.GetById(id);
            if (productDO != null)
            {
                var productImageList = _productImageBL.GetList(x => x.Productid == id);
                var model = new ProductViewModel
                {
                    ProductDO = productDO,
                    ProductImageList = productImageList
                };

                return View(model);
            }
            else
            {
                return BadRequest("Something went wrong!");
            }
        }

        public async Task<IActionResult> MultipleUpload(int id, IFormFile file)
        {
            if (file.Length > 0)
            {
                var uploadHelpers = new UploadHelper(_hosting);
                var fileName = await uploadHelpers.Upload(file, "products/" + id);
                var productImage = new ProductImageDO
                {
                    Address = "/upload/products" + id + "/" + fileName,
                    Productid = id
                };

                var result = _productImageBL.Add(productImage);
                return Json(result);
            }
            else
            {
                return Ok();
            }
        }
    }
}
