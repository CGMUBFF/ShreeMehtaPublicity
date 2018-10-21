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

        private void Amount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == ".")
            {
                if (!((TextBox)sender).Text.Contains("."))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            else if (!(char.IsDigit(e.Text, e.Text.Length - 1)))
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void Amount_LostFocus(object sender, RoutedEventArgs e)
        {
            /*if (Amount.Text == null || Amount.Text.Trim().Equals(""))
            {
                Amount.Text = "0";
                Amount.Foreground = new SolidColorBrush(Colors.Gray);
            }
            else if (Double.Parse(Amount.Text) == 0)
            {
                Amount.Text = "0";
                Amount.Foreground = new SolidColorBrush(Colors.Gray);
            }
            else if (Amount.Text.Contains("."))
            {
                if (Amount.Text.LastIndexOf(".") == (Amount.Text.Length - 1))
                    Amount.Text += "00";
                else if (Amount.Text.LastIndexOf(".") == (Amount.Text.Length - 2))
                    Amount.Text += "0";
            }
            else
            {
                Amount.Text += ".00";
            }*/
        }

        private void Amount_GotFocus(object sender, RoutedEventArgs e)
        {
            /*if (Double.Parse(Amount.Text) == 0)
            {
                Amount.Text = "";
                Amount.Foreground = new SolidColorBrush(Colors.Black);
            }*/
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
