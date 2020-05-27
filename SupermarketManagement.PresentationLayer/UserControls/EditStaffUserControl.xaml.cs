using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using SupermarketManagement.Core.Models;
using System.Windows;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for EditStaffUserControl.xaml
    /// </summary>
    public partial class EditStaffUserControl : UserControl
    {
        private readonly IStaffBusiness _staffBusiness;
        public StaffViewModel staffViewModel;
        public EditStaffUserControl(Staff staff)
        {
            _staffBusiness = new StaffBusiness();
            InitializeComponent();
            staffViewModel = new StaffViewModel(staff);
            ComboBoxStaffRole.Items.Add(new ComboBoxItem() { Content = "Nhân viên bán hàng", Tag = (int)EStaffRole.SaleStaff });
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


        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (staffViewModel.IsValidModel())
            {
                var isUpdate = _staffBusiness.Update(staffViewModel);
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

        private void ComboBoxStaffRole_Changed(object sender, SelectionChangedEventArgs e)
        {
            var item = (ComboBoxItem)ComboBoxStaffRole.SelectedItem;
            staffViewModel.StaffRole = int.Parse(item.Tag.ToString());
        }
    }
}
