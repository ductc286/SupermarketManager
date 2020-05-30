using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using SupermarketManagement.Core.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for EditCategoryUserControl.xaml
    /// </summary>
    public partial class EditCategoryUserControl : UserControl
    {
        public event EventHandler ExecuteMethod;
        public CategoryViewModel categoryViewModel;
        private readonly ICategoryBusiness _categoryBusiness;

        public EditCategoryUserControl(CategoryViewModel categoryViewModel)
        {
            _categoryBusiness = new CategoryBusiness();
            this.categoryViewModel = categoryViewModel;
            InitializeComponent();
            InitializeData();
        }

        public EditCategoryUserControl(Category category)
        {
            _categoryBusiness = new CategoryBusiness();
            this.categoryViewModel = new CategoryViewModel(category);
            InitializeComponent();
            InitializeData();
        }

        protected virtual void OnExecuteMethod()
        {
            if (ExecuteMethod != null) ExecuteMethod(this, EventArgs.Empty);
        }

        public void ChildButton_Click(object sender, EventArgs e)
        {
            OnExecuteMethod();
        }

        private void InitializeData()
        {
            LoadEdit(categoryViewModel);
        }

        private void LoadEdit(CategoryViewModel categoryViewModel)
        {
            this.DataContext = categoryViewModel;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (categoryViewModel.IsValidModel())
            {
                var isUpdate = _categoryBusiness.Update(categoryViewModel);
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
    }
}
