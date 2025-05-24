using DPA.Ecommerce.DOMAIN.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Ecommerce.DOMAIN.Core.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<IEnumerable<Favorite>> GetAllFavorites();
        Task<Favorite> GetFavoriteById(int id);
        Task<int> AddFavorite(Favorite favorite);
        Task<bool> DeleteFavorite(int id);
    }
}
