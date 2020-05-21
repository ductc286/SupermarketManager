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
    /// Interaction logic for ListPurchaseBillUserControl.xaml
    /// </summary>
    public partial class ListPurchaseBillUserControl : UserControl
    {

        private readonly IPurchaseBillBusiness _purchaseBillBusiness;
        public List<PurchaseBill> purchaseBills;
        public ListPurchaseBillUserControl()
        {
            InitializeComponent();
            _purchaseBillBusiness = new PurchaseBillBusiness();
            purchaseBills = _purchaseBillBusiness.GetAll();
            InitializeData();
        }

        /// <summary>
        /// List the methods needed for data initialization
        /// </summary>
        private void InitializeData()
        {
            DataContext = purchaseBills;
            LoadList(purchaseBills);
        }

        public void LoadList(List<PurchaseBill> purchaseBills)
        {
            ListPurchaseBills.ItemsSource = purchaseBills;
        }

        private void Open_EditPurchaseBill(object sender, RoutedEventArgs e)
        {
            var purchaseBill = (PurchaseBill)ListPurchaseBills.SelectedItem;
            if (purchaseBill != null)
            {
                EditPurchaseBillWindow editPurchaseBillWindow = new EditPurchaseBillWindow(purchaseBill);
                editPurchaseBillWindow.ShowDialog();
            }
        }

        private void Open_DetailPurchaseBill(object sender, RoutedEventArgs e)
        {
            var purchaseBill = (PurchaseBill)ListPurchaseBills.SelectedItem;
            if (purchaseBill != null)
            {
                DetailPurchaseBillUserWindow detailPurchaseBillUserWindow = new DetailPurchaseBillUserWindow(purchaseBill);
                detailPurchaseBillUserWindow.ShowDialog();
            }
            
        }
    }
}
