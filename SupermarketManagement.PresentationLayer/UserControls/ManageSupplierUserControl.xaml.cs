using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for ManageSupplierUserControl.xaml
    /// </summary>
    public partial class ManageSupplierUserControl : UserControl
    {

        public ManageSupplierUserControl()
        {
            InitializeComponent();
            InitializeData();
        }

        /// <summary>
        /// List the methods needed for data initialization
        /// </summary>
        private void InitializeData()
        {
            DisplayList();
            DisplayDetail();
        }

        private void DisplayList()
        {
            ListSupplierUserControl listSupplierUserControl = new ListSupplierUserControl();
            ListSupplier.Children.Add(listSupplierUserControl);
        }

        private void DisplayDetail()
        {
            DetailSupplierUserControl detailSupplierUserControl = new DetailSupplierUserControl();
            FormSupplier.Children.Add(detailSupplierUserControl);
        }

        
    }
}
