using Supermarketmanagement.Core.ViewModels;
using Supermarketmanagement.PresentationLayer.UserControls;
using SupermarketManagement.Core.Models;
using System.Windows;

namespace Supermarketmanagement.PresentationLayer.Windows
{
    /// <summary>
    /// Interaction logic for EditSupplierWindow.xaml
    /// </summary>
    public partial class EditSupplierWindow : Window
    {

        public SupplierViewModel supplierViewModel;
        public EditSupplierWindow(Supplier supplier)
        {
            InitializeComponent();
            this.supplierViewModel = new SupplierViewModel()
            {
                SupplierId = supplier.SupplierId,
                SupplierName = supplier.SupplierName,
                Description = supplier.Description
            };
            this.DataContext = supplierViewModel;
            
            LoadData(supplierViewModel);
        }
        
        private void LoadData(SupplierViewModel supplierViewModel)
        {
            EditSupplierUserControl editSupplierUserControl = new EditSupplierUserControl(supplierViewModel);
            MainControl.Items.Add(editSupplierUserControl);
        }
    }
}
