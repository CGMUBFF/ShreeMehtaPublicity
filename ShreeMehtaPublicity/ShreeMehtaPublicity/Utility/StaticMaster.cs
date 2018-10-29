using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShreeMehtaPublicity.Utility
{
    public class StaticMaster
    {
        public static DateTime? convertStringToDate(string date)
        {
            if (date == null)
                return DateTime.Parse("0001-01-01");
            return DateTime.Parse(date);
        }

        public static string convertDateToString(DateTime? date)
        {
            
            if(date == null)
                return DateTime.Parse("0001-01-01").ToString("yyyy-MM-dd");
            return date.Value.ToString("yyyy-MM-dd");
        }

        public static string convertStringToSiteStatus(string statusString)
        {
            switch (statusString)
            {
                case Status.ACTV:
                    {
                        return "ACTV";
                    }
                case Status.IACT:
                    {
                        return "IACT";
                    }
                default:
                    {
                        return statusString;
                    }
            }
        }

        public static string convertSiteStatusToString(string status)
        {
            switch (status)
            {
                case "ACTV":
                    {
                        return Status.ACTV;
                    }
                case "IACT":
                    {
                        return Status.IACT;
                    }
                default:
                    {
                        return status;
                    }
            }
        }

        public static string convertStringToOrderStatus(string statusString)
        {
            switch (statusString)
            {
                case Status.RUNN:
                    {
                        return "RUNN";
                    }
                case Status.PREE:
                    {
                        return "PREE";
                    }
                case Status.FNSH :
                    {
                        return "FNSH";
                    }
                case Status.CNCL :
                    {
                        return "CNCL";
                    }
                default:
                    {
                        return statusString;
                    }
            }
        }

        public static string convertOrderStatusToString(string status)
        {
            switch (status)
            {
                case "RUNN":
                    {
                        return Status.RUNN;
                    }
                case "PREE":
                    {
                        return Status.PREE;
                    }
                case "FNSH":
                    {
                        return Status.FNSH;
                    }
                case "CNCL":
                    {
                        return Status.CNCL;
                    }
                default:
                    {
                        return status;
                    }
            }
        }

        public static string convertStringToClientStatus(string statusString)
        {
            switch (statusString)
            {
                case Status.ACTV:
                    {
                        return "ACTV";
                    }
                case Status.IACT:
                    {
                        return "IACT";
                    }
                default:
                    {
                        return statusString;
                    }
            }
        }

        public static string convertClientStatusToString(string status)
        {
            switch (status)
            {
                case "ACTV":
                    {
                        return Status.ACTV;
                    }
                case "IACT":
                    {
                        return Status.IACT;
                    }
                default:
                    {
                        return status;
                    }
            }
        }

        public static string convertDisplayDateToString(DateTime? date)
        {
            if (date == null)
                return DateTime.Parse("0001-01-01").ToString("dd-MMM-yyyy");
            return date.Value.ToString("dd-MMM-yyyy");
        }
    }
}
