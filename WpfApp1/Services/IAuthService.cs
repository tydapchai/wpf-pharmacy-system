using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public interface IAuthService
    {
        Task<bool> ValidateLoginAsync(string username, string password);
        Task<Account?> GetAccountByUsernameAsync(string username);
        Task<Account> CreateAccountAsync(Account account);
        Task<bool> UpdateBalanceAsync(int accountId, decimal newBalance);
        Task<Account?> GetAccountByIdAsync(int id);
    }
} 