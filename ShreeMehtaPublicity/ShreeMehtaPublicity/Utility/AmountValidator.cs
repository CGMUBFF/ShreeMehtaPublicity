using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ShreeMehtaPublicity.Utility
{
    public class AmountValidator : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                Double.Parse(value.ToString());
            }
            catch (Exception)
            {
                try
                {
                    return value.ToString().Remove(value.ToString().Length - 1);
                }
                catch (Exception)
                {
                    return "";
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
