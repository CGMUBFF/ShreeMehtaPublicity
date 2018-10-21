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
using ShreeMehtaPublicity.VIEW;
using ShreeMehtaPublicity.MODEL;

namespace ShreeMehtaPublicity.VIEWMODEL
{
    public class OrderMgmtViewModel : ViewModelBase
    {
        private Database db;

        #region Variable Declaration
        private string _amount;
        public string Amount
        {
            get { 
                return _amount; 
            }
            set { 
                _amount = value; 
                OnPropertyChanged("Amount"); 
            }
        }

        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get { 
                return _startDate; 
            }
            set { 
                _startDate = value; 
                OnPropertyChanged("StartDate");  
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

        private DateTime? _endDate;
        public DateTime? EndDate
        {
            get { 
                return _endDate; 
            }
            set { 
                _endDate = value;
                OnPropertyChanged("EndDate"); 
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
        
        private ObservableCollection<SiteModel> _sites;
        public ObservableCollection<SiteModel> Sites
        {
            get
            {
                return _sites;
            }
            set
            {
                _sites = value;
                OnPropertyChanged("Sites");
            }
        }

        private ObservableCollection<ClientModel> _clients;
        public ObservableCollection<ClientModel> Clients
        {
            get
            {
                return _clients;
            }
            set
            {
                _clients = value;
                OnPropertyChanged("Clients");
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
        
        private ClientModel _selectedClient;
        public ClientModel SelectedClient
        {
            get
            {
                return _selectedClient;
            }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
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

        private OrderModel _selectedOrder;
        public OrderModel SelectedOrder
        {
            get
            {
                return _selectedOrder;
            }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }

        private Boolean _mdfyEnable;
        public Boolean MdfyEnable
        {
            get
            {
                return _mdfyEnable;
            }
            set
            {
                _mdfyEnable = value;
                OnPropertyChanged("MdfyEnable");
            }
        }

        private Boolean _cnclEnable;
        public Boolean CnclEnable
        {
            get
            {
                return _cnclEnable;
            }
            set
            {
                _cnclEnable = value;
                OnPropertyChanged("CnclEnable");
            }
        }

        private ObservableCollection<string> _listOfStatus;
        public ObservableCollection<string> ListOfStatus
        {
            get
            {
                return _listOfStatus;
            }
            set
            {
                _listOfStatus = value;
                OnPropertyChanged("ListOfStatus");
            }
        }

        private string _selectedStatus;
        public string SelectedStatus
        {
            get
            {
                return _selectedStatus;
            }
            set
            {
                _selectedStatus = value;
                OnPropertyChanged("SelectedStatus");
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

        private Boolean _endDateReadOnly;
        public Boolean EndDateReadOnly
        {
            get
            {
                return _endDateReadOnly;
            }
            set
            {
                _endDateReadOnly = value;
                OnPropertyChanged("EndDateReadOnly");
            }
        }
        #endregion

        #region Constructor
        public OrderMgmtViewModel()
        {
            db = Database.getInstance();
    
            Sites = new ObservableCollection<SiteModel>(db.db_GetAllSites());
            Sites.Insert(0, new SiteModel { SiteSeqNum = 0, SiteName = "ALL" });
            
            Clients = new ObservableCollection<ClientModel>(db.db_GetAllClients());
            Clients.Insert(0,new ClientModel { ClientSeqNum = 0, ClientName = "ALL" });

            ListOfStatus = new ObservableCollection<string>();
            ListOfStatus.Add("ALL");
            ListOfStatus.Add(Status.RUNN);
            ListOfStatus.Add(Status.PREE);
            ListOfStatus.Add(Status.FNSH);
            ListOfStatus.Add(Status.CNCL);

            resetFields();
            searchOrders();
        }
        #endregion

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
            ListOfOrders = new ObservableCollection<OrderModel>(db.db_GetOrderList(SelectedClient.ClientSeqNum, SelectedSite.SiteSeqNum, Double.Parse(Amount), StaticMaster.convertDateToString(StartDate), StaticMaster.convertDateToString(EndDate), StaticMaster.convertStringToOrderStatus(SelectedStatus)));
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

        #region Reset Fields
        private void resetFields()
        {
            SelectedSite = Sites.FirstOrDefault();
            SelectedClient = Clients.FirstOrDefault();
            Amount = "0";
            StartDate = null;
            EndDate = null;
            SelectedStatus = ListOfStatus.FirstOrDefault();
            if (StartDate == null)
                DisplayStartDate = System.DateTime.Today;
            else
                DisplayStartDate = StartDate;

            if (EndDate == null)
                DisplayEndDate = System.DateTime.Today;
            else
                DisplayEndDate = EndDate;
            EndDateEnable = true;
            EndDateReadOnly = true;
            MdfyEnable = false;
            CnclEnable = false;
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
            if (EndDate == null || EndDate < StartDate)
                EndDate = StartDate;

            if (StartDate != null)
                EndDateReadOnly = false;
        }
        #endregion

        #region SelectedOrderChanged Command
        private RelayCommand selectedOrderChangedCommand;
        public ICommand SelectedOrderChangedCommand
        {
            get
            {
                return selectedOrderChangedCommand ?? (selectedOrderChangedCommand = new RelayCommand(param => this.SelectedOrderChanged()));
            }
        }
        private void SelectedOrderChanged()
        {
            if (SelectedOrder != null && (SelectedOrder.OrderStatus.Equals(Status.RUNN) || SelectedOrder.OrderStatus.Equals(Status.PREE)))
                MdfyEnable = true;
            else
                MdfyEnable = false;

            if (SelectedOrder != null &&  SelectedOrder.OrderStatus.Equals(Status.PREE))
                CnclEnable = true;
            else
                CnclEnable = false;
        }
        #endregion
    }
}
