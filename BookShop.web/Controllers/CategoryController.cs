using BookShop.DAL.Context;
using BookShop.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveCreate(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return RedirectToAction(nameof(Show));
            }
            return View("Create",category);
        }


        public IActionResult Show()
        {
            var Categories= _db.Categories.ToList();
            return View("Categories",Categories);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _db.Categories.Find(id);
            if (category == null)//if i wrote wrong id or not exist id
                return NotFound();
            return View(category);
        }

        [HttpPost]
        public IActionResult SaveEdit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                return RedirectToAction(nameof(Show));
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var category = _db.Categories.Find(id);
            if (category == null)
                return NotFound();
            return View(category);
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _db.Categories.Find(id);
            if (category == null) return NotFound();

            _db.Categories.Remove(category);
            _db.SaveChanges();

            return RedirectToAction(nameof(Show));
        }



    }
}
