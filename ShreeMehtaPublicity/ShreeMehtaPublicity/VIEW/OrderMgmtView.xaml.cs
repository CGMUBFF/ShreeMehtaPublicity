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
using System.Text.RegularExpressions;

namespace ShreeMehtaPublicity.VIEW
{
    /// <summary>
    /// Interaction logic for OrderMgmtView.xaml
    /// </summary>
    public partial class OrderMgmtView : UserControl
    {
        private MainWindow parent;
        private PlaceOrderView placeOrderView;
        private PlaceOrderView mdfyOrderView;
        private PlaceOrderView cnclOrderView;
        private VIEWMODEL.OrderMgmtViewModel orderMgmtViewModel;

        public OrderMgmtView(MainWindow parent)
        {
            this.parent = parent;
            orderMgmtViewModel = new VIEWMODEL.OrderMgmtViewModel();

            this.DataContext = orderMgmtViewModel;
            InitializeComponent();

            this.Visibility = Visibility.Visible;
        }

        private void Place_Order(object sender, RoutedEventArgs e)
        {
            place();
        }

        private void Mdfy_Order(object sender, RoutedEventArgs e)
        {
            mdfy();
        }

        private void Cncl_Order(object sender, RoutedEventArgs e)
        {
            cncl();
        }

        private void OrderMgmtWindow_Closing(object sender, RoutedEventArgs e)
        {
            clos();
        }

        private void place()
        {
            placeOrderView = new PlaceOrderView("ADD", null, this);
            placeOrderView.Owner = parent;
            placeOrderView.Show();
        }

        private void mdfy()
        {
            mdfyOrderView = new PlaceOrderView("MDFY", orderMgmtViewModel.SelectedOrder, this);
            mdfyOrderView.Owner = parent;
            mdfyOrderView.Show();
        }

        private void cncl()
        {
            cnclOrderView = new PlaceOrderView("CNCL", orderMgmtViewModel.SelectedOrder, this);
            cnclOrderView.Owner = parent;
            cnclOrderView.Show();
        }

        private void clos()
        {
            if (placeOrderView != null)
                placeOrderView.Close();
            if (mdfyOrderView != null)
                mdfyOrderView.Close();
            if (cnclOrderView != null)
                cnclOrderView.Close();

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
                orderMgmtViewModel.searchOrders();
                this.Focus();
            }
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
            if (Amount.Text == null || Amount.Text.Trim().Equals(""))
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
            }
        }

        private void Amount_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Double.Parse(Amount.Text) == 0)
            {
                Amount.Text = "";
                Amount.Foreground = new SolidColorBrush(Colors.Black);
            }
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

        private void StartDate_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!EndDate.IsEnabled)
                StatusComboBox.Focus();
        }

        private void EndDate_CalendarOpened(object sender, RoutedEventArgs e)
        {
            DatePicker datepicker = (DatePicker)sender;

            if (orderMgmtViewModel.EndDateReadOnly)
                datepicker.IsDropDownOpen = false;
        }
    }
}
