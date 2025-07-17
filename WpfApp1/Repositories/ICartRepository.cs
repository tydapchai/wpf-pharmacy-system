using WpfApp1.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WpfApp1.Repositories
{
    public interface ICartRepository
    {
        Task<IEnumerable<CartItem>> GetByAccountIdAsync(int accountId);
        Task<CartItem> AddAsync(CartItem cartItem);
        Task UpdateAsync(CartItem cartItem);
        Task DeleteAsync(int cartItemId);
        Task ClearByAccountIdAsync(int accountId);
    }
} 