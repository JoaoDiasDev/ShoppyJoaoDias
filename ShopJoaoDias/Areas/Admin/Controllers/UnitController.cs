using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Admin.Models;

namespace ShopJoaoDias.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuth]
    public class UnitController : Controller
    {
        private IUnitBL _unitBL;

        public UnitController(IServiceProvider serviceProvider)
        {
            _unitBL = serviceProvider.GetRequiredService<IUnitBL>();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var unitList = _unitBL.GetList();
            return View(unitList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                var unitDO = new UnitDO();
                return View(unitDO);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Create(UnitDO unitDO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var addUnit = _unitBL.Add(unitDO);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try it again!";
                    return View(unitDO);
                }

            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong please try it again!";
                return View(unitDO);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var result = _unitBL.GetById(id);
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, UnitDO unitDO)
        {
            try
            {
                if (unitDO != null)
                {
                    var updateUnit = _unitBL.Update(unitDO);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try it again!";
                    return View(unitDO);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong please try it again!";
                return View(unitDO);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _unitBL.GetById(id);
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Delete(int id, UnitDO unitDO)
        {
            var result = _unitBL.GetById(id);
            try
            {
                bool value = _unitBL.Delete(result);

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
