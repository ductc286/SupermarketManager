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
    /// Interaction logic for ListStaffUserControl.xaml
    /// </summary>
    public partial class ListStaffUserControl : UserControl
    {
        public List<Staff> staffs;
        private readonly IStaffBusiness _staffBusiness;
        public ListStaffUserControl()
        {
            _staffBusiness = new StaffBusiness();
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            staffs = _staffBusiness.GetAll();
            this.DataContext = staffs;
            ListStaffs.ItemsSource = staffs;
        }

        private void OpenWindow_Add(object sender, System.Windows.RoutedEventArgs e)
        {
            AddStaffUserControl addStaffUserControl = new AddStaffUserControl();
            DialogWindow dialogWindow = new DialogWindow(addStaffUserControl, UsecaseStringContants.addStaff, addStaffUserControl.Width, addStaffUserControl.Height);
            dialogWindow.ShowDialog();
            InitializeData();
        }

        private void OpenWindow_Edit(object sender, System.Windows.RoutedEventArgs e)
        {
            var staff = (Staff)ListStaffs.SelectedItem;
            if (staff == null)
            {
                MessageBox.Show("Chưa có mục nào được chọn!", "Edit", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                EditStaffUserControl editStaffUserControl = new EditStaffUserControl(staff);
                DialogWindow dialogWindow = new DialogWindow(editStaffUserControl, UsecaseStringContants.editStaff, editStaffUserControl.Width, editStaffUserControl.Height);
                dialogWindow.ShowDialog();
                InitializeData();
            }
            
        }
    }
}
