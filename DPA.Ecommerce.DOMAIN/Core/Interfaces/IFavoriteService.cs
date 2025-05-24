using DPA.Ecommerce.DOMAIN.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Ecommerce.DOMAIN.Core.Interfaces
{
    public interface IFavoriteService
    {
        Task<IEnumerable<FavoriteUserProductsDTO>> GetAllFavorites();
        Task<FavoriteDTO> GetFavoriteById(int id);
        Task<int> AddFavorite(FavoriteCreateDTO favoriteDTO);
        Task<bool> DeleteFavorite(int id);
    }
}
