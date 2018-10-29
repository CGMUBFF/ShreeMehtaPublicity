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
using System.Text.RegularExpressions;

namespace ShreeMehtaPublicity.VIEW
{
    /// <summary>
    /// Interaction logic for PlaceOrderView.xaml
    /// </summary>
    public partial class PlaceOrderView : Window
    {
        private OrderMgmtView parent;
        private VIEWMODEL.PlaceOrderViewModel placeOrderViewModel;

        public PlaceOrderView(string action, MODEL.OrderModel orderModel, OrderMgmtView parent)
        {
            this.parent = parent;

            placeOrderViewModel = new VIEWMODEL.PlaceOrderViewModel(this, action, orderModel);
            this.DataContext = placeOrderViewModel;
            InitializeComponent();

            this.Activate();
        }

        private void PlaceOrderWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            close();
        }

        public void close()
        {
            parent.CallBack();
        }

        private void StartDate_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DatePicker datepicker = (DatePicker)sender;

            if ((bool)e.NewValue)
            {
                datepicker.IsTabStop = !(bool)e.NewValue;
            }
        }

        private void EndDate_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DatePicker datepicker = (DatePicker)sender;

            if ((bool)e.NewValue)
            {
                datepicker.IsTabStop = !(bool)e.NewValue;
            }
        }

        private void EndDate_CalendarOpened(object sender, RoutedEventArgs e)
        {
            DatePicker datepicker = (DatePicker)sender;

            if (placeOrderViewModel.EndDateReadOnly)
                datepicker.IsDropDownOpen = false;
        }
    }
}
