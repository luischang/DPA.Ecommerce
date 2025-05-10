using DPA.Ecommerce.DOMAIN.Core.DTOs;
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
        //private readonly ICategoryRepository _categoryRepository;
        //public CategoriesController(ICategoryRepository categoryRepository)
        //{
        //    _categoryRepository = categoryRepository;
        //}
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        //Get all categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }
        //Get category by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        //Add category
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryCreateDTO categoryCreateDTO)
        {
            if (categoryCreateDTO == null)
            {
                return BadRequest();
            }
            var categoryId = await _categoryService.AddCategory(categoryCreateDTO);
            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryId }, categoryCreateDTO);
        }

        //Update category
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryListDTO categoryListDTO)
        {
            if (id != categoryListDTO.Id)
            {
                return BadRequest();
            }
            var result = await _categoryService.UpdateCategory(categoryListDTO);
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
            var result = await _categoryService.DeleteCategory(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        //Get category with products
        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetCategoryWithProducts(int id)
        {
            var categoryProducts = await _categoryService.GetCategoryWithProducts(id);
            if (categoryProducts == null)
            {
                return NotFound();
            }
            return Ok(categoryProducts);
        }
    }
}
