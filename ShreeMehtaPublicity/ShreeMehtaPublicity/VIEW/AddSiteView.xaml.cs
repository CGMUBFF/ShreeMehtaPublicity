using System.Windows;

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
