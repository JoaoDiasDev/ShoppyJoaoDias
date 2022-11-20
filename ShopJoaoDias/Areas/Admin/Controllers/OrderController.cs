using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Member.Models;

namespace ShopJoaoDias.Areas.Admin.Controllers
{
    [Area("Admin")]
    [MemberAuth]
    public class OrderController : Controller
    {
        private IPaymentBL _paymentBL;
        private IOrderBL _orderBL;

        public OrderController(IServiceProvider serviceProvider)
        {
            _paymentBL = serviceProvider.GetRequiredService<IPaymentBL>();
            _orderBL = serviceProvider.GetRequiredService<IOrderBL>(); ;
        }

        public IActionResult Index(int status = 0)
        {
            var payments = _paymentBL.GetList(x => x.Status == status);
            return View(payments);
        }

        public IActionResult Detail(int id)
        {
            var payment = _paymentBL.Get(x => x.Id == id);
            return View(payment);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Detail(int id, IFormCollection form)
        {
            var payment = _paymentBL.Get(x => x.Id == id);
            var desc = form["description"];
            var shippingDate = DateTime.Parse(form["shipping-date"]);
            var shippingChase = form["shipping_chase_number"];
            var status = int.Parse(form["status"]);
            payment.Status = status;
            payment.UpdatedAt = DateTime.Now;
            _paymentBL.Update(payment);

            var order = _orderBL.Get(x => x.Paymentid == id);
            order.Description = desc;
            order.ShippingDate = shippingDate;
            order.ShippingChaseNo = shippingChase;
            _orderBL.Update(order);
            return RedirectToAction("Detail", new { id = id });
        }
    }
}
