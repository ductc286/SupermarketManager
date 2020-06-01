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

        private IPurchaseBillBusiness _purchaseBillBusiness;
        public List<PurchaseBill> purchaseBills;
        public ListPurchaseBillUserControl()
        {
            InitializeComponent();
            InitializeData();
        }

        /// <summary>
        /// List the methods needed for data initialization
        /// </summary>
        private void InitializeData()
        {
            _purchaseBillBusiness = new PurchaseBillBusiness();
            purchaseBills = _purchaseBillBusiness.GetAll();
            DataContext = purchaseBills;
            ListPurchaseBills.ItemsSource = purchaseBills;
        }

        private void Open_EditPurchaseBill(object sender, RoutedEventArgs e)
        {
            var purchaseBill = (PurchaseBill)ListPurchaseBills.SelectedItem;
            if (purchaseBill != null)
            {
                EditPurchaseBillUserControl editPurchaseBillUserControl = new EditPurchaseBillUserControl(purchaseBill);
                DialogWindow dialogWindow = new DialogWindow(editPurchaseBillUserControl, UsecaseStringContants.editPurchaseBill, editPurchaseBillUserControl.Width, editPurchaseBillUserControl.Height);
                dialogWindow.ShowDialog();
            }
        }

        private void Open_DetailPurchaseBill(object sender, RoutedEventArgs e)
        {
            var purchaseBill = (PurchaseBill)ListPurchaseBills.SelectedItem;
            if (purchaseBill != null)
            {
                DetailPurchaseBillUserControl detailPurchaseBillUserControl = new DetailPurchaseBillUserControl(purchaseBill);
                DialogWindow dialogWindow = new DialogWindow(detailPurchaseBillUserControl, UsecaseStringContants.detailPurchaseBill, detailPurchaseBillUserControl.Width, detailPurchaseBillUserControl.Height);
                dialogWindow.ShowDialog();
            }
            
        }

        private void ButtonReload_Click(object sender, RoutedEventArgs e)
        {
            InitializeData();
        }
    }
}
