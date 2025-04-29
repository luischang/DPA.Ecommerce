using DPA.Ecommerce.DOMAIN.Core.Entities;
using DPA.Ecommerce.DOMAIN.Core.Interfaces;
using DPA.Ecommerce.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Ecommerce.DOMAIN.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbueContext _context;
        public CategoryRepository(StoreDbueContext context)
        {
            _context = context;
        }

        //Get all categories
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Category.Where(c => c.IsActive == true).ToListAsync();
        }
        //Get category by id
        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Category.Where(c => c.Id == id && c.IsActive == true).FirstOrDefaultAsync();
        }
        //Add category
        public async Task<int> AddCategory(Category category)
        {
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        //Update category
        public async Task<bool> UpdateCategory(Category category)
        {
            var existingCategory = await GetCategoryById(category.Id);
            if (existingCategory == null)
            {
                return false;
            }
            existingCategory.Description = category.Description;
            existingCategory.IsActive = category.IsActive;
            _context.Category.Update(existingCategory);
            await _context.SaveChangesAsync();
            return true;
        }

        //Delete category
        public async Task<bool> DeleteCategory(int id)
        {
            var category = await GetCategoryById(id);
            if (category == null)
            {
                return false;
            }
            category.IsActive = false;
            _context.Category.Update(category);
            await _context.SaveChangesAsync();
            return true;
        }
        // Delete category by id (remove)
        public async Task<bool> RemoveCategory(int id)
        {
            var category = await GetCategoryById(id);
            if (category == null)
            {
                return false;
            }
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
