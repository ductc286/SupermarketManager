using SupermarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for DetailPurchaseBillUserControl.xaml
    /// </summary>
    public partial class DetailPurchaseBillUserControl : UserControl
    {
        public PurchaseBill purchaseBill;
        public DetailPurchaseBillUserControl(PurchaseBill purchaseBill)
        {
            InitializeComponent();
            this.purchaseBill = purchaseBill;
            this.DataContext = purchaseBill;
            DataGrid_PurchaseBillDetail.DataContext = purchaseBill.PurchaseBillDetails;
            DataGrid_PurchaseBillDetail.ItemsSource = purchaseBill.PurchaseBillDetails;
        }
    }
}
