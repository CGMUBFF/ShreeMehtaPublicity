using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;

using ShreeMehtaPublicity.VIEW;
using ShreeMehtaPublicity.MODEL;
using ShreeMehtaPublicity.Utility;

namespace ShreeMehtaPublicity.VIEWMODEL
{
    public class PlaceOrderViewModel : ViewModelBase
    {
        private Database db;
        private PlaceOrderView parent;
        private OrderModel orderModel;
        private string action;
        private string orderStatus;
        
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

        private string _charges;
        public string Charges
        {
            get
            {
                return _charges;
            }
            set
            {
                _charges = value;
                OnPropertyChanged("Charges");
            }
        }

        private string _printing;
        public string Printing
        {
            get
            {
                return _printing;
            }
            set
            {
                _printing = value;
                OnPropertyChanged("Printing");
            }
        }

        private string _mounting;
        public string Mounting
        {
            get
            {
                return _mounting;
            }
            set
            {
                _mounting = value;
                OnPropertyChanged("Mounting");
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

        private Boolean _siteEnable;
        public Boolean SiteEnable
        {
            get
            {
                return _siteEnable;
            }
            set
            {
                _siteEnable = value;
                OnPropertyChanged("SiteEnable");
            }
        }

        private Boolean _clientEnable;
        public Boolean ClientEnable
        {
            get
            {
                return _clientEnable;
            }
            set
            {
                _clientEnable = value;
                OnPropertyChanged("ClientEnable");
            }
        }

        private Boolean _amountEnable;
        public Boolean AmountEnable
        {
            get
            {
                return _amountEnable;
            }
            set
            {
                _amountEnable = value;
                OnPropertyChanged("AmountEnable");
            }
        }

        private Boolean _startDateEnable;
        public Boolean StartDateEnable
        {
            get
            {
                return _startDateEnable;
            }
            set
            {
                _startDateEnable = value;
                OnPropertyChanged("StartDateEnable");
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

        private string _actionLable;
        public string ActionLable
        {
            get
            {
                return _actionLable;
            }
            set
            {
                _actionLable = value;
                OnPropertyChanged("Action");
            }
        }

        private string _actionButton;
        public string ActionButton
        {
            get
            {
                return _actionButton;
            }
            set
            {
                _actionButton = value;
                OnPropertyChanged("Action");
            }
        }
        #endregion

        #region Constructor
        public PlaceOrderViewModel(PlaceOrderView parent, string action, OrderModel orderModel)
        {
            db = Database.getInstance();
            this.parent = parent;
            this.action = action;

            if(orderModel != null)
                this.orderModel = orderModel;
            
            switch(action)
            {
                case "ADD" :
                    {
                        ActionLable = "Place Order";
                        ActionButton = "Place";
                        Sites = new ObservableCollection<SiteModel>(db.db_GetAllSites().Where(i => i.SiteStatus.Equals(Status.ACTV)));
                        Clients = new ObservableCollection<ClientModel>(db.db_GetAllClients().Where(i => i.ClientStatus.Equals(Status.ACTV)));
                        break;
                    }
                case "MDFY" :
                    {
                        ActionLable = "Modify Order";
                        ActionButton = "Modify";
                        Sites = new ObservableCollection<SiteModel>(db.db_GetAllSites());
                        Clients = new ObservableCollection<ClientModel>(db.db_GetAllClients());
                        break;
                    }
                case "CNCL":
                    {
                        ActionLable = "Cancel Order";
                        ActionButton = "Cancel";
                        Sites = new ObservableCollection<SiteModel>(db.db_GetAllSites());
                        Clients = new ObservableCollection<ClientModel>(db.db_GetAllClients());
                        break;
                    }
                default :
                    {
                        break;
                    }
            }
            resetFields();
        }
        #endregion

        #region saveOrders Command
        private RelayCommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new RelayCommand(param => this.Save()));
            }
        }
        public void Save()
        {
            if (validate())
            {
                orderStatus = getOrderStatus(StartDate, EndDate);
                switch(action)
                {
                    case "ADD" :
                        {
                            string output = db.db_PlaceOrder(SelectedSite.SiteSeqNum, SelectedClient.ClientSeqNum, Double.Parse(Charges), Double.Parse(Printing), Double.Parse(Mounting), StaticMaster.convertDateToString(StartDate), StaticMaster.convertDateToString(EndDate), StaticMaster.convertStringToOrderStatus(orderStatus));
                            if (output.Equals(Status.SUCC))
                            {
                                if (true)//WpfMessageBox.Show("Order Placed Successfully", Status.SUCC) == MessageBoxResult.OK)
                                {
                                    parent.Close();
                                }
                            }
                            break;
                        }
                    case "MDFY" :
                        {
                            string output = db.db_MdfyOrder(orderModel.OrderSeqNum, Double.Parse(Charges), Double.Parse(Printing), Double.Parse(Mounting), StaticMaster.convertDateToString(StartDate), StaticMaster.convertDateToString(EndDate), StaticMaster.convertStringToOrderStatus(orderStatus));
                            if (output.Equals(Status.SUCC))
                            {
                                if (true)//WpfMessageBox.Show("Order Modified Successfully", Status.SUCC) == MessageBoxResult.OK)
                                {
                                    parent.Close();
                                }
                            }
                            break;
                        }
                    case "CNCL" :
                        {
                            string output = db.db_CnclOrder(orderModel.OrderSeqNum);
                            if (output.Equals(Status.SUCC))
                            {
                                if (true)//WpfMessageBox.Show("Order Cancelled Successfully", Status.SUCC) == MessageBoxResult.OK)
                                {
                                    parent.Close();
                                }
                            }
                            break;
                        }
                    default :
                        {
                            //WpfMessageBox.Show("Invalid Operation",Status.ERR);
                            break;
                        }
                }
            }
        }

        private string getOrderStatus(DateTime? StartDate, DateTime? EndDate)
        {
            string status;

            while (true)
            {
                if (StartDate <= DateTime.Today && EndDate >= DateTime.Today)
                {
                    status = Status.RUNN;
                    break;
                }
                else if(StartDate > DateTime.Today)
                {
                    status = Status.PREE;
                    break;
                }
                else if(EndDate < DateTime.Today)
                {
                    status = Status.FNSH;
                    break;
                }
                else
                {
                    status = Status.CNCL;
                    break;
                }
            }
            return status;
        }
        #endregion
 
        private bool validate()
        {
            String ErrorMsg = null;

            while (true)
            {
                if (SelectedSite == null)
                {
                    ErrorMsg = "Please Select Site";
                    this.parent.SiteFilter.Focus();
                    break;
                }

                if (SelectedClient == null)
                {
                    ErrorMsg = "Please Select Client";
                    this.parent.ClientFilter.Focus();
                    break;
                }

                /*if (Double.Parse(Amount) == 0)
                {
                    ErrorMsg = "Please Enter Amount";
                    this.parent.Charges.Focus();
                    break;
                }*/

                if (StartDate == null)
                {
                    ErrorMsg = "Please Select Start Date";
                    this.parent.StartDate.Focus();
                    break;
                }

                if (EndDate == null)
                {
                    ErrorMsg = "Please Select End Date";
                    this.parent.EndDate.Focus();
                    break;
                }

                if (StartDate > EndDate)
                {
                    ErrorMsg = "Start Date can not be greater than End Date";
                    this.parent.EndDate.Focus();
                    break;
                }

                switch(action)
                {
                    case "ADD" :
                        {
                            if (StartDate < StaticMaster.convertStringToDate(StaticMaster.convertDateToString(DateTime.Today)))
                            {
                                ErrorMsg = "Start Date Can not be Less than Current Date";
                                this.parent.StartDate.Focus();
                                break;
                            }

                            if (EndDate < StaticMaster.convertStringToDate(StaticMaster.convertDateToString(DateTime.Today)))
                            {
                                ErrorMsg = "End Date Can not be Less than Current Date";
                                this.parent.EndDate.Focus();
                                break;
                            }

                            ErrorMsg = db.db_CheckBookingDates(StaticMaster.convertDateToString(StartDate), StaticMaster.convertDateToString(EndDate), SelectedSite.SiteSeqNum, 0);
                            if(ErrorMsg != null)
                                this.parent.StartDate.Focus();
                            break;
                        }
                    case "MDFY" :
                        {
                            if (orderModel.OrderStatus.Equals(Status.PREE))
                            {
                                if (StartDate < StaticMaster.convertStringToDate(StaticMaster.convertDateToString(DateTime.Today)))
                                {
                                    ErrorMsg = "Start Date Can not be Less than Current Date";
                                    this.parent.StartDate.Focus();
                                    break;
                                }
                            }

                            if (EndDate < StaticMaster.convertStringToDate(StaticMaster.convertDateToString(DateTime.Today)))
                            {
                                ErrorMsg = "End Date Can not be Less than Current Date";
                                this.parent.EndDate.Focus();
                                break;
                            }
                            ErrorMsg = db.db_CheckBookingDates(StaticMaster.convertDateToString(StartDate), StaticMaster.convertDateToString(EndDate), SelectedSite.SiteSeqNum, orderModel.OrderSeqNum);
                            if (ErrorMsg != null)
                                this.parent.StartDate.Focus();
                            break;
                        }
                }
                break;
            }
            if (ErrorMsg != null)
            {
                //WpfMessageBox.Show(ErrorMsg,Status.ERR);
                return false;
            }
            return true;
        }

        #region Close Command
        private RelayCommand closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                return closeCommand ?? (closeCommand = new RelayCommand(param => this.Close()));
            }
        }
        public void Close()
        {
            parent.Close();
        }
        #endregion

