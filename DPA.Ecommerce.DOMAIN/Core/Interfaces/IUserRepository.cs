using DPA.Ecommerce.DOMAIN.Core.Entities;
using System.Threading.Tasks;

namespace DPA.Ecommerce.DOMAIN.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByIdAsync(int id);
        Task<int> AddUserAsync(User user);
    }
}
