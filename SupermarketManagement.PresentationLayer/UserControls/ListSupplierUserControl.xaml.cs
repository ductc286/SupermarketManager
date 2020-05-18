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
            suppliers = _supplierBusiness.GetAll();
            InitializeData();
        }

        /// <summary>
        /// List the methods needed for data initialization
        /// </summary>
        private void InitializeData()
        {
            LoadList(suppliers);
        }

        public void LoadList(List<Supplier> suppliers)
        {
            ListSuppliers.ItemsSource = suppliers;
            
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
                EditSupplierWindow editSupplierWindow = new EditSupplierWindow(supplier);
                editSupplierWindow.Show();
            }
        }
    }
}
