using DPA.Ecommerce.DOMAIN.Core.DTOs;

namespace DPA.Ecommerce.DOMAIN.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<int> AddCategory(CategoryCreateDTO categoryDTO);
        Task<bool> DeleteCategory(int id);
        Task<IEnumerable<CategoryListDTO>> GetAllCategories();
        Task<CategoryListDTO> GetCategoryById(int id);
        Task<bool> UpdateCategory(CategoryListDTO categoryDTO);
        Task<CategoryProductsDTO> GetCategoryWithProducts(int id);
    }
}