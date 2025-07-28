using BookShop.DAL.UnitOfwork.Interfaces;
using BookShop.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;

namespace BookShop.web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitofwork;

        public ProductController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        //show all products even with its categories 
        public async Task<IActionResult> Index()
        {
            var products = await _unitofwork.Products.GetAllAsync(p => p.Category);

            return View("Index", products);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //var categories = await _unitofwork.Categories.GetAllAsync();
            //ViewBag.categories = new SelectList(categories, "Id", "CatName");
            await LoadCategoriesAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveCreate(Product product)
        {
            if (ModelState.IsValid)
            {
                await _unitofwork.Products.AddAsync(product);//adding my product
                await _unitofwork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            await LoadCategoriesAsync();
            return View("Create", product);



        }
        private async Task LoadCategoriesAsync()
        {
            var categories = await _unitofwork.Categories.GetAllAsync();
            ViewBag.categories = new SelectList(categories, "Id", "CatName");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _unitofwork.Products.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();

            }
            await LoadCategoriesAsync();
            return View(product);

        }
        [HttpPost]
        public async Task<IActionResult> SaveEdit(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitofwork.Products.Update(product);
                await _unitofwork.CompleteAsync();
                return RedirectToAction(nameof(Index));

            }
            await LoadCategoriesAsync();
            return View("Edit", product);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _unitofwork.Products.GetAllAsync(P => P.Category);
            var selectedproduct = product.FirstOrDefault(p => p.Id == id);
            if (selectedproduct == null)
            {
                return NotFound();
            }
            return View(selectedproduct);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _unitofwork.Products.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return View(product); 
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _unitofwork.Products.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            _unitofwork.Products.Delete(product);
            await _unitofwork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
