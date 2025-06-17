using DPA.Ecommerce.DOMAIN.Core.DTOs;
using DPA.Ecommerce.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]        
        public async Task<ActionResult<IEnumerable<ProductListDTO>>> GetAll()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(ProductCreateDTO dto)
        {
            var id = await _productService.AddProduct(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductUpdateDTO dto)
        {
            var result = await _productService.UpdateProduct(dto);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _productService.DeleteProduct(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
