using Supermarketmanagement.Core.Common;
using Supermarketmanagement.Core.ViewModels;
using Supermarketmanagement.PresentationLayer.Common;
using Supermarketmanagement.PresentationLayer.Custom;
using Supermarketmanagement.PresentationLayer.UserControls;
using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using System;
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
            #region Staff to test
            StaffBusiness staffBusiness = new StaffBusiness();
            var staff = staffBusiness.GetStaffViewModel(new LoginStaffViewModel() { Account = "Admin", Password = "234ksf" });
            StaffGlobal.CurrentStaff = staff;
            #endregion
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
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
            //ListProductUserControl listProductUserControl = new ListProductUserControl();
            //CustomTabItem customTabItem = new CustomTabItem() { Title = "Tab Default", Content = listProductUserControl, Name = "Default" };
            //ActionTabControl(MainTabControl);
            //MainTabControl.Items.Clear();
            //MainTabControl.Items.Add(customTabItem);

            //AddProductUserControl addProductUserControl = new AddProductUserControl();
            //CustomTabItem customTabItem = new CustomTabItem() { Title = "Tab Default", Content = addProductUserControl};

            AddPurchaseBillUserControl addPurchaseBillUserControl = new AddPurchaseBillUserControl();
            //EditPurchaseBillUserControl editPurchaseBillUserControl = new EditPurchaseBillUserControl();
            CustomTabItem customTabItem = new CustomTabItem() { Title = "Tab Default", Content = addPurchaseBillUserControl };

            MainTabControl.Items.Clear();
            MainTabControl.Items.Add(customTabItem);
        }


        private void MenuListProduct_Click(object sender, RoutedEventArgs e)
        {
            //If found  tab was ListProduct, selected for Tabcontrol
            var index = TabControlManagement.GetIndexByTitle(MainTabControl, UsecaseStringContants.listProduct);
            if (index >= 0)
            {
                MainTabControl.SelectedIndex = index;
            }
            //If not found tab was ListProduct, add and selected
            else
            {
                ListProductUserControl listProductUserControl = new ListProductUserControl();
                CustomTabItem customTabItem = new CustomTabItem()
                {
                    Title = UsecaseStringContants.listProduct,
                    Content = listProductUserControl
                };
                MainTabControl.Items.Add(customTabItem);
                MainTabControl.SelectedItem = customTabItem;
            }
        }

        private void MenuListSuplier(object sender, RoutedEventArgs e)
        {
            //If found  tab was ListSuplier, selected for Tabcontrol
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
            //If found tab was AddProduct, selected for Tabcontrol
            var index = TabControlManagement.GetIndexByTitle(MainTabControl, UsecaseStringContants.addProduct);
            if (index >= 0)
            {
                MainTabControl.SelectedIndex = index;
            }
            //If not found tab was ListSuplier, add and selected
            else
            {
                AddProductUserControl addProductUserControl = new AddProductUserControl();
                CustomTabItem customTabItem = new CustomTabItem()
                {
                    Title = UsecaseStringContants.addProduct,
                    Content = addProductUserControl
                };
                MainTabControl.Items.Add(customTabItem);
                MainTabControl.SelectedItem = customTabItem;
            }
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

        private void MenuManageSuplier(object sender, RoutedEventArgs e)
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
                ManageSupplierUserControl manageSupplierUserControl = new ManageSupplierUserControl();
                CustomTabItem customTabItem = new CustomTabItem()
                {
                    Title = UsecaseStringContants.listSupplier,
                    Content = manageSupplierUserControl
                };
                MainTabControl.Items.Add(customTabItem);
                MainTabControl.SelectedItem = customTabItem;
            }
        }


        // method to test, need remove when done this project
        private void MenuEditSupplier_Click(object sender, RoutedEventArgs e)
        {
            //If found a ListSuplier, selected for Tabcontrol
            var index = TabControlManagement.GetIndexByTitle(MainTabControl, UsecaseStringContants.editSupplier);
            if (index >= 0)
            {
                MainTabControl.SelectedIndex = index;
            }
            //If not found tab was ListSuplier, add and selected
            else
            {
                SupplierBusiness supplierBusiness = new SupplierBusiness();
                var supplier = supplierBusiness.GetAll()[0];
                SupplierViewModel supplierViewModel = new SupplierViewModel()
                {
                    SupplierId = supplier.SupplierId,
                    SupplierName = supplier.SupplierName,
                    Description = supplier.Description

                };
                EditSupplierUserControl editSupplierUserControl = new EditSupplierUserControl(supplierViewModel);
                CustomTabItem customTabItem = new CustomTabItem()
                {
                    Title = UsecaseStringContants.editSupplier,
                    Content = editSupplierUserControl
                };
                MainTabControl.Items.Add(customTabItem);
                MainTabControl.SelectedItem = customTabItem;
            }
        }

        private void MenuListCategory_Click(object sender, RoutedEventArgs e)
        {
            //If found  tab was ListCategory, selected for Tabcontrol
            var index = TabControlManagement.GetIndexByTitle(MainTabControl, UsecaseStringContants.listCategory);
            if (index >= 0)
            {
                MainTabControl.SelectedIndex = index;
            }
            //If not found tab was ListCategory, add and selected
            else
            {
                ListCategoryUserControl listCategoryUserControl = new ListCategoryUserControl();
                CustomTabItem customTabItem = new CustomTabItem()
                {
                    Title = UsecaseStringContants.listCategory,
                    Content = listCategoryUserControl
                };
                MainTabControl.Items.Add(customTabItem);
                MainTabControl.SelectedItem = customTabItem;
            }
        }

        private void MenuAddCategory_Click(object sender, RoutedEventArgs e)
        {
            //If found a AddCategory tabitem, selected for Tabcontrol
            var index = TabControlManagement.GetIndexByTitle(MainTabControl, UsecaseStringContants.addCategory);
            if (index >= 0)
            {
                MainTabControl.SelectedIndex = index;
            }
            //If not found tab was AddCategory tabitem, add and selected
            else
            {
                AddSupplierUserControl addSupplierUserControl = new AddSupplierUserControl();
                CustomTabItem customTabItem = new CustomTabItem()
                {
                    Title = UsecaseStringContants.addCategory,
                    Content = addSupplierUserControl
                };
                MainTabControl.Items.Add(customTabItem);
                MainTabControl.SelectedItem = customTabItem;
            }
        }

        private void MenuAddPurchaseBill(object sender, RoutedEventArgs e)
        {
            //If found a AddPurchaseBill tabitem, selected for Tabcontrol
            var index = TabControlManagement.GetIndexByTitle(MainTabControl, UsecaseStringContants.addPurchaseBill);
            if (index >= 0)
            {
                MainTabControl.SelectedIndex = index;
            }
            //If not found tab was AddPurchaseBill tabitem, add and selected
            else
            {
                AddPurchaseBillUserControl addPurchaseBillUserControl = new AddPurchaseBillUserControl();
                CustomTabItem customTabItem = new CustomTabItem()
                {
                    Title = UsecaseStringContants.addPurchaseBill,
                    Content = addPurchaseBillUserControl
                };
                MainTabControl.Items.Add(customTabItem);
                MainTabControl.SelectedItem = customTabItem;
            }
        }

        private void MenuListPurchaseBill(object sender, RoutedEventArgs e)
        {
            //If found  tab was ListPurchaseBill, selected for Tabcontrol
            var index = TabControlManagement.GetIndexByTitle(MainTabControl, UsecaseStringContants.listPurchaseBill);
            if (index >= 0)
            {
                MainTabControl.SelectedIndex = index;
            }
            //If not found tab was ListPurchaseBill, add and selected
            else
            {
                ListPurchaseBillUserControl listPurchaseBillUserControl = new ListPurchaseBillUserControl();
                CustomTabItem customTabItem = new CustomTabItem()
                {
                    Title = UsecaseStringContants.listPurchaseBill,
                    Content = listPurchaseBillUserControl
                };
                MainTabControl.Items.Add(customTabItem);
                MainTabControl.SelectedItem = customTabItem;
            }
        }


    }
}