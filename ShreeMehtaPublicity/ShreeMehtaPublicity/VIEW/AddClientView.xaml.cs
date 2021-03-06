﻿using System;
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
    /// Interaction logic for AddClientView.xaml
    /// </summary>
    public partial class AddClientView : Window
    {
        ClientMgmtView parent;
        VIEWMODEL.AddClientViewModel addClientViewModel;

        public AddClientView(ClientMgmtView parent, string action, MODEL.ClientModel clientModel)
        {
            this.parent = parent;

            this.addClientViewModel = new VIEWMODEL.AddClientViewModel(this, action, clientModel);
            this.DataContext = this.addClientViewModel;
            InitializeComponent();

            this.Activate();
        }

        private void AddClientWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parent.CallBack();
        }

        public void close()
        {
            parent.CallBack();
        }
    }
}
