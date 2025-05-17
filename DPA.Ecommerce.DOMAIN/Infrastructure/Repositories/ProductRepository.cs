using DPA.Ecommerce.DOMAIN.Core.Entities;
using DPA.Ecommerce.DOMAIN.Core.Interfaces;
using DPA.Ecommerce.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Ecommerce.DOMAIN.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbueContext _context;
        public ProductRepository(StoreDbueContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Product.Where(p => p.IsActive == true).ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Product.FirstOrDefaultAsync(p => p.Id == id && p.IsActive == true);
        }

        public async Task<int> AddProduct(Product product)
        {
            product.IsActive = true;
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var existingProduct = await GetProductById(product.Id);
            if (existingProduct == null)
            {
                return false;
            }
            existingProduct.Description = product.Description;
            existingProduct.ImageUrl = product.ImageUrl;
            existingProduct.Stock = product.Stock;
            existingProduct.Price = product.Price;
            existingProduct.Discount = product.Discount;
            existingProduct.CategoryId = product.CategoryId;
            //existingProduct.IsActive = product.IsActive;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await GetProductById(id);
            if (product == null)
            {
                return false;
            }
            product.IsActive = false;
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
