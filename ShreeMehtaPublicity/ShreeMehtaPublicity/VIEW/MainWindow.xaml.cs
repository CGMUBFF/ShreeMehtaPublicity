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

using ShreeMehtaPublicity.Utility;

namespace ShreeMehtaPublicity.VIEW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db;
        //string LoginId;

        public MainWindow(/*string LoginId=null*/)
        {
            //this.LoginId = LoginId;
            db = Database.getInstance();

            this.DataContext = new VIEWMODEL.MainWindowViewModel();
            InitializeComponent();

            this.Activate();
            //this.Close();
            /*SiteMgmtView siteMgmtView = new SiteMgmtView(this);
            menuItem_grid.Children.Add(siteMgmtView);*/

            SiteCautationView siteCautationView = new SiteCautationView(this);
            menuItem_grid.Children.Add(siteCautationView);
        }

        private void onClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Put Command instead of this inn VM
            //mainWindow.Update();
            /*if(true)//WpfMessageBox.Show("Do You Want to Logout?","Logout",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                string output = db.db_Logout(LoginId);
                if(!output.Equals(Status.SUCC))
                {
                    e.Reset = true;
                }
            }
            else
            {
                e.Reset = true;
            }*/
        }

        public void CallBack()
        {
            menuItem_grid.Children.Clear();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.CallBack();
            this.Close();
        }

        private void MenuItemClick(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            MenuUnderline.Margin = new Thickness(10 + (150 * index), 0, 0, 0);

            menuItem_grid.Children.Clear();

            switch(index)
            {
                case 0:
                    SiteMgmtView siteMgmtView = new SiteMgmtView(this);
                    menuItem_grid.Children.Add(siteMgmtView);
                    break;
                case 1:                    
                    ClientMgmtView clientMgmtView = new ClientMgmtView(this);
                    menuItem_grid.Children.Add(clientMgmtView);
                    break;
                case 2:
                    OrderMgmtView orderMgmtView = new OrderMgmtView(this);
                    menuItem_grid.Children.Add(orderMgmtView);
                    break;
                case 3:
                    SiteCautationView siteCautationView = new SiteCautationView(this);
                    menuItem_grid.Children.Add(siteCautationView);
                    break;
            }
        }
    }
}
