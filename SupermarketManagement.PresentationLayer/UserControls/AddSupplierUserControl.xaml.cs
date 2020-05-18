using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for AddSupplierUserControl.xaml
    /// </summary>
    public partial class AddSupplierUserControl : UserControl
    {
        private readonly ISupplierBusiness _supplierBusiness;
        public SupplierViewModel supplierViewModel;
        public AddSupplierUserControl()
        {
            _supplierBusiness = new SupplierBusiness();
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            LoadAdd();
        }

        private void LoadAdd()
        {
            supplierViewModel = new SupplierViewModel();
            this.DataContext = supplierViewModel;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (supplierViewModel.IsValidModel())
            {
                var isSuccess = _supplierBusiness.Add(supplierViewModel);
                if (isSuccess)
                {
                    MessageBox.Show("Đã thêm thành công!", "Add", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công!", "Add", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }

    }
}
