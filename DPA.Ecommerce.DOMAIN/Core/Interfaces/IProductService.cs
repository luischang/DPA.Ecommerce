using DPA.Ecommerce.DOMAIN.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Ecommerce.DOMAIN.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductListDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(int id);
        Task<int> AddProduct(ProductCreateDTO productDTO);
        Task<bool> UpdateProduct(ProductUpdateDTO productDTO);
        Task<bool> DeleteProduct(int id);
    }
}
