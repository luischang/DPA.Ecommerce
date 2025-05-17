using DPA.Ecommerce.DOMAIN.Core.Entities;
using DPA.Ecommerce.DOMAIN.Core.Interfaces;
using DPA.Ecommerce.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPA.Ecommerce.DOMAIN.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly StoreDbueContext _context;
        public OrdersRepository(StoreDbueContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            return await _context.Orders.Include(o => o.OrderDetail).ToListAsync();
        }
        public async Task<Orders> GetOrderById(int id)
        {
            return await _context.Orders.Include(o => o.OrderDetail).FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task<int> AddOrder(Orders order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }
        public async Task<bool> UpdateOrder(Orders order)
        {
            _context.Orders.Update(order);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return false;
            _context.Orders.Remove(order);
            return await _context.SaveChangesAsync() > 0;
        }
    }

    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly StoreDbueContext _context;
        public OrderDetailRepository(StoreDbueContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderId(int orderId)
        {
            return await _context.OrderDetail.Where(od => od.OrdersId == orderId).ToListAsync();
        }
        public async Task<int> AddOrderDetail(OrderDetail detail)
        {
            await _context.OrderDetail.AddAsync(detail);
            await _context.SaveChangesAsync();
            return detail.Id;
        }
        public async Task<bool> DeleteOrderDetail(int id)
        {
            var detail = await _context.OrderDetail.FindAsync(id);
            if (detail == null) return false;
            _context.OrderDetail.Remove(detail);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
