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
    /// Interaction logic for ViewSite.xaml
    /// </summary>
    public partial class ViewSite : UserControl
    {
        private MainWindow parent;
        private VIEWMODEL.ViewSiteViewModel viewSiteViewModel;

        public ViewSite(MainWindow parent, MODEL.SiteModel siteModel)
        {
            this.parent = parent;
            this.viewSiteViewModel = new VIEWMODEL.ViewSiteViewModel(siteModel);
            this.DataContext = this.viewSiteViewModel;
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            parent.menuItem_grid.Children.Remove(this);
        }
    }
}
