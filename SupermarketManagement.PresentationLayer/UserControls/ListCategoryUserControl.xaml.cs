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
        public List<Category> categories = new List<Category>();
        public ListCategoryUserControl()
        {
            InitializeComponent();
            _categoryBusiness = new CategoryBusiness();
            InitializeData();
        }

        /// <summary>
        /// List the methods needed for data initialization
        /// </summary>
        private void InitializeData()
        {
            categories = _categoryBusiness.GetAll();
            ListCategories.ItemsSource = null;
            ListCategories.ItemsSource = categories;
            this.DataContext = categories;
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
                //EditCategoryWindow editCategoryWindow = new EditCategoryWindow(category);
                //var show = editCategoryWindow.ShowDialog();

                EditCategoryUserControl editCategoryUserControl = new EditCategoryUserControl(category);
                DialogWindow dialogWindow = new DialogWindow(editCategoryUserControl, UsecaseStringContants.editCategory, editCategoryUserControl.Width, editCategoryUserControl.Height);
                dialogWindow.ShowDialog();

                InitializeData();
                //editCategoryWindow.Closed += dialog_Closed;
                //categories = _categoryBusiness.GetAll();
                //this.DataContext = categories;
                //ListCategories.ItemsSource = null;
                //ListCategories.ItemsSource = categories;

            }
        }
        private void dialog_Closed(object sender, System.EventArgs e)
        {
            Button_Edit.Content = "NEw Edit";
            categories = _categoryBusiness.GetAll();
            this.DataContext = categories;
            ListCategories.ItemsSource = null;
            ListCategories.ItemsSource = categories;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var obj = (Category)ListCategories.SelectedItem;
            if (obj == null)
            {
                MessageBox.Show("Chưa có mục nào được chọn!", "Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            else if (obj != null)
            {
                var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này?", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (confirm == MessageBoxResult.OK)
                {
                    bool isSuccess = _categoryBusiness.Delete(obj.CategoryId);
                    if (isSuccess)
                    {
                        InitializeData();
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công, có thể mục này không được phép xóa.", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                }

            }
        }
    }
}
