using DPA.Ecommerce.DOMAIN.Core.Entities;
using DPA.Ecommerce.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Ecommerce.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        //Get all categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategories();
            return Ok(categories);
        }
        //Get category by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        //Add category
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            var categoryId = await _categoryRepository.AddCategory(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryId }, category);
        }

        //Update category
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            var result = await _categoryRepository.UpdateCategory(category);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        //Delete category
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryRepository.DeleteCategory(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
