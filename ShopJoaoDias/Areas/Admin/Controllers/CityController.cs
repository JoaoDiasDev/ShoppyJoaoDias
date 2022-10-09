using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Admin.Models;
using ShopJoaoDias.Extensions;

namespace ShopJoaoDias.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuth]
    public class CityController : Controller
    {
        private ICityBL _cityBL;
        private IProvinceBL _provinceBL;

        public CityController(IServiceProvider serviceProvider)
        {
            _cityBL = serviceProvider.GetRequiredService<ICityBL>();
            _provinceBL = serviceProvider.GetRequiredService<IProvinceBL>();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cityListDO = _cityBL.GetList();

            var model = new CityViewModel
            {
                CityDOList = cityListDO,
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                var provinceList = _provinceBL.GetList();
                var model = new CityViewModel
                {
                    ProvinceDOList = provinceList
                };

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Create(CityViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cityDO = model.CityDO;
                    cityDO.CreatedAt = DateTime.Now;
                    cityDO.UpdatedAt = DateTime.Now;

                    if (!(string.IsNullOrEmpty(cityDO.Slug)))
                    {
                        var slug = Functions.FriendlyUrl(cityDO.Slug);
                        cityDO.Slug = slug;
                    }
                    else
                    {
                        var slug = Functions.FriendlyUrl(cityDO.Name);
                        cityDO.Slug = slug;
                    }

                    var addCity = _cityBL.Add(cityDO);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try it again!";
                    return View(model);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong please try it again!";
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var cityDO = _cityBL.GetById(id);
                var provinceDOList = _provinceBL.GetList();
                var model = new CityViewModel
                {
                    CityDO = cityDO,
                    ProvinceDOList = provinceDOList
                };

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, CityViewModel model)
        {
            try
            {
                var cityDO = model.CityDO;
                if (ModelState.IsValid)
                {
                    cityDO.UpdatedAt = DateTime.Now;
                    if (!string.IsNullOrEmpty(cityDO.Slug))
                    {
                        var slug = Functions.FriendlyUrl(cityDO.Slug);
                        cityDO.Slug = slug;
                    }
                    else
                    {
                        var slug = Functions.FriendlyUrl(cityDO.Name);
                        cityDO.Slug = slug;
                    }

                    var result = _cityBL.Add(cityDO);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try it again!";
                    return View(model);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong please try it again!";
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _cityBL.GetById(id);
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Delete(int id, CityDO cityDO)
        {
            var result = _cityBL.GetById(id);
            try
            {
                bool value = _cityBL.Delete(result);
                if (value)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try it again!";
                    return View(result);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong please try it again!";
                return View(result);
            }
        }
    }
}
