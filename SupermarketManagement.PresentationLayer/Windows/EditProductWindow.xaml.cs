using Supermarketmanagement.PresentationLayer.UserControls;
using SupermarketManagement.Core.Models;
using System.Windows;

namespace Supermarketmanagement.PresentationLayer.Windows
{
    /// <summary>
    /// Interaction logic for EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        public EditProductWindow(Product product)
        {
            InitializeComponent();
            LoadData(product);
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Owner = Application.Current.MainWindow;
        }



        private void LoadData(Product product)
        {
            EditProductUserControl editProductUserControl = new EditProductUserControl(product);
            MainControl.Items.Add(editProductUserControl);
        }
    }
}
