using ShreeMehtaPublicity.MODEL;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;

namespace ShreeMehtaPublicity.VIEW
{
    /// <summary>
    /// Interaction logic for CreateCautationView.xaml
    /// </summary>
    public partial class CreateCautationView : Window
    {
        private SiteCautationView parent;
        VIEWMODEL.CreateCautationViewModel createCautationViewModel;
        public CreateCautationView(SiteCautationView parent, ObservableCollection<SiteCautationModel> listofSelectedCautation)
        {
            this.parent = parent;

            createCautationViewModel = new VIEWMODEL.CreateCautationViewModel(this, listofSelectedCautation);
            this.DataContext = createCautationViewModel;
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
            parent.CallBack(createCautationViewModel.CautationConfirmed);
        }

        public void editSite()
        {
            this.Close();
        }
    }
}
