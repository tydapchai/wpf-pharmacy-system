using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category);
        Task<bool> UpdateStockAsync(int productId, int quantity);
    }
} 