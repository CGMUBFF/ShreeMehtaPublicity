using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;


using ShreeMehtaPublicity.Utility;
using ShreeMehtaPublicity.MODEL;

namespace ShreeMehtaPublicity.VIEWMODEL
{
    public class SiteMgmtViewModel : ViewModelBase
    {
        private Database db;

        #region Variable Declaration
        private ObservableCollection<SiteModel> _listofSites;
        public ObservableCollection<SiteModel> ListofSites
        {
            get
            {
                return _listofSites;
            }
            set
            {
                _listofSites = value;
                OnPropertyChanged("ListofSites");
            }
        }

        private SiteModel _selectedSite;
        public SiteModel SelectedSite
        {
            get
            {
                return _selectedSite;
            }
            set
            {
                _selectedSite = value;
                OnPropertyChanged("SelectedSite");
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
                if (value != _displayStartDate)
                {
                    _displayStartDate = value;
                    OnPropertyChanged("DisplayStartDate");
                }
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
                if (value != _displayEndDate)
                {
                    _displayEndDate = value;
                    OnPropertyChanged("DisplayEndDate");
                }
            }
        }

        private ObservableCollection<string> _listofStatus;
        public ObservableCollection<string> ListofStatus
        {
            get
            {
                return _listofStatus;
            }
            set
            {
                _listofStatus = value;
                OnPropertyChanged("ListofStatus");
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

        #region Filter Variables
        private string _siteName;
        public string fSiteName
        {
            get
            {
                return _siteName;
            }
            set
            {
                _siteName = value;
                OnPropertyChanged("fSiteName");
            }
        }

        private string _siteAddress;
        public string fSiteAddress
        {
            get
            {
                return _siteAddress;
            }
            set
            {
                _siteAddress = value;
                OnPropertyChanged("fSiteAddress");
            }
        }

        private string _siteHeight;
        public string fSiteHeight
        {
            get
            {
                return _siteHeight;
            }
            set
            {
                _siteHeight = value;
                OnPropertyChanged("fSiteHeight");
            }
        }

        private string _siteWidth;
        public string fSiteWidth
        {
            get
            {
                return _siteWidth;
            }
            set
            {
                _siteWidth = value;
                OnPropertyChanged("fSiteWidth");
            }
        }

        private string _siteAmount;
        public string fSiteAmount
        {
            get
            {
                return _siteAmount;
            }
            set
            {
                _siteAmount = value;
                OnPropertyChanged("fSiteAmount");
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

        private string _selectedStatus;
        public string fSelectedStatus
        {
            get
            {
                return _selectedStatus;
            }
            set
            {
                _selectedStatus = value;
                OnPropertyChanged("fSelectedStatus");
            }
        }
        #endregion

        #endregion

        #region Constructor
        public SiteMgmtViewModel()
        {
            db = Database.getInstance();

            ListofStatus = new ObservableCollection<string>();
            ListofStatus.Add("ALL");
            ListofStatus.Add(Status.ACTV);
            ListofStatus.Add(Status.IACT);

            resetFields();
            searchSites();
        }
        #endregion

        #region SearchSite Command
        private RelayCommand searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return searchCommand ?? (searchCommand = new RelayCommand(param => this.searchSites()));
            }
        }
        public void searchSites()
        {
            ListofSites = db.db_GetSiteList(StaticMaster.convertDateToString(fStartDate), StaticMaster.convertDateToString(fEndDate), StaticMaster.convertStringToSiteStatus(fSelectedStatus), fSiteHeight==null?"ALL":fSiteHeight, fSiteWidth==null?"ALL":fSiteWidth, fSiteAmount==null?"ALL":fSiteAmount, fSiteName==null?"ALL":fSiteName, fSiteAddress==null?"ALL":fSiteAddress);
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
            searchSites();
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

            if(fStartDate != null)
            {
                EndDateEnable = true;
            }
        }
        #endregion

        private void resetFields()
        {
            fSiteName = null;
            fSiteAddress = null;
            fSiteHeight = null;
            fSiteWidth = null;
            fSiteAmount = null;
            fStartDate = null;
            fEndDate = null;
            fSelectedStatus = ListofStatus.FirstOrDefault(x => x.Equals(Status.ACTV));

            SelectedSite = null;
      
            if (fStartDate == null)
                DisplayStartDate = System.DateTime.Today;
            else
                DisplayStartDate = fStartDate;

            if (fEndDate == null)
                DisplayEndDate = System.DateTime.Today;
            else
                DisplayEndDate = fEndDate;

            EndDateEnable = false;
        }
    }
}
