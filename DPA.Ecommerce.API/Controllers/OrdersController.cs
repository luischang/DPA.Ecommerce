using DPA.Ecommerce.DOMAIN.Core.DTOs;
using DPA.Ecommerce.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAll()
        {
            var orders = await _ordersService.GetAllOrders();
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetById(int id)
        {
            var order = await _ordersService.GetOrderById(id);
            if (order == null) return NotFound();
            return Ok(order);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(OrderCreateDTO dto)
        {
            var id = await _ordersService.AddOrder(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }
    }
}
