using Supermarketmanagement.PresentationLayer.UserControls;
using SupermarketManagement.Core.Models;
using System.Windows;

namespace Supermarketmanagement.PresentationLayer.Windows
{
    /// <summary>
    /// Interaction logic for EditPurchaseBillWindow.xaml
    /// </summary>
    public partial class EditPurchaseBillWindow : Window
    {

        public EditPurchaseBillWindow(PurchaseBill purchaseBill)
        {
            InitializeComponent();
            EditPurchaseBillUserControl editPurchaseBillUserControl = new EditPurchaseBillUserControl(purchaseBill);
            MainControl.Items.Add(editPurchaseBillUserControl);
        }
    }
}
