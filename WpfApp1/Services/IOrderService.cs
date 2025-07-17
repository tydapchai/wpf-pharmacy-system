using WpfApp1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WpfApp1.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<List<Order>> GetOrdersByAccountIdAsync(int accountId);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
    }
} 