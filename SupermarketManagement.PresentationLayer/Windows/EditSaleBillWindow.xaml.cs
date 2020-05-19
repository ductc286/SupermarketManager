using Supermarketmanagement.PresentationLayer.UserControls;
using SupermarketManagement.Core.Models;
using System.Windows;

namespace Supermarketmanagement.PresentationLayer.Windows
{
    /// <summary>
    /// Interaction logic for EditSaleBillWindow.xaml
    /// </summary>
    public partial class EditSaleBillWindow : Window
    {

        public EditSaleBillWindow(SaleBill saleBill)
        {
            InitializeComponent();
            EditSaleBillUserControl editSaleBillUserControl = new EditSaleBillUserControl(saleBill);
            MainControl.Items.Add(editSaleBillUserControl);
        }
    }
}
