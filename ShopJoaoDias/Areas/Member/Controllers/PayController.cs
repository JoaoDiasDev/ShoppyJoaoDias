using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Member.Models;
using ShopJoaoDias.Models;

namespace ShopJoaoDias.Areas.Member.Controllers
{
    [Area("Member")]
    [MemberAuth]
    public class PayController : Controller
    {
        private IBasketBL _basketBL;
        private IAddressBL _addressBL;
        private IShippingBL _shippingBL;
        private IUserBL _userBL;
        private IPaymentBL _paymentBL;
        private IOrderBL _orderBL;
        private IOrderitemBL _orderItemBL;

        public PayController(IServiceProvider serviceProvider)
        {
            _basketBL = serviceProvider.GetRequiredService<IBasketBL>();
            _addressBL = serviceProvider.GetRequiredService<IAddressBL>();
            _shippingBL = serviceProvider.GetRequiredService<IShippingBL>();
            _userBL = serviceProvider.GetRequiredService<IUserBL>();
            _paymentBL = serviceProvider.GetRequiredService<IPaymentBL>();
            _orderBL = serviceProvider.GetRequiredService<IOrderBL>();
            _orderItemBL = serviceProvider.GetRequiredService<IOrderitemBL>();
        }

        public IActionResult Index()
        {
            var user = HttpContext.Items["Model"] as UserDO;
            var shippingList = _shippingBL.GetList();
            var addressList = _addressBL.GetList(x => x.Userid == user.Id);
            var model = new BasketViewModel
            {
                ShippingList = shippingList,
                AddressList = addressList
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult CheckOut(IFormCollection form)
        {
            try
            {
                var user = HttpContext.Items["Model"] as UserDO;
                int addressId = int.Parse(form["addressId"].ToString());
                int shippingId = int.Parse(form["shippingId"].ToString());
                var address = _addressBL.GetById(addressId);
                var shipping = _shippingBL.GetById(shippingId);
                var basketList = _basketBL.GetList(x => x.Userid == user.Id);
                if (basketList == null || basketList.Count() == 0)
                {
                    return BadRequest("Your basket is empty");
                }
                else
                {
                    var model = new BasketViewModel
                    {
                        Shipping = shipping,
                        Address = address,
                        BasketList = basketList
                    };
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult Payment(IFormCollection form)
        {
            try
            {
                var user = HttpContext.Items["Model"] as UserDO;
                var thisUser = _userBL.GetById(user.Id);
                var shippingId = int.Parse(form["shippingId"].ToString());
                var addressId = int.Parse(form["addressId"].ToString());
                var payment = new PaymentDO();
                var shipping = _shippingBL.GetById(shippingId);
                var basketList = _basketBL.GetList(x => x.Userid == user.Id);
                decimal total = 0;
                foreach (var basket in basketList)
                {
                    total += decimal.Parse((basket.Product.Price * basket.Piece).ToString());
                }

                var guid = Guid.NewGuid().ToString();
                payment.Guid = guid;
                payment.Userid = user.Id;
                payment.Type = 1;
                payment.Email = thisUser.Email;
                payment.CreditCard = form["cardno"];
                payment.Lastdate = form["month"] + "/" + form["year"];
                payment.Shippingid = shippingId;
                payment.Bankid = 0;
                payment.Paymentstatus = 1;
                payment.Totalprice = total + shipping.Desiprice;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
