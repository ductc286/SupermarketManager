using Supermarketmanagement.Core.ViewModels;
using Supermarketmanagement.PresentationLayer.UserControls;
using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using SupermarketManagement.Core.Models;
using System.Windows;

namespace Supermarketmanagement.PresentationLayer.Windows
{
    /// <summary>
    /// Interaction logic for EditCategoryWindow.xaml
    /// </summary>
    public partial class EditCategoryWindow : Window
    {
        public CategoryViewModel categoryViewModel;
        private readonly ICategoryBusiness _categoryBusiness;
        public EditCategoryWindow(Category category)
        {
            InitializeComponent();
            this.categoryViewModel = new CategoryViewModel()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
            this.DataContext = categoryViewModel;
            _categoryBusiness = new CategoryBusiness();
            LoadData(categoryViewModel);
        }

        private void LoadData(CategoryViewModel categoryViewModel)
        {
            EditCategoryUserControl editCategoryUserControl = new EditCategoryUserControl(categoryViewModel);
            MainControl.Items.Add(editCategoryUserControl);
        }
    }
}
