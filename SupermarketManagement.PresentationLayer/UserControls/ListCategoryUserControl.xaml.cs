using Supermarketmanagement.Core.ViewModels;
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
    /// Interaction logic for ListCategoryUserControl.xaml
    /// </summary>
    public partial class ListCategoryUserControl : UserControl
    {

        private readonly ICategoryBusiness _categoryBusiness;
        public List<Category> categories;
        public ListCategoryUserControl()
        {
            InitializeComponent();
            _categoryBusiness = new CategoryBusiness();
            categories = _categoryBusiness.GetAll();
            InitializeData();
        }

        /// <summary>
        /// List the methods needed for data initialization
        /// </summary>
        private void InitializeData()
        {
            LoadList(categories);
        }

        public void LoadList(List<Category> categories)
        {
            ListCategories.ItemsSource = categories;

        }

        private void Open_EditCategory(object sender, RoutedEventArgs e)
        {
            var category = (Category)ListCategories.SelectedItem;
            if (category == null)
            {
                MessageBox.Show("Vui lòng chọn một mục trong danh sách!", "Edit", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                EditCategoryWindow editCategoryWindow = new EditCategoryWindow(category);
                editCategoryWindow.Show();
            }
        }
    }
}
