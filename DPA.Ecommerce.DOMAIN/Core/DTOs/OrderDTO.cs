using System;
using System.Collections.Generic;

namespace DPA.Ecommerce.DOMAIN.Core.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UserId { get; set; }
        public string? Status { get; set; }
        public decimal? TotalAmount { get; set; }
        public List<OrderDetailDTO>? Details { get; set; }
    }
    public class OrderCreateDTO
    {
        public int? UserId { get; set; }
        public List<OrderDetailCreateDTO>? Details { get; set; }
    }
    public class OrderDetailDTO
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
    }
    public class OrderDetailCreateDTO
    {
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}
