using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using SupermarketManagement.Core.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for EditProductUserControl.xaml
    /// </summary>
    public partial class EditProductUserControl : UserControl
    {
        private readonly IProductBusiness _productBusiness;
        private readonly ICategoryBusiness _categoryBusiness;
        private readonly ISupplierBusiness _supplierBusiness;
        public ProductViewModel productViewModel;

        public EditProductUserControl(ProductViewModel productViewModel)
        {
            _productBusiness = new ProductBusiness();
            _categoryBusiness = new CategoryBusiness();
            _supplierBusiness = new SupplierBusiness();
            this.productViewModel = productViewModel;

            InitializeComponent();
            InitializeData();
        }
        public EditProductUserControl(Product product)
        {
            _productBusiness = new ProductBusiness();
            _categoryBusiness = new CategoryBusiness();
            _supplierBusiness = new SupplierBusiness();
            this.productViewModel = new ProductViewModel(product);

            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            LoadEdit(productViewModel);
            var categories = _categoryBusiness.GetAll();
            LoadComboBoxCategories(categories);
            var suppliers = _supplierBusiness.GetAll();
            LoadComboBoxSuppliers(suppliers);
            productViewModel.AcceptValidModel = false;
        }

        private void LoadComboBoxSuppliers(List<Supplier> suppliers)
        {
            //int currentIndex = 0;
            //if (suppliers != null && suppliers.Count != 0)
            //{
            //    foreach (var item in suppliers)
            //    {
            //        if (item.SupplierId == productViewModel.SupplierId)
            //        {
            //            currentIndex = item.SupplierId;
            //        }
            //        ComboBoxSuppliers.Items.Add(new ComboBoxItem { Content = item.SupplierName, Tag = item.SupplierId });

            //    }
            //}
            //ComboBoxSuppliers.SelectedIndex = currentIndex;
            ////SupplierId.Text = suppliers[currentIndex].SupplierId.ToString();
            //productViewModel.SupplierId = suppliers[currentIndex].SupplierId;
            if (suppliers != null && suppliers.Count != 0)
            {
                var indexWillSelect = 0;
                var supplierIdWillSelect = suppliers[0].SupplierId;
                int i = 0;
                foreach (var item in suppliers)
                {
                    var comboxItem = new ComboBoxItem { Content = item.SupplierName, Tag = item.SupplierId };
                    ComboBoxSuppliers.Items.Add(comboxItem);
                    if (item.SupplierId == productViewModel.SupplierId)
                    {
                        indexWillSelect = i;
                        supplierIdWillSelect = item.SupplierId;
                    }
                    i++;
                }
                ComboBoxSuppliers.SelectedIndex = indexWillSelect;
                productViewModel.SupplierId = supplierIdWillSelect;
                SupplierId.Text = supplierIdWillSelect.ToString();
            }
        }

        private void LoadComboBoxCategories(List<Category> categories)
        {
            //int currentIndex = 0;
            //if (categories != null && categories.Count != 0)
            //{
            //    foreach (var item in categories)
            //    {
            //        if (item.CategoryId == productViewModel.CategoryId)
            //        {
            //            currentIndex = item.CategoryId;
            //        }
            //        ComboBoxCategories.Items.Add(new ComboBoxItem { Content = item.CategoryName, Tag = item.CategoryId });

            //    }
            //}
            //ComboBoxCategories.SelectedIndex = currentIndex;
            ////CategoryId.Text = categories[currentIndex].CategoryId.ToString();
            //productViewModel.CategoryId = categories[currentIndex].CategoryId;

            if (categories != null && categories.Count != 0)
            {
                var indexWillSelect = 0;
                var categoryIdWillSelect = categories[0].CategoryId;
                int i = 0;
                foreach (var item in categories)
                {
                    var comboxItem = new ComboBoxItem { Content = item.CategoryName, Tag = item.CategoryId };
                    ComboBoxCategories.Items.Add(comboxItem);
                    if (item.CategoryId == productViewModel.CategoryId)
                    {
                        indexWillSelect = i;
                        categoryIdWillSelect = item.CategoryId;
                    }
                    i++;
                }
                ComboBoxCategories.SelectedIndex = indexWillSelect;
                productViewModel.CategoryId = categoryIdWillSelect;
                CategoryId.Text = categoryIdWillSelect.ToString();
            }
        }

        private void LoadEdit(ProductViewModel productViewModel)
        {
            this.DataContext = productViewModel;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (productViewModel.IsValidModel())
            {
                var isUpdate = _productBusiness.Update(productViewModel);
                if (isUpdate)
                {
                    MessageBox.Show("Đã cập nhật thành công!", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công!", "Update", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ComboBoxCategories_Changed(object sender, SelectionChangedEventArgs e)
        {
            var currentItem = (ComboBoxItem)ComboBoxCategories.SelectedItem;
            if (currentItem != null)
            {
                CategoryId.Text = currentItem.Tag.ToString();
            }
        }

        private void ComboBoxSuppliers_Changed(object sender, SelectionChangedEventArgs e)
        {
            var currentItem = (ComboBoxItem)ComboBoxCategories.SelectedItem;
            if (currentItem != null)
            {
                SupplierId.Text = currentItem.Tag.ToString();
            }
        }
    }
}
