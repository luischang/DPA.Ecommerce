using DPA.Ecommerce.DOMAIN.Core.DTOs;
using DPA.Ecommerce.DOMAIN.Core.Entities;
using DPA.Ecommerce.DOMAIN.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPA.Ecommerce.DOMAIN.Core.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;
        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<IEnumerable<FavoriteUserProductsDTO>> GetAllFavorites()
        {
            var favorites = await _favoriteRepository.GetAllFavorites();
            var grouped = favorites.Select(f => new FavoriteUserProductsDTO
            {
                UserId = f.UserId,
                FirstName = f.User?.FirstName,
                LastName = f.User?.LastName,
                Products = new List<FavoriteProductDTO>
                {
                    new FavoriteProductDTO
                    {
                        Id = f.Product.Id,
                        Description = f.Product.Description,
                        ImageUrl = f.Product.ImageUrl
                    }
                }
            }).ToList();

            //var grouped = favorites
            //    .Where(f => f.User != null && f.Product != null)
            //    .GroupBy(f => f.User)
            //    .Select(g => new FavoriteUserProductsDTO
            //    {
            //        UserId = g.Key.Id,
            //        FirstName = g.Key.FirstName,
            //        LastName = g.Key.LastName,
            //        Products = g.Select(f => new FavoriteProductDTO
            //        {
            //            Id = f.Product.Id,
            //            Description = f.Product.Description,
            //            ImageUrl = f.Product.ImageUrl
            //        }).ToList()
            //    });
            return grouped;
        }

        public async Task<FavoriteDTO> GetFavoriteById(int id)
        {
            var f = await _favoriteRepository.GetFavoriteById(id);
            if (f == null) return null;
            return new FavoriteDTO
            {
                Id = f.Id,
                UserId = f.UserId,
                ProductId = f.ProductId,
                CreatedAt = f.CreatedAt
            };
        }

        public async Task<int> AddFavorite(FavoriteCreateDTO favoriteDTO)
        {
            var favorite = new Favorite
            {
                UserId = favoriteDTO.UserId,
                ProductId = favoriteDTO.ProductId,
                CreatedAt = System.DateTime.UtcNow
            };
            return await _favoriteRepository.AddFavorite(favorite);
        }

        public async Task<bool> DeleteFavorite(int id)
        {
            return await _favoriteRepository.DeleteFavorite(id);
        }
    }
}
