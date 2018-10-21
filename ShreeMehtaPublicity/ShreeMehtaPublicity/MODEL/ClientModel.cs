using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ShreeMehtaPublicity.MODEL
{
    public class ClientModel : VIEWMODEL.ViewModelBase
    {
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
                OnPropertyChanged("PartySeqNum");
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
    }
}
