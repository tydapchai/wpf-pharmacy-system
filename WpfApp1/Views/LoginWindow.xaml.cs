using System.Windows;
using WpfApp1.ViewModels;
using System.Windows.Controls;

namespace WpfApp1.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            
            // Set up dependency injection (simplified for demo)
            var dbContext = new Data.PharmacyDbContext();
            var accountRepository = new Repositories.AccountRepository(dbContext);
            var authService = new Services.AuthService(accountRepository);
            
            DataContext = new LoginViewModel(authService);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is WpfApp1.ViewModels.LoginViewModel vm)
            {
                vm.Password = ((PasswordBox)sender).Password;
            }
        }

        private void Register_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Open register window first, then close login window
            var registerWindow = new WpfApp1.Views.RegisterWindow();
            registerWindow.Show();
            this.Close();
        }
    }
} 