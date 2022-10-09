using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Admin.Models;
using ShopJoaoDias.Extensions;

namespace ShopJoaoDias.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuth]
    public class CategoryController : Controller
    {
        private ICategoryBL _categoryBL;

        public CategoryController(IServiceProvider serviceProvider)
        {
            _categoryBL = serviceProvider.GetRequiredService<ICategoryBL>();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categoryList = _categoryBL.GetList(x => x.Deleted == 0);
            return View(categoryList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CategoryViewModel();
            try
            {
                var categoryList = _categoryBL.GetList(x => x.Parentid == 0);

                model = new CategoryViewModel
                {
                    CategoryDOList = categoryList
                };

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Create(CategoryViewModel model)
        {
            try
            {
                var categoryDO = model.CategoryDO;
                categoryDO.CreatedAt = DateTime.Now;
                categoryDO.UpdatedAt = DateTime.Now;
                categoryDO.Status = 1;
                if (!(string.IsNullOrEmpty(categoryDO.Slug)))
                {
                    var slug = Functions.FriendlyUrl(categoryDO.Slug);
                    categoryDO.Slug = slug;
                }
                else
                {
                    var slug = Functions.FriendlyUrl(categoryDO.Name);
                    categoryDO.Slug = slug;
                }

                if (string.IsNullOrEmpty(categoryDO.Description))
                {
                    var desc = "this is description about " + categoryDO.Name;
                    categoryDO.Description = desc;
                }
                if (string.IsNullOrEmpty(categoryDO.Pagetitle))
                {
                    var title = "this is page title for " + categoryDO.Name;
                    categoryDO.Pagetitle = title;
                }

                if (string.IsNullOrEmpty(categoryDO.Metadescription))
                {
                    var metaDesc = "this is meta description for " + categoryDO.Name;
                    categoryDO.Metadescription = metaDesc;
                }

                var addCategoryDO = _categoryBL.Add(categoryDO);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("model");
            }
        }
    }
}
