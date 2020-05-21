using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.Core.Models;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for DetailSaleBillUserControl.xaml
    /// </summary>
    public partial class DetailSaleBillUserControl : UserControl
    {

        public SaleBillViewModel saleBillViewModel;

        public DetailSaleBillUserControl(SaleBill saleBill)
        {
            InitializeComponent();
            this.saleBillViewModel = new SaleBillViewModel(saleBill);
            this.DataContext = saleBillViewModel;
            Load_DataGrid_SaleBillDetail();
        }

        private void Load_DataGrid_SaleBillDetail()
        {
            DataGrid_SaleBillDetail.DataContext = saleBillViewModel.SaleBillDetailViewModels;
            DataGrid_SaleBillDetail.ItemsSource = saleBillViewModel.SaleBillDetailViewModels;
        }
    }
}
