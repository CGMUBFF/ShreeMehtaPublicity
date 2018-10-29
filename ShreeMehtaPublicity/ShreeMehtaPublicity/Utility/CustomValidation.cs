using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ShreeMehtaPublicity.Utility
{
    class CustomValidation
    {
        public static bool validateString(string value)
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                return true;
            return false;
        }

        public static bool validateMail(string value)
        {
            if (!Regex.IsMatch(value, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                return true;
            return false;
        }

        public static bool validateMobile(string value)
        {
            if (!Regex.IsMatch(value, @"^([0-9]{10})$"))
                return true;
            
            return false;
        }

        public static bool validationDouble(string value)
        {
            try
            {
                if (Double.Parse(value) == 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return true;
            }
            return false;
        }
    }
}
