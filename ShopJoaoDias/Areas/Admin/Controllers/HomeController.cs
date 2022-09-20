using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Admin.Models;

namespace ShopJoaoDias.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuth]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