        #region Reset Fields
        private void resetFields()
        {
            switch(action)
            {
                case "ADD" :
                    {
                        SelectedSite = Sites.FirstOrDefault();
                        SelectedClient = Clients.FirstOrDefault();
                        Amount = "0";
                        Charges = "0";
                        Printing = "0";
                        Mounting = "0";
                        StartDate = null;
                        EndDate = null;
                        SiteEnable = true;
                        ClientEnable = true;
                        AmountEnable = true;
                        StartDateEnable = true;
                        EndDateEnable = true;
                        EndDateReadOnly = true;
                        if (StartDate == null)
                            DisplayStartDate = System.DateTime.Today;
                        else
                            DisplayStartDate = StartDate;

                        if (EndDate == null)
                            DisplayEndDate = System.DateTime.Today;
                        else
                            DisplayEndDate = EndDate;
                        break;
                    }
                case "MDFY" :
                    {
                        SelectedSite = Sites.FirstOrDefault(i => i.SiteSeqNum == orderModel.OrderSite.SiteSeqNum);
                        SelectedClient = Clients.FirstOrDefault(i => i.ClientSeqNum == orderModel.OrderClient.ClientSeqNum );
                        Amount = orderModel.OrderTotalAmount.ToString();
                        Printing = orderModel.OrderPrintingAmount.ToString();
                        Charges = orderModel.OrderGeneralAmount.ToString();
                        Mounting = orderModel.OrderMountingAmount.ToString();
                        StartDate = orderModel.OrderStartDate;
                        EndDate = orderModel.OrderEndDate;
                        SiteEnable = false;
                        ClientEnable = false;
                        AmountEnable = true;
                        StartDateEnable = true;
                        EndDateEnable = true;
                        EndDateReadOnly = false;
                        switch(orderModel.OrderStatus)
                        {
                            case Status.RUNN : 
                                {
                                    StartDateEnable = false;
                                    break;
                                }
                            case Status.FNSH :
                                {
                                    StartDateEnable = false;
                                    EndDateEnable = false;
                                    EndDateReadOnly = true;
                                    break;
                                }
                            case Status.CNCL :
                                {
                                    StartDateEnable = false;
                                    EndDateEnable = false;
                                    EndDateReadOnly = true;
                                    break;
                                }
                        }
                        if (StartDate == null)
                            DisplayStartDate = System.DateTime.Today;
                        else
                            DisplayStartDate = StartDate;

                        if (EndDate == null)
                            DisplayEndDate = System.DateTime.Today;
                        else
                            DisplayEndDate = EndDate;
                                break;
                    }
            
                    
                case "CNCL" :
                    {
                        SelectedSite = Sites.FirstOrDefault(i => i.SiteSeqNum == orderModel.OrderSite.SiteSeqNum);
                        SelectedClient = Clients.FirstOrDefault(i => i.ClientSeqNum == orderModel.OrderClient.ClientSeqNum );
                        Amount = orderModel.OrderTotalAmount.ToString();
                        Printing = orderModel.OrderPrintingAmount.ToString();
                        Charges = orderModel.OrderGeneralAmount.ToString();
                        Mounting = orderModel.OrderMountingAmount.ToString();
                        StartDate = orderModel.OrderStartDate;
                        EndDate = orderModel.OrderEndDate;
                        SiteEnable = false;
                        ClientEnable = false;
                        AmountEnable = false;
                        StartDateEnable = false;
                        EndDateEnable = false;
                        EndDateReadOnly = true;
                
                        if (StartDate == null)
                            DisplayStartDate = System.DateTime.Today;
                        else
                            DisplayStartDate = StartDate;

                        if (EndDate == null)
                            DisplayEndDate = System.DateTime.Today;
                        else
                            DisplayEndDate = EndDate;
                        break;
                    }

                default:
                    {
                        SelectedSite = Sites.FirstOrDefault();
                        SelectedClient = Clients.FirstOrDefault();
                        Amount = "0";
                        Charges = "0";
                        Printing = "0";
                        Mounting = "0";
                        StartDate = null;
                        EndDate = null;
                        SiteEnable = true;
                        ClientEnable = true;
                        AmountEnable = true;
                        StartDateEnable = true;
                        EndDateEnable = false;
                        EndDateReadOnly = true;
                        if (StartDate == null)
                            DisplayStartDate = System.DateTime.Today;
                        else
                            DisplayStartDate = StartDate;

                        if (EndDate == null)
                            DisplayEndDate = System.DateTime.Today;
                        else
                            DisplayEndDate = EndDate;
                        break;
                    }
            }
            
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
            {
                EndDateReadOnly = false;
            }
        }
        #endregion
    }
}
