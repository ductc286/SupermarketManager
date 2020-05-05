using Supermarketmanagement.PresentationLayer.Common;
using Supermarketmanagement.PresentationLayer.Custom;
using Supermarketmanagement.PresentationLayer.UserControls;
using System.Windows;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.Windows
{
    /// <summary>
    /// Interaction logic for MainManagementWindow.xaml
    /// </summary>
    public partial class MainManagementWindow : Window
    {
        public MainManagementWindow()
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
            InitializeData();
        }
        /// <summary>
        /// List the methods needed for data initialization
        /// </summary>
        private void InitializeData()
        {
            LoadMainTabControl();
        }

        private void LoadMainTabControl()
        {
            ListProductUserControl listProductUserControl = new ListProductUserControl();
            CustomTabItem customTabItem = new CustomTabItem() { Title = "Tab1", Content = listProductUserControl, Name = "Name1" };
            ActionTabControl(MainTabControl);
            MainTabControl.Items.Clear();
            MainTabControl.Items.Add(customTabItem);
        }

        public void ActionTabControl(TabControl tabControl)
        {

        }
        public void AddAndGoTabControl()
        {

        }
        private void MenuListProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuListSuplier(object sender, RoutedEventArgs e)
        {
            //If found a ListSuplier, selected for Tabcontrol
            var index = TabControlManagement.GetIndexByTitle(MainTabControl, UsecaseStringContants.listSupplier);
            if (index >= 0)
            {
                MainTabControl.SelectedIndex = index;
            }
            //If not found tab was ListSuplier, add and selected
            else
            {
                ListSupplierUserControl listSupplierUserControl = new ListSupplierUserControl();
                CustomTabItem customTabItem = new CustomTabItem() 
                {
                    Title = UsecaseStringContants.listSupplier,
                    Content = listSupplierUserControl 
                };
                MainTabControl.Items.Add(customTabItem);
                MainTabControl.SelectedItem = customTabItem;
            }
        }

        private void MenuAddProduct_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            //If found a AddSupplier tabitem, selected for Tabcontrol
            var index = TabControlManagement.GetIndexByTitle(MainTabControl, UsecaseStringContants.addSupplier);
            if (index >= 0)
            {
                MainTabControl.SelectedIndex = index;
            }
            //If not found tab was AddSupplier tabitem, add and selected
            else
            {
                AddSupplierUserControl addSupplierUserControl = new AddSupplierUserControl();
                CustomTabItem customTabItem = new CustomTabItem()
                {
                    Title = UsecaseStringContants.addSupplier,
                    Content = addSupplierUserControl
                };
                MainTabControl.Items.Add(customTabItem);
                MainTabControl.SelectedItem = customTabItem;
            }
        }
    }
}