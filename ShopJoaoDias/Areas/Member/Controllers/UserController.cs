using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Member.Models;
using ShopJoaoDias.Extensions;
using System.ComponentModel.DataAnnotations;

namespace ShopJoaoDias.Areas.Member.Controllers
{
    [Area("Member")]
    [MemberAuth]
    public class UserController : Controller
    {
        private IUserBL _userBL;
        private ICityBL _cityBL;
        private IProvinceBL _provinceBL;

        public UserController(IServiceProvider serviceProvider)
        {
            _userBL = serviceProvider.GetRequiredService<IUserBL>();
            _cityBL = serviceProvider.GetRequiredService<ICityBL>();
            _provinceBL = serviceProvider.GetRequiredService<IProvinceBL>();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Index(IFormCollection form)
        {
            try
            {
                var username = form["username"].ToString();
                var password = form["password"].ToString();
                var user = _userBL.Get(x => x.Email == username);
                if (user != null)
                {
                    if (Encryption.Decrypt(user.Password) == password)
                    {
                        var userIdCookie = new CookieOptions();
                        userIdCookie.Expires = DateTime.Now.AddDays(3);
                        Response.Cookies.Append("shoppyUserId", user.Id.ToString(), userIdCookie);
                        var usernameCookie = new CookieOptions
                        {
                            Expires = DateTime.Now.AddDays(3),
                        };
                        Response.Cookies.Append("shoppyUsername", user.Name + " " + user.Surname, usernameCookie);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.error = "Please check your username and password";
                        return View();
                    }
                }
                else
                {
                    ViewBag.error = "Please check your username and password";
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Please check your username and password";
                return View();
            }
        }

        public IActionResult SignUp()
        {
            var provinces = _provinceBL.GetList();
            var user = new UserDO();
            var model = new UserViewModel
            {
                User = user,
                Provinces = provinces
            };
            return View(model);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult SignUp(IFormCollection form, UserViewModel model)
        {
            try
            {
                var user = model.User;
                if (user == null || form == null || form.Keys.Count == 0)
                {
                    return BadRequest("Something went wrong!");
                }
                else
                {
                    var attr = new EmailAddressAttribute();
                    user.CreatedAt = DateTime.Now;
                    user.UpdatedAt = DateTime.Now;
                    user.Password = Encryption.Encrypt(user.Password);
                    string day = form["day"];
                    string month = form["month"];
                    string year = form["year"];
                    user.Birthday = DateOnly.Parse(year + "-" + month + "-" + day);
                    user.Email = attr.IsValid(user.Email) ? user.Email : "";
                    if (user.Email == "")
                    {
                        return RedirectToAction("SignUp");
                    }
                    else
                    {
                        var userEmailControl = _userBL.Get(x => x.Email == user.Email);
                        if (userEmailControl != null)
                        {
                            ViewBag.error = "this email is already taken";
                            return View(model);
                        }
                    }

                    var addedUser = _userBL.Add(user);
                    if (addedUser != null)
                    {
                        var userIdCookie = new CookieOptions();
                        userIdCookie.Expires = DateTime.Now.AddDays(3);
                        Response.Cookies.Append("shoppyUserId", addedUser.Id.ToString(), userIdCookie);
                        var usernameCookie = new CookieOptions
                        {
                            Expires = DateTime.Now.AddDays(3)
                        };
                        Response.Cookies.Append("shoppyUsername", addedUser.Name + " " + addedUser.Surname, usernameCookie);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.error = "something went wrong";
                        return View(model);
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.error = "something went wrong";
                return View(model);
            }
        }

        public IActionResult City(int id)
        {
            var cityDOs = _cityBL.GetList(x => x.Provinceid == id);
            return Json(cityDOs);
        }
    }
}
