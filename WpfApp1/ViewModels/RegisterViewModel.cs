using System;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfApp1.Models;
using WpfApp1.Services;
using System.Windows;

namespace WpfApp1.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private readonly IAuthService _authService;
        private string _username = string.Empty;
        private string _password = string.Empty;
        private string _confirmPassword = string.Empty;
        private string _fullName = string.Empty;
        private string _email = string.Empty;
        private string _errorMessage = string.Empty;

        public RegisterViewModel(IAuthService authService)
        {
            _authService = authService;
            RegisterCommand = new RelayCommand(async () => await RegisterAsync());
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged();
            }
        }

        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand RegisterCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private async Task RegisterAsync()
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Please enter both username and password.";
                return;
            }

            if (Password != ConfirmPassword)
            {
                ErrorMessage = "Passwords do not match.";
                return;
            }

            if (string.IsNullOrWhiteSpace(FullName))
            {
                ErrorMessage = "Please enter your full name.";
                return;
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                ErrorMessage = "Please enter your email.";
                return;
            }

            if (Password.Length < 6)
            {
                ErrorMessage = "Password must be at least 6 characters long.";
                return;
            }

            try
            {
                // Check if username already exists
                var existingAccount = await _authService.GetAccountByUsernameAsync(Username);
                if (existingAccount != null)
                {
                    ErrorMessage = "Username already exists. Please choose a different username.";
                    return;
                }

                // Create new account
                var newAccount = new Account
                {
                    Username = Username,
                    Password = Password, // Note: In real app, this should be hashed
                    FullName = FullName,
                    Email = Email,
                    Role = "User", // Default role for new registrations
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true
                };

                var createdAccount = await _authService.CreateAccountAsync(newAccount);
                if (createdAccount != null)
                {
                    MessageBox.Show("Registration successful! You can now login with your new account.", 
                                   "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    // Đóng RegisterWindow và mở LoginWindow
                    foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                    {
                        if (window is WpfApp1.Views.RegisterWindow)
                        {
                            var loginWindow = new WpfApp1.Views.LoginWindow();
                            loginWindow.Show();
                            window.Close();
                            break;
                        }
                    }
                }
                else
                {
                    ErrorMessage = "Registration failed. Please try again.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Registration error: {ex.Message}";
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 