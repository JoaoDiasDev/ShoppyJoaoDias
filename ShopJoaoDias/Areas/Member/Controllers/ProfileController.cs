using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Member.Models;
using ShopJoaoDias.Models;

namespace ShopJoaoDias.Areas.Member.Controllers
{
    [Area("Member")]
    [MemberAuth]
    public class ProfileController : Controller
    {
        private IUserBL _userBL;
        private IAddressBL _addressBL;

        public ProfileController(IServiceProvider serviceProvider)
        {
            _userBL = serviceProvider.GetRequiredService<IUserBL>();
            _addressBL = serviceProvider.GetRequiredService<IAddressBL>();
        }

        public IActionResult Index()
        {
            var user = HttpContext.Items["Model"] as UserDO;
            var profile = _userBL.GetById(user.Id);
            return View(profile);
        }

        public IActionResult Edit()
        {
            var user = HttpContext.Items["Model"] as UserDO;
            var profile = _userBL.GetById(user.Id);
            return View(profile);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(UserDO user, IFormCollection form)
        {
            try
            {
                var userDO = HttpContext.Items["Model"] as UserDO;
                var myUser = _userBL.GetById(userDO.Id);
                myUser.UpdatedAt = DateTime.Now;
                myUser.Name = user.Name;
                myUser.Surname = user.Surname;
                myUser.Phone = user.Phone;


                var birthday = form["yearName"] + "-" + form["monthName"] + "-" + form["dayName"];
                DateOnly birthdayFormat = DateOnly.Parse(birthday);
                myUser.Birthday = birthdayFormat;

                var updatedUser = _userBL.Update(myUser);
                if (updatedUser != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try it again!";
                    return View(user);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong please try it again!";
                return View(user);
            }
        }

        public IActionResult AddressBook()
        {
            var user = HttpContext.Items["Model"] as UserDO;
            var addressList = _addressBL.GetList(x => x.Userid == user.Id);

            var model = new BasketViewModel
            {
                AddressList = addressList
            };

            return View(model);
        }
    }
}
