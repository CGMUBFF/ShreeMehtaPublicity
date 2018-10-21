using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;

using ShreeMehtaPublicity.Utility;
using ShreeMehtaPublicity.VIEW;
using ShreeMehtaPublicity.MODEL;

namespace ShreeMehtaPublicity.VIEWMODEL
{
    public class ViewSiteViewModel : ViewModelBase
    {
        private SiteModel siteModel;
        private Database db;

        #region Variable Declaration
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

        private ObservableCollection<OrderModel> _listOfOrders;
        public ObservableCollection<OrderModel> ListOfOrders
        {
            get
            {
                return _listOfOrders;
            }
            set
            {
                _listOfOrders = value;
                OnPropertyChanged("ListOfOrders");
            }
        }

        private double _totalAmount;
        public double TotalAmount
        {
            get
            {
                return _totalAmount;
            }
            set
            {
                _totalAmount = value;
                OnPropertyChanged("TotalAmount");
            }
        }

        private DateTime? _startDate;
        public DateTime? fStartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                if (value != _startDate)
                {
                    _startDate = value;
                    OnPropertyChanged("fStartDate");
                }
            }
        }

        private DateTime? _endDate;
        public DateTime? fEndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                if (value != _endDate)
                {
                    _endDate = value;
                    OnPropertyChanged("fEndDate");
                }
            }
        }

        private DateTime? _displayStartDate;
        public DateTime? DisplayStartDate
        {
            get
            {
                return _displayStartDate;
            }
            set
            {
                _displayStartDate = value;
                OnPropertyChanged("DisplayStartDate");
            }
        }

        private DateTime? _displayEndDate;
        public DateTime? DisplayEndDate
        {
            get
            {
                return _displayEndDate;
            }
            set
            {
                _displayEndDate = value;
                OnPropertyChanged("DisplayEndDate");
            }
        }

        private Boolean _endDateEnable;
        public Boolean EndDateEnable
        {
            get
            {
                return _endDateEnable;
            }
            set
            {
                _endDateEnable = value;
                OnPropertyChanged("EndDateEnable");
            }
        }

        private string _dateRange;
        public string DateRange
        {
            get
            {
                return _dateRange;
            }
            set
            {
                _dateRange = value;
                OnPropertyChanged("DateRange");
            }
        }

        private int _fontSize;
        public int FontSize
        {
            get
            {
                return _fontSize;
            }
            set
            {
                _fontSize = value;
                OnPropertyChanged("FontSize");
            }
        }
        #endregion

        public ViewSiteViewModel(SiteModel siteModel)
        {
            db = Database.getInstance();

            this.siteModel = siteModel;
            SiteSeqNum = siteModel.SiteSeqNum;
            SiteName = siteModel.SiteName;
            SiteHeight = siteModel.SiteHeight;
            SiteWidth = siteModel.SiteWidth;
            SiteAmount = siteModel.SiteAmount;
            SiteAddress = siteModel.SiteAddress;
            SiteStatus = siteModel.SiteStatus;
            
            resetFields();
            searchOrders();
        }

        private void resetFields()
        {
            EndDateEnable = false;
            fStartDate = null;
            fEndDate = null;
            if (fStartDate == null)
                DisplayStartDate = System.DateTime.Today;
            else
                DisplayStartDate = fStartDate;

            if (fEndDate == null)
                DisplayEndDate = System.DateTime.Today;
            else
                DisplayEndDate = fEndDate;
            TotalAmount = 0;

            DateRange = "Till Date";
            FontSize = 20;
        }

        #region searchOrders Command
        private RelayCommand searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return searchCommand ?? (searchCommand = new RelayCommand(param => this.searchOrders()));
            }
        }
        public void searchOrders()
        {
            TotalAmount = 0;
            ListOfOrders = new ObservableCollection<OrderModel>(db.db_GetOrderList(0, siteModel.SiteSeqNum, 0, StaticMaster.convertDateToString(fStartDate), StaticMaster.convertDateToString(fEndDate), "ALL"));
            for (int i = 0; i < ListOfOrders.Count; i++)
            {
                TotalAmount += (ListOfOrders.ToArray())[i].OrderGeneralAmount;
            }
            if (fStartDate != null && fEndDate != null)
            {
                DateRange = "From : " + StaticMaster.convertDisplayDateToString(fStartDate) + "\nTo : " + StaticMaster.convertDisplayDateToString(fEndDate);
                FontSize = 15;
            }
        }
        #endregion

        #region Reset Command
        private RelayCommand resetCommand;
        public ICommand ResetCommand
        {
            get
            {
                return resetCommand ?? (resetCommand = new RelayCommand(param => this.Reset()));
            }
        }
        public void Reset()
        {
            resetFields();
            searchOrders();
        }
        #endregion

        #region StartDateChanged Command
        private RelayCommand startDateChangedCommand;
        public ICommand StartDateChangedCommand
        {
            get
            {
                return startDateChangedCommand ?? (startDateChangedCommand = new RelayCommand(param => this.StartDateChanged()));
            }
        }
        private void StartDateChanged()
        {
            if (fEndDate == null || fEndDate < fStartDate)
            {
                fEndDate = fStartDate;
            }

            if (fStartDate != null)
            {
                EndDateEnable = true;
            }
        }
        #endregion
    }
}
