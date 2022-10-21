using Microsoft.AspNetCore.Mvc;

namespace ShopJoaoDias.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
