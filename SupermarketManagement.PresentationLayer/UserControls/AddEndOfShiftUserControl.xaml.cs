using Supermarketmanagement.Core.Common;
using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using SupermarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for AddEndOfShifUserControl.xaml
    /// </summary>
    public partial class AddEndOfShiftUserControl : UserControl
    {
        public EndOfShiftViewModel endOfShiftViewModel;
        private IEndOfShiftBusiness _endOfShiftBusiness;
        public AddEndOfShiftUserControl()
        {
            endOfShiftViewModel = new EndOfShiftViewModel();
            _endOfShiftBusiness = new EndOfShiftBusiness();
            InitializeComponent();
            this.DataContext = endOfShiftViewModel;
            InitializeData();
        }

        private void InitializeData()
        {
            
            StaffName.Text = StaffGlobal.CurrentStaff.Account;
            Load_ComboBoxTotalHours();

        }
        private void Load_ComboBoxTotalHours()
        {
            List<int> listlHours = new List<int>() { 2, 4, 8 };
            foreach (var item in listlHours)
            {
                var comboboxItem = new ComboBoxItem()
                {
                    Content = item.ToString(),
                    Tag = item
                };
                ComboBoxTotalHours.Items.Add(comboboxItem);
            }
            ComboBoxTotalHours.SelectedIndex = 0;
            TotalHours.Text = "2";
            endOfShiftViewModel.TotalHours = 2;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (endOfShiftViewModel.IsValidModel())
            {
                var isSuccess = _endOfShiftBusiness.Add(endOfShiftViewModel);
                if (isSuccess)
                {
                    MessageBox.Show("Đã thêm thành công!", "Add", MessageBoxButton.OK, MessageBoxImage.Information);
                    endOfShiftViewModel = new EndOfShiftViewModel();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công!", "Add", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ComboBoxTotalHours_Changed(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem comboBoxItem =(ComboBoxItem) ComboBoxTotalHours.SelectedItem;
            if (comboBoxItem != null)
            {
                TotalHours.Text = comboBoxItem.Tag.ToString();
            }
            
        }
    }
}
