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

        public ProductController(IServiceProvider serviceProvider)
        {
            _productBL = serviceProvider.GetRequiredService<IProductBL>();
            _categoryBL = serviceProvider.GetRequiredService<ICategoryBL>();
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

            return View();
        }
    }
}
