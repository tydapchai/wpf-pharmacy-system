using WpfApp1.Data;
using WpfApp1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace WpfApp1.Services
{
    public class OrderService : IOrderService
    {
        public async Task<Order> CreateOrderAsync(Order order)
        {
            using (var db = new PharmacyDbContext())
            {
                db.Orders.Add(order);
                await db.SaveChangesAsync();
                return order;
            }
        }

        public async Task<List<Order>> GetOrdersByAccountIdAsync(int accountId)
        {
            using (var db = new PharmacyDbContext())
            {
                return await db.Orders
                    .Where(o => o.AccountId == accountId)
                    .Include(o => o.Account)
                    .OrderByDescending(o => o.OrderDate)
                    .ToListAsync();
            }
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            using (var db = new PharmacyDbContext())
            {
                return await db.Orders
                    .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                    .FirstOrDefaultAsync(o => o.Id == orderId);
            }
        }

        public async Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            using (var db = new PharmacyDbContext())
            {
                return await db.OrderItems
                    .Where(oi => oi.OrderId == orderId)
                    .Include(oi => oi.Product)
                    .ToListAsync();
            }
        }
    }
} 