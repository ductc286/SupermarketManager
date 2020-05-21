using Supermarketmanagement.PresentationLayer.Custom;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for AddMultilpleSaleBillUserControl.xaml
    /// </summary>
    public partial class AddMultilpleSaleBillUserControl : UserControl
    {
        int maxAddSaleBillTab = 5;

        public AddMultilpleSaleBillUserControl()
        {
            InitializeComponent();
            LoadMainTabControl();
        }

        private void LoadMainTabControl()
        {
            AddSaleBillUserControl addSaleBillUserControl = new AddSaleBillUserControl();
            CustomTabItem customTabItem = new CustomTabItem() { Title = GenerateTabTitle(1), Content = addSaleBillUserControl };
            TabControl_AddSaleBills.Items.Clear();
            TabControl_AddSaleBills.Items.Add(customTabItem);
            TabControl_AddSaleBills.SelectedItem = customTabItem;
        }

        private void MenuAddSaleBill_Click(object sender, RoutedEventArgs e)
        {
            var numberItem = TabControl_AddSaleBills.Items.Count;
            if (numberItem >= maxAddSaleBillTab)
            {
                MessageBox.Show("Số tab tạo hóa đơn tối đa là !"+maxAddSaleBillTab, "Add more", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            ////reset the list of tab titles
            for (int i = 0; i < numberItem; i++)
            {
                CustomTabItem currentTab = (CustomTabItem)TabControl_AddSaleBills.Items[i];
                currentTab.Title = GenerateTabTitle(i + 1);
            }
            //Add new tab
            AddSaleBillUserControl addSaleBillUserControl = new AddSaleBillUserControl();
            CustomTabItem customTabItem = new CustomTabItem() { Title = GenerateTabTitle(numberItem+1), Content = addSaleBillUserControl };
            TabControl_AddSaleBills.Items.Add(customTabItem);
            TabControl_AddSaleBills.SelectedItem = customTabItem;
        }

        private string GenerateTabTitle(int index)
        {
            return "Hoá đơn " + index;
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            LoadMainTabControl();
        }
    }
}
