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
    /// Interaction logic for MainManagementWindow.xaml
    /// </summary>
    public partial class MainManagementWindow : Window
    {
        public MainManagementWindow()
        {
            #region Staff to test
            //StaffBusiness staffBusiness = new StaffBusiness();
            //var staff = staffBusiness.GetStaffViewModel(new LoginStaffViewModel() { Account = "Admin", Password = "matkhau123" });
            //StaffGlobal.CurrentStaff = staff;
            #endregion
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
            InitializeData();
            //this.Width = 1300;
            //this.Height = 720;
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
            MenuStatistics_Click(null, null);
            //AddPurchaseBillUserControl addPurchaseBillUserControl = new AddPurchaseBillUserControl();
            ////EditPurchaseBillUserControl editPurchaseBillUserControl = new EditPurchaseBillUserControl();
            //CustomTabItem customTabItem = new CustomTabItem() { Title = "Tab Default", Content = addPurchaseBillUserControl };

            //MainTabControl.Items.Clear();
            //MainTabControl.Items.Add(customTabItem);
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
            CurrenTabTitle.Content = UsecaseStringContants.listProduct;
            this.Title = UsecaseStringContants.listProduct;
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
            CurrenTabTitle.Content = UsecaseStringContants.listSupplier;
            this.Title = UsecaseStringContants.listSupplier;
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
            CurrenTabTitle.Content = UsecaseStringContants.addProduct;
            this.Title = UsecaseStringContants.addProduct;
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
            CurrenTabTitle.Content = UsecaseStringContants.addSupplier;
            this.Title = UsecaseStringContants.addSupplier;
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
            CurrenTabTitle.Content = UsecaseStringContants.listSupplier;
            this.Title = UsecaseStringContants.listSupplier;
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
            CurrenTabTitle.Content = UsecaseStringContants.editSupplier;
            this.Title = UsecaseStringContants.editSupplier;
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
            CurrenTabTitle.Content = UsecaseStringContants.listCategory;
            this.Title = UsecaseStringContants.listCategory;
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
                AddCategoryUserControl addCategoryUserControl = new AddCategoryUserControl();
                CustomTabItem customTabItem = new CustomTabItem()
                {
                    Title = UsecaseStringContants.addCategory,
                    Content = addCategoryUserControl
                };
                MainTabControl.Items.Add(customTabItem);
                MainTabControl.SelectedItem = customTabItem;
            }
            CurrenTabTitle.Content = UsecaseStringContants.addCategory;
            this.Title = UsecaseStringContants.addCategory;
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
            CurrenTabTitle.Content = UsecaseStringContants.addPurchaseBill;
            this.Title = UsecaseStringContants.addPurchaseBill;
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
            CurrenTabTitle.Content = UsecaseStringContants.listPurchaseBill;
            this.Title = UsecaseStringContants.listPurchaseBill;
        }

        private void MenuEndOfShift_Click(object sender, RoutedEventArgs e)
        {
            //If found  tab was EndOfShift, selected for Tabcontrol
            var index = TabControlManagement.GetIndexByTitle(MainTabControl, UsecaseStringContants.listEndOfShift);
            if (index >= 0)
            {
                MainTabControl.SelectedIndex = index;
            }
            //If not found tab was EndOfShift, add and selected
            else
            {
                ListEndOfShiftUserControl listEndOfShiftUserControl = new ListEndOfShiftUserControl() { CanAprrove = true};
                listEndOfShiftUserControl.SetupButton();
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

        private void MenuListSaleBill_Click(object sender, RoutedEventArgs e)
        {
            //If found  tab was ListSaleBill, selected for Tabcontrol
            var index = TabControlManagement.GetIndexByTitle(MainTabControl, UsecaseStringContants.listSaleBill);
            if (index >= 0)
            {
                MainTabControl.SelectedIndex = index;
            }
            //If not found tab was ListSaleBill, add and selected
            else
            {
                ListSaleBillUserControl listSaleBillUserControl = new ListSaleBillUserControl();
                listSaleBillUserControl.SetUpForAdmin();
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

        private void MenuStatistics_Click(object sender, RoutedEventArgs e)
        {
            //If found  tab was Statistics, selected for Tabcontrol
            var index = TabControlManagement.GetIndexByTitle(MainTabControl, UsecaseStringContants.statistics);
            if (index >= 0)
            {
                MainTabControl.SelectedIndex = index;
            }
            //If not found tab was Statistics, add and selected
            else
            {
                StatisticsUserControl statisticsUserControl = new StatisticsUserControl();
                CustomTabItem customTabItem = new CustomTabItem()
                {
                    Title = UsecaseStringContants.statistics,
                    Content = statisticsUserControl
                };
                MainTabControl.Items.Add(customTabItem);
                MainTabControl.SelectedItem = customTabItem;
            }
            CurrenTabTitle.Content = UsecaseStringContants.statistics;
            this.Title = UsecaseStringContants.statistics;
        }

        private void MenuManageStaff_Click(object sender, RoutedEventArgs e)
        {
            //If found  tab was ManageStaff, selected for Tabcontrol
            var index = TabControlManagement.GetIndexByTitle(MainTabControl, UsecaseStringContants.manageStaff);
            if (index >= 0)
            {
                MainTabControl.SelectedIndex = index;
            }
            //If not found tab was ManageStaff, add and selected
            else
            {
                ListStaffUserControl listStaffUserControl = new ListStaffUserControl();
                CustomTabItem customTabItem = new CustomTabItem()
                {
                    Title = UsecaseStringContants.manageStaff,
                    Content = listStaffUserControl
                };
                MainTabControl.Items.Add(customTabItem);
                MainTabControl.SelectedItem = customTabItem;
            }
            CurrenTabTitle.Content = UsecaseStringContants.manageStaff;
            this.Title = UsecaseStringContants.manageStaff;
        }
    }
}