using Entities;
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
            var user = HttpContext.Items["Model"] as UserDO;
            return View(user);
        }
    }
}
