using DPA.Ecommerce.DOMAIN.Core.Entities;
using DPA.Ecommerce.DOMAIN.Core.Interfaces;
using DPA.Ecommerce.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPA.Ecommerce.DOMAIN.Infrastructure.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly StoreDbueContext _context;
        public FavoriteRepository(StoreDbueContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Favorite>> GetAllFavorites()
        {
            return await _context
                        .Favorite
                        .Include(p => p.Product)
                        .Include(u => u.User)
                        .ToListAsync();
        }

        public async Task<Favorite> GetFavoriteById(int id)
        {
            return await _context.Favorite.FindAsync(id);
        }

        public async Task<int> AddFavorite(Favorite favorite)
        {
            _context.Favorite.Add(favorite);
            await _context.SaveChangesAsync();
            return favorite.Id;
        }

        public async Task<bool> DeleteFavorite(int id)
        {
            var favorite = await _context.Favorite.FindAsync(id);
            if (favorite == null) return false;
            _context.Favorite.Remove(favorite);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
