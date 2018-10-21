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
using System.Windows.Shapes;

namespace ShreeMehtaPublicity.VIEW
{
    /// <summary>
    /// Interaction logic for TodayTomorrowSiteView.xaml
    /// </summary>
    public partial class TodayTomorrowSiteView : UserControl
    {
        private MainWindow parent;
        public TodayTomorrowSiteView(string action, MainWindow parent)
        {
            this.parent = parent;

            this.DataContext = new VIEWMODEL.TodayTomorrowSiteViewModel(action);
            InitializeComponent();

            this.Visibility = Visibility.Visible;
        }

        private void TodayTomorrowSiteWindow_Closing(object sender, RoutedEventArgs e)
        {
            clos();   
        }

        private void clos()
        {
            parent.Focus();
            parent.Activate();
            this.Visibility = Visibility.Hidden;
            parent.CallBack();
        }

        private void EnterKey_Ok(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                clos();
        }

        private void EscapeKey_Clos(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                clos();
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            OkButton.Focus();
        }
    }
}
