using DPA.Ecommerce.DOMAIN.Core.DTOs;
using DPA.Ecommerce.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;
        public FavoritesController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteUserProductsDTO>>> GetAll()
        {
            var favorites = await _favoriteService.GetAllFavorites();
            return Ok(favorites);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteDTO>> GetById(int id)
        {
            var favorite = await _favoriteService.GetFavoriteById(id);
            if (favorite == null) return NotFound();
            return Ok(favorite);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(FavoriteCreateDTO dto)
        {
            var id = await _favoriteService.AddFavorite(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _favoriteService.DeleteFavorite(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
