using DPA.Ecommerce.DOMAIN.Core.Entities;
using DPA.Ecommerce.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Ecommerce.DOMAIN.Infrastructure.Repositories
{
    public class CategoryRepository
    {
        private readonly StoreDbueContext _context;
        public CategoryRepository(StoreDbueContext context)
        {
            _context = context;
        }

        //Get all categories
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Category.ToListAsync();
        }
        //Get category by id
        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Category.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        //Add category
        public async Task<int> AddCategory(Category category)
        {
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

    }
}
