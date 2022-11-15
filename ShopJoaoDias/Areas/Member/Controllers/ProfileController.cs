using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Member.Models;

namespace ShopJoaoDias.Areas.Member.Controllers
{
    [Area("Member")]
    [MemberAuth]
    public class ProfileController : Controller
    {
        private IUserBL _userBL;

        public ProfileController(IServiceProvider serviceProvider)
        {
            _userBL = serviceProvider.GetRequiredService<IUserBL>();
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
                var birthday = form["yearName"] + "/" + form["monthName"] + "/" + form["dayName"];
                var birthdayFormat = DateTime.Parse(birthday);
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
