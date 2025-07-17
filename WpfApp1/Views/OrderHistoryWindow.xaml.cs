using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.Views
{
    public partial class OrderHistoryWindow : Window
    {
        private Account _account;
        private OrderService _orderService;
        private List<Order> _orders;

        public OrderHistoryWindow(Account account)
        {
            InitializeComponent();
            _account = account;
            _orderService = new OrderService();
            
            WelcomeText.Text = $"Chào mừng, {_account.FullName}!";
            
            LoadOrders();
        }

        public class ProductPurchaseSummary
        {
            public string ProductName { get; set; } = string.Empty;
            public int TotalQuantity { get; set; }
            public decimal TotalSpent { get; set; }
        }

        private async void LoadOrders()
        {
            try
            {
                _orders = await _orderService.GetOrdersByAccountIdAsync(_account.Id);
                
                // Load order items for each order
                foreach (var order in _orders)
                {
                    order.OrderItems = await _orderService.GetOrderItemsByOrderIdAsync(order.Id);
                    // Tính lại tổng giá tiền đơn hàng
                    order.TotalAmount = order.OrderItems.Sum(item => item.TotalPrice);
                }
                
                // Tổng hợp theo từng loại thuốc
                var allOrderItems = _orders.SelectMany(o => o.OrderItems);
                var summary = allOrderItems
                    .GroupBy(item => item.Product.Name)
                    .Select(g => new ProductPurchaseSummary
                    {
                        ProductName = g.Key,
                        TotalQuantity = g.Sum(x => x.Quantity),
                        TotalSpent = g.Sum(x => x.TotalPrice)
                    })
                    .ToList();
                OrdersItemsControl.ItemsSource = summary;
                
                if (summary.Count == 0)
                {
                    MessageBox.Show("Bạn chưa có đơn hàng nào.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lịch sử đơn hàng: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
} 