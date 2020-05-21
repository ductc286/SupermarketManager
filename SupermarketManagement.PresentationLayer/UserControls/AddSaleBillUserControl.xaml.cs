using Supermarketmanagement.Core.Common;
using Supermarketmanagement.Core.ViewModels;
using Supermarketmanagement.PresentationLayer.Windows;
using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for AddSalesBillUserControl.xaml
    /// </summary>
    public partial class AddSaleBillUserControl : UserControl
    {
        public SaleBillViewModel saleBillViewModel;
        private readonly ISaleBillBusiness _saleBillBusiness;
        public AddSaleBillUserControl()
        {
            saleBillViewModel = new SaleBillViewModel();
            _saleBillBusiness = new SaleBillBusiness();
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            this.DataContext = saleBillViewModel;
            Load_DataGrid_SaleBillDetail();
            Account.Text = StaffGlobal.CurrentStaff.Account;
        }

        private void Load_DataGrid_SaleBillDetail()
        {
            DataGrid_SaleBillDetail.DataContext = saleBillViewModel.SaleBillDetailViewModels;
            DataGrid_SaleBillDetail.ItemsSource = saleBillViewModel.SaleBillDetailViewModels;
        }

        private void Name_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var row = GetParent<DataGridRow>((TextBlock)sender);
            var index = DataGrid_SaleBillDetail.Items.IndexOf(row.Item);
            SearchProductsWindow searchPurchaseDetailsWindow = new SearchProductsWindow();
            searchPurchaseDetailsWindow.ShowDialog();
            var product = searchPurchaseDetailsWindow.product;
            if (product == null)
            {
                return;
            }
            var item = new SaleBillDetailViewModel(product);
            if (item != null)
            {
                AddOrUpdateToList(saleBillViewModel.SaleBillDetailViewModels, item, index);
                DataGrid_SaleBillDetail.ItemsSource = null;
                DataGrid_SaleBillDetail.ItemsSource = saleBillViewModel.SaleBillDetailViewModels;
                DataGrid_SaleBillDetail.SelectedItem = item;
            }
        }

        private TargetType GetParent<TargetType>(DependencyObject o)
            where TargetType : DependencyObject
        {
            if (o == null || o is TargetType) return (TargetType)o;
            return GetParent<TargetType>(VisualTreeHelper.GetParent(o));
        }

        private void AddOrUpdateToList(IList<SaleBillDetailViewModel> saleBillDetailViewModels, SaleBillDetailViewModel saleBillDetailViewModel, int index)
        {
            var item = saleBillDetailViewModels.SingleOrDefault(p => p.ProductId == saleBillDetailViewModel.ProductId);
            if (item != null)
            {
                item.Quantity = item.Quantity + 1;
            }
            else
            {
                if (index >= saleBillDetailViewModels.Count)
                {
                    saleBillDetailViewModels.Add(saleBillDetailViewModel);
                }
                else
                {
                    saleBillDetailViewModels[index] = saleBillDetailViewModel;
                }
            }
        }

        private void DataGrid_PurchaseBillDetail_Changed(object sender, SelectionChangedEventArgs e)
        {
            saleBillViewModel.TotalMoney = saleBillViewModel.TotalMoney;
        }

        private void Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (saleBillViewModel.SaleBillDetailViewModels == null || saleBillViewModel.SaleBillDetailViewModels.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào được thêm!", "Add", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (saleBillViewModel.IsValidModel())
                {
                    var isSuccess = _saleBillBusiness.Add(saleBillViewModel);
                    if (isSuccess)
                    {
                        MessageBox.Show("Đã thêm thành công!", "Add", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công!", "Add", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void Quantity_Changed(object sender, TextChangedEventArgs e)
        {
            saleBillViewModel.TotalMoney = saleBillViewModel.TotalMoney;
        }
    }
}
