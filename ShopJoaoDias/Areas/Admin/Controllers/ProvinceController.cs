using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Admin.Models;

namespace ShopJoaoDias.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuth]
    public class ProvinceController : Controller
    {
        private IProvinceBL _provinceBL;

        public ProvinceController(IServiceProvider serviceProvider)
        {
            _provinceBL = serviceProvider.GetRequiredService<IProvinceBL>();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var provinceList = _provinceBL.GetList();
            return View(provinceList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                var provinceDO = new ProvinceDO();
                return View(provinceDO);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Create(ProvinceDO provinceDO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var addProvince = _provinceBL.Add(provinceDO);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try it again!";
                    return View(provinceDO);
                }

            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong please try it again!";
                return View(provinceDO);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var result = _provinceBL.GetById(id);
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, ProvinceDO provinceDO)
        {
            try
            {
                if (provinceDO != null)
                {
                    var updateProvince = _provinceBL.Update(provinceDO);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try it again!";
                    return View(provinceDO);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong please try it again!";
                return View(provinceDO);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _provinceBL.GetById(id);
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Delete(int id, ProvinceDO provinceDO)
        {
            var result = _provinceBL.GetById(id);
            try
            {
                bool value = _provinceBL.Delete(result);

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
                return RedirectToAction("Index");
            }
        }
    }
}
