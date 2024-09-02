using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Categories()
        {
            var categories = await _categoryService.GetCategories();

            if (categories == null)
            {
                return NotFound("Categories not found");
            }

            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "CategoryById")]
        public async Task<ActionResult<CategoryDto>> CategoryById(int id)
        {
            var category = await _categoryService.GetById(id);

            if (category == null)
            {
                return NotFound("Category not found");
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest("Invalid Data");
            }

            await _categoryService.Add(categoryDto);

            return new CreatedAtRouteResult("CategoryById", new {id = categoryDto.Id}, categoryDto);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody] CategoryDto categoryDto )
        {

            if (id != categoryDto.Id)
            {
                return BadRequest("Invalid Data");
            }

            if (categoryDto == null)
            {
                return BadRequest();
            }

            await _categoryService.Update(categoryDto);

            return Ok(categoryDto);

        }
    }
}
