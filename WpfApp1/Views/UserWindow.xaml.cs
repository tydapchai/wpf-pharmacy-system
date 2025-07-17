using System.Windows;
using WpfApp1.Models;
using WpfApp1.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.Generic;
using System.Collections;

namespace WpfApp1.Views
{
    public partial class UserWindow : Window, INotifyPropertyChanged
    {
        private Account _account;
        private ProductService _productService;
        private CartService _cartService;
        private OrderService _orderService;
        
        public ObservableCollection<Product> AllProducts { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Product> CurrentPageProducts { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<CartItem> CartItems { get; set; } = new ObservableCollection<CartItem>();
        
        // Property để binding với username
        public Account CurrentAccount { get; set; }
        
        // Paging properties
        private int _currentPage = 1;
        private int _pageSize = 6;
        private int _totalPages = 1;
        
        public string PageInfo => $"Page {_currentPage} of {_totalPages}";
        public bool CanGoToPreviousPage => _currentPage > 1;
        public bool CanGoToNextPage => _currentPage < _totalPages;
        
        // Cart properties
        public decimal CartTotal => CartItems.Sum(item => item.TotalPrice);
        
        // Thêm thuộc tính lưu toàn bộ sản phẩm gốc
        private List<Product> MasterProducts = new List<Product>();
        
        public event PropertyChangedEventHandler? PropertyChanged;
        
        public UserWindow(Account account)
        {
            InitializeComponent();
            _account = account;
            CurrentAccount = account;
            _productService = new ProductService(new Repositories.ProductRepository(new Data.PharmacyDbContext()));
            _cartService = new CartService(new Repositories.CartRepository(new Data.PharmacyDbContext()));
            _orderService = new OrderService();
            DataContext = this;
            LoadProducts();
            LoadCartItems();
        }

        private async void LoadProducts()
        {
            AllProducts.Clear();
            MasterProducts.Clear();
            // Luôn tạo mới ProductService với DbContext mới để lấy dữ liệu mới nhất
            var productService = new ProductService(new Repositories.ProductRepository(new Data.PharmacyDbContext()));
            var products = await productService.GetAllProductsAsync();
            foreach (var p in products)
            {
                AllProducts.Add(p);
                MasterProducts.Add(p);
            }
            _currentPage = 1;
            UpdatePaging();
            OnPropertyChanged(nameof(AllProducts));
            OnPropertyChanged(nameof(CurrentPageProducts));
        }

        private async void LoadCartItems()
        {
            CartItems.Clear();
            var cartItems = await _cartService.GetCartItemsAsync(_account.Id);
            foreach (var item in cartItems)
            {
                CartItems.Add(item);
            }
            OnPropertyChanged(nameof(CartTotal));
        }

        private void UpdatePaging()
        {
            _totalPages = (int)Math.Ceiling((double)AllProducts.Count / _pageSize);
            if (_currentPage > _totalPages) _currentPage = _totalPages;
            if (_currentPage < 1) _currentPage = 1;
            
            CurrentPageProducts.Clear();
            var startIndex = (_currentPage - 1) * _pageSize;
            var endIndex = Math.Min(startIndex + _pageSize, AllProducts.Count);
            
            for (int i = startIndex; i < endIndex; i++)
            {
                CurrentPageProducts.Add(AllProducts[i]);
            }
            
            OnPropertyChanged(nameof(PageInfo));
            OnPropertyChanged(nameof(CanGoToPreviousPage));
            OnPropertyChanged(nameof(CanGoToNextPage));
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string keyword = SearchTextBox.Text.Trim().ToLower();
            AllProducts.Clear();
            IEnumerable<Product> filtered;
            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = MasterProducts.Where(p =>
                    p.Name.ToLower().Contains(keyword) ||
                    p.Category.ToLower().Contains(keyword) ||
                    p.Manufacturer.ToLower().Contains(keyword));
            }
            else
            {
                filtered = MasterProducts;
            }
            foreach (var p in filtered)
            {
                AllProducts.Add(p);
            }
            _currentPage = 1;
            UpdatePaging();
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                UpdatePaging();
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                UpdatePaging();
            }
        }

