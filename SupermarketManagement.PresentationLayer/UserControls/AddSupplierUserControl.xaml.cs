using SupermarketManagement.Core.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for AddSupplierUserControl.xaml
    /// </summary>
    public partial class AddSupplierUserControl : UserControl
    {
        private Supplier _supplier;
        public AddSupplierUserControl()
        {
            _supplier = new Supplier();
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            LoadAdd(_supplier);
        }

        private void LoadAdd(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
