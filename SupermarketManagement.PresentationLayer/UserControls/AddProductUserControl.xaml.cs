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
    /// Interaction logic for AddProductUserControl.xaml
    /// </summary>
    public partial class AddProductUserControl : UserControl
    {

        private readonly IProductBusiness _productBusiness;
        private readonly ICategoryBusiness _categoryBusiness;
        private readonly ISupplierBusiness _supplierBusiness;
        public ProductViewModel productViewModel;
        public AddProductUserControl()
        {
            _productBusiness = new ProductBusiness();
            _categoryBusiness = new CategoryBusiness();
            _supplierBusiness = new SupplierBusiness();
            productViewModel = new ProductViewModel();
            
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            LoadAdd(productViewModel);
            var categories = _categoryBusiness.GetAll();
            LoadComboBoxCategories(categories);
            var suppliers = _supplierBusiness.GetAll();
            LoadComboBoxSuppliers(suppliers);
            productViewModel.AcceptValidModel = false;
        }

        private void LoadComboBoxSuppliers(List<Supplier> suppliers)
        {
            int currentIndex = 0;
            if (suppliers != null && suppliers.Count != 0)
            {
                foreach (var item in suppliers)
                {
                    if (item.SupplierId == productViewModel.SupplierId)
                    {
                        currentIndex = item.SupplierId;
                    }
                    ComboBoxSuppliers.Items.Add(new ComboBoxItem { Content = item.SupplierName, Tag = item.SupplierId });

                }
            }
            ComboBoxSuppliers.SelectedIndex = currentIndex;
            //SupplierId.Text = suppliers[currentIndex].SupplierId.ToString();
            productViewModel.SupplierId = suppliers[currentIndex].SupplierId;
        }

        private void LoadComboBoxCategories(List<Category> categories)
        {
            int currentIndex = 0;
            if (categories != null && categories.Count != 0)
            {                
                foreach (var item in categories)
                {
                    if (item.CategoryId == productViewModel.CategoryId)
                    {
                        currentIndex = item.CategoryId;
                    }
                    ComboBoxCategories.Items.Add(new ComboBoxItem { Content = item.CategoryName, Tag = item.CategoryId });
                    
                }
            }
            ComboBoxCategories.SelectedIndex = currentIndex;
            //CategoryId.Text = categories[currentIndex].CategoryId.ToString();
            productViewModel.CategoryId = categories[currentIndex].CategoryId;
        }

        private void LoadAdd(ProductViewModel productViewModel)
        {
            this.DataContext = productViewModel;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (productViewModel.IsValidModel())
            {
                var isSuccess = _productBusiness.Add(productViewModel);
                if (isSuccess)
                {
                    MessageBox.Show("Đã thêm thành công!", "Add", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công!", "Add", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ComboBoxCategories_Changed(object sender, SelectionChangedEventArgs e)
        {
            var currentItem = (ComboBoxItem)ComboBoxCategories.SelectedItem;
            CategoryId.Text = currentItem.Tag.ToString();
        }

        private void ComboBoxSuppliers_Changed(object sender, SelectionChangedEventArgs e)
        {
            var currentItem = (ComboBoxItem)ComboBoxSuppliers.SelectedItem;
            SupplierId.Text = currentItem.Tag.ToString();
        }
    }

}
