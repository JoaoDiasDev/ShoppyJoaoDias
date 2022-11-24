using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Member.Models;
using ShopJoaoDias.Extensions;

namespace ShopJoaoDias.Areas.Member.Controllers
{
    [Area("Member")]
    public class UserController : Controller
    {
        private IUserBL _userBL;
        private ICityBL _cityBL;
        private IProvinceBL _provinceBL;
        private IResetPasswordBL _resetPasswordBL;
        private IConfiguration _configuration { get; set; }

        public UserController(IServiceProvider serviceProvider)
        {
            _userBL = serviceProvider.GetRequiredService<IUserBL>();
            _cityBL = serviceProvider.GetRequiredService<ICityBL>();
            _provinceBL = serviceProvider.GetRequiredService<IProvinceBL>();
            _resetPasswordBL = serviceProvider.GetRequiredService<IResetPasswordBL>();
            _configuration = serviceProvider.GetRequiredService<IConfiguration>();
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

        public IActionResult LogOut()
        {
            if (HttpContext.Request.Cookies.Count > 0)
            {
                foreach (var item in HttpContext.Request.Cookies.Keys)
                {
                    Response.Cookies.Delete(item);
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult LostPassword()
        {
            return View();
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult LostPassword(IFormCollection form)
        {
            try
            {
                var email = form["email"];
                var user = _userBL.Get(x => x.Email == email);
                if (user != null)
                {
                    try
                    {
                        var guid = Guid.NewGuid().ToString();
                        var resetPassword = new ResetPasswordDO
                        {
                            CreatedAt = DateTime.Now,
                            Email = user.Email,
                            Guid = guid,
                            Lastdate = DateTime.Now.AddHours(3),
                            Userid = user.Id
                        };

                        var addResetPassword = _resetPasswordBL.Add(resetPassword);
                        if (addResetPassword != null)
                        {
                            var sendingEmail = _configuration.GetSection("MailAddress").GetSection("address").Value;
                            var password = _configuration.GetSection("password").Value;
                            var siteAddress = _configuration.GetSection("SiteAddress").Value;

                            var dateTime = DateTime.Now;

                            var mailIt = new MailMessage();
                            mailIt.To.Add(new MailAddress(user.Email, user.Name + " " + user.Surname));
                            mailIt.From = new MailAddress(sendingEmail, "Shoppy System");
                            mailIt.Subject = "Reset ur password";
                            mailIt.Body = $@"<h4>You requested to renew your password</h4>
                                             <h5>Time</h5>{dateTime}
                                             <a href='{siteAddress}/Member/User/NewPass/{guid}'> Please click this URL</a>";
                            mailIt.IsBodyHtml = true;
                            var client = new SmtpClient();

                            client.Host = "smtp.yandex.com";
                            client.Port = 587;
                            client.EnableSsl = true;
                            client.UseDefaultCredentials = false;
                            client.Credentials = new NetworkCredential(sendingEmail, password);
                            client.DeliveryMethod = SmtpDeliveryMethod.Network;
                            client.Send(mailIt);
                            return Ok(new { text = "success" });
                        }
                    }
                    catch (Exception ex)
                    {

                        return BadRequest(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return View();
        }

        public IActionResult NewPass(string id)
        {
            var resetPassword = _resetPasswordBL.Get(x => x.Guid == id);
            if (resetPassword != null)
            {
                if (resetPassword.Lastdate(DateTime.Now))
                {
                    return BadRequest("please use another token to change your password");
                }
                else
                {
                    return View(resetPassword);
                }
            }
            else
            {
                return BadRequest("Something went wrong please try it again!");
            }
        }
    }
}
