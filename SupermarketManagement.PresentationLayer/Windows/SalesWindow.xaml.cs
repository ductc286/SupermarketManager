using Supermarketmanagement.Core.Common;
using Supermarketmanagement.PresentationLayer.Common;
using Supermarketmanagement.PresentationLayer.Custom;
using Supermarketmanagement.PresentationLayer.UserControls;
using System;
using System.Windows;

namespace Supermarketmanagement.PresentationLayer.Windows
{
    /// <summary>
    /// Interaction logic for SalesWindow.xaml
    /// </summary>
    public partial class SalesWindow : Window
    {
        public SalesWindow()
        {
            #region Staff to test
            //StaffBusiness staffBusiness = new StaffBusiness();
            //var staff = staffBusiness.GetStaffViewModel(new LoginStaffViewModel() { Account = "Admin", Password = "matkhau123" });
            //StaffGlobal.CurrentStaff = staff;
            #endregion
            //this.WindowState = WindowState.Maximized;

            InitializeComponent();
            //this.Width = 1300;
            //this.Height = 720;
            //this.WindowState = WindowState.Maximized;
            InitializeData();
            this.Width = 1300;
            this.Height = 720;

        }

        /// <summary>
        /// List the methods needed for data initialization
        /// </summary>
        private void InitializeData()
        {
            Account.Text = StaffGlobal.Account;
            CurrentDate.Text = DateTime.Now.ToShortDateString();
            LoadMainTabControl();
        }

        private void LoadMainTabControl()
        {
            MenuAddSaleBill_Click(null, null);
        }

        private void MenuAddSaleBill_Click(object sender, RoutedEventArgs e)
        {
            //If found tab was AddSaleBill, selected for Tabcontrol
            var index = TabControlManagement.GetIndexByTitle(MainTabControl, UsecaseStringContants.addSaleBill);
            if (index >= 0)
            {
                MainTabControl.SelectedIndex = index;
            }
            //If not found tab was AddSaleBill, add and selected
            else
            {
                AddMultilpleSaleBillUserControl addMultilpleSaleBillUserControl = new AddMultilpleSaleBillUserControl();
                CustomTabItem customTabItem = new CustomTabItem()
                {
                    Title = UsecaseStringContants.addSaleBill,
                    Content = addMultilpleSaleBillUserControl
                };
                MainTabControl.Items.Add(customTabItem);
                MainTabControl.SelectedItem = customTabItem;
            }
            CurrenTabTitle.Content = UsecaseStringContants.addSaleBill;
            this.Title = UsecaseStringContants.addSaleBill;
        }

        private void MenuListSaleBill_Click(object sender, RoutedEventArgs e)
        {
            //If found tab was ListSaleBill, selected for Tabcontrol
            var index = TabControlManagement.GetIndexByTitle(MainTabControl, UsecaseStringContants.listSaleBill);
            if (index >= 0)
            {
                MainTabControl.SelectedIndex = index;
            }
            //If not found tab was ListSaleBill, add and selected
            else
            {
                ListSaleBillUserControl listSaleBillUserControl = new ListSaleBillUserControl();
                CustomTabItem customTabItem = new CustomTabItem()
                {
                    Title = UsecaseStringContants.listSaleBill,
                    Content = listSaleBillUserControl
                };
                MainTabControl.Items.Add(customTabItem);
                MainTabControl.SelectedItem = customTabItem;
            }
            CurrenTabTitle.Content = UsecaseStringContants.listSaleBill;
            this.Title = UsecaseStringContants.listSaleBill;
        }

        private void MenuAddEndOfShift_Click(object sender, RoutedEventArgs e)
        {
            //If found tab was AddEndOfShift, selected for Tabcontrol
            var index = TabControlManagement.GetIndexByTitle(MainTabControl, UsecaseStringContants.addEndOfShift);
            if (index >= 0)
            {
                MainTabControl.SelectedIndex = index;
            }
            //If not found tab was AddEndOfShift, add and selected
            else
            {
                AddEndOfShiftUserControl addEndOfShiftUserControl = new AddEndOfShiftUserControl();
                CustomTabItem customTabItem = new CustomTabItem()
                {
                    Title = UsecaseStringContants.addEndOfShift,
                    Content = addEndOfShiftUserControl
                };
                MainTabControl.Items.Add(customTabItem);
                MainTabControl.SelectedItem = customTabItem;
            }
            CurrenTabTitle.Content = UsecaseStringContants.addEndOfShift;
            this.Title = UsecaseStringContants.addEndOfShift;
        }

        private void MenuListEndOfShift_Click(object sender, RoutedEventArgs e)
        {
            //If found tab was ListEndOfShift, selected for Tabcontrol
            var index = TabControlManagement.GetIndexByTitle(MainTabControl, UsecaseStringContants.listEndOfShift);
            if (index >= 0)
            {
                MainTabControl.SelectedIndex = index;
            }
            //If not found tab was ListEndOfShift, add and selected
            else
            {
                ListEndOfShiftUserControl listEndOfShiftUserControl = new ListEndOfShiftUserControl();
                CustomTabItem customTabItem = new CustomTabItem()
                {
                    Title = UsecaseStringContants.listEndOfShift,
                    Content = listEndOfShiftUserControl
                };
                MainTabControl.Items.Add(customTabItem);
                MainTabControl.SelectedItem = customTabItem;
            }
            CurrenTabTitle.Content = UsecaseStringContants.listEndOfShift;
            this.Title = UsecaseStringContants.listEndOfShift;
        }

        private void MenuChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordUserControl changePasswordUserControl = new ChangePasswordUserControl();
            DialogWindow dialogWindow = new DialogWindow(changePasswordUserControl, UsecaseStringContants.changePassword);
            dialogWindow.ShowDialog();
        }
    }
}
