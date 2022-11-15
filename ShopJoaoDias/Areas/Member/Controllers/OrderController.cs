using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Member.Models;
using ShopJoaoDias.Models;

namespace ShopJoaoDias.Areas.Member.Controllers
{
    [Area("Member")]
    [MemberAuth]
    public class OrderController : Controller
    {
        private IBasketBL _basketBL;
        private IAddressBL _addressBL;
        private IShippingBL _shippingBL;
        private IPaymentBL _paymentBL;

        public OrderController(IServiceProvider serviceProvider)
        {
            _basketBL = serviceProvider.GetRequiredService<IBasketBL>();
            _addressBL = serviceProvider.GetRequiredService<IAddressBL>();
            _shippingBL = serviceProvider.GetRequiredService<IShippingBL>();
            _paymentBL = serviceProvider.GetRequiredService<IPaymentBL>();
        }

        public IActionResult Index(int id = 0)
        {
            var user = HttpContext.Items["Model"] as UserDO;
            var paymentList = new List<PaymentDO>();

            if (id == 0)
            {
                paymentList = _paymentBL.GetList(x => x.Userid == user.Id).OrderByDescending(x => x.CreatedAt).Take(5).ToList();
            }
            else if (id == 1)
            {
                paymentList = _paymentBL.GetList(x => x.CreatedAt > DateTime.Now.AddDays(-15) && x.Userid == user.Id).OrderByDescending(x => x.CreatedAt).ToList();
            }
            else if (id == 2)
            {
                paymentList = _paymentBL.GetList(x => x.CreatedAt > DateTime.Now.AddDays(-30) && x.Userid == user.Id).OrderByDescending(x => x.CreatedAt).ToList();
            }
            else if (id == 3)
            {
                paymentList = _paymentBL.GetList(x => x.CreatedAt > DateTime.Now.AddMonths(-6) && x.Userid == user.Id).OrderByDescending(x => x.CreatedAt).ToList();
            }
            else if (id == 4)
            {
                paymentList = _paymentBL.GetList(x => x.CreatedAt.Year == DateTime.Now.Year && x.Userid == user.Id).OrderByDescending(x => x.CreatedAt).ToList();
            }
            else
            {
                paymentList = _paymentBL.GetList(x => x.Userid == user.Id).ToList();
            }

            var model = new BasketViewModel
            {
                PaymentList = paymentList
            };

            ViewBag.Sort = id;

            return View(model);
        }
    }
}
