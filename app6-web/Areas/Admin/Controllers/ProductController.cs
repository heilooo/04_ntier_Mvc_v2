using Microsoft.AspNetCore.Mvc;
using ntier.DataAccess.Services;
using ntier.DataAccess.Services.Interface;
using ntier.Models;
using ntire.DataAccess;

namespace app6_web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _ProductService;
        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        //index
        public IActionResult Index()
        {
            IEnumerable<Product> ProductList = _ProductService.GetAll();
            return View(ProductList);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }
        //post
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            
            if (ModelState.IsValid)
            {
                _ProductService.Add(obj);
                _ProductService.Save();
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
            var productFirst = _ProductService.GetFirstOrDefault(c => c.Id == id);
            //var categorySingel = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (productFirst == null)
            {
                return NotFound();
            }
            return View(productFirst);
        }
        //post
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            
            if (ModelState.IsValid)
            {
                _ProductService.Update(obj);
                _ProductService.Save();
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
            var productFirst = _ProductService.GetFirstOrDefault(c => c.Id == id);
            //var categorySingel = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (productFirst == null)
            {
                return NotFound();
            }
            return View(productFirst);
        }
        //post
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {

            var obj = _ProductService.GetFirstOrDefault(c => c.Id == id); ;

            _ProductService.Remove(obj);
            _ProductService.Save();
            TempData["success"] = "دسته با موفقیت  حذف شد";
            return RedirectToAction("Index");


        }



    }
}
