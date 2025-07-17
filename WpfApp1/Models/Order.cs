using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WpfApp1.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [Required]
        public int AccountId { get; set; }
        
        [Required]
        public decimal TotalAmount { get; set; }
        
        public DateTime OrderDate { get; set; } = DateTime.Now;
        
        [StringLength(50)]
        public string Status { get; set; } = "Pending";
        
        // Navigation properties
        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
} 