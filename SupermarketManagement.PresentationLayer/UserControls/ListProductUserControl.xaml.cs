using Supermarketmanagement.PresentationLayer.Windows;
using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using SupermarketManagement.Core.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for ListProductUserControl.xaml
    /// </summary>
    public partial class ListProductUserControl : UserControl
    {
        private readonly IProductBusiness _productBusiness;
        public List<Product> products;

        public ListProductUserControl()
        {
            InitializeComponent();
            _productBusiness = new ProductBusiness();
            products = _productBusiness.GetAll();
            InitializeData();
        }

        /// <summary>
        /// List the methods needed for data initialization
        /// </summary>
        private void InitializeData()
        {
            LoadListProduct(products);
        }

        private void LoadListProduct(List<Product> products)
        {
            ListViewProducts.ItemsSource = products;
            
        }

        private void Edit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            var product = (Product)ListViewProducts.SelectedItem;
            if (product == null)
            {
                MessageBox.Show("Vui lòng chọn một mục trong danh sách!", "Edit", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                EditProductWindow editProductWindow = new EditProductWindow(product);
                editProductWindow.Owner = Application.Current.MainWindow; // We must also set the owner for this to work.
                editProductWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                //editProductWindow.Top = mainWindow.Top + 20;

                editProductWindow.Show();
            }
        }
    }
}
