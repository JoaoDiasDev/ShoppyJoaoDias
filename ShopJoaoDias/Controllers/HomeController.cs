using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Models;

namespace ShopJoaoDias.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryBL _categoryBL;
        private IProductBL _productBL;
        private IBrandBL _brandBL;
        private IBasketBL _basketBL;
        private IWishlistBL _wishListBL;

        public HomeController(IServiceProvider serviceProvider)
        {
            _categoryBL = serviceProvider.GetRequiredService<ICategoryBL>();
            _productBL = serviceProvider.GetRequiredService<IProductBL>();
            _brandBL = serviceProvider.GetRequiredService<IBrandBL>();
            _basketBL = serviceProvider.GetRequiredService<IBasketBL>();
            _wishListBL = serviceProvider.GetRequiredService<IWishlistBL>();
        }

        public IActionResult Index()
        {
            var categories = _categoryBL.GetList();
            var products = _productBL.GetList();
            var brands = _brandBL.GetList();

            var model = new HomeViewModel
            {
                BrandList = brands,
                ProductList = products,
                CategoryList = categories
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [Route("/Json/UserProperties")]
        public IActionResult UserProperties()
        {
            var model = new JsonViewModel();
            var username = HttpContext.Request.Cookies["shoppyUsername"];
            var userId = HttpContext.Request.Cookies["shoppyUserId"];
            if (userId == null && username == null)
            {
                return Json(model);
            }

            var user = new UserDO
            {
                Name = username
            };

            var id = int.Parse(userId);
            var basketList = _basketBL.GetList(x => x.Userid == id);
            var wishListDOList = _wishListBL.GetList(x => x.Userid == id);
            model.User = user;
            model.BasketList = basketList;
            model.WishListDoList = wishListDOList;

            return Json(model);
        }
    }
}
