﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ShreeMehtaPublicity.Utility
{
    public class StatusConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString().Equals(Status.ACTV))
                return true;
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool status = System.Convert.ToBoolean(value);//Reverse value will be passed
            if (status)
                return Status.IACT;
            else
                return Status.ACTV;
        }
    }
}
