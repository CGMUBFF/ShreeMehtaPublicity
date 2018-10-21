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
using System.Windows.Controls.Primitives;

namespace ShreeMehtaPublicity.VIEW
{
    /// <summary>
    /// Interaction logic for SiteMgmtView.xaml
    /// </summary>
    public partial class SiteMgmtView : UserControl
    {
        private MainWindow parent;
        private AddSiteView addSiteView;
        private AddSiteView mdfySiteView;
        private AddSiteView actvSiteView;
        private AddSiteView iactSiteView;
        private VIEWMODEL.SiteMgmtViewModel siteMgmtViewModel;

        public SiteMgmtView(MainWindow parent)
        {
            this.parent = parent;
            siteMgmtViewModel = new VIEWMODEL.SiteMgmtViewModel();

            this.DataContext = siteMgmtViewModel;
            InitializeComponent();

            this.Visibility = Visibility.Visible;
        }

        private void Add_Site(object sender, RoutedEventArgs e)
        {
            add();
        }

        private void Mdfy_Site(object sender, RoutedEventArgs e)
        {
            mdfy();
        }

        private void SiteMgmtWindow_Closing(object sender, RoutedEventArgs e)
        {
            close();
        }

        private void View_Site(object sender, RoutedEventArgs e)
        {
            parent.menuItem_grid.Children.Add(new ViewSite(parent, siteMgmtViewModel.SelectedSite));
        }

        private void add()
        {
            addSiteView = new AddSiteView(this, "ADD", null);
            addSiteView.Owner = parent;
            addSiteView.Show();
        }

        private void mdfy()
        {
            mdfySiteView = new AddSiteView(this, "MDFY", siteMgmtViewModel.SelectedSite);
            mdfySiteView.Owner = parent;
            mdfySiteView.Show();
        }

        private void actv()
        {
            actvSiteView = new AddSiteView(this, "ACTV", siteMgmtViewModel.SelectedSite);
        }

        private void iact()
        {
            iactSiteView = new AddSiteView(this, "IACT", siteMgmtViewModel.SelectedSite);
        }

        private void close()
        {
            if (addSiteView != null)
                addSiteView.Close();
            else if (mdfySiteView != null)
                mdfySiteView.Close();
            else if (iactSiteView != null)
                iactSiteView = null;
            else if (actvSiteView != null)
                actvSiteView = null;

            parent.Focus();
            parent.Activate();
            this.Visibility = Visibility.Hidden;
            parent.CallBack();
        }

        public void CallBack()
        {
            parent.Focus();
            parent.Activate();
            if (this.IsVisible)
            {
                siteMgmtViewModel.searchSites();
                this.Focus();
            }
        }

        private void switch_Click(object sender, RoutedEventArgs e)
        {
            if (siteMgmtViewModel.SelectedSite.SiteStatus.Equals(Utility.Status.ACTV))
                iact();
            else
                actv();
        }
    }
}
