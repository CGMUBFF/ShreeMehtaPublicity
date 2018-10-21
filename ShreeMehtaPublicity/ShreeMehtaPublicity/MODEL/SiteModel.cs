using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ShreeMehtaPublicity.MODEL
{
    public class SiteModel : VIEWMODEL.ViewModelBase
    {
        private int _siteSeqNum;
        public int SiteSeqNum
        {
            get
            {
                return _siteSeqNum;
            }
            set
            {
                _siteSeqNum = value;
                OnPropertyChanged("SiteSeqNum");
            }
        }

        private string _siteName;
        public string SiteName
        {
            get
            {
                return _siteName;
            }
            set
            {
                _siteName = value;
                OnPropertyChanged("SiteName");
            }
        }

        private string _siteAddress;
        public string SiteAddress
        {
            get
            {
                return _siteAddress;
            }
            set
            {
                _siteAddress = value;
                OnPropertyChanged("SiteAddress");
            }

        }

        private string _siteHeight;
        public string SiteHeight
        {
            get
            {
                return _siteHeight;
            }
            set
            {
                _siteHeight = value;
                OnPropertyChanged("SiteHeight");
            }
        }

        private string _siteWidth;
        public string SiteWidth
        {
            get
            {
                return _siteWidth;
            }
            set
            {
                _siteWidth = value;
                OnPropertyChanged("SiteWidth");
            }
        }

        private string _siteAmount;
        public string SiteAmount
        {
            get
            {
                return _siteAmount;
            }
            set
            {
                _siteAmount = value;
                OnPropertyChanged("SiteAmount");
            }
        }

        private string _siteStatus;
        public string SiteStatus
        {
            get
            {
                return _siteStatus;
            }
            set
            {
                _siteStatus = value;
                OnPropertyChanged("SiteStatus");
            }
        }
    }
}
