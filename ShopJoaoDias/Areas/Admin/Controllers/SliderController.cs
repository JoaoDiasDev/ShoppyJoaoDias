using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using ShopJoaoDias.Areas.Member.Models;
using ShopJoaoDias.Helpers;

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

        public IActionResult Create()
        {
            try
            {
                var slider = new SliderDO();
                return View(slider);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Create(SliderDO slider)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var addSlider = _sliderBL.Add(slider);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Something went wrong please try it again!";
                    return View(slider);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Something went wrong please try it again!";
                return View(slider);
            }
        }

        public async Task<IActionResult> SingleUpload(IFormFile file)
        {
            if (file.Length > 0)
            {
                var uploadHelpers = new UploadHelper(_hosting);
                var fileName = await uploadHelpers.Upload(file, "slider/");
                return Ok("/upload/slider/" + fileName);
            }
            else
            {
                return Ok();
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                var slider = _sliderBL.GetById(id);
                return View(slider);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, SliderDO slider)
        {
            try
            {
                if (slider != null)
                {
                    var updateSlider = _sliderBL.Update(slider);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Something went wrong please try it again!";
                    return View(slider);
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong please try it again!";
                return View(slider);
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var slider = _sliderBL.GetById(id);
                return View(slider);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Delete(int id, SliderDO slider)
        {
            var result = _sliderBL.GetById(id);
            try
            {
                bool value = _sliderBL.Delete(result);
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
