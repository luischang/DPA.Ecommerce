using DPA.Ecommerce.DOMAIN.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Ecommerce.DOMAIN.Core.Interfaces
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Orders>> GetAllOrders();
        Task<Orders> GetOrderById(int id);
        Task<int> AddOrder(Orders order);
        Task<bool> UpdateOrder(Orders order);
        Task<bool> DeleteOrder(int id);
    }
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderId(int orderId);
        Task<int> AddOrderDetail(OrderDetail detail);
        Task<bool> DeleteOrderDetail(int id);
    }
}
