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
    public class SiteCautationViewModel : ViewModelBase
    {
        private Database db;

        #region Variable Declaration
        private ObservableCollection<SiteCautationModel> _listofCautationSitesFromDb;
        public ObservableCollection<SiteCautationModel> ListofCautationSitesFromDb
        {
            get
            {
                return _listofCautationSitesFromDb;
            }
            set
            {
                _listofCautationSitesFromDb = value;
                OnPropertyChanged("ListofCautationSitesFromDb");
            }
        }
        
        private ObservableCollection<SiteCautationModel> _listofCautationSites;
        public ObservableCollection<SiteCautationModel> ListofCautationSites
        {
            get
            {
                return _listofCautationSites;
            }
            set
            {
                _listofCautationSites = value;
                OnPropertyChanged("ListofCautationSites");
            }
        }

        private ObservableCollection<SiteCautationModel> _listofSelectedCautationSites;
        public ObservableCollection<SiteCautationModel> ListofSelectedCautationSites
        {
            get
            {
                return _listofSelectedCautationSites;
            }
            set
            {
                _listofSelectedCautationSites = value;
                OnPropertyChanged("ListofSelectedCautationSites");
            }
        }

        private SiteCautationModel _selectedCautationSite;
        public SiteCautationModel SelectedCautationSite
        {
            get
            {
                return _selectedCautationSite;
            }
            set
            {
                _selectedCautationSite = value;
                OnPropertyChanged("SelectedCautationSite");
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

        private Boolean _selectAllFlag;
        public Boolean SelectAllFlag
        {
            get
            {
                return _selectAllFlag;
            }
            set
            {
                _selectAllFlag = value;
                OnPropertyChanged("SelectAllFlag");
            }
        }

        private string _selectAllText;
        public string SelectAllText
        {
            get
            {
                return _selectAllText;
            }
            set
            {
                _selectAllText = value;
                OnPropertyChanged("SelectAllText");
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
        public SiteCautationViewModel()
        {
            db = Database.getInstance();

            ListofCautationSites = new ObservableCollection<SiteCautationModel>();
            ListofSelectedCautationSites = new ObservableCollection<SiteCautationModel>();

            ListofStatus = new ObservableCollection<string>();
            ListofStatus.Add("ALL");
            ListofStatus.Add(Status.ACTV);
            ListofStatus.Add(Status.IACT);

            SelectAllText = " Select All";
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
            ListofCautationSitesFromDb = db.db_GetCautationSiteList(StaticMaster.convertDateToString(_startDate), StaticMaster.convertDateToString(_endDate), StaticMaster.convertStringToSiteStatus(_selectedStatus), _siteHeight == null ? "ALL" : _siteHeight, _siteWidth == null ? "ALL" : _siteWidth, _siteAmount == null ? "ALL" : _siteAmount, _siteName == null ? "ALL" : _siteName, _siteAddress == null ? "ALL" : _siteAddress);
            ListofCautationSites = new ObservableCollection<SiteCautationModel>(_listofSelectedCautationSites);
            foreach (SiteCautationModel cautationSite in _listofCautationSitesFromDb)
            {
                if (!_listofCautationSites.Contains(cautationSite, new InlineComparer<SiteCautationModel>((i1, i2) => i1.SiteSeqNum == i2.SiteSeqNum, i => i.SiteSeqNum.GetHashCode())))
                {
                    ListofCautationSites.Add(cautationSite);
                }
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
            if (_endDate == null || _endDate < _startDate)
            {
                fEndDate = _startDate;
            }

            if (_startDate != null)
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
            fSelectedStatus = _listofStatus.FirstOrDefault(x => x.Equals(Status.ACTV));

            SelectedCautationSite = null;

            if (fStartDate == null)
                DisplayStartDate = System.DateTime.Today;
            else
                DisplayStartDate = _startDate;

            if (fEndDate == null)
                DisplayEndDate = System.DateTime.Today;
            else
                DisplayEndDate = _endDate;

            EndDateEnable = false;
        }

        #region CautationSiteChecked Command
        public void cautationSiteChecked(bool IsChecked)
        {
            if (IsChecked)
                ListofSelectedCautationSites.Add(_selectedCautationSite);
            else
                ListofSelectedCautationSites.Remove(_selectedCautationSite);
        }
        #endregion

        #region AllCautationSiteChecked Command
        public void allCautationSiteChecked(bool IsChecked)
        {
            ListofSelectedCautationSites.Clear();
            foreach (SiteCautationModel siteCautation in ListofCautationSites)
            {
                siteCautation.SiteCautationFlag = IsChecked;
            }
            if (IsChecked)
            {
                ListofSelectedCautationSites = new ObservableCollection<SiteCautationModel>(_listofCautationSites);
            }
        }
        #endregion

        #region CreateCautation Command
        private RelayCommand createCautationCommand;
        public ICommand CreateCautationCommand
        {
            get
            {
                return createCautationCommand ?? (createCautationCommand = new RelayCommand(param => this.createCautation()));
            }
        }
        public void createCautation()
        {
            
        }
        #endregion

        #region ResetCautation Command
        private RelayCommand resetCautationCommand;
        public ICommand ResetCautationCommand
        {
            get
            {
                return resetCautationCommand ?? (resetCautationCommand = new RelayCommand(param => this.resetCautation()));
            }
        }
        public void resetCautation()
        {
            ListofSelectedCautationSites.Clear();
            ListofCautationSites.Clear();
            /*foreach (SiteModel site in _listofSites)
            {
                SiteCautationModel siteCautationModel = bundleSiteCautationModel(site);

                ListofCautationSites.Add(siteCautationModel);
            }*/
        }
        #endregion
    }
}
