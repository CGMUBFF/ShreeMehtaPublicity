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
using System.Collections.ObjectModel;

using ShreeMehtaPublicity.MODEL;

namespace ShreeMehtaPublicity.VIEW
{
    /// <summary>
    /// Interaction logic for CreateCautationView.xaml
    /// </summary>
    public partial class CreateCautationView : Window
    {
        private SiteCautationView parent;
        public CreateCautationView(SiteCautationView parent, ObservableCollection<SiteCautationModel> listofSelectedCautation)
        {
            this.parent = parent;

            this.DataContext = new VIEWMODEL.CreateCautationViewModel(this, listofSelectedCautation);           
            InitializeComponent();
            
            this.Activate();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ClientList.ItemsSource);
            view.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(toText.Text))
                return true;
            else
                return (((item as ClientModel).ClientName.IndexOf(toText.Text, StringComparison.OrdinalIgnoreCase) >= 0) || ((item as ClientModel).ClientMail.IndexOf(toText.Text, StringComparison.OrdinalIgnoreCase) >= 0));
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ClientList.ItemsSource).Refresh();
        }

        private void CreateCautationView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            close();
        }

        public void close()
        {
            parent.CallBack();
        }

        public void editSite()
        {
            this.Close();
        }
    }
}
