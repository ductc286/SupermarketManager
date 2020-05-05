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
            _loginStaffViewModel = new LoginStaffViewModel() { AcceptValidModel = false };
            this.DataContext = _loginStaffViewModel;
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            _loginStaffViewModel = (LoginStaffViewModel)this.DataContext;
            if (_loginStaffViewModel.IsValidModel())
            {
                var currentStaff = _staffBusiness.GetStaffViewModel(_loginStaffViewModel);
                if (currentStaff == null)
                {
                    MessageBox.Show("Đăng nhập không thành công", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    StaffGlobal.CurrentStaff = currentStaff;
                    MessageBox.Show("Đăng nhập thành công", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainManagementWindow mainManagementWindow = new MainManagementWindow();
                    this.Hide();
                    mainManagementWindow.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu không hợp lệ!", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
