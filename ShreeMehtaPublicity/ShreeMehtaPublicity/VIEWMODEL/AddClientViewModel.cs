using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;

using ShreeMehtaPublicity.Utility;
using ShreeMehtaPublicity.VIEW;
using ShreeMehtaPublicity.MODEL;

namespace ShreeMehtaPublicity.VIEWMODEL
{
    public class AddClientViewModel : ViewModelBase
    {
        private Database db;
        private AddClientView parent;
        private ClientModel clientModel;
        private string action;
        private int contactPersonCount;

        #region Variable Declaration
        private ObservableCollection<ContactPersonModel> _listofContactPersons;
        public ObservableCollection<ContactPersonModel> ListofContactPersons
        {
            get
            {
                return _listofContactPersons;
            }
            set
            {
                _listofContactPersons = value;
                OnPropertyChanged("ListofContactPersons");
            }
        }

        private ContactPersonModel _selectedContactPerson;
        public ContactPersonModel SelectedContactPerson
        {
            get
            {
                return _selectedContactPerson;
            }
            set
            {
                _selectedContactPerson = value;
                OnPropertyChanged("SelectedContactPerson");
            }
        }

        private int _contactPersonSeqNum;
        public int ContactPersonSeqNum
        {
            get
            {
                return _contactPersonSeqNum;
            }
            set
            {
                _contactPersonSeqNum = value;
                OnPropertyChanged("ContactPersonSeqNum");
            }
        }

        private String _contactPersonName;
        public String ContactPersonName
        {
            get
            {
                return _contactPersonName;
            }
            set
            {
                _contactPersonName = value;
                OnPropertyChanged("ContactPersonName");
            }
        }

        private string _contactPersonMobile;
        public string ContactPersonMobile
        {
            get
            {
                return _contactPersonMobile;
            }
            set
            {
                _contactPersonMobile = value;
                OnPropertyChanged("ContactPersonMobile");
            }
        }

        private string _contactPersonMail;
        public string ContactPersonMail
        {
            get
            {
                return _contactPersonMail;
            }
            set
            {
                _contactPersonMail = value;
                OnPropertyChanged("ContactPersonMail");
            }
        }

