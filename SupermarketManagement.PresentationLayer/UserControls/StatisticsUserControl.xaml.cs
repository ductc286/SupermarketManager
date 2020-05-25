using Supermarketmanagement.Core.Utilities;
using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using System;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for StatisticsUserControl.xaml
    /// </summary>
    public partial class StatisticsUserControl : UserControl
    {
        private StatisticsViewModel statisticsViewModel;
        private readonly IStatisticsBusiness statisticsBusiness;
        public DateTime fromDate = DateTime.Now;
        public DateTime toDate = DateTime.Now;

        public StatisticsUserControl()
        {
            statisticsBusiness = new StatisticsBusiness();
            
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            statisticsViewModel = statisticsBusiness.GetStatisticsViewModel(fromDate, toDate);
            this.DataContext = statisticsViewModel;
        }

        private void ComboBoxInterval_Click(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBoxItem)ComboBoxInterval.SelectedItem;
            switch (comboBox.Tag)
            {
                case "ToDay":
                    DateTimeUtilities.GetIntervalToDay(ref fromDate, ref toDate);
                    InitializeData();
                    break;
                case "ThisMonth":
                    DateTimeUtilities.GetIntervalThisMonth(ref fromDate, ref toDate);
                    InitializeData();
                    break;
                case "ThisYear":
                    DateTimeUtilities.GetIntervalThisYear(ref fromDate, ref toDate);
                    InitializeData();
                    break;
                default:
                    break;
            }
        }

    }
}
