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
        // M�todos de actualizaci�n y borrado pueden agregarse seg�n necesidad
    }
}
