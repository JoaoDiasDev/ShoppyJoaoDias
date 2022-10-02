using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Admin.Models;
using ShopJoaoDias.Extensions;

namespace ShopJoaoDias.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuth]
    public class AdminController : Controller
    {
        private IAdminBL _adminBL;

        public AdminController(IServiceProvider serviceProvider)
        {
            _adminBL = serviceProvider.GetRequiredService<IAdminBL>();
        }

        public IActionResult Index()
        {
            var adminList = _adminBL.GetList();
            return View(adminList);
        }

        public IActionResult Create()
        {
            var adminDO = new AdminDO();
            return View(adminDO);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Create(AdminDO adminDO)
        {
            try
            {
                var usernameCheck = _adminBL.Login(adminDO);
                if (usernameCheck != null)
                {
                    ViewBag.error = "This username is already taken! Use another one";
                    return View(adminDO);
                }
                adminDO.CreatedAt = DateTime.Now;
                adminDO.UpdatedAt = DateTime.Now;
                adminDO.Authority = 5;
                adminDO.Password = Encryption.Encrypt(adminDO.Password);
                var addAdminDO = _adminBL.Add(adminDO);
                if (addAdminDO != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please check it";
                    return View(adminDO);
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View(adminDO);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var result = _adminBL.GetById(id);
                ViewBag.password = Encryption.Decrypt(result.Password);
                return View(result);
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, AdminDO adminDO)
        {
            try
            {
                adminDO.UpdatedAt = DateTime.Now;
                adminDO.Password = Encryption.Encrypt(adminDO.Password);
                var resultDO = _adminBL.Update(adminDO);

                if (resultDO != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong, please check it!";
                    return View(adminDO);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong, please check it!";
                return View(adminDO);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _adminBL.GetById(id);
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Delete(int id, AdminDO adminDO)
        {
            var result = _adminBL.GetById(id);
            try
            {
                bool value = _adminBL.Delete(result);
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
