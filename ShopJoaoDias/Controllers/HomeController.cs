using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Helpers;
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
        private ISliderBL _sliderBL;

        public HomeController(IServiceProvider serviceProvider)
        {
            _categoryBL = serviceProvider.GetRequiredService<ICategoryBL>();
            _productBL = serviceProvider.GetRequiredService<IProductBL>();
            _brandBL = serviceProvider.GetRequiredService<IBrandBL>();
            _basketBL = serviceProvider.GetRequiredService<IBasketBL>();
            _wishListBL = serviceProvider.GetRequiredService<IWishlistBL>();
            _sliderBL = serviceProvider.GetRequiredService<ISliderBL>();
        }

        public IActionResult Index()
        {
            var categories = _categoryBL.GetList();
            var products = _productBL.GetList();
            var brands = _brandBL.GetList();
            var sliders = _sliderBL.GetList();

            var model = new HomeViewModel
            {
                BrandList = brands,
                ProductList = products,
                CategoryList = categories,
                SliderList = sliders
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

        public IActionResult Search([FromQuery(Name = "q")] string searchText = "", [FromQuery(Name = "p")] int page = 1,
            [FromQuery(Name = "perPage")] int perPage = 10, [FromQuery(Name = "sort")] int sort = 1)
        {
            var result = new List<ProductDO>();
            if (searchText != null)
            {
                var resultOrdered = _productBL.GetList(x => x.Name.Equals(searchText) || x.Description.Contains(searchText));
                if (sort == 1)
                {
                    result = resultOrdered.OrderByDescending(x => x.Id).ToList();
                }
                else if (sort == 2)
                {
                    result = resultOrdered.OrderBy(x => x.Id).ToList();
                }
                else if (sort == 3)
                {
                    result = resultOrdered.OrderBy(x => x.Price).ToList();
                }
                else if (sort == 4)
                {
                    result = resultOrdered.OrderByDescending(x => x.Price).ToList();
                }
            }

            var skip = (page - 1) * perPage;
            var productList = result.Skip(skip).Take(perPage).ToList();
            var totalCount = result.Count();
            var searchPaginationHelper = new SearchPaginationHelper();
            var searchProducts = searchPaginationHelper.CategoryProduct(totalCount, page, searchText, productList, perPage, 1);

            var model = new FrontCategoryViewModel
            {
                CategoryProduct = searchProducts,
                Page = page,
                SearchQuery = searchText
            };
            return View(model);
        }
    }
}
