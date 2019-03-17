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

namespace ShreeMehtaPublicity.VIEW
{
    /// <summary>
    /// Interaction logic for SiteCautationView.xaml
    /// </summary>
    public partial class SiteCautationView : UserControl
    {
        private MainWindow parent;
        private CreateCautationView createCautationView;
        private VIEWMODEL.SiteCautationViewModel siteCautationViewModel;

        public SiteCautationView(MainWindow parent)
        {
            this.parent = parent;
            siteCautationViewModel = new VIEWMODEL.SiteCautationViewModel();

            this.DataContext = siteCautationViewModel;
            InitializeComponent();

            this.Visibility = Visibility.Visible;
        }

        private void close()
        {
            parent.Focus();
            parent.Activate();
            this.Visibility = Visibility.Hidden;
            parent.CallBack();
        }

        public void CallBack(bool resetCautation)
        {
            parent.Focus();
            parent.Activate();
            if (this.IsVisible)
            {
                if (resetCautation)
                {
                    siteCautationViewModel.ListofSelectedCautationSites.Clear();
                }
                siteCautationViewModel.searchSites();
                this.Focus();
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            siteCautationViewModel.cautationSiteChecked((bool)((CheckBox)sender).IsChecked);
        }

        private void All_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            siteCautationViewModel.allCautationSiteChecked((bool)((CheckBox)sender).IsChecked);
        }

        private void CreateCautation_Click(object sender, RoutedEventArgs e)
        {
            createCautationView = new CreateCautationView(this, siteCautationViewModel.ListofSelectedCautationSites);
            createCautationView.Owner = parent;
            createCautationView.Show();
        }

        private void CautationHistory(object sender, RoutedEventArgs e)
        {
            parent.menuItem_grid.Children.Add(new CautationHistory());
        }
    }
}
