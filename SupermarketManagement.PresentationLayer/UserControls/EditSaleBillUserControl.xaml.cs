using Supermarketmanagement.Core.ViewModels;
using Supermarketmanagement.PresentationLayer.Custom;
using Supermarketmanagement.PresentationLayer.Windows;
using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using SupermarketManagement.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for EditSaleBillUserControl.xaml
    /// </summary>
    public partial class EditSaleBillUserControl : UserControl
    {
        private readonly ISaleBillBusiness _saleBillBusiness;
        public SaleBillViewModel saleBillViewModel;

        public EditSaleBillUserControl(SaleBill saleBill)
        {
            InitializeComponent();
            _saleBillBusiness = new SaleBillBusiness();
            this.saleBillViewModel = new SaleBillViewModel(saleBill);
            this.DataContext = saleBillViewModel;
            Load_DataGrid_PurchaseBillDetail();
        }

        private void Load_DataGrid_PurchaseBillDetail()
        {
            DataGrid_SaleBillDetail.DataContext = saleBillViewModel.SaleBillDetailViewModels;
            DataGrid_SaleBillDetail.ItemsSource = saleBillViewModel.SaleBillDetailViewModels;
        }

        private void Name_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var row = GetParent<DataGridRow>((TextBlock)sender);
            var index = DataGrid_SaleBillDetail.Items.IndexOf(row.Item);
            SearchProductsWindow searchProductsWindow = new SearchProductsWindow();
            searchProductsWindow.ShowDialog();
            var product = searchProductsWindow.product;
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

        private TargetType GetParent<TargetType>(DependencyObject o)
            where TargetType : DependencyObject
        {
            if (o == null || o is TargetType) return (TargetType)o;
            return GetParent<TargetType>(VisualTreeHelper.GetParent(o));
        }

        private void DataGrid_SaleBillDetail_Changed(object sender, SelectionChangedEventArgs e)
        {
            saleBillViewModel.TotalMoney = saleBillViewModel.TotalMoney;
        }

        private void Quantity_Changed(object sender, TextChangedEventArgs e)
        {
            var row = GetParent<DataGridRow>((CustomTextBox)sender);
            var index = DataGrid_SaleBillDetail.Items.IndexOf(row.Item);
            if (index < saleBillViewModel.SaleBillDetailViewModels.Count)
            {
                if (saleBillViewModel.SaleBillDetailViewModels[index].Quantity > saleBillViewModel.SaleBillDetailViewModels[index].Inventory)
                {
                    saleBillViewModel.SaleBillDetailViewModels[index].Quantity = saleBillViewModel.SaleBillDetailViewModels[index].Inventory;
                }
                saleBillViewModel.TotalMoney = saleBillViewModel.TotalMoney;
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (saleBillViewModel.IsValidModel())
            {
                var isUpdate = _saleBillBusiness.Update(saleBillViewModel);
                if (isUpdate)
                {
                    MessageBox.Show("Đã cập nhật thành công!", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công!", "Update", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }
}
