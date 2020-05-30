using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using SupermarketManagement.Core.Models;
using System.Windows;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for AddStaffUserControl.xaml
    /// </summary>
    public partial class AddStaffUserControl : UserControl
    {
        public StaffViewModel staffViewModel;
        private readonly IStaffBusiness _staffBusiness;
        public AddStaffUserControl()
        {
            _staffBusiness = new StaffBusiness();
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            staffViewModel = new StaffViewModel();
            ComboBoxStaffRole.Items.Add(new ComboBoxItem(){ Content = "Nhân viên bán hàng", Tag = (int)EStaffRole.SaleStaff });
            ComboBoxStaffRole.Items.Add(new ComboBoxItem() { Content = "Người quản lý", Tag = (int)EStaffRole.Administrator });
            if (staffViewModel.StaffRole == (int)EStaffRole.SaleStaff)
            {
                ComboBoxStaffRole.SelectedIndex = 0;
            }
            else
            {
                ComboBoxStaffRole.SelectedIndex = 1;
            }
            this.DataContext = staffViewModel;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (staffViewModel.IsValidModel())
            {
                var isSuccess = _staffBusiness.Add(staffViewModel);
                if (isSuccess)
                {
                    MessageBox.Show("Đã thêm thành công!", "Add", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công!", "Add", MessageBoxButton.OK, MessageBoxImage.Error);
                    InitializeData();
                }
            }
        }

        private void ComboBoxStaffRole_Changed(object sender, SelectionChangedEventArgs e)
        {
            var item = (ComboBoxItem)ComboBoxStaffRole.SelectedItem;
            staffViewModel.StaffRole = int.Parse(item.Tag.ToString());
        }

        private void Password_Change(object sender, RoutedEventArgs e)
        {
            //staffViewModel.Password = PasswordBox.Password;
            Password.Text = PasswordBox.Password;
        }
    }
}
