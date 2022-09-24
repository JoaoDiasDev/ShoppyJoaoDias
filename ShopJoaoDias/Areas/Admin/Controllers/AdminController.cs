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
    }
}
