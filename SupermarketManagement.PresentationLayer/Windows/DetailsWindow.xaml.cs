using Supermarketmanagement.PresentationLayer.UserControls;
using SupermarketManagement.Core.Models;
using System.Windows;

namespace Supermarketmanagement.PresentationLayer.Windows
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        public DetailsWindow()
        {
            InitializeComponent();
        }

        public DetailsWindow(SaleBill saleBill)
        {
            DetailSaleBillUserControl detailSaleBillUserControl = new DetailSaleBillUserControl(saleBill);
            //this.Content = detailSaleBillUserControl;
            //MainControl.Items.Add(detailSaleBillUserControl);
            InitializeComponent();
            MainControl.Items.Add(detailSaleBillUserControl);

        }
    }
}
