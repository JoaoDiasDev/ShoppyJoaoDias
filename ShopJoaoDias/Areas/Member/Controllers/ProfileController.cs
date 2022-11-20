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
        private IProvinceBL _provinceBL;
        private ICityBL _cityBL;

        public ProfileController(IServiceProvider serviceProvider)
        {
            _userBL = serviceProvider.GetRequiredService<IUserBL>();
            _addressBL = serviceProvider.GetRequiredService<IAddressBL>();
            _provinceBL = serviceProvider.GetRequiredService<IProvinceBL>();
            _cityBL = serviceProvider.GetRequiredService<ICityBL>();
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

        public IActionResult AddAddress()
        {
            List<ProvinceDO> provinces = _provinceBL.GetList();
            var model = new AddressViewModel
            {
                Provinces = provinces
            };
            return View(model);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult AddAddress(AddressViewModel model)
        {
            var provinces = _provinceBL.GetList();
            var addressViewModel = new AddressViewModel
            {
                Provinces = provinces
            };

            try
            {
                var user = HttpContext.Items["Model"] as UserDO;
                var myUser = _userBL.GetById(user.Id);
                var address = model.Address;
                address.Userid = myUser.Id;
                address.Country = Convert.ToInt32(address.Country);
                address.Cityid = Convert.ToInt32(address.Cityid);
                address.CreatedAt = DateTime.Now;
                address.UpdatedAt = DateTime.Now;
                var addedAddress = _addressBL.Add(address);
                if (addedAddress != null)
                {
                    return RedirectToAction("AddressBook");
                }
                else
                {
                    ViewBag.error = "something went wrong please try it again!";
                    return View(addressViewModel);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "something went wrong please try it again!";
                return View(addressViewModel);
            }
        }

        public IActionResult EditAddress(int id)
        {
            try
            {
                var user = HttpContext.Items["Model"] as UserDO;
                var myUser = _userBL.GetById(user.Id);
                var address = _addressBL.Get(x => x.Id == id && x.Userid == myUser.Id);
                var provinces = _provinceBL.GetList(x => x.Id == id);
                var model = new AddressViewModel
                {
                    Provinces = provinces,
                    Address = address,
                };

                return View(model);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult EditAddress(int id, AddressViewModel model)
        {
            var provinces = _provinceBL.GetList();
            var addressViewModel = new AddressViewModel
            {
                Provinces = provinces
            };

            try
            {
                var user = HttpContext.Items["Model"] as UserDO;
                var address = model.Address;
                address.Userid = user.Id;
                address.Id = id;
                address.UpdatedAt = DateTime.Now;
                var addedAddress = _addressBL.Update(address);
                if (addedAddress != null)
                {
                    return RedirectToAction("AddressBook");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try again!";
                    return View(addressViewModel);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong please try again!";
                return View(addressViewModel);
            }
        }


        public IActionResult SelectCity(int id)
        {
            var cities = _cityBL.GetList(x => x.Provinceid == id).ToList();
            return Json(cities);
        }
    }
}
