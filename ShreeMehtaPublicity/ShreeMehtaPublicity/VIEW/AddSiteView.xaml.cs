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
    /// Interaction logic for AddSiteView.xaml
    /// </summary>
    public partial class AddSiteView : Window
    {
        private SiteMgmtView parent;

        public AddSiteView(SiteMgmtView parent, string action, MODEL.SiteModel siteModel)
        {
            this.parent = parent;

            this.DataContext = new VIEWMODEL.AddSiteViewModel(this, action, siteModel);
            InitializeComponent();

            this.Activate();
        }

        private void AddSiteWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            close();
        }

        public void close()
        {
            parent.CallBack();
        }
    }
}
