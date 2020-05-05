using SupermarketManagement.Core.Models;
using System.Windows;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for DetailSupplierUserControl.xaml
    /// </summary>
    public partial class DetailSupplierUserControl : UserControl
    {
        private Supplier _supplier;
        public DetailSupplierUserControl(Supplier supplier)
        {
            _supplier = supplier;
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            LoadDetail(_supplier);
        }

        private void LoadDetail(Supplier supplier)
        {
            this.DataContext = supplier;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
