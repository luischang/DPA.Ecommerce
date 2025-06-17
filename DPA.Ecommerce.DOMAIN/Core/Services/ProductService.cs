using DPA.Ecommerce.DOMAIN.Core.DTOs;
using DPA.Ecommerce.DOMAIN.Core.Entities;
using DPA.Ecommerce.DOMAIN.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPA.Ecommerce.DOMAIN.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductListDTO>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return products.Select(p => new ProductListDTO
            {
                Id = p.Id,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Stock = p.Stock,
                Price = p.Price,
                CategoryId = p.CategoryId
            });
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var p = await _productRepository.GetProductById(id);
            if (p == null) return null;
            return new ProductDTO
            {
                Id = p.Id,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Stock = p.Stock,
                Price = p.Price,
                Discount = p.Discount,
                CategoryId = p.CategoryId,
                IsActive = p.IsActive
            };
        }

        public async Task<int> AddProduct(ProductCreateDTO productDTO)
        {
            var product = new Product
            {
                Description = productDTO.Description,
                ImageUrl = productDTO.ImageUrl,
                Stock = productDTO.Stock,
                Price = productDTO.Price,
                Discount = productDTO.Discount,
                CategoryId = productDTO.CategoryId,
                IsActive = true
            };
            return await _productRepository.AddProduct(product);
        }

        public async Task<bool> UpdateProduct(ProductUpdateDTO productDTO)
        {
            var product = new Product
            {
                Id = productDTO.Id,
                Description = productDTO.Description,
                ImageUrl = productDTO.ImageUrl,
                Stock = productDTO.Stock,
                Price = productDTO.Price,
                Discount = productDTO.Discount,
                CategoryId = productDTO.CategoryId,
                IsActive = true
            };
            return await _productRepository.UpdateProduct(product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _productRepository.DeleteProduct(id);
        }
    }
}
