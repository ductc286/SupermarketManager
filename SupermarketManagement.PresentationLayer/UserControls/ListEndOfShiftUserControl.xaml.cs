using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using SupermarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for ListEndOfShiftUserControl.xaml
    /// </summary>
    public partial class ListEndOfShiftUserControl : UserControl
    {
        IEndOfShiftBusiness _endOfShiftBusiness;
        public List<EndOfShift> endOfShifts;
        public bool CanAprrove { get; set; } = false;
        public ListEndOfShiftUserControl()
        {
            InitializeComponent();
            InitializeData();
            SetupButton();
        }

        public void SetupButton()
        {
            if (CanAprrove)
            {
                Button_Approve.Visibility = Visibility.Visible;
                Button_Delete.Visibility = Visibility.Hidden;
            }
            else
            {
                Button_Approve.Visibility = Visibility.Hidden;
                Button_Delete.Visibility = Visibility.Visible;
            }
        }

        private void InitializeData()
        {
            _endOfShiftBusiness = new EndOfShiftBusiness();
            endOfShifts = _endOfShiftBusiness.GetAll();
            this.DataContext = endOfShifts;
            ListViewEndOfShifts.ItemsSource = endOfShifts;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var endOfShift = (EndOfShift)ListViewEndOfShifts.SelectedItem;
            if (endOfShift != null)
            {
                if (endOfShift.IsApproved)
                {
                    MessageBox.Show("Không thể xoá đơn hàng đã được phê duyệt!", "Delete", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    _endOfShiftBusiness.Delete(endOfShift);
                    InitializeData();
                }
            }
        }

        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            var endOfShift = (EndOfShift)ListViewEndOfShifts.SelectedItem;
            if (endOfShift != null)
            {
                if (endOfShift.IsApproved)
                {
                    MessageBox.Show("Phiếu này đã được phê duyệt rồi!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    _endOfShiftBusiness.Approve(endOfShift);
                    InitializeData();
                }
            }
        }

        private void ButtonReload_Click(object sender, RoutedEventArgs e)
        {
            InitializeData();
        }
    }
}
