using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ShreeMehtaPublicity.MODEL
{
    public class OrderModel : VIEWMODEL.ViewModelBase
    {
        private int _orderSeqNum;
        public int OrderSeqNum
        {
            get
            {
                return _orderSeqNum;
            }
            set
            {
                _orderSeqNum = value;
                OnPropertyChanged("OrderSeqNum");
            }
        }

        private SiteModel _orderSite;
        public SiteModel OrderSite
        {
            get
            {
                return _orderSite;
            }
            set
            {
                _orderSite = value;
                OnPropertyChanged("OrderSite");
            }
        }
        
        private ClientModel _orderClient;
        public ClientModel OrderClient
        {
            get
            {
                return _orderClient;
            }
            set
            {
                _orderClient = value;
                OnPropertyChanged("OrderClient");
            }
        }
        
        private DateTime? _orderStartDate;
        public DateTime? OrderStartDate
        {
            get
            {
                return _orderStartDate;
            }
            set
            {
                _orderStartDate = value;
                OnPropertyChanged("OrderStartDate");
            }
        }

        private DateTime? _orderEndDate;
        public DateTime? OrderEndDate
        {
            get
            {
                return _orderEndDate;
            }
            set
            {
                _orderEndDate = value;
                OnPropertyChanged("OrderEndDate");
            }
        }

        private double _orderGeneralAmount;
        public double OrderGeneralAmount
        {
            get
            {
                return _orderGeneralAmount;
            }
            set
            {
                _orderGeneralAmount = value;
                OnPropertyChanged("OrderGeneralAmount");
            }
        }

        private double _orderPrintingAmount;
        public double OrderPrintingAmount
        {
            get
            {
                return _orderPrintingAmount;
            }
            set
            {
                _orderPrintingAmount = value;
                OnPropertyChanged("OrderPrintingAmount");
            }
        }

        private double _orderMountingAmount;
        public double OrderMountingAmount
        {
            get
            {
                return _orderMountingAmount;
            }
            set
            {
                _orderMountingAmount = value;
                OnPropertyChanged("OrderMountingAmount");
            }
        }
        
        private string _orderStatus;
        public string OrderStatus
        {
            get
            {
                return _orderStatus;
            }
            set
            {
                _orderStatus = value;
                OnPropertyChanged("OrderStatus");
            }
        }

        private double _orderTotalAmount;
        public double OrderTotalAmount
        {
            get
            {
                return _orderTotalAmount;
            }
            set
            {
                _orderTotalAmount = value;
                OnPropertyChanged("OrderTotalAmount");
            }
        }
    }
}
