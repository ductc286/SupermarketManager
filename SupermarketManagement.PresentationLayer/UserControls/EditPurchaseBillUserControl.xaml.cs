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
    /// Interaction logic for EditPurchaseBillUserControl.xaml
    /// </summary>
    public partial class EditPurchaseBillUserControl : UserControl
    {
        private readonly IPurchaseBillBusiness _purchaseBillBusiness;
        private readonly ISupplierBusiness _supplierBusiness;
        public PurchaseBillViewModel purchaseBillViewModel;
        public EditPurchaseBillUserControl(PurchaseBillViewModel purchaseBillViewModel)
        {
            InitializeComponent();
            _purchaseBillBusiness = new PurchaseBillBusiness();
            _supplierBusiness = new SupplierBusiness();
            this.purchaseBillViewModel = purchaseBillViewModel;
            InitializeData();
        }
        public EditPurchaseBillUserControl(PurchaseBill purchaseBill)
        {
            InitializeComponent();
            _purchaseBillBusiness = new PurchaseBillBusiness();
            _supplierBusiness = new SupplierBusiness();
            this.purchaseBillViewModel = new PurchaseBillViewModel(purchaseBill);
            InitializeData();
        }

        private void InitializeData()
        {
            this.DataContext = purchaseBillViewModel;

            var suppliers = _supplierBusiness.GetAll();
            LoadComboBoxSuppliers(suppliers);
            purchaseBillViewModel.AcceptValidModel = false;
            Load_DataGrid_PurchaseBillDetail();
        }


        private void Load_DataGrid_PurchaseBillDetail()
        {
            DataGrid_PurchaseBillDetail.DataContext = purchaseBillViewModel.PurchaseBillDetailViewModels;
            DataGrid_PurchaseBillDetail.ItemsSource = purchaseBillViewModel.PurchaseBillDetailViewModels;
        }

        private void LoadComboBoxSuppliers(List<Supplier> suppliers)
        {
            if (suppliers != null && suppliers.Count != 0)
            {
                foreach (var item in suppliers)
                {
                    var comboxItem = new ComboBoxItem { Content = item.SupplierName, Tag = item.SupplierId };
                    ComboBoxSuppliers.Items.Add(comboxItem);
                    if (item.SupplierId == purchaseBillViewModel.SupplierId)
                    {
                        ComboBoxSuppliers.SelectedItem =comboxItem;
                    }
                }
            }
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (purchaseBillViewModel.PurchaseBillDetailViewModels == null || purchaseBillViewModel.PurchaseBillDetailViewModels.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào được thêm!", "Add", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (purchaseBillViewModel.IsValidModel())
                {
                    var isSuccess = _purchaseBillBusiness.Add(purchaseBillViewModel);
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

        private void ComboBoxSuppliers_Changed(object sender, SelectionChangedEventArgs e)
        {
            var currentItem = (ComboBoxItem)ComboBoxSuppliers.SelectedItem;
            SupplierId.Text = currentItem.Tag.ToString();
        }

        private void Name_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var row = GetParent<DataGridRow>((TextBlock)sender);
            var index = DataGrid_PurchaseBillDetail.Items.IndexOf(row.Item);
            SearchPurchaseDetailsWindow searchPurchaseDetailsWindow = new SearchPurchaseDetailsWindow();
            searchPurchaseDetailsWindow.ShowDialog();
            var product = searchPurchaseDetailsWindow.product;
            if (product == null)
            {
                return;
            }
            var item = new PurchaseBillDetailViewModel(product);
            if (item != null)
            {
                AddOrUpdateToList(purchaseBillViewModel.PurchaseBillDetailViewModels, item, index);
                DataGrid_PurchaseBillDetail.ItemsSource = null;
                DataGrid_PurchaseBillDetail.ItemsSource = purchaseBillViewModel.PurchaseBillDetailViewModels;
                DataGrid_PurchaseBillDetail.SelectedItem = item;
            }
        }

        private void AddOrUpdateToList(IList<PurchaseBillDetailViewModel> purchaseBillDetailViewModels, PurchaseBillDetailViewModel purchaseBillDetailViewModel, int index)
        {
            var item = purchaseBillDetailViewModels.SingleOrDefault(p => p.ProductId == purchaseBillDetailViewModel.ProductId);
            if (item != null)
            {
                item.Quantity = item.Quantity + 1;
            }
            else
            {
                if (index >= purchaseBillDetailViewModels.Count)
                {
                    purchaseBillDetailViewModels.Add(purchaseBillDetailViewModel);
                }
                else
                {
                    purchaseBillDetailViewModels[index] = purchaseBillDetailViewModel;
                }
            }
        }

        private TargetType GetParent<TargetType>(DependencyObject o)
            where TargetType : DependencyObject
        {
            if (o == null || o is TargetType) return (TargetType)o;
            return GetParent<TargetType>(VisualTreeHelper.GetParent(o));
        }


        private void DataGrid_PurchaseBillDetail_Changed(object sender, SelectionChangedEventArgs e)
        {
            purchaseBillViewModel.TotalMoney = purchaseBillViewModel.TotalMoney;
        }

        private void Quantity_Changed(object sender, TextChangedEventArgs e)
        {
            var row = GetParent<DataGridRow>((CustomTextBox)sender);
            var index = DataGrid_PurchaseBillDetail.Items.IndexOf(row.Item);
            if (index < purchaseBillViewModel.PurchaseBillDetailViewModels.Count)
            {
                if (purchaseBillViewModel.PurchaseBillDetailViewModels[index].Quantity > purchaseBillViewModel.PurchaseBillDetailViewModels[index].Inventory)
                {
                    purchaseBillViewModel.PurchaseBillDetailViewModels[index].Quantity = purchaseBillViewModel.PurchaseBillDetailViewModels[index].Inventory;
                }
                purchaseBillViewModel.TotalMoney = purchaseBillViewModel.TotalMoney;
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (purchaseBillViewModel.IsValidModel())
            {
                var isUpdate = _purchaseBillBusiness.Update(purchaseBillViewModel);
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
