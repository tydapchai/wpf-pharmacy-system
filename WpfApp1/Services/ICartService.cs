using WpfApp1.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WpfApp1.Services
{
    public interface ICartService
    {
        Task<IEnumerable<CartItem>> GetCartItemsAsync(int accountId);
        Task<CartItem> AddToCartAsync(CartItem cartItem);
        Task UpdateCartItemAsync(CartItem cartItem);
        Task RemoveFromCartAsync(int cartItemId);
        Task ClearCartAsync(int accountId);
    }
} 