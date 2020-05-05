using SupermarketManagement.Core.Models;
using System.Windows;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for EditSupplierUserControl.xaml
    /// </summary>
    public partial class EditSupplierUserControl : UserControl
    {
        private Supplier _supplier;
        public EditSupplierUserControl(Supplier supplier)
        {
            _supplier = supplier;
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            LoadEdit(_supplier);
        }

        private void LoadEdit(Supplier supplier)
        {
            this.DataContext = supplier;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
