using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for ListSuplierUserControl.xaml
    /// </summary>
    public partial class ListSupplierUserControl : UserControl
    {
        private readonly ISupplierBusiness _supplierBusiness;
        public ListSupplierUserControl()
        {
            _supplierBusiness = new SupplierBusiness();
            InitializeComponent();
            InitializeData();
        }

        /// <summary>
        /// List the methods needed for data initialization
        /// </summary>
        private void InitializeData()
        {
            LoadList();
        }

        private void LoadList()
        {
            var listProducts = _supplierBusiness.GetAll();
            ListSuppliers.ItemsSource = listProducts;
        }
    }
}
