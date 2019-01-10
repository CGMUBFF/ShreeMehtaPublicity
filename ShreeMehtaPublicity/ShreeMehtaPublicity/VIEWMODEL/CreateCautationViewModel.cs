using ShreeMehtaPublicity.MODEL;
using ShreeMehtaPublicity.Utility;
using ShreeMehtaPublicity.VIEW;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ShreeMehtaPublicity.VIEWMODEL
{
    public class CreateCautationViewModel : ViewModelBase
    {
        private Database db;
        private CreateCautationView parent;

        #region Variable Declaration
        private CautationModel _cautationCreated;
        public CautationModel CautationCreated
        {
            get { return _cautationCreated; }
            set { _cautationCreated = value; OnPropertyChanged("CautationCreated"); }
        }

        private ObservableCollection<SiteCautationModel> _listofSelectedCautation;
        public ObservableCollection<SiteCautationModel> ListofSelectedCautation
        {
            get { return _listofSelectedCautation; }
            set { _listofSelectedCautation = value; OnPropertyChanged("ListofSelectedCautation"); }
        }

        private Boolean _cautationConfirmed;
        public Boolean CautationConfirmed
        {
            get { return _cautationConfirmed; }
            set { _cautationConfirmed = value; OnPropertyChanged("CautationConfirmed"); }
        }

        private ObservableCollection<ClientModel> _listofSelectedClients;
        public ObservableCollection<ClientModel> ListofSelectedClients
        {
            get { return _listofSelectedClients; }
            set { _listofSelectedClients = value; OnPropertyChanged("ListofSelectedClients"); }
        }

        private ClientModel _selectedCautationClient;
        public ClientModel SelectedCautationClient
        {
            get { return _selectedCautationClient; }
            set { _selectedCautationClient = value; OnPropertyChanged("SelectedCautationClient"); }
        }

        private ClientModel _selectedClient;
        public ClientModel SelectedClient
        {
            get { return _selectedClient; }
            set { _selectedClient = value; OnPropertyChanged("SelectedClient"); }
        }

        private ObservableCollection<ClientModel> _listofClients;
        public ObservableCollection<ClientModel> ListofClients
        {
            get { return _listofClients; }
            set { _listofClients = value; OnPropertyChanged("ListofClients"); }
        }

        private string _to;
        public string To
        {
            get { return _to; }
            set { _to = value; OnPropertyChanged("To"); }
        }

        private string _subject;
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; OnPropertyChanged("Subject"); }
        }

        private string _body;
        public string Body
        {
            get { return _body; }
            set { _body = value; OnPropertyChanged("Body"); }
        }

        private int _cautationSeqNo;
        public int CautationSeqNo
        {
            get { return _cautationSeqNo; }
            set { _cautationSeqNo = value; OnPropertyChanged("CautationSeqNo"); }
        }

        private string _actionLabel;
        public string ActionLabel
        {
            get { return _actionLabel; }
            set { _actionLabel = value; OnPropertyChanged("ActionLabel"); }
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
        public CreateCautationViewModel(CreateCautationView parent, ObservableCollection<SiteCautationModel> listofSelectedCautation)
        {
            db = Database.getInstance();
            this.ListofSelectedCautation = new ObservableCollection<SiteCautationModel>(listofSelectedCautation);
            this.parent = parent;
            this.ListofClients = db.db_GetAllClients();
            ListofSelectedClients = new ObservableCollection<ClientModel>();

            CautationConfirmed = false;
            ActionLabel = "Create Cautation";
            StatusString = "";
            StatusStringFlag = Visibility.Collapsed;
        }
        #endregion

        #region Edit Command
        private RelayCommand editCommand;
        public ICommand EditCommand
        {
            get
            {
                return editCommand ?? (editCommand = new RelayCommand(param => this.Edit()));
            }
        }
        private void Edit()
        {
            parent.editSite();
        }
        #endregion

        #region Confirm Command
        private RelayCommand confirmCommand;
        public ICommand ConfirmCommand
        {
            get
            {
                return confirmCommand ?? (confirmCommand = new RelayCommand(param => this.Confirm()));
            }
        }
        private void Confirm()
        {
            int draft_seq_no = -1;
            string output = db.db_addNewCautation(_listofSelectedCautation);
            if (output != null)
            {
                try
                {
                    draft_seq_no = Int32.Parse(output);
                    CautationConfirmed = true;
                }
                catch (Exception e)
                {
                    StatusString = "Failed to Create Cautation, Please create cautation again";
                    ForegroundColor = System.Windows.Media.Brushes.Red;
                    StatusStringFlag = Visibility.Visible;
                }
            }
            CautationSeqNo = draft_seq_no;
            
            CautationCreated = db.db_getCautationDetail(_cautationSeqNo);

            FileOperations.createCautationPDFFile(_listofSelectedCautation, _cautationCreated.CautationFileName);

            ActionLabel = "Send Cautation";
        }
        #endregion

        #region Save Command
        private RelayCommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new RelayCommand(param => this.Save("0")));
            }
        }
        private void Save(string sendFlag)
        {
            string output = db.db_updateNewCautation(_listofSelectedClients, _subject, _body, _cautationCreated.CautationFileName, sendFlag, _cautationCreated.CautationSeqNo);

            if (output.Equals(Status.SUCC))
            {
                StatusString = "Cautation Saved Successfully";
                ForegroundColor = System.Windows.Media.Brushes.Green;
            }
            else if (output.Equals(Status.ERR))
            {
                StatusString = "Failed to Save Cautation";
                ForegroundColor = System.Windows.Media.Brushes.Red;
            }
            else
            {
                StatusString = output;
                ForegroundColor = System.Windows.Media.Brushes.Red;
            }

            CautationCreated = db.db_getCautationDetail(_cautationSeqNo);
        }
        #endregion

        #region Send Command
        private RelayCommand sendCommand;
        public ICommand SendCommand
        {
            get
            {
                return sendCommand ?? (sendCommand = new RelayCommand(param => this.Send()));
            }
        }
        private void Send()
        {
            Save("1");
            if (validateSave())
            {
                Mail mail = new Mail();

                String output = mail.SendCautation(_cautationCreated.ClientList, _cautationCreated.Body, _cautationCreated.Subject, _cautationCreated.CautationFileName);
                if (output.Equals(Status.SUCC))
                {
                    StatusString = "Cautation Send Successfully";
                    ForegroundColor = System.Windows.Media.Brushes.Green;
                }
                else if (output.Equals(Status.ERR))
                {
                    StatusString = "Failed to Send Cautation";
                    ForegroundColor = System.Windows.Media.Brushes.Red;
                }
                else
                {
                    StatusString = output;
                    ForegroundColor = System.Windows.Media.Brushes.Red;
                }
                StatusStringFlag = Visibility.Visible;
            }
            /*
                        if (output.Equals(Status.SUCC))
                        {
                            var messageBoxResult = CustomMessageBox.Show(output, "Order Canceled Successfully", MessageBoxButton.OK);
                            if (messageBoxResult == MessageBoxResult.OK)
                            {
                                parent.Close();
                            }
                        }
                        else if (output.Equals(Status.ERR))
                        {
                            var messageBoxResult = CustomMessageBox.Show(output, "Failed to Cancel Order", MessageBoxButton.OK);
                            if (messageBoxResult == MessageBoxResult.OK)
                            {
                                //parent.Close();
                            }
                        }
                        else
                        {
                            var messageBoxResult = CustomMessageBox.Show(Status.ERR, output, MessageBoxButton.OK);
                            if (messageBoxResult == MessageBoxResult.OK)
                            {
                                //parent.Close();
                            }
                        }*/
        }

        private bool validateSave()
        {
            if (!StatusString.Equals("Cautation Saved Successfully"))
            {
                StatusString = "Please Send Cautation again";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                return false;
            }
            else if (ListofSelectedClients.Count <= 0)
            {
                StatusString = "Please Select Clients";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.To.Focus();
                return false;
            }
            else if (CustomValidation.validateString(_subject))
            {
                StatusString = "Please Enter Subject";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.Subject.Focus();
                return false;
            }
            else if (CustomValidation.validateString(_body))
            {
                StatusString = "Please Enter Body";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.Body.Focus();
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

        #region NewClientSelected Command
        private RelayCommand newClientSelectedCommand;
        public ICommand NewClientSelectedCommand
        {
            get
            {
                return newClientSelectedCommand ?? (newClientSelectedCommand = new RelayCommand(param => this.newClientSelected()));
            }
        }
        private void newClientSelected()
        {
            if (ListofSelectedClients.IndexOf(SelectedClient) <= -1)
                if(SelectedClient != null)
                    ListofSelectedClients.Add(SelectedClient);

            To = "";
        }
        #endregion

        #region DeleteCautationClient Command
        private RelayCommand deleteCautationClientCommand;
        public ICommand DeleteCautationClientCommand
        {
            get
            {
                return deleteCautationClientCommand ?? (deleteCautationClientCommand = new RelayCommand(param => this.deleteCautationClient()));
            }
        }
        private void deleteCautationClient()
        {
            if(SelectedCautationClient != null)
                if (ListofSelectedClients.IndexOf(SelectedCautationClient) > -1)
                    ListofSelectedClients.Remove(SelectedCautationClient);
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
            if(StatusString.Equals("Cautation Send Successfully"))
                parent.Close();
            
            StatusStringFlag = Visibility.Collapsed;
            StatusString = "";
        }
        #endregion
    }
}
