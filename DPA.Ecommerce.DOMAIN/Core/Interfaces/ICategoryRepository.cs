using DPA.Ecommerce.DOMAIN.Core.Entities;

namespace DPA.Ecommerce.DOMAIN.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<int> AddCategory(Category category);
        Task<bool> DeleteCategory(int id);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task<bool> RemoveCategory(int id);
        Task<bool> UpdateCategory(Category category);
    }
}