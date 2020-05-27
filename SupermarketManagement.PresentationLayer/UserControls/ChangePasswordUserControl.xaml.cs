using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using System.Windows;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for ChangePasswordUserControl.xaml
    /// </summary>
    public partial class ChangePasswordUserControl : UserControl
    {
        private readonly IStaffBusiness _staffBusiness;
        public ChangePasswordViewModel changePasswordViewModel;
        public ChangePasswordUserControl()
        {
            _staffBusiness = new StaffBusiness();
            changePasswordViewModel = new ChangePasswordViewModel();
            InitializeComponent();
            this.DataContext = changePasswordViewModel;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (changePasswordViewModel.IsValidModel())
            {
                var isSuccess = _staffBusiness.ChangePassword(changePasswordViewModel);
                if (isSuccess)
                {
                    MessageBox.Show("Đã đổi mật khẩu thành công!", "Change password", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Thất bại, vui lòng kiểm tra lại thông tin!", "Change password", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
