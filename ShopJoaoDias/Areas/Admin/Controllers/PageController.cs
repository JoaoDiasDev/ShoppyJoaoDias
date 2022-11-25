using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Member.Models;
using ShopJoaoDias.Extensions;

namespace ShopJoaoDias.Areas.Admin.Controllers
{
    [Area("Admin")]
    [MemberAuth]
    public class PageController : Controller
    {
        private IPageBL _pageBL;

        public PageController(IServiceProvider serviceProvider)
        {
            _pageBL = serviceProvider.GetRequiredService<IPageBL>();
        }

        public IActionResult Index()
        {
            var pages = _pageBL.GetList();

            return View(pages);
        }

        public IActionResult Create()
        {
            try
            {
                var page = new PageDO();
                return View(page);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Create(PageDO page)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(page.Slug))
                    {
                        var slug = Functions.FriendlyUrl(page.Slug);
                        page.Slug = slug;
                    }
                    else
                    {
                        var slug = Functions.FriendlyUrl(page.Title);
                        page.Slug = slug;
                    }

                    page.CreatedAt = DateTime.Now;
                    page.UpdatedAt = DateTime.Now;
                    var addPage = _pageBL.Add(page);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try it again!";
                    return View(page);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong please try it again!";
                return View(page);
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                var result = _pageBL.GetById(id);
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, PageDO pageDO)
        {
            try
            {
                if (pageDO != null)
                {
                    if (!string.IsNullOrEmpty(pageDO.Slug))
                    {
                        var slug = Functions.FriendlyUrl(pageDO.Slug);
                        pageDO.Slug = slug;
                    }
                    else
                    {
                        var slug = Functions.FriendlyUrl(pageDO.Title);
                        pageDO.Slug = slug;
                    }

                    pageDO.UpdatedAt = DateTime.Now;
                    var updatePage = _pageBL.Update(pageDO);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try it again!";
                    return View(pageDO);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong please try it again!";
                return View(pageDO);
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var result = _pageBL.GetById(id);
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Delete(int id, PageDO page)
        {
            var result = _pageBL.GetById(id);
            try
            {
                var value = _pageBL.Delete(result);
                if (value)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try it again!";
                    return View(result);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong please try it again!";
                return View(result);
            }
        }
    }
}
