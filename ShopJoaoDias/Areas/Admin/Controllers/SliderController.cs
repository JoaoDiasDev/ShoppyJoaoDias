using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Member.Models;

namespace ShopJoaoDias.Areas.Admin.Controllers
{
    [Area("Admin")]
    [MemberAuth]
    public class SliderController : Controller
    {
        private ISliderBL _sliderBL;
        private IWebHostEnvironment _hosting;

        public SliderController(ServiceProvider serviceProvider)
        {
            _sliderBL = serviceProvider.GetRequiredService<ISliderBL>();
            _hosting = serviceProvider.GetRequiredService<IWebHostEnvironment>();
        }

        public IActionResult Index()
        {
            var sliderList = _sliderBL.GetList();
            return View(sliderList);
        }
    }
}
