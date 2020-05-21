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
            InitializeData();
        }

        /// <summary>
        /// List the methods needed for data initialization
        /// </summary>
        private void InitializeData()
        {
            saleBills = _saleBillBusiness.GetAll();
            DataContext = saleBills;
            ListSaleBills.ItemsSource = saleBills;
        }

        public void SetUpForAdmin()
        {
            Button_Edit.Visibility = Visibility.Hidden;
            Button_Delete.Visibility = Visibility.Hidden;
        }

        private void Open_Detail(object sender, RoutedEventArgs e)
        {
            var saleBill = (SaleBill)ListSaleBills.SelectedItem;
            if (saleBill != null)
            {
                DetailsWindow detailsWindow = new DetailsWindow(saleBill);
                detailsWindow.ShowDialog();
            }

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

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var saleBill = (SaleBill)ListSaleBills.SelectedItem;
            if (saleBill == null)
            {
                MessageBox.Show("Chưa có mục nào được chọn!", "Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (saleBill.IsAprroved)
            {
                MessageBox.Show("Không thể xoá đơn hàng đã được phê duyệt!", "Delete", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (saleBill != null)
            {
                var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này?", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (confirm == MessageBoxResult.OK)
                {
                    _saleBillBusiness.Delete(saleBill);
                    InitializeData();
                }
                
            }
        }
    }
}