        private String _clientName;
        public String ClientName
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
                OnPropertyChanged("ActionLable");
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
                OnPropertyChanged("ActionButton");
            }
        }

        private string _contactPersonAction;
        public string ContactPersonAction
        {
            get
            {
                return _contactPersonAction;
            }
            set
            {
                _contactPersonAction = value;
                OnPropertyChanged("ContactPersonAction");
            }
        }
        
        #endregion

        #region Constructor
        public AddClientViewModel(AddClientView parent, string action, MODEL.ClientModel clientModel)
        {
            db = Database.getInstance();
            contactPersonCount = 0;
            ContactPersonAction = "Add";

            this.parent = parent;
            ListofContactPersons = new ObservableCollection<ContactPersonModel>();
            ContactPersonName = null;
            ContactPersonMobile = null;
            ContactPersonMail = null;

            if (clientModel != null)
            {
                this.clientModel = clientModel;
                ClientName = clientModel.ClientName;
                ClientMail = clientModel.ClientMail;
                ClientLandline = clientModel.ClientLandline;
                ClientGST = clientModel.ClientGST;
                ClientMobile = clientModel.ClientMobile;
                ClientAddress = clientModel.ClientAddress;
                ClientBranch = clientModel.ClientBranch;
                ListofContactPersons = new ObservableCollection<ContactPersonModel>(db.db_GetContactPersonList(this.clientModel.ClientSeqNum));
            }
            this.action = action;
            switch (action)
            {
                case "ADD":
                    {
                        ActionLable = "Add New Client";
                        ActionButton = "Add";
                        break;
                    }
                case "MDFY":
                    {
                        ActionLable = "Modify Client";
                        ActionButton = "Modify";
                        break;
                    }
                case "ACTV":
                    {
                        string output = db.db_IactvClient(clientModel, "ACTV");
                        if (output.Equals(Status.SUCC))
                        {
                            parent.close();
                        }
                        break;
                    }
                case "IACT":
                    {
                        string output = db.db_IactvClient(clientModel, "IACT");
                        if (output.Equals(Status.SUCC))
                        {
                            parent.close();
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }
        #endregion

        #region saveClient Command
        private RelayCommand saveClientCommand;
        public ICommand SaveClientCommand
        {
            get
            {
                return saveClientCommand ?? (saveClientCommand = new RelayCommand(param => this.saveClient()));
            }
        }
        public void saveClient()
        {
            switch (action)
            {
                case "ADD": { addClient(); break; }
                case "MDFY": { mdfyClient(); break; }
            }

        }
        
        private void addClient()
        {
            string output = db.db_AddNewClient(ClientName, ClientAddress, ClientBranch, ClientLandline, ClientMobile, ClientGST, ClientMail, ListofContactPersons);
            if (output.Equals(Status.SUCC))
            {
                if (true)//WpfMessageBox.Show("Client Added Successfully", Status.SUCC) == MessageBoxResult.OK)
                {
                    parent.Close();
                }
            }
        }
        private void mdfyClient()
        {
            string output = db.db_MdfyClient(clientModel, ClientName, ClientAddress, ClientBranch, ClientGST, ClientLandline, ClientMobile, ClientMail, ListofContactPersons);
            if (output.Equals(Status.SUCC))
            {
                    if (true)//WpfMessageBox.Show("Client Modified Successfully", Status.SUCC) == MessageBoxResult.OK)
                    {
                        parent.Close();
                    }
            }
        }
        #endregion

        #region Close Command
        private RelayCommand closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                return closeCommand ?? (closeCommand = new RelayCommand(param => this.Close()));
            }
        }
        private void Close()
        {
            parent.Close();
        }
        #endregion

        #region saveContactPerson Command
        private RelayCommand saveContactPersonCommand;
        public ICommand SaveContactPersonCommand
        {
            get
            {
                return saveContactPersonCommand ?? (saveContactPersonCommand = new RelayCommand(param => this.saveContactPerson()));
            }
        }
        public void saveContactPerson()
        {
            if (this.ContactPersonSeqNum == 0)
                ListofContactPersons.Add(new ContactPersonModel { ContactPersonName = this.ContactPersonName, ContactPersonMobile = this.ContactPersonMobile, ContactPersonMail = this.ContactPersonMail, ContactPersonSeqNum = ++this.contactPersonCount, ClientSeqNum = this.clientModel.ClientSeqNum});
            else
            {
                ContactPersonModel contactPerson = ListofContactPersons.FirstOrDefault(i => i.ContactPersonSeqNum == this.ContactPersonSeqNum);
                contactPerson.ContactPersonName = this.ContactPersonName;
                contactPerson.ContactPersonMobile = this.ContactPersonMobile;
                contactPerson.ContactPersonMail = this.ContactPersonMail;
            }
            resetContactPerson();
        }
        #endregion

        #region resetContactPerson Command
        private RelayCommand resetContactPersonCommand;
        public ICommand ResetContactPersonCommand
        {
            get
            {
                return resetContactPersonCommand ?? (resetContactPersonCommand = new RelayCommand(param => this.resetContactPerson()));
            }
        }
        public void resetContactPerson()
        {
            this.ContactPersonName = null;
            this.ContactPersonMobile = null;
            this.ContactPersonMail = null;
            this.ContactPersonSeqNum = 0;
            this.ContactPersonAction = "Add";
        }
        #endregion

        #region mdfyContactPerson Command
        private RelayCommand mdfyContactPersonCommand;
        public ICommand MdfyContactPersonCommand
        {
            get
            {
                return mdfyContactPersonCommand ?? (mdfyContactPersonCommand = new RelayCommand(param => this.mdfyContactPerson()));
            }
        }
        public void mdfyContactPerson()
        {
            this.ContactPersonName = SelectedContactPerson.ContactPersonName;
            this.ContactPersonMobile = SelectedContactPerson.ContactPersonMobile;
            this.ContactPersonMail = SelectedContactPerson.ContactPersonMail;
            this.ContactPersonSeqNum = SelectedContactPerson.ContactPersonSeqNum;
            this.ContactPersonAction = "Modify";
        }
        #endregion

        #region deltContactPerson Command
        private RelayCommand deltContactPersonCommand;
        public ICommand DeltContactPersonCommand
        {
            get
            {
                return deltContactPersonCommand ?? (deltContactPersonCommand = new RelayCommand(param => this.deltContactPerson()));
            }
        }
        public void deltContactPerson()
        {
            ListofContactPersons.Remove(SelectedContactPerson);
            resetContactPerson();
        }
        #endregion
    }
}