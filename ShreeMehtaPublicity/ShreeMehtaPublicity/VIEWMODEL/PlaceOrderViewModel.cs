﻿using System;
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
        private string _statusString;
        public string StatusString
        {
            get { return _statusString; }
            set { _statusString = value; OnPropertyChanged("StatusString"); }
        }

        private System.Windows.Media.Brush _foregroundColor;
        public System.Windows.Media.Brush ForegroundColor
        {
            get { return _foregroundColor; }
            set { _foregroundColor = value; OnPropertyChanged("ForegroundColor"); }
        }

        private Visibility _statusStringFlag;
        public Visibility StatusStringFlag
        {
            get { return _statusStringFlag; }
            set { _statusStringFlag = value; OnPropertyChanged("StatusStringFlag"); }
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
            StatusString = "";
            StatusStringFlag = Visibility.Collapsed;
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
                                StatusString = "Order Placed Successfully";
                                ForegroundColor = System.Windows.Media.Brushes.Green;
                            }
                            else if (output.Equals(Status.ERR))
                            {
                                StatusString = "Failed to Place Order";
                                ForegroundColor = System.Windows.Media.Brushes.Red;
                            }
                            else
                            {
                                StatusString = output;
                                ForegroundColor = System.Windows.Media.Brushes.Red;
                            }
                            StatusStringFlag = Visibility.Visible;
                            break;
                        }
                    case "MDFY" :
                        {
                            string output = db.db_MdfyOrder(orderModel.OrderSeqNum, Double.Parse(Charges), Double.Parse(Printing), Double.Parse(Mounting), StaticMaster.convertDateToString(StartDate), StaticMaster.convertDateToString(EndDate), StaticMaster.convertStringToOrderStatus(orderStatus));
                            if (output.Equals(Status.SUCC))
                            {
                                StatusString = "Order Modified Successfully";
                                ForegroundColor = System.Windows.Media.Brushes.Green;
                            }
                            else if (output.Equals(Status.ERR))
                            {
                                StatusString = "Failed to Modify Order";
                                ForegroundColor = System.Windows.Media.Brushes.Red;
                            }
                            else
                            {
                                StatusString = output;
                                ForegroundColor = System.Windows.Media.Brushes.Red;
                            }
                            StatusStringFlag = Visibility.Visible;
                            break;
                        }
                    case "CNCL" :
                        {
                            var messageBoxResult = CustomMessageBox.Show("Confirmation", "Do you want to Cancel Order " + orderModel.OrderSeqNum + " ?", MessageBoxButton.YesNo);
                            if (messageBoxResult == MessageBoxResult.Yes)
                            {
                                string output = db.db_CnclOrder(orderModel.OrderSeqNum);
                                if (output.Equals(Status.SUCC))
                                {
                                    StatusString = "Order Cancelled Successfully";
                                    ForegroundColor = System.Windows.Media.Brushes.Green;
                                }
                                else if (output.Equals(Status.ERR))
                                {
                                    StatusString = "Failed to Cancel Order";
                                    ForegroundColor = System.Windows.Media.Brushes.Red;
                                }
                                else
                                {
                                    StatusString = output;
                                    ForegroundColor = System.Windows.Media.Brushes.Red;
                                }
                                StatusStringFlag = Visibility.Visible;
                            }
                            break;
                        }
                    default :
                        {
                            StatusString = "Invalid Operation";
                            ForegroundColor = System.Windows.Media.Brushes.Red;
                            StatusStringFlag = Visibility.Visible;
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

            if (_selectedSite == null || CustomValidation.validateString(_selectedSite.SiteName))
            {
                StatusString = "Please Select Site";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.SiteFilter.Focus();
                return false;
            }

            if (_selectedClient == null || CustomValidation.validateString(_selectedClient.ClientName))
            {
                StatusString = "Please Select Client";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.ClientFilter.Focus();
                return false;
            }

            if (_startDate == null)
            {
                StatusString = "Please Select Order Start Date";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.StartDate.Focus();
                return false;
            }

            if (_endDate == null)
            {
                StatusString = "Please Select Order End Date";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.EndDate.Focus();
                return false;
            }

            if (_startDate > _endDate)
            {
                StatusString = "End Date can not be greater than Start Date";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.EndDate.Focus();
                return false;
            }

            switch(action)
            {
                case "ADD" :
                    {
                        if (_startDate < StaticMaster.convertStringToDate(StaticMaster.convertDateToString(DateTime.Today)))
                        {
                            StatusString = "Start Date Can not be Less than Current Date";
                            ForegroundColor = System.Windows.Media.Brushes.Red;
                            this.parent.StartDate.Focus();
                            return false;
                        }
                        ErrorMsg = db.db_CheckBookingDates(StaticMaster.convertDateToString(_startDate), StaticMaster.convertDateToString(_endDate), _selectedSite.SiteSeqNum, 0);
                        if (ErrorMsg != null)
                        {
                            StatusString = ErrorMsg;
                            ForegroundColor = System.Windows.Media.Brushes.Red;
                            this.parent.StartDate.Focus();
                            return false;
                        }
                        if (_endDate < StaticMaster.convertStringToDate(StaticMaster.convertDateToString(DateTime.Today)))
                        {
                            StatusString = "End Date Can not be Less than Current Date";
                            ForegroundColor = System.Windows.Media.Brushes.Red;
                            this.parent.EndDate.Focus();
                            return false;
                        }
                        break;
                    }
                case "MDFY" :
                    {
                        if (orderModel.OrderStatus.Equals(Status.PREE))
                        {
                            if (_startDate < StaticMaster.convertStringToDate(StaticMaster.convertDateToString(DateTime.Today)))
                            {
                                StatusString = "Start Date Can not be Less than Current Date";
                                ForegroundColor = System.Windows.Media.Brushes.Red;
                                this.parent.StartDate.Focus();
                                return false;
                            }
                        }
                        ErrorMsg = db.db_CheckBookingDates(StaticMaster.convertDateToString(_startDate), StaticMaster.convertDateToString(_endDate), _selectedSite.SiteSeqNum, orderModel.OrderSeqNum);
                        if (ErrorMsg != null)
                        {
                            StatusString = ErrorMsg;
                            ForegroundColor = System.Windows.Media.Brushes.Red;
                            this.parent.StartDate.Focus();
                            return false;
                        }
                        if (_endDate < StaticMaster.convertStringToDate(StaticMaster.convertDateToString(DateTime.Today)))
                        {
                            StatusString = "End Date Can not be Less than Current Date";
                            ForegroundColor = System.Windows.Media.Brushes.Red;
                            this.parent.EndDate.Focus();
                            return false;
                        }
                        break;
                    }
            }

            if (CustomValidation.validateString(_charges) || CustomValidation.validationDouble(_charges))
            {
                StatusString = "Please Enter Charges";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.Charges.Focus();
                return false;
            }
            if (CustomValidation.validateString(_printing) || CustomValidation.validationDouble(_printing))
            {
                StatusString = "Please Enter Printing Amount";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.Printing.Focus();
                return false;
            }
            if (CustomValidation.validateString(_mounting) || CustomValidation.validationDouble(_mounting))
            {
                StatusString = "Please Enter Mounting Amount";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.Mounting.Focus();
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
                        SelectedSite = _sites.FirstOrDefault();
                        SelectedClient = _clients.FirstOrDefault();
                        Amount = "0";
                        Charges = _selectedSite.SiteAmount;
                        Printing = null;
                        Mounting = null;
                        StartDate = null;
                        EndDate = null;
                        SiteEnable = true;
                        ClientEnable = true;
                        AmountEnable = true;
                        StartDateEnable = true;
                        EndDateEnable = false;
                        EndDateReadOnly = true;
                        if (_startDate == null)
                            DisplayStartDate = System.DateTime.Today;
                        else
                            DisplayStartDate = _startDate;

                        if (_endDate == null)
                            DisplayEndDate = System.DateTime.Today;
                        else
                            DisplayEndDate = _endDate;
                        break;
                    }
                case "MDFY" :
                    {
                        SelectedSite = _sites.FirstOrDefault(i => i.SiteSeqNum == orderModel.OrderSite.SiteSeqNum);
                        SelectedClient = _clients.FirstOrDefault(i => i.ClientSeqNum == orderModel.OrderClient.ClientSeqNum );
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
                        if (_startDate == null)
                            DisplayStartDate = System.DateTime.Today;
                        else
                            DisplayStartDate = _startDate;

                        if (_endDate == null)
                            DisplayEndDate = System.DateTime.Today;
                        else
                            DisplayEndDate = _endDate;
                        break;
                    }
            
                    
                case "CNCL" :
                    {
                        SelectedSite = _sites.FirstOrDefault(i => i.SiteSeqNum == orderModel.OrderSite.SiteSeqNum);
                        SelectedClient = _clients.FirstOrDefault(i => i.ClientSeqNum == orderModel.OrderClient.ClientSeqNum );
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
                
                        if (_startDate == null)
                            DisplayStartDate = System.DateTime.Today;
                        else
                            DisplayStartDate = _startDate;

                        if (_endDate == null)
                            DisplayEndDate = System.DateTime.Today;
                        else
                            DisplayEndDate = _endDate;
                        break;
                    }

                default:
                    {
                        SelectedSite = _sites.FirstOrDefault();
                        SelectedClient = _clients.FirstOrDefault();
                        Amount = null;
                        Charges = _selectedSite.SiteAmount;
                        Printing = null;
                        Mounting = null;
                        StartDate = null;
                        EndDate = null;
                        SiteEnable = true;
                        ClientEnable = true;
                        AmountEnable = true;
                        StartDateEnable = true;
                        EndDateEnable = false;
                        EndDateReadOnly = true;
                        if (_startDate == null)
                            DisplayStartDate = System.DateTime.Today;
                        else
                            DisplayStartDate = _startDate;

                        if (_endDate == null)
                            DisplayEndDate = System.DateTime.Today;
                        else
                            DisplayEndDate = _endDate;
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
            if (_endDate == null || _endDate < _startDate)
                EndDate = _startDate;
            
            if (_startDate != null)
            {
                EndDateEnable = true;
                EndDateReadOnly = false;
            }
        }
        #endregion

        #region SelectedSiteChanged Command
        private RelayCommand selectedSiteChangedCommand;
        public ICommand SelectedSiteChangedCommand
        {
            get
            {
                return selectedSiteChangedCommand ?? (selectedSiteChangedCommand = new RelayCommand(param => this.SelectedSiteChanged()));
            }
        }
        private void SelectedSiteChanged()
        {
            Charges = _selectedSite.SiteAmount;
        }
        #endregion

        #region Ok Command
        private RelayCommand okCommand;
        public ICommand OkCommand
        {
            get
            {
                return okCommand ?? (okCommand = new RelayCommand(param => this.Ok()));
            }
        }
        private void Ok()
        {
            if (StatusString.Equals("Order Cancelled Successfully") || StatusString.Equals("Order Modified Successfully") || StatusString.Equals("Order Placed Successfully"))
                parent.Close();

            StatusStringFlag = Visibility.Collapsed;
            StatusString = "";
        }
        #endregion
    }
}
