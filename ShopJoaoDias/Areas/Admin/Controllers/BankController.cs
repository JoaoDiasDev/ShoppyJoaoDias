using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Admin.Models;
using ShopJoaoDias.Helpers;

namespace ShopJoaoDias.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuth]
    public class BankController : Controller
    {
        private IBankBL _bankBL;
        private IWebHostEnvironment _hosting;

        public BankController(IServiceProvider serviceProvider)
        {
            _bankBL = serviceProvider.GetRequiredService<IBankBL>();
            _hosting = serviceProvider.GetRequiredService<IWebHostEnvironment>();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var bankList = _bankBL.GetList();
            return View(bankList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var bankDO = new BankDO();
            return View(bankDO);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Create(int id, BankDO bankDO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bankDO.CreatedAt = DateTime.Now;
                    bankDO.UpdatedAt = DateTime.Now;
                    if (string.IsNullOrEmpty(bankDO.Description))
                    {
                        bankDO.Description = "this description for " + bankDO.Name;
                    }
                    var addbank = _bankBL.Add(bankDO);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try it again!";
                    return View(bankDO);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong please try it again!";
                return View(bankDO);
            }
        }

        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file.Length > 0)
            {
                var uploadHelper = new UploadHelper(_hosting);
                string fileName = await uploadHelper.Upload(file, "banks");
                return Json(fileName);
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var bankdDO = _bankBL.GetById(id);
                return View(bankdDO);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, BankDO bankDO)
        {
            try
            {
                if (bankDO != null)
                {
                    var updateBank = _bankBL.Update(bankDO);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try it again!";
                    return View(bankDO);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong please try it again!";
                return View(bankDO);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var bankDO = _bankBL.GetById(id);
                return View(bankDO);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Delete(int id, BankDO bankDO)
        {
            var bank = _bankBL.GetById(id);
            try
            {
                bool value = _bankBL.Delete(bank);
                if (value)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try it again!";
                    return View(bank);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong please try it again!";
                return View(bank);
            }
        }
    }
}
