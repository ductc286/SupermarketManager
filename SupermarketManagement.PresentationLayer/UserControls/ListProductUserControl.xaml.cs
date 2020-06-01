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
        private IProductBusiness _productBusiness;
        public List<Product> products;

        public ListProductUserControl()
        {
            InitializeComponent();
            InitializeData();
        }

        /// <summary>
        /// List the methods needed for data initialization
        /// </summary>
        private void InitializeData()
        {
            _productBusiness = new ProductBusiness();
            products = _productBusiness.GetAll();
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
                EditProductUserControl editProductUserControl = new EditProductUserControl(product);
                DialogWindow dialogWindow = new DialogWindow(editProductUserControl, UsecaseStringContants.editProduct, editProductUserControl.Width, editProductUserControl.Height);
                dialogWindow.ShowDialog();
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var obj = (Product)ListViewProducts.SelectedItem;
            if (obj == null)
            {
                MessageBox.Show("Chưa có mục nào được chọn!", "Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            else if (obj != null)
            {
                var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này?", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (confirm == MessageBoxResult.OK)
                {
                    bool isSuccess = _productBusiness.Delete(obj.ProductId);
                    if (isSuccess)
                    {
                        InitializeData();
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công, có thể mục này không được phép xóa.", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                }

            }
        }

        private void ButtonReload_Click(object sender, RoutedEventArgs e)
        {
            InitializeData();
        }
    }
}
