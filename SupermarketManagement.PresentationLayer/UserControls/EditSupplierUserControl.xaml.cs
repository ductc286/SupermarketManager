using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using System.Windows;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for EditSupplierUserControl.xaml
    /// </summary>
    public partial class EditSupplierUserControl : UserControl
    {
        public SupplierViewModel supplierViewModel;
        private readonly ISupplierBusiness _supplierBusiness;
        public EditSupplierUserControl(SupplierViewModel supplierViewModel)
        {
            _supplierBusiness = new SupplierBusiness();
            this.supplierViewModel = supplierViewModel;
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            LoadEdit(supplierViewModel);
        }

        private void LoadEdit(SupplierViewModel supplierViewModel)
        {
            this.DataContext = supplierViewModel;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (supplierViewModel.IsValidModel())
            {
                var isUpdate = _supplierBusiness.Update(supplierViewModel);
                if (isUpdate)
                {
                    MessageBox.Show("Đã cập nhật thành công!", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công!", "Update", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
