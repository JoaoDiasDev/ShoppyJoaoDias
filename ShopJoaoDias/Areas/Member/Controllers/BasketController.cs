using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Member.Models;
using ShopJoaoDias.Models;

namespace ShopJoaoDias.Areas.Member.Controllers
{
    [Area("Member")]
    [MemberAuth]
    public class BasketController : Controller
    {
        private IBasketBL _basketBL;

        public BasketController(IServiceProvider serviceProvider)
        {
            _basketBL = serviceProvider.GetRequiredService<IBasketBL>();
        }

        public IActionResult Index()
        {
            var user = HttpContext.Items["Model"] as UserDO;
            var basketList = _basketBL.GetList(x => x.Userid == user.Id);
            var model = new BasketViewModel
            {
                BasketList = basketList
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddBask(IFormCollection form)
        {
            try
            {
                if (form != null)
                {
                    var userDO = HttpContext.Items["Model"] as UserDO;
                    var productId = int.Parse(form["productId"]);
                    var piece = int.Parse(form["piece"]);

                    var basket = _basketBL.Get(x => x.Userid == userDO.Id && x.Productid == productId);
                    if (basket != null)
                    {
                        basket.Piece += piece;
                        basket.UpdatedAt = DateTime.Now;
                        basket.CreatedAt = DateTime.Now;
                        var updatedBasket = _basketBL.Update(basket);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        var insertBasket = new BasketDO
                        {
                            Piece = piece,
                            Productid = productId,
                            Userid = userDO.Id,
                            UpdatedAt = DateTime.Now,
                            CreatedAt = DateTime.Now

                        };
                        _basketBL.Add(insertBasket);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return BadRequest("Something went wrong!");
                }
            }
            catch (Exception)
            {

                return BadRequest("Something went wrong!");
            }
        }

        public IActionResult Delete(int id)
        {
            var userDO = HttpContext.Items["Model"] as UserDO;
            var basket = _basketBL.Get(x => x.Id == id && x.Userid == userDO.Id);
            if (basket != null)
            {
                _basketBL.Delete(basket);
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAll(int id)
        {
            var userDO = HttpContext.Items["Model"] as UserDO;
            _basketBL.DeleteAll(userDO.Id);
            return RedirectToAction("Index");
        }
    }
}
