using Supermarketmanagement.Core.Common;
using Supermarketmanagement.Core.ViewModels;
using Supermarketmanagement.PresentationLayer.Common;
using Supermarketmanagement.PresentationLayer.Custom;
using Supermarketmanagement.PresentationLayer.UserControls;
using SupermarketManagement.BLL.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            var staff = staffBusiness.GetStaffViewModel(new LoginStaffViewModel() { Account = "Admin", Password = "234ksf" });
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
            AddSaleBillUserControl addSaleBillUserControl = new AddSaleBillUserControl();
            //EditPurchaseBillUserControl editPurchaseBillUserControl = new EditPurchaseBillUserControl();
            CustomTabItem customTabItem = new CustomTabItem() { Title = "Tab Default", Content = addSaleBillUserControl };

            MainTabControl.Items.Clear();
            MainTabControl.Items.Add(customTabItem);
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
                AddSaleBillUserControl addSaleBillUserControl = new AddSaleBillUserControl();
                CustomTabItem customTabItem = new CustomTabItem()
                {
                    Title = UsecaseStringContants.addSaleBill,
                    Content = addSaleBillUserControl
                };
                MainTabControl.Items.Add(customTabItem);
                MainTabControl.SelectedItem = customTabItem;
            }
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
        }

        private void MenuAddEndOfShift_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuListEndOfShift_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
