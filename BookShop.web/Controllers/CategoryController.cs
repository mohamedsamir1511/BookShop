using BookShop.DAL.UnitOfwork.Interfaces;
using BookShop.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveCreate(Category category)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Categories.AddAsync(category);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Show));
            }
            return View("Create", category);
        }

        public async Task<IActionResult> Show()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            var sorted = categories.OrderBy(c => c.CatOrder)
                                   .ThenByDescending(c => c.CatName)
                                   .ToList();

            return View("Categories", sorted);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveEdit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Categories.Update(category);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Show));
            }
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            _unitOfWork.Categories.Delete(category);
            await _unitOfWork.CompleteAsync();

            return RedirectToAction(nameof(Show));
        }
    }
}
