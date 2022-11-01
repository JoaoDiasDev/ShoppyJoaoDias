using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Extensions;

namespace ShopJoaoDias.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private IAdminBL _adminBl;

        public LoginController(IServiceProvider serviceProvider)
        {
            _adminBl = serviceProvider.GetRequiredService<IAdminBL>();
        }


        public IActionResult Index()
        {
            var adminDO = new AdminDO();
            return View(adminDO);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(AdminDO adminDO)
        {
            if (adminDO != null && adminDO.Username.Length > 3 && adminDO.Password.Length > 3)
            {
                var loginDO = _adminBl.Login(adminDO);
                if (loginDO != null)
                {
                    var dbPassword = Encryption.Decrypt(loginDO.Password);
                    if (dbPassword == adminDO.Password)
                    {
                        var userIdCookie = new CookieOptions
                        {
                            Expires = DateTime.Now.AddDays(3)
                        };
                        Response.Cookies.Append("userid", loginDO.Id.ToString(), userIdCookie);
                        var usernameCookie = new CookieOptions
                        {
                            Expires = DateTime.Now.AddDays(3)
                        };
                        Response.Cookies.Append("username", loginDO.Username.ToString(), usernameCookie);
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ViewBag.Error = "Something went wrong please try it again.";
                        return View(adminDO);
                    }
                }
                else
                {
                    ViewBag.Error = "Something went wrong please try it again.";
                    return View(adminDO);
                }
            }
            else
            {
                ViewBag.Error = "Something went wrong please try it again.";
                return View(adminDO);
            }
        }


    }
}
