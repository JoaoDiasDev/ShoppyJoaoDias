using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Admin.Models;
using ShopJoaoDias.Extensions;
using ShopJoaoDias.Helpers;

namespace ShopJoaoDias.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuth]
    public class CategoryController : Controller
    {
        private ICategoryBL _categoryBL;
        private IWebHostEnvironment _hosting;

        public CategoryController(IServiceProvider serviceProvider)
        {
            _categoryBL = serviceProvider.GetRequiredService<ICategoryBL>();
            _hosting = serviceProvider.GetRequiredService<IWebHostEnvironment>();
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var categoryDO = _categoryBL.GetById(id);
                var categoryList = _categoryBL.GetList();
                var model = new CategoryViewModel
                {
                    CategoryDO = categoryDO,
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
        public IActionResult Edit(int id, CategoryViewModel model)
        {
            try
            {
                var categoryDO = model.CategoryDO;
                if (ModelState.IsValid)
                {
                    categoryDO.UpdatedAt = DateTime.Now;
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

                    var result = _categoryBL.Update(categoryDO);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try it again";
                    return View(model);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _categoryBL.GetById(id);
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Delete(int id, CategoryDO categoryDO)
        {
            var result = _categoryBL.GetById(id);
            try
            {
                result.Deleted = 1;
                _categoryBL.Update(result);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file.Length > 0)
            {
                var uploadHelper = new UploadHelper(_hosting);
                string fileName = await uploadHelper.Upload(file, "categories");
                return Json(fileName);
            }
            else
            {
                return Ok();
            }
        }
    }
}
