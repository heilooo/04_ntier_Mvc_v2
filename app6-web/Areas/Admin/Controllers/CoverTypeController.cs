using Microsoft.AspNetCore.Mvc;
using ntier.DataAccess.Services;
using ntier.DataAccess.Services.Interface;
using ntier.Models;
using ntire.DataAccess;

namespace app6_web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly ICoverTypeService _CoverTypeService;
        public CoverTypeController(ICoverTypeService CoverTypeService)
        {
            _CoverTypeService = CoverTypeService;
        }
        //index
        public IActionResult Index()
        {
            IEnumerable<CoverType> CoverTypeList = _CoverTypeService.GetAll();
            return View(CoverTypeList);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }
        //post
        [HttpPost]
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _CoverTypeService.Add(obj);
                _CoverTypeService.Save();
                TempData["success"] = "تایپ با موفقیت ایجاد شد";
                return RedirectToAction("Index");
            }
            return View(obj);


        }
        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var CoverTypeFromDb = _db.Categories.Find(id);
            var CoverTypeFirst = _CoverTypeService.GetFirstOrDefault(c => c.Id == id);
            //var CoverTypeSingel = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (CoverTypeFirst == null)
            {
                return NotFound();
            }
            return View(CoverTypeFirst);
        }
        //post
        [HttpPost]
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _CoverTypeService.Update(obj);
                _CoverTypeService.Save();
                TempData["success"] = "تایپ با موفقیت  ویرایش شد";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var coverTypeFromDb = _db.Categories.Find(id);
            var coverTypeFirst = _CoverTypeService.GetFirstOrDefault(c => c.Id == id);
            //var coverTypeSingel = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (coverTypeFirst == null)
            {
                return NotFound();
            }
            return View(coverTypeFirst);
        }
        //post
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {

            var obj = _CoverTypeService.GetFirstOrDefault(c => c.Id == id); ;

            _CoverTypeService.Remove(obj);
            _CoverTypeService.Save();
            TempData["success"] = "تایپ با موفقیت  حذف شد";
            return RedirectToAction("Index");
        }
    }
}
