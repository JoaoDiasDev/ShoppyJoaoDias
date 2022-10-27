using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Member.Models;

namespace ShopJoaoDias.Areas.Member.Controllers
{
    [Area("Member")]
    [MemberAuth]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
