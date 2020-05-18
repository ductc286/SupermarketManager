using Supermarketmanagement.PresentationLayer.UserControls;
using SupermarketManagement.Core.Models;
using System.Windows;

namespace Supermarketmanagement.PresentationLayer.Windows
{
    /// <summary>
    /// Interaction logic for DetailPurchaseBillUserWindow.xaml
    /// </summary>
    public partial class DetailPurchaseBillUserWindow : Window
    {

        public PurchaseBill purchaseBill;
        public DetailPurchaseBillUserWindow(PurchaseBill purchaseBill)
        {
            InitializeComponent();
            this.purchaseBill = purchaseBill;
            LoadData(purchaseBill);
        }

        private void LoadData(PurchaseBill purchaseBill)
        {
            DetailPurchaseBillUserControl detailPurchaseBillUserControl = new DetailPurchaseBillUserControl(purchaseBill);
            MainControl.Items.Add(detailPurchaseBillUserControl);
        }
    }
}
