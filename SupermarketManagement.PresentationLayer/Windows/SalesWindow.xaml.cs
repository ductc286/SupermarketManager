using Supermarketmanagement.Core.Common;
using Supermarketmanagement.Core.ViewModels;
using Supermarketmanagement.PresentationLayer.Common;
using Supermarketmanagement.PresentationLayer.Custom;
using Supermarketmanagement.PresentationLayer.UserControls;
using SupermarketManagement.BLL.Business;
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
            StaffBusiness staffBusiness = new StaffBusiness();
            var staff = staffBusiness.GetStaffViewModel(new LoginStaffViewModel() { Account = "Admin", Password = "matkhau123" });
            StaffGlobal.CurrentStaff = staff;
            #endregion
            //this.WindowState = WindowState.Maximized;
            
            InitializeComponent();
            this.Width = 1370;
            this.Height = 770;
            InitializeData();
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
            AddMultilpleSaleBillUserControl addMultilpleSaleBillUserControl = new AddMultilpleSaleBillUserControl();
            CustomTabItem customTabItem = new CustomTabItem() { Title = UsecaseStringContants.addSaleBill, Content = addMultilpleSaleBillUserControl };
            MainTabControl.Items.Clear();
            MainTabControl.Items.Add(customTabItem);
            CurrenTabTitle.Content = UsecaseStringContants.addSaleBill;
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
        }
    }
}
