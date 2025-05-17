using DPA.Ecommerce.DOMAIN.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Ecommerce.DOMAIN.Core.Interfaces
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrderDTO>> GetAllOrders();
        Task<OrderDTO> GetOrderById(int id);
        Task<int> AddOrder(OrderCreateDTO orderDTO);
        // Métodos de actualización y borrado pueden agregarse según necesidad
    }
}
