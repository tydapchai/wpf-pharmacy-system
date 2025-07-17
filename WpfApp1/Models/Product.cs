using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WpfApp1.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        
        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }
        
        [StringLength(200)]
        public string? ImagePath { get; set; }
        
        [StringLength(300)]
        public string? ImageUrl { get; set; } // Đường dẫn tới ảnh trong thư mục images
        
        [StringLength(50)]
        public string Category { get; set; } = "General";
        
        [StringLength(100)]
        public string Manufacturer { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
} 