using Microsoft.AspNetCore.Mvc;
using ntier.DataAccess.Repository.IRepository;
using ntier.Models;
using ntire.DataAccess;

namespace app6_web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _db;
        public CategoryController(IUnitOfWork db)
        {
            _db = db;
        }
        //index
        public IActionResult Index()
        {
            IEnumerable<Category> CtaegoryList = _db.Category.GetAll();
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
                _db.Category.Add(obj);
                _db.Save();
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
            var categoryFirst = _db.Category.GetFirstOrDefault(c => c.Id == id);
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
                _db.Category.Update(obj);
                _db.Save();
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
            var categoryFirst = _db.Category.GetFirstOrDefault(c => c.Id == id);
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

            var obj = _db.Category.GetFirstOrDefault(c => c.Id == id); ;

            _db.Category.Remove(obj);
            _db.Save();
            TempData["success"] = "دسته با موفقیت  حذف شد";
            return RedirectToAction("Index");


        }



    }
}
