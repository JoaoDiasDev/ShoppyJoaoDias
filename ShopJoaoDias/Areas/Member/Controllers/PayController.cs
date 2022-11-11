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
                string remoteIpAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

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
                payment.Ccsecurity = form["securityCode"];
                payment.Shippingid = shippingId;
                payment.Bankid = 0;
                payment.Paymentstatus = 1;
                payment.Totalprice = total + shipping.Desiprice;
                payment.Status = 0;
                payment.Productprice = total;
                payment.Shippingprice = shipping.Desiprice;
                payment.Token = remoteIpAddress;
                payment.CreatedAt = DateTime.Now;
                payment.UpdatedAt = DateTime.Now;
                var addPayment = _paymentBL.Add(payment);

                if (addPayment != null)
                {
                    var order = new OrderDO
                    {
                        Userid = thisUser.Id,
                        Orderid = guid,
                        Basketid = guid,
                        Paymentid = addPayment.Id,
                        Status = 1,
                        PaymentStatus = 1,
                        ShippingDate = null,
                        ShippingChaseNo = null,
                        Description = "",
                        Paid = total,
                        Amount = total + shipping.Desiprice,
                        Paypalid = "",
                        CurrencyUnit = 1,
                        Guid = guid,
                        InvoiceAddressId = addressId,
                        DeliveryAddressId = addressId,
                        Installment = 0,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    };
                    var addedOrder = _orderBL.Add(order);
                    if (addedOrder != null)
                    {
                        foreach (var basketItem in basketList)
                        {
                            var thisGuid = Guid.NewGuid();
                            var price = decimal.Parse(basketItem.Product.Discount != null ? basketItem.Product.Discount.ToString() : basketItem.Product.Price.ToString());
                            var orderItem = new OrderitemDO
                            {
                                UserId = thisUser.Id,
                                PaymentId = addPayment.Id,
                                OrderId = addedOrder.Id,
                                ProductId = basketItem.Productid,
                                OrderItemGuid = thisGuid.ToString(),
                                Quantity = basketItem.Piece,
                                Price = price,
                                WithoutDiscount = decimal.Parse(basketItem.Product.Price.ToString()),
                                TotalPrice = price * basketItem.Piece,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            };
                            _orderItemBL.Add(orderItem);
                            _basketBL.Delete(basketItem);
                        }
                    }
                }
                return RedirectToAction("Sucess", new { id = guid });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult Success(string id)
        {
            return BadRequest(id);
        }
    }
}
