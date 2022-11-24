using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Models;

namespace ShopJoaoDias.Controllers
{
    public class ProductController : Controller
    {
        private IProductBL _productBL;
        private ICategoryBL _categoryBL;
        private IWishlistBL _wishListBL;

        public ProductController(IServiceProvider serviceProvider)
        {
            _productBL = serviceProvider.GetRequiredService<IProductBL>();
            _categoryBL = serviceProvider.GetRequiredService<ICategoryBL>();
            _wishListBL = serviceProvider.GetRequiredService<IWishlistBL>();
        }

        [Route("{id:int}/{slug}")]
        public IActionResult Index(int id, string slug)
        {
            try
            {
                if (slug != null)
                {
                    var productDO = _productBL.Get(x => x.Easyurl == slug && x.Id == id);
                    var relatedProducts = _productBL.GetList(x => x.Categoryid == productDO.Categoryid && x.Id != productDO.Id).Take(6).ToList();
                    var categoryId = productDO.Category.Parentid != null ? int.Parse(productDO.Category.Parentid.ToString()) : 0;
                    var parentCategory = new CategoryDO();
                    if (categoryId > 0)
                    {
                        parentCategory = _categoryBL.GetById(categoryId);
                    }
                    var model = new FrontProductViewModel
                    {
                        ProductDO = productDO,
                        ProductList = relatedProducts,
                        ParentCategory = parentCategory
                    };
                    return View(model);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult AddWishList(int id)
        {
            var username = HttpContext.Request.Cookies["shoppyUsername"];
            var userId = HttpContext.Request.Cookies["shoppyUserId"];
            if (userId == null || username == null)
            {
                return Ok("0");
            }
            else
            {
                var wishCheck = _wishListBL.Get(x => x.Productid == id && x.Userid == int.Parse(userId));
                if (wishCheck == null)
                {
                    var wishListDO = new WishlistDO
                    {
                        Createdat = DateTime.Now,
                        Productid = id,
                        Updatedat = DateTime.Now,
                        Userid = int.Parse(userId)

                    };
                    _wishListBL.Add(wishListDO);
                }
                return Ok("1");
            }
        }

        public IActionResult DeleteWish(int id)
        {
            var username = HttpContext.Request.Cookies["shoppyUsername"];
            var userId = HttpContext.Request.Cookies["shoppyUserId"];
            if (userId == null || username == null)
            {
                return Ok("0");
            }
            else
            {
                var wishList = _wishListBL.Get(x => x.Productid == id && x.Userid == int.Parse(userId));
                if (wishList != null)
                {
                    _wishListBL.Delete(wishList);
                }
                return Ok("1");
            }
        }

        [HttpGet]
        [Route("/Json/ProductWishList/{id}")]
        public IActionResult ProductWishList(int id)
        {
            if (id > 0)
            {


                var username = HttpContext.Request.Cookies["shoppyUsername"];
                var userId = HttpContext.Request.Cookies["shoppyUserId"];
                if (userId == null && username == null)
                {
                    return Ok("0");
                }
                else
                {
                    var wishList = _wishListBL.Get(x => x.Userid == int.Parse(userId) && x.Productid == id);
                    if (wishList != null)
                    {
                        return Ok("1");
                    }
                    else
                    {
                        return Ok("0");
                    }
                }
            }
            else
            {
                return Ok("0");
            }
        }
    }
}
