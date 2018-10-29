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
    public class ClientMgmtViewModel : ViewModelBase
    {
        private Database db;

        #region Variable Declaration
        private ObservableCollection<ClientModel> _listofClients;
        public ObservableCollection<ClientModel> ListofClients
        {
            get
            {
                return _listofClients;
            }
            set
            {
                _listofClients = value;
                OnPropertyChanged("ListofClients");
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

        private string _fselectedStatus;
        public string fSelectedStatus
        {
            get
            {
                return _fselectedStatus;
            }
            set
            {
                _fselectedStatus = value;
                OnPropertyChanged("fSelectedStatus");
            }
        }

        private string _fclientName;
        public string fClientName
        {
            get
            {
                return _fclientName;
            }
            set
            {
                _fclientName = value;
                OnPropertyChanged("fClientName");
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
        #endregion

        #region Constructor
        public ClientMgmtViewModel()
        {
            db = Database.getInstance();

            ListofStatus = new ObservableCollection<string>();
            ListofStatus.Add("ALL");
            ListofStatus.Add(Status.ACTV);
            ListofStatus.Add(Status.IACT);

            resetFields();
            searchClients();
        }
        #endregion

        #region searchOrders Command
        private RelayCommand searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return searchCommand ?? (searchCommand = new RelayCommand(param => this.searchClients()));
            }
        }
        public void searchClients()
        {
            ListofClients = db.db_GetClientList(StaticMaster.convertStringToClientStatus(_fselectedStatus), _fclientName==null?"ALL":_fclientName);
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
            searchClients();
        }
        #endregion

        private void resetFields()
        {
            fClientName = null;
            fSelectedStatus = _listofStatus.FirstOrDefault(x => x.Equals(Status.ACTV));
        }
    }
}
