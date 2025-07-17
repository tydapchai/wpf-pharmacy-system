using System.Windows;
using WpfApp1.Models;
using WpfApp1.Services;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;
using System;

namespace WpfApp1.Views
{
    public partial class AddProductWindow : Window
    {
        private readonly ProductService _productService;
        public Product EditedProduct { get; private set; }
        private string _selectedImageFileName = null;
        public AddProductWindow()
        {
            InitializeComponent();
            _productService = new ProductService(new Repositories.ProductRepository(new Data.PharmacyDbContext()));
        }
        public AddProductWindow(Product product) : this()
        {
            this.Title = "Chỉnh sửa sản phẩm";
            TitleTextBlock.Text = "Chỉnh sửa sản phẩm";
            SaveButton.Content = "Cập nhật";
            
            // Gán dữ liệu cũ lên form
            NameTextBox.Text = product.Name;
            DescriptionTextBox.Text = product.Description;
            CategoryTextBox.Text = product.Category;
            ManufacturerTextBox.Text = product.Manufacturer;
            PriceTextBox.Text = product.Price.ToString();
            StockTextBox.Text = product.StockQuantity.ToString();
            EditedProduct = product;
        }
        private void ChooseImageButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
            if (dialog.ShowDialog() == true)
            {
                ImagePathTextBox.Text = dialog.FileName;
                _selectedImageFileName = dialog.FileName;
                PreviewImage.Source = new BitmapImage(new System.Uri(dialog.FileName));
            }
        }
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (EditedProduct == null)
            {
                // Thêm mới
                var product = new Product
                {
                    Name = NameTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    Category = CategoryTextBox.Text,
                    Manufacturer = ManufacturerTextBox.Text,
                    Price = decimal.TryParse(PriceTextBox.Text, out var price) ? price : 0,
                    StockQuantity = int.TryParse(StockTextBox.Text, out var stock) ? stock : 0
                };
                // Xử lý ảnh
                if (!string.IsNullOrEmpty(_selectedImageFileName) && File.Exists(_selectedImageFileName))
                {
                    string imagesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
                    if (!Directory.Exists(imagesDir)) Directory.CreateDirectory(imagesDir);
                    string ext = Path.GetExtension(_selectedImageFileName);
                    string newFileName = Guid.NewGuid().ToString() + ext;
                    string destPath = Path.Combine(imagesDir, newFileName);
                    File.Copy(_selectedImageFileName, destPath, true);
                    product.ImageUrl = "images/" + newFileName;
                }
                await _productService.CreateProductAsync(product);
                MessageBox.Show("Thêm thuốc thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                // Sửa
                EditedProduct.Name = NameTextBox.Text;
                EditedProduct.Description = DescriptionTextBox.Text;
                EditedProduct.Category = CategoryTextBox.Text;
                EditedProduct.Manufacturer = ManufacturerTextBox.Text;
                EditedProduct.Price = decimal.TryParse(PriceTextBox.Text, out var price) ? price : 0;
                EditedProduct.StockQuantity = int.TryParse(StockTextBox.Text, out var stock) ? stock : 0;
                // Nếu chọn ảnh mới khi sửa
                if (!string.IsNullOrEmpty(_selectedImageFileName) && File.Exists(_selectedImageFileName))
                {
                    string imagesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
                    if (!Directory.Exists(imagesDir)) Directory.CreateDirectory(imagesDir);
                    string ext = Path.GetExtension(_selectedImageFileName);
                    string newFileName = Guid.NewGuid().ToString() + ext;
                    string destPath = Path.Combine(imagesDir, newFileName);
                    File.Copy(_selectedImageFileName, destPath, true);
                    EditedProduct.ImageUrl = "images/" + newFileName;
                }
                this.DialogResult = true;
                this.Close();
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
} 