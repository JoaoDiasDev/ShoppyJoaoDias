using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Admin.Models;
using ShopJoaoDias.Extensions;

namespace ShopJoaoDias.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuth]
    public class BrandController : Controller
    {
        private IBrandBL _brandBL;

        public BrandController(IServiceProvider serviceProvider)
        {
            _brandBL = serviceProvider.GetRequiredService<IBrandBL>();
        }
        [HttpGet]
        public IActionResult Index()
        {
            var brandDO = _brandBL.GetList();
            return View(brandDO);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var brandDO = new BrandDO();
            return View(brandDO);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Create(BrandDO brandDO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    brandDO.CreatedAt = DateTime.Now;
                    brandDO.UpdatedAt = DateTime.Now;

                    if (!string.IsNullOrEmpty(brandDO.Slug))
                    {
                        var slug = Functions.FriendlyUrl(brandDO.Slug);
                        brandDO.Slug = slug;
                    }
                    else
                    {
                        var slug = Functions.FriendlyUrl(brandDO.Name);
                        brandDO.Slug = slug;
                    }

                    if (brandDO.Description == null)
                    {
                        var desc = "All products with best price from " + brandDO.Name;
                        brandDO.Description = desc;
                    }

                    if (brandDO.Title == null)
                    {
                        brandDO.Title = brandDO.Name;
                    }
                    var addBrand = _brandBL.Add(brandDO);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try it again!";
                    return View(brandDO);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong please try it again!";
                return View(brandDO);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var brandDO = _brandBL.GetById(id);
                return View(brandDO);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, BrandDO brandDO)
        {
            try
            {
                if (brandDO != null)
                {
                    brandDO.UpdatedAt = DateTime.Now;
                    var updatedBrand = _brandBL.Update(brandDO);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try it again!";
                    return View(brandDO);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong please try it again!";
                return View(brandDO);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var brandDO = _brandBL.GetById(id);
                return View(brandDO);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Delete(int id, BrandDO brandDO)
        {
            var brand = _brandBL.GetById(id);
            try
            {
                bool value = _brandBL.Delete(brand);
                if (value)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong pelase try it again!";
                    return View(brand);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong pelase try it again!";
                return View(brand);
            }
        }
    }
}
