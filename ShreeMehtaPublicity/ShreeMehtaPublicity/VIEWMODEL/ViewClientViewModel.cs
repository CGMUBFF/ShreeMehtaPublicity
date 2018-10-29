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
    public class ViewClientViewModel : ViewModelBase
    {
        private ClientModel clientModel;
        private Database db;

        #region Variable Declaration
        private int _clientSeqNum;
        public int ClientSeqNum
        {
            get
            {
                return _clientSeqNum;
            }
            set
            {
                _clientSeqNum = value;
                OnPropertyChanged("ClientSeqNum");
            }
        }

        private string _clientName;
        public string ClientName
        {
            get
            {
                return _clientName;
            }
            set
            {
                _clientName = value;
                OnPropertyChanged("ClientName");
            }
        }

        private string _clientLandline;
        public string ClientLandline
        {
            get
            {
                return _clientLandline;
            }
            set
            {
                _clientLandline = value;
                OnPropertyChanged("ClientLandline");
            }
        }

        private string _clientMobile;
        public string ClientMobile
        {
            get
            {
                return _clientMobile;
            }
            set
            {
                _clientMobile = value;
                OnPropertyChanged("ClientMobile");
            }
        }

        private string _clientAddress;
        public string ClientAddress
        {
            get
            {
                return _clientAddress;
            }
            set
            {
                _clientAddress = value;
                OnPropertyChanged("ClientAddress");
            }

        }

        private string _clientBranch;
        public string ClientBranch
        {
            get
            {
                return _clientBranch;
            }
            set
            {
                _clientBranch = value;
                OnPropertyChanged("ClientBranch");
            }
        }

        private string _clientGST;
        public string ClientGST
        {
            get
            {
                return _clientGST;
            }
            set
            {
                _clientGST = value;
                OnPropertyChanged("ClientGST");
            }

        }

        private string _clientMail;
        public string ClientMail
        {
            get
            {
                return _clientMail;
            }
            set
            {
                _clientMail = value;
                OnPropertyChanged("ClientMail");
            }
        }

        private string _clientStatus;
        public string ClientStatus
        {
            get
            {
                return _clientStatus;
            }
            set
            {
                _clientStatus = value;
                OnPropertyChanged("ClientStatus");
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

        private ObservableCollection<ContactPersonModel> _listOfContactPersons;
        public ObservableCollection<ContactPersonModel> ListOfContactPersons
        {
            get
            {
                return _listOfContactPersons;
            }
            set
            {
                _listOfContactPersons = value;
                OnPropertyChanged("ListOfContactPersons");
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

        public ViewClientViewModel(MODEL.ClientModel clientModel)
        {
            db = Database.getInstance();

            this.clientModel = clientModel;
            ClientSeqNum = clientModel.ClientSeqNum;
            ClientName = clientModel.ClientName;
            ClientLandline = clientModel.ClientLandline;
            ClientMobile = clientModel.ClientMobile;
            ClientAddress = clientModel.ClientAddress;
            ClientBranch = clientModel.ClientBranch;
            ClientGST = clientModel.ClientGST;
            ClientMail = clientModel.ClientMail;
            ClientStatus = clientModel.ClientStatus;

            ListOfContactPersons = new ObservableCollection<ContactPersonModel>(db.db_GetContactPersonList(clientModel.ClientSeqNum));

            resetFields();
            searchOrders();
        }

        private void resetFields()
        {
            EndDateEnable = false;
            fStartDate = null;
            fEndDate = null;
            if (_startDate == null)
                DisplayStartDate = System.DateTime.Today;
            else
                DisplayStartDate = _startDate;

            if (_endDate == null)
                DisplayEndDate = System.DateTime.Today;
            else
                DisplayEndDate = _endDate;
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
            ListOfOrders = new ObservableCollection<OrderModel>(db.db_GetOrderList(clientModel.ClientSeqNum, 0, 0, StaticMaster.convertDateToString(_startDate), StaticMaster.convertDateToString(_endDate), "ALL"));
            for (int i = 0; i < _listOfOrders.Count; i++)
            {
                TotalAmount += (_listOfOrders.ToArray())[i].OrderTotalAmount;
            }
            if (_startDate != null && _endDate != null)
            {
                DateRange = "From : " + StaticMaster.convertDisplayDateToString(_startDate) + "\nTo : " + StaticMaster.convertDisplayDateToString(_endDate);
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
    }
}
