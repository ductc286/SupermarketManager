using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using System.Windows;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for AddCategoryUserControl.xaml
    /// </summary>
    public partial class AddCategoryUserControl : UserControl
    {

        private readonly ICategoryBusiness _categoryBusiness;
        public CategoryViewModel categoryViewModel;
        public AddCategoryUserControl()
        {
            InitializeComponent();
            _categoryBusiness = new CategoryBusiness();
            categoryViewModel = new CategoryViewModel();
            InitializeData();
        }

        private void InitializeData()
        {
            LoadAdd(categoryViewModel);
        }

        private void LoadAdd(CategoryViewModel categoryViewModel)
        {
            
            this.DataContext = categoryViewModel;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (categoryViewModel.IsValidModel())
            {
                var isSuccess = _categoryBusiness.Add(categoryViewModel);
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
    }
}
