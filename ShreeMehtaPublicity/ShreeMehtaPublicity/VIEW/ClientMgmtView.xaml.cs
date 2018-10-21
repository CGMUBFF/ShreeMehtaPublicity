using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for ClientMgmtView.xaml
    /// </summary>
    public partial class ClientMgmtView : UserControl
    {
        private MainWindow parent;
        private AddClientView addClientView;
        private AddClientView mdfyClientView;
        private AddClientView actvClientView;
        private AddClientView iactClientView;
        private VIEWMODEL.ClientMgmtViewModel clientMgmtViewModel;

        public ClientMgmtView(MainWindow parent)
        {
            this.parent = parent;
            clientMgmtViewModel = new VIEWMODEL.ClientMgmtViewModel();

            this.DataContext = clientMgmtViewModel;
            InitializeComponent();

            this.Visibility = Visibility.Visible;
        }

        private void Add_Client(object sender, RoutedEventArgs e)
        {
            add();
        }

        private void Mdfy_Client(object sender, RoutedEventArgs e)
        {
            //ListViewItem listViewItem = (ListViewItem)sender;
            mdfy();
        }

        private void Actv_Client(object sender, RoutedEventArgs e)
        {
            actv();
        }

        private void Iact_Client(object sender, RoutedEventArgs e)
        {
            iact();
        }

        private void ClientMgmtWindow_Closing(object sender, RoutedEventArgs e)
        {
            close();
        }

        private void View_Client(object sender, RoutedEventArgs e)
        {
            parent.menuItem_grid.Children.Add(new ViewClient(parent, clientMgmtViewModel.SelectedClient));
        }

        private void add()
        {
            addClientView = new AddClientView(this, "ADD", null);
            addClientView.Owner = parent;
            addClientView.Show();
        }

        private void mdfy()
        {
            mdfyClientView = new AddClientView(this, "MDFY", clientMgmtViewModel.SelectedClient);
            mdfyClientView.Owner = parent;
            mdfyClientView.Show();
        }

        private void actv()
        {
            actvClientView = new AddClientView(this, "ACTV", clientMgmtViewModel.SelectedClient);
        }

        private void iact()
        {
            iactClientView = new AddClientView(this, "IACT", clientMgmtViewModel.SelectedClient);
        }

        private void close()
        {
            if (addClientView != null)
                addClientView.Close();
            if (mdfyClientView != null)
                mdfyClientView.Close();
            if (actvClientView != null)
                actvClientView.Close();
            if (iactClientView != null)
                iactClientView.Close();

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
                clientMgmtViewModel.searchClients();
                this.Focus();
            }
        }

        private void switch_Click(object sender, RoutedEventArgs e)
        {
            if (clientMgmtViewModel.SelectedClient.ClientStatus.Equals(Utility.Status.ACTV))
                iact();
            else
                actv();
        }
    }
}
