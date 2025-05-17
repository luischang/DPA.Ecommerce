using DPA.Ecommerce.DOMAIN.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Ecommerce.DOMAIN.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<int> AddProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
