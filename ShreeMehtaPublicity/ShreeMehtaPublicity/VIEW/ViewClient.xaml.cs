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
    /// Interaction logic for ViewClient.xaml
    /// </summary>
    public partial class ViewClient : UserControl
    {
        private MainWindow parent;
        private VIEWMODEL.ViewClientViewModel viewClientViewModel;

        public ViewClient(MainWindow parent, MODEL.ClientModel clientModel)
        {
            this.parent = parent;
            this.viewClientViewModel = new VIEWMODEL.ViewClientViewModel(clientModel);
            this.DataContext = this.viewClientViewModel;
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            parent.menuItem_grid.Children.Remove(this);
        }
    }
}
