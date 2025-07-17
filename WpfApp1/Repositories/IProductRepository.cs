using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using WpfApp1.Models;

namespace WpfApp1.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task DeleteAsync(int id);
        Task<IEnumerable<Product>> GetByCategoryAsync(string category);
        Task<bool> ExistsAsync(int id);
    }
} 