using System.Windows;
using WpfApp1.ViewModels;
using System.Windows.Controls;

namespace WpfApp1.Views
{
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            
            // Set up dependency injection (simplified for demo)
            var dbContext = new Data.PharmacyDbContext();
            var accountRepository = new Repositories.AccountRepository(dbContext);
            var authService = new Services.AuthService(accountRepository);
            
            DataContext = new RegisterViewModel(authService);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is RegisterViewModel vm)
            {
                vm.Password = ((PasswordBox)sender).Password;
            }
        }

        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is RegisterViewModel vm)
            {
                vm.ConfirmPassword = ((PasswordBox)sender).Password;
            }
        }

        private void Login_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Open login window first, then close register window
            var loginWindow = new WpfApp1.Views.LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
} 