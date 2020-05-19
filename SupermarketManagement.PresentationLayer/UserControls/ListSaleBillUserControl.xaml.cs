using Supermarketmanagement.PresentationLayer.Windows;
using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using SupermarketManagement.Core.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for ListSaleBillUserControl.xaml
    /// </summary>
    public partial class ListSaleBillUserControl : UserControl
    {

        private readonly ISaleBillBusiness _saleBillBusiness;
        public List<SaleBill> saleBills;
        public ListSaleBillUserControl()
        {
            InitializeComponent();
            _saleBillBusiness = new SaleBillBusiness();
            //saleBills = _saleBillBusiness.GetAll();
            saleBills = _saleBillBusiness.GetAll();
            InitializeData();
        }

        /// <summary>
        /// List the methods needed for data initialization
        /// </summary>
        private void InitializeData()
        {
            DataContext = saleBills;
            LoadList();
        }

        public void LoadList()
        {
            
            ListSaleBills.ItemsSource = saleBills;
        }




        private void Open_Detail(object sender, RoutedEventArgs e)
        {
            //var purchaseBill = (PurchaseBill)ListPurchaseBills.SelectedItem;
            //if (purchaseBill != null)
            //{
            //    DetailPurchaseBillUserWindow detailPurchaseBillUserWindow = new DetailPurchaseBillUserWindow(purchaseBill);
            //    detailPurchaseBillUserWindow.ShowDialog();
            //}
        }

        private void Open_Edit(object sender, RoutedEventArgs e)
        {
            var saleBill = (SaleBill)ListSaleBills.SelectedItem;
            if (saleBill == null)
            {
                MessageBox.Show("Chưa có mục nào được chọn!", "Edit", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (saleBill.IsAprroved)
            {
                MessageBox.Show("Không thể sửa đơn hàng đã được phê duyệt!", "Edit", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (saleBill != null)
            {

                EditSaleBillWindow editSaleBillWindow = new EditSaleBillWindow(saleBill);
                editSaleBillWindow.ShowDialog();
            }
        }
    }
}
