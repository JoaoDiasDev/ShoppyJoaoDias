using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Admin.Models;

namespace ShopJoaoDias.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuth]
    public class BrandController : Controller
    {
        private IBrandBL _brandBL;

        public BrandController(IServiceProvider serviceProvider)
        {
            _brandBL = serviceProvider.GetRequiredService<IBrandBL>();
        }

        public IActionResult Index()
        {
            var brandDO = _brandBL.GetList();
            return View(brandDO);
        }

        public IActionResult Create()
        {
            var brandDO = new BrandDO();
            return View(brandDO);
        }
    }
}
