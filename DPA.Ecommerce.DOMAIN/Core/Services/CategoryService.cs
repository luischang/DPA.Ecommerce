using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA.Ecommerce.DOMAIN.Core.DTOs;
using DPA.Ecommerce.DOMAIN.Core.Entities;
using DPA.Ecommerce.DOMAIN.Core.Interfaces;

namespace DPA.Ecommerce.DOMAIN.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryListDTO>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategories();
            var categoriesDTO = categories.Select(c => new CategoryListDTO
            {
                Id = c.Id,
                Description = c.Description
            });

            return categoriesDTO;
        }

        public async Task<CategoryListDTO> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return null;
            }
            var categoryDTO = new CategoryListDTO
            {
                Id = category.Id,
                Description = category.Description
            };
            return categoryDTO;
        }

        public async Task<int> AddCategory(CategoryCreateDTO categoryDTO)
        {
            var category = new Category
            {
                Description = categoryDTO.Description,
                IsActive = true
            };
            return await _categoryRepository.AddCategory(category);
        }

        //Update category
        public async Task<bool> UpdateCategory(CategoryListDTO categoryDTO)
        {
            var category = new Category
            {
                Id = categoryDTO.Id,
                Description = categoryDTO.Description,
                IsActive = true
            };
            return await _categoryRepository.UpdateCategory(category);
        }
        //Delete category
        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return false;
            }
            category.IsActive = false;
            return await _categoryRepository.UpdateCategory(category);
        }

        //Get category with products
        public async Task<CategoryProductsDTO> GetCategoryWithProducts(int id)
        {

            var category = await _categoryRepository.GetCategoryWithProducts(id);
            if (category == null)
            {
                return null;
            }
            var categoryDTO = new CategoryProductsDTO
            {
                Id = category.Id,
                Description = category.Description,
                Products = category.Product.Select(p => new ProductListDTO
                {
                    Id = p.Id,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                    ImageUrl = p.ImageUrl,
                }).ToList()
            };
            return categoryDTO;
        }

    }
}
