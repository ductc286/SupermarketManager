using System.Windows;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.Windows
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        //public DialogWindow()
        //{
        //    InitializeComponent();
        //    InitializeData();
        //}

        public DialogWindow(UserControl userControl, string title, double width = 400, double height = 450)
        {
            InitializeComponent();
            this.Title = title;
            MainControl.Items.Clear();
            MainControl.Items.Add(userControl);
            SetSize(width, height);
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Owner = Application.Current.MainWindow;
        }

        private void SetSize(double width, double height)
        {
            this.Height = (height + 120);
            this.Width = (width + 80);
        }
    }

    //public enum MySizeWindow { Small, Medium, Big }
}
