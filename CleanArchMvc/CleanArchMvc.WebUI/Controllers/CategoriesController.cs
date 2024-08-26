using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class CategoriesController(ICategoryService categoryService) : Controller
    {
        private readonly ICategoryService _categoryService = categoryService;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategories();

            return View(categories);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Add(category);

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var categoryDTO = await _categoryService.GetById(id);

            if (categoryDTO == null)
                return NotFound();

            return View(categoryDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryService.Update(categoryDto);
                }
                catch (Exception)
                {

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(categoryDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
                return NotFound();

            var categoryDto = await _categoryService.GetById(Id);

            if (categoryDto == null)
                return NotFound();

            return View(categoryDto);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryService.Remove(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? Id)
        {
            if(Id == null)
                return NotFound();

            var categoryDto = await _categoryService.GetById(Id);

            if (categoryDto == null)
                return NotFound();

            return View(categoryDto);
        }
    }
}
