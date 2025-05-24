using System;

namespace DPA.Ecommerce.DOMAIN.Core.DTOs
{
    public class FavoriteDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class FavoriteCreateDTO
    {
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
    }

    public class FavoriteListDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class FavoriteUserProductsDTO
    {
        public int? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<FavoriteProductDTO> Products { get; set; } = new();
    }

    public class FavoriteProductDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
