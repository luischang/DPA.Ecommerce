using DPA.Ecommerce.DOMAIN.Core.DTOs;
using DPA.Ecommerce.DOMAIN.Core.Entities;
using DPA.Ecommerce.DOMAIN.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPA.Ecommerce.DOMAIN.Core.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrdersService(IOrdersRepository ordersRepository, IOrderDetailRepository orderDetailRepository)
        {
            _ordersRepository = ordersRepository;
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<IEnumerable<OrderDTO>> GetAllOrders()
        {
            var orders = await _ordersRepository.GetAllOrders();
            return orders.Select(o => new OrderDTO
            {
                Id = o.Id,
                CreatedAt = o.CreatedAt,
                UserId = o.UserId,
                Status = o.Status,
                TotalAmount = o.TotalAmount,
                Details = o.OrderDetail?.Select(d => new OrderDetailDTO
                {
                    Id = d.Id,
                    ProductId = d.ProductId,
                    Quantity = d.Quantity,
                    Price = d.Price
                }).ToList()
            });
        }
        public async Task<OrderDTO> GetOrderById(int id)
        {
            var o = await _ordersRepository.GetOrderById(id);
            if (o == null) return null;
            return new OrderDTO
            {
                Id = o.Id,
                CreatedAt = o.CreatedAt,
                UserId = o.UserId,
                Status = o.Status,
                TotalAmount = o.TotalAmount,
                Details = o.OrderDetail?.Select(d => new OrderDetailDTO
                {
                    Id = d.Id,
                    ProductId = d.ProductId,
                    Quantity = d.Quantity,
                    Price = d.Price
                }).ToList()
            };
        }
        public async Task<int> AddOrder(OrderCreateDTO orderDTO)
        {
            var order = new Orders
            {
                CreatedAt = DateTime.UtcNow,
                UserId = orderDTO.UserId,
                Status = "N",
                TotalAmount = 0 // Se calculará abajo
            };
            order.Id = await _ordersRepository.AddOrder(order);
            decimal total = 0;
            if (orderDTO.Details != null)
            {
                foreach (var d in orderDTO.Details)
                {
                    var detail = new OrderDetail
                    {
                        OrdersId = order.Id,
                        ProductId = d.ProductId,
                        Quantity = d.Quantity,
                        Price = d.Price,
                        CreatedAt = DateTime.UtcNow
                    };
                    await _orderDetailRepository.AddOrderDetail(detail);
                    total += (d.Price ?? 0) * (d.Quantity ?? 0);
                }
            }
            order.TotalAmount = total;
            await _ordersRepository.UpdateOrder(order);
            return order.Id;
        }
    }
}
