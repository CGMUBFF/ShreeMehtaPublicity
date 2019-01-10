using ShreeMehtaPublicity.MODEL;
using ShreeMehtaPublicity.Utility;
using ShreeMehtaPublicity.VIEW;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

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
            StatusString = "";
            StatusStringFlag = Visibility.Collapsed;
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
            if (validation())
            {
                string output = db.db_AddNewClient( _clientName, _clientAddress, _clientBranch, _clientLandline, _clientMobile, _clientGST, _clientMail, _listofContactPersons);
                if (output.Equals(Status.SUCC))
                {
                    StatusString = "Client Added Successfully";
                    ForegroundColor = System.Windows.Media.Brushes.Green;
                }
                else if (output.Equals(Status.ERR))
                {
                    StatusString = "Failed to Add Client";
                    ForegroundColor = System.Windows.Media.Brushes.Red;
                }
                else
                {
                    StatusString = output;
                    ForegroundColor = System.Windows.Media.Brushes.Red;
                }
                StatusStringFlag = Visibility.Visible;
            }
        }
        private void mdfyClient()
        {
            if (validation())
            {
                string output = db.db_MdfyClient(clientModel, _clientName, _clientAddress, _clientBranch, _clientGST, _clientLandline, _clientMobile, _clientMail, _listofContactPersons);
                if (output.Equals(Status.SUCC))
                {
                    StatusString = "Client Modified Successfully";
                    ForegroundColor = System.Windows.Media.Brushes.Green;
                }
                else if (output.Equals(Status.ERR))
                {
                    StatusString = "Failed to Modify Client";
                    ForegroundColor = System.Windows.Media.Brushes.Red;
                }
                else
                {
                    StatusString = output;
                    ForegroundColor = System.Windows.Media.Brushes.Red;
                }
                StatusStringFlag = Visibility.Visible;
            }
        }
        private bool validation()
        {
            if (CustomValidation.validateString(_clientName))
            {
                StatusString = "Please Enter Name of Client";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.ClientName.Focus();
                return false;
            }
            if (CustomValidation.validateString(_clientLandline))
            {
                StatusString = "Please Enter Landline Number";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.ClientLandline.Focus();
                return false;
            }
            if (CustomValidation.validateString(_clientMobile))
            {
                StatusString = "Please Enter Valid Mobile Number";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.ClientMobile.Focus();
                return false;
            }
            if (CustomValidation.validateMobile(_clientMobile))
            {
                StatusString = "Please Enter Valid Mobile Number";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.ClientMobile.Focus();
                return false;
            }
            if (CustomValidation.validateString(_clientMail))
            {
                StatusString = "Please Enter Valid Email-Id";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.ClientMail.Focus();
                return false;
            }
            if(CustomValidation.validateMail(_clientMail))
            {
                StatusString = "Please Enter Valid Email-Id";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.ClientMail.Focus();
                return false;
            }
            if (CustomValidation.validateString(_clientAddress))
            {
                StatusString = "Please Enter Head Office Address";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.ClientAddress.Focus();
                return false;
            }
            if (CustomValidation.validateString(_clientBranch))
            {
                StatusString = "Please Enter Branch Address";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.ClientBranch.Focus();
                return false;
            }
            if (CustomValidation.validateString(_clientGST))
            {
                StatusString = "Please Enter Client's GST Number";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.ClientGST.Focus();
                return false;
            }
            return true;
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
            if (validationContactPerson())
            {
                if (this._contactPersonSeqNum == 0)//Add New Contact Person
                {
                    if (clientModel == null)
                    {
                        ListofContactPersons.Add(new ContactPersonModel { ContactPersonName = this._contactPersonName, ContactPersonMobile = this._contactPersonMobile, ContactPersonMail = this._contactPersonMail, ContactPersonSeqNum = ++this.contactPersonCount, ClientSeqNum = 0 });
                    }
                    else
                    {
                        ListofContactPersons.Add(new ContactPersonModel { ContactPersonName = this._contactPersonName, ContactPersonMobile = this._contactPersonMobile, ContactPersonMail = this._contactPersonMail, ContactPersonSeqNum = ++this.contactPersonCount, ClientSeqNum = this.clientModel.ClientSeqNum });
                    }
                }
                else//Modify Contact Person
                {
                    ContactPersonModel contactPerson = _listofContactPersons.FirstOrDefault(i => i.ContactPersonSeqNum == this._contactPersonSeqNum);
                    contactPerson.ContactPersonName = this._contactPersonName;
                    contactPerson.ContactPersonMobile = this._contactPersonMobile;
                    contactPerson.ContactPersonMail = this._contactPersonMail;
                }
                resetContactPerson();
            }
        }
        private bool validationContactPerson()
        {
            if (CustomValidation.validateString(_contactPersonName))
            {
                StatusString = "Please Enter Contact Person's Name";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.ContactName.Focus();
                return false;
            }
            if (CustomValidation.validateString(_contactPersonMobile))
            {
                StatusString = "Please Enter Valid Contact Person's Number";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.ContactMobile.Focus();
                return false;
            }
            if (CustomValidation.validateMobile(_contactPersonMobile))
            {
                StatusString = "Please Enter Valid Contact Person's Number";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.ContactMobile.Focus();
                return false;
            }
            if (CustomValidation.validateString(_contactPersonMail))
            {
                StatusString = "Please Enter Valid Contact Person's Mail";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.ContactMail.Focus();
                return false;
            }
            if (CustomValidation.validateMail(_contactPersonMail))
            {
                StatusString = "Please Enter Valid Contact Person's Mail";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.ContactMail.Focus();
                return false;
            }
            return true;
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
            this.ContactPersonName = _selectedContactPerson.ContactPersonName;
            this.ContactPersonMobile = _selectedContactPerson.ContactPersonMobile;
            this.ContactPersonMail = _selectedContactPerson.ContactPersonMail;
            this.ContactPersonSeqNum = _selectedContactPerson.ContactPersonSeqNum;
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
            if (StatusString.Equals("Client Added Successfully") || StatusString.Equals("Client Modified Successfully"))
                parent.Close();

            StatusStringFlag = Visibility.Collapsed;
            StatusString = "";
        }
        #endregion
    }
}