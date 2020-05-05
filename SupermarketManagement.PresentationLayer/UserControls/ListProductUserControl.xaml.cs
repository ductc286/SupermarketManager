using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using System;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for ListProductUserControl.xaml
    /// </summary>
    public partial class ListProductUserControl : UserControl
    {
        private readonly IProductBusiness _productBusiness;
        public ListProductUserControl()
        {
            _productBusiness = new ProductBusiness();
            InitializeComponent();
            InitializeData();
        }

        /// <summary>
        /// List the methods needed for data initialization
        /// </summary>
        private void InitializeData()
        {
            LoadListProduct();
        }

        private void LoadListProduct()
        {
            var listProducts = _productBusiness.GetAll();
            ListViewProducts.ItemsSource = listProducts;
        }
    }
}