        private async void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is FrameworkElement fe && fe.Tag is Product product)
                {
                    // Lấy lại cart từ database để đảm bảo đúng user
                    var dbCartItems = (await _cartService.GetCartItemsAsync(_account.Id)).ToList();
                    var existingItem = dbCartItems.FirstOrDefault(item => item.ProductId == product.Id);

                    if (existingItem != null)
                    {
                        // Tăng số lượng nếu đã có
                        int? quantity = ShowInputQuantityDialog("Chọn số lượng", $"Nhập số lượng muốn thêm cho {product.Name}:", 1);
                        if (quantity == null) return;
                        existingItem.Quantity += quantity.Value;
                        existingItem.TotalPrice = existingItem.Quantity * product.Price;
                        await _cartService.UpdateCartItemAsync(existingItem);

                        // Giảm tồn kho
                        using (var db = new Data.PharmacyDbContext())
                        {
                            var dbProduct = db.Products.FirstOrDefault(p => p.Id == product.Id);
                            if (dbProduct != null)
                            {
                                dbProduct.StockQuantity -= quantity.Value;
                                if (dbProduct.StockQuantity < 0) dbProduct.StockQuantity = 0;
                                db.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        // Hiển thị hộp thoại nhập số lượng
                        int? quantity = ShowInputQuantityDialog("Chọn số lượng", $"Nhập số lượng cho {product.Name}:", 1);
                        if (quantity == null) return; // Người dùng bấm Hủy

                        var cartItem = new Models.CartItem
                        {
                            AccountId = _account.Id,
                            ProductId = product.Id,
                            Quantity = quantity.Value,
                            TotalPrice = product.Price * quantity.Value
                        };
                        var addedItem = await _cartService.AddToCartAsync(cartItem);

                        // Giảm tồn kho
                        using (var db = new Data.PharmacyDbContext())
                        {
                            var dbProduct = db.Products.FirstOrDefault(p => p.Id == product.Id);
                            if (dbProduct != null)
                            {
                                dbProduct.StockQuantity -= quantity.Value;
                                if (dbProduct.StockQuantity < 0) dbProduct.StockQuantity = 0;
                                db.SaveChanges();
                            }
                        }
                    }

                    // Reload lại CartItems để hiển thị đúng
                    CartItems.Clear();
                    var updatedCart = await _cartService.GetCartItemsAsync(_account.Id);
                    foreach (var item in updatedCart)
                        CartItems.Add(item);

                    OnPropertyChanged(nameof(CartTotal));
                    LoadProducts(); // Cập nhật lại danh sách sản phẩm trên view
                    UpdatePaging();
                    OnPropertyChanged(nameof(AllProducts));
                    OnPropertyChanged(nameof(CurrentPageProducts));
                    MessageBox.Show($"Đã thêm {product.Name} vào giỏ hàng!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null)
                    message += "\nInner: " + ex.InnerException.Message;
                if (ex.InnerException?.InnerException != null)
                    message += "\nInner2: " + ex.InnerException.InnerException.Message;
                MessageBox.Show($"Lỗi khi thêm vào giỏ hàng: {message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void AddToCartCard_Click(object sender, RoutedEventArgs e)
        {
            await Dispatcher.InvokeAsync(async () =>
            {
                try
                {
                    if (sender is FrameworkElement fe && fe.Tag is Product product)
                    {
                        // Lấy lại cart từ database để đảm bảo đúng user
                        var dbCartItems = (await _cartService.GetCartItemsAsync(_account.Id)).ToList();
                        var existingItem = dbCartItems.FirstOrDefault(item => item.ProductId == product.Id);

                        if (existingItem != null)
                        {
                            int? quantity = ShowInputQuantityDialog("Chọn số lượng", $"Nhập số lượng muốn thêm cho {product.Name}:", 1);
                            if (quantity == null) return;
                            existingItem.Quantity += quantity.Value;
                            existingItem.TotalPrice = existingItem.Quantity * product.Price;
                            await _cartService.UpdateCartItemAsync(existingItem);

                            // Giảm tồn kho
                            using (var db = new Data.PharmacyDbContext())
                            {
                                var dbProduct = db.Products.FirstOrDefault(p => p.Id == product.Id);
                                if (dbProduct != null)
                                {
                                    dbProduct.StockQuantity -= quantity.Value;
                                    if (dbProduct.StockQuantity < 0) dbProduct.StockQuantity = 0;
                                    db.SaveChanges();
                                }
                            }
                        }
                        else
                        {
                            int? quantity = ShowInputQuantityDialog("Chọn số lượng", $"Nhập số lượng cho {product.Name}:", 1);
                            if (quantity == null) return;

                            var cartItem = new Models.CartItem
                            {
                                AccountId = _account.Id,
                                ProductId = product.Id,
                                Quantity = quantity.Value,
                                TotalPrice = product.Price * quantity.Value
                            };
                            var addedItem = await _cartService.AddToCartAsync(cartItem);

                            // Giảm tồn kho
                            using (var db = new Data.PharmacyDbContext())
                            {
                                var dbProduct = db.Products.FirstOrDefault(p => p.Id == product.Id);
                                if (dbProduct != null)
                                {
                                    dbProduct.StockQuantity -= quantity.Value;
                                    if (dbProduct.StockQuantity < 0) dbProduct.StockQuantity = 0;
                                    db.SaveChanges();
                                }
                            }
                        }
                        LoadCartItems();
                        LoadProducts();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm vào giỏ: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        private async void RemoveFromCart_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement fe && fe.Tag is Models.CartItem cartItem)
            {
                await _cartService.RemoveFromCartAsync(cartItem.Id);
                CartItems.Remove(cartItem);
                OnPropertyChanged(nameof(CartTotal));

                // Tăng lại tồn kho
                using (var db = new Data.PharmacyDbContext())
                {
                    var dbProduct = db.Products.FirstOrDefault(p => p.Id == cartItem.ProductId);
                    if (dbProduct != null)
                    {
                        dbProduct.StockQuantity += cartItem.Quantity;
                        db.SaveChanges();
                    }
                }

                MessageBox.Show($"Đã xóa {cartItem.Product.Name} khỏi giỏ hàng!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadProducts(); // Cập nhật lại danh sách sản phẩm trên view
                UpdatePaging();
                OnPropertyChanged(nameof(AllProducts));
                OnPropertyChanged(nameof(CurrentPageProducts));
            }
        }

        private async void Checkout_Click(object sender, RoutedEventArgs e)
        {
            if (CartItems.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống! Vui lòng thêm sản phẩm vào giỏ hàng.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show($"Tổng tiền: {CartTotal:C}\nBạn có muốn thanh toán?", "Xác nhận thanh toán", MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    // Kiểm tra số dư tài khoản
                    using (var db = new Data.PharmacyDbContext())
                    {
                        var dbAccount = db.Accounts.FirstOrDefault(a => a.Id == _account.Id);
                        if (dbAccount != null)
                        {
                            if (dbAccount.Balance < CartTotal)
                            {
                                MessageBox.Show("Số dư tài khoản không đủ để thanh toán!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            dbAccount.Balance -= CartTotal;
                            db.SaveChanges();

                            // Cập nhật lại balance trên view
                            _account.Balance = dbAccount.Balance;
                            CurrentAccount.Balance = dbAccount.Balance;
                            OnPropertyChanged(nameof(CurrentAccount));
                        }
                    }

                    // Tạo đơn hàng
                    var order = new Order
                    {
                        AccountId = _account.Id,
                        OrderDate = DateTime.Now,
                        TotalAmount = CartTotal,
                        Status = "Completed"
                    };

                    // Thêm các item vào đơn hàng
                    foreach (var cartItem in CartItems)
                    {
                        var orderItem = new OrderItem
                        {
                            ProductId = cartItem.ProductId,
                            Quantity = cartItem.Quantity,
                            UnitPrice = cartItem.Product.Price,
                            TotalPrice = cartItem.Quantity * cartItem.Product.Price
                        };
                        order.OrderItems.Add(orderItem);
                    }

                    // Lưu đơn hàng vào database
                    await _orderService.CreateOrderAsync(order);

                    // Xóa giỏ hàng
                    await _cartService.ClearCartAsync(_account.Id);
                    CartItems.Clear();
                    OnPropertyChanged(nameof(CartTotal));

                    MessageBox.Show("Thanh toán thành công! Cảm ơn bạn đã mua hàng.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi thanh toán: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Mở lại cửa sổ đăng nhập
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            Application.Current.MainWindow = loginWindow;

            // Đóng cửa sổ user hiện tại
            this.Close();
        }

        private void OrderHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            var orderHistoryWindow = new Views.OrderHistoryWindow(_account);
            orderHistoryWindow.Show();
        }

        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị hộp thoại nhập số tiền
            var inputDialog = new Window
            {
                Title = "Nạp tiền",
                Width = 300,
                Height = 150,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ResizeMode = ResizeMode.NoResize
            };

            var stack = new StackPanel { Margin = new Thickness(10) };
            stack.Children.Add(new TextBlock { Text = "Nhập số tiền muốn nạp:", Margin = new Thickness(0, 0, 0, 10) });

            var textBox = new TextBox { Text = "0", Margin = new Thickness(0, 0, 0, 10) };
            stack.Children.Add(textBox);

            var buttonPanel = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right };
            var okButton = new Button { Content = "OK", Width = 60, Margin = new Thickness(0, 0, 10, 0) };
            var cancelButton = new Button { Content = "Hủy", Width = 60 };
            buttonPanel.Children.Add(okButton);
            buttonPanel.Children.Add(cancelButton);
            stack.Children.Add(buttonPanel);

            decimal? result = null;
            okButton.Click += (s, ev) =>
            {
                if (decimal.TryParse(textBox.Text, out decimal value) && value > 0)
                {
                    result = value;
                    inputDialog.DialogResult = true;
                    inputDialog.Close();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số tiền hợp lệ (>0).");
                }
            };
            cancelButton.Click += (s, ev) =>
            {
                inputDialog.DialogResult = false;
                inputDialog.Close();
            };

            inputDialog.Content = stack;
            inputDialog.ShowDialog();
            if (result == null) return;

            // Cập nhật balance trong database
            using (var db = new Data.PharmacyDbContext())
            {
                var dbAccount = db.Accounts.FirstOrDefault(a => a.Id == _account.Id);
                if (dbAccount != null)
                {
                    dbAccount.Balance += result.Value;
                    db.SaveChanges();
                    _account.Balance = dbAccount.Balance;
                    CurrentAccount.Balance = dbAccount.Balance;
                    OnPropertyChanged(nameof(CurrentAccount));
                    MessageBox.Show($"Nạp {result.Value:N2} thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản để nạp tiền.");
                }
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Hàm hiển thị hộp thoại nhập số lượng
        public static int? ShowInputQuantityDialog(string title, string prompt, int defaultValue = 1)
        {
            var inputDialog = new Window
            {
                Title = title,
                Width = 300,
                Height = 150,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ResizeMode = ResizeMode.NoResize
            };

            var stack = new StackPanel { Margin = new Thickness(10) };
            stack.Children.Add(new TextBlock { Text = prompt, Margin = new Thickness(0, 0, 0, 10) });

            var textBox = new TextBox { Text = defaultValue.ToString(), Margin = new Thickness(0, 0, 0, 10) };
            stack.Children.Add(textBox);

            var buttonPanel = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right };
            var okButton = new Button { Content = "OK", Width = 60, Margin = new Thickness(0, 0, 10, 0) };
            var cancelButton = new Button { Content = "Hủy", Width = 60 };
            buttonPanel.Children.Add(okButton);
            buttonPanel.Children.Add(cancelButton);
            stack.Children.Add(buttonPanel);

            int? result = null;
            okButton.Click += (s, e) =>
            {
                if (int.TryParse(textBox.Text, out int value) && value > 0)
                {
                    result = value;
                    inputDialog.DialogResult = true;
                    inputDialog.Close();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số lượng hợp lệ (>0).");
                }
            };
            cancelButton.Click += (s, e) =>
            {
                inputDialog.DialogResult = false;
                inputDialog.Close();
            };

            inputDialog.Content = stack;
            inputDialog.ShowDialog();
            return result;
        }
    }
} 