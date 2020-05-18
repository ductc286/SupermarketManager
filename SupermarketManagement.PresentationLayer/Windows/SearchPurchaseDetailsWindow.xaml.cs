using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using SupermarketManagement.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.Windows
{
    /// <summary>
    /// Interaction logic for SearchPurchaseDetailsWindow.xaml
    /// </summary>
    public partial class SearchPurchaseDetailsWindow : Window
    {
        private readonly IProductBusiness _productBusiness;
        private List<Product> _products;
        public Product product = null;
        public SearchPurchaseDetailsWindow()
        {
            InitializeComponent();
            _productBusiness = new ProductBusiness();
            LoadData();
        }


        private void LoadData()
        {
            _products = _productBusiness.GetAll();
            DataGrid_PurchaseBillDetail.DataContext = _products;
            DataGrid_PurchaseBillDetail.ItemsSource = _products;

        }


        private void SearchList(object sender, TextChangedEventArgs e)
        {
            var searchKeywork = Search.Text;
            var newList = new List<Product>();
            newList = GetListBySearchFull(searchKeywork);
            DataGrid_PurchaseBillDetail.ItemsSource = newList;
        }

        private List<Product> GetListBySearchFull(string searchKeywork)
        {
            int.TryParse(searchKeywork, out int productId);
            var result = _products.Where(p => p.ProductName.Contains(searchKeywork)
            || (p.Serial != null && p.Serial.Contains(searchKeywork))
            || p.ProductId == productId).ToList();
            return result;
        }


        private void DataGrid_PurchaseBillDetail_Changed(object sender, SelectionChangedEventArgs e)
        {
            product = (Product)DataGrid_PurchaseBillDetail.SelectedItem;
            this.Close();
        }
    }
}
