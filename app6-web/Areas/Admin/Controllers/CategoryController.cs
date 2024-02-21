using Microsoft.AspNetCore.Mvc;
using ntier.DataAccess.Services;
using ntier.DataAccess.Services.Interface;
using ntier.Models;
using ntire.DataAccess;

namespace app6_web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _CategoryService;
        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }
        //index
        public IActionResult Index()
        {
            IEnumerable<Category> CtaegoryList = _CategoryService.GetAll();
            return View(CtaegoryList);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }
        //post
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder)
            {
                ModelState.AddModelError("Name", "مقدار هر دو قیلد نباید یکی باشد");

            }
            if (ModelState.IsValid)
            {
                _CategoryService.Add(obj);
                _CategoryService.Save();
                TempData["success"] = "دسته با موفقیت ایجاد شد";
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
            //var categoryFromDb = _db.Categories.Find(id);
            var categoryFirst = _CategoryService.GetFirstOrDefault(c => c.Id == id);
            //var categorySingel = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFirst == null)
            {
                return NotFound();
            }
            return View(categoryFirst);
        }
        //post
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder)
            {
                ModelState.AddModelError("Name", "مقدار هر دو قیلد نباید یکی باشد");

            }
            if (ModelState.IsValid)
            {
                _CategoryService.Update(obj);
                _CategoryService.Save();
                TempData["success"] = "دسته با موفقیت  ویرایش شد";
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
            //var categoryFromDb = _db.Categories.Find(id);
            var categoryFirst = _CategoryService.GetFirstOrDefault(c => c.Id == id);
            //var categorySingel = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFirst == null)
            {
                return NotFound();
            }
            return View(categoryFirst);
        }
        //post
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {

            var obj = _CategoryService.GetFirstOrDefault(c => c.Id == id); ;

            _CategoryService.Remove(obj);
            _CategoryService.Save();
            TempData["success"] = "دسته با موفقیت  حذف شد";
            return RedirectToAction("Index");


        }



    }
}
