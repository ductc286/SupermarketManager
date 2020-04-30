using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using System.Windows;

namespace Supermarketmanagement.PresentationLayer.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginStaffViewModel _loginStaffViewModel;
        private readonly IStaffBusiness _staffBusiness;
        public LoginWindow()
        {
            InitializeComponent();
            _staffBusiness = new StaffBusiness();
            this.DataContext = _loginStaffViewModel;
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            _loginStaffViewModel = (LoginStaffViewModel)this.DataContext;
            var currentStaff = _staffBusiness.GetStaffViewModel(_loginStaffViewModel);
            if (currentStaff == null)
            {
                MessageBox.Show("Đăng nhập không thành công");
            }
            else
            {
                MessageBox.Show("thanh cong");
            }
        }
    }

}
