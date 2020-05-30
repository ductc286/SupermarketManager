using Supermarketmanagement.Core.ViewModels;
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
    /// Interaction logic for ListSuplierUserControl.xaml
    /// </summary>
    public partial class ListSupplierUserControl : UserControl
    {
        private readonly ISupplierBusiness _supplierBusiness;
        public List<Supplier> suppliers;
        public ListSupplierUserControl()
        {
            InitializeComponent();
            _supplierBusiness = new SupplierBusiness();
            
            InitializeData();
        }

        /// <summary>
        /// List the methods needed for data initialization
        /// </summary>
        private void InitializeData()
        {
            suppliers = _supplierBusiness.GetAll();
            ListSuppliers.ItemsSource = suppliers;
            ListSuppliers.Items.Refresh();
        }


        private void OpenWindow_Edit(object sender, System.Windows.RoutedEventArgs e)
        {
            var supplier = (Supplier)ListSuppliers.SelectedItem;
            if (supplier == null)
            {
                MessageBox.Show("Vui lòng chọn một mục trong danh sách!", "Edit", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                //EditSupplierWindow editSupplierWindow = new EditSupplierWindow(supplier);
                //editSupplierWindow.Show();
                EditSupplierUserControl editSupplierUserControl = new EditSupplierUserControl(supplier);
                DialogWindow dialogWindow = new DialogWindow(editSupplierUserControl, UsecaseStringContants.editSupplier);
                dialogWindow.ShowDialog();
                InitializeData();
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var obj = (Supplier)ListSuppliers.SelectedItem;
            if (obj == null)
            {
                MessageBox.Show("Chưa có mục nào được chọn!", "Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            else if (obj != null)
            {
                var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này?", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (confirm == MessageBoxResult.OK)
                {
                    bool isSuccess = _supplierBusiness.Delete(obj.SupplierId);
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
    }
}
