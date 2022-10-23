using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Helpers;
using ShopJoaoDias.Models;

namespace ShopJoaoDias.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryBL _categoryBL;
        private IProductBL _productBL;

        public CategoryController(IServiceProvider serviceProvider)
        {
            _categoryBL = serviceProvider.GetRequiredService<ICategoryBL>();
            _productBL = serviceProvider.GetRequiredService<IProductBL>();
        }

        [Route("/Category/{slug}/{page?}")]
        public IActionResult Index(string slug, int page = 1, [FromQuery(Name = "minPrice")] int minPrice = 0, [FromQuery(Name = "maxPrice")] int maxPrice = 0)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return BadRequest("something went wrong");
            }
            else
            {
                var categoryDO = _categoryBL.Get(x => x.Slug == slug);
                if (categoryDO == null)
                {
                    return BadRequest("something went wrong");
                }
                else
                {
                    var products = categoryDO.Parentid == 0
                        ? _productBL.GetProductPerPage(categoryDO.Id, page, true)
                        : _productBL.GetProductPerPage(categoryDO.Id, page, false);

                    if (minPrice != 0)
                    {
                        products = products.Where(x => x.Price >= float.Parse(minPrice.ToString())).ToList();
                    }
                    if (maxPrice != 0)
                    {
                        products = products.Where(x => x.Price <= float.Parse(maxPrice.ToString())).ToList();
                    }


                    var perPage = 3;
                    var skip = (page - 1) * perPage;
                    var productList = products.Skip(skip).Take(perPage).ToList();

                    var totalCount = products.Count();
                    var paginationHelper = new PaginationHelper();
                    var categoryProduct = paginationHelper.CategoryProduct(totalCount, page, categoryDO, productList,
                                                                           perPage, sort: 1, minPrice.ToString(), maxPrice.ToString());
                    var categoryDOList = _categoryBL.GetList();
                    var model = new FrontCategoryViewModel
                    {
                        CategoryProduct = categoryProduct,
                        CategoryList = categoryDOList,
                        CategoryDO = categoryDO,
                    };
                    return View(model);
                }
            }

        }
    }
}
