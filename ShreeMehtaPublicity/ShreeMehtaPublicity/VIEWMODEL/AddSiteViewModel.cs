using ShreeMehtaPublicity.MODEL;
using ShreeMehtaPublicity.Utility;
using ShreeMehtaPublicity.VIEW;
using System;
using System.Windows;
using System.Windows.Input;

namespace ShreeMehtaPublicity.VIEWMODEL
{
    public class AddSiteViewModel : ViewModelBase
    {
        private Database db;
        private AddSiteView parent;
        private SiteModel siteModel;
        private string action;

        #region Variable Declaration
        private String _siteName;
        public String SiteName
        {
            get { return _siteName; }
            set { _siteName = value; OnPropertyChanged("SiteName"); }
        }

        private String _siteAddress;
        public String SiteAddress
        {
            get { return _siteAddress; }
            set { _siteAddress = value; OnPropertyChanged("SiteAddress"); }
        }

        private String _siteHeight;
        public String SiteHeight
        {
            get { return _siteHeight; }
            set { _siteHeight = value; OnPropertyChanged("SiteHeight"); }
        }

        private String _siteWidth;
        public String SiteWidth
        {
            get { return _siteWidth; }
            set { _siteWidth = value; OnPropertyChanged("SiteWidth"); }
        }

        private String _siteAmount;
        public String SiteAmount
        {
            get { return _siteAmount; }
            set { _siteAmount = value; OnPropertyChanged("SiteAmount"); }
        }

        private string _actionLable;
        public string ActionLable
        {
            get { return _actionLable; }
            set { _actionLable = value; OnPropertyChanged("Action"); }
        }

        private string _actionButton;
        public string ActionButton
        {
            get { return _actionButton; }
            set { _actionButton = value; OnPropertyChanged("ActionButton"); }
        }

        private string _siteImage;
        public string SiteImage
        {
            get { return _siteImage; }
            set { _siteImage = value; OnPropertyChanged("SiteImage"); }
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
        public AddSiteViewModel(AddSiteView parent, string action, MODEL.SiteModel siteModel)
        {
            db = Database.getInstance();
            this.parent = parent;
            if (siteModel != null)
            {
                this.siteModel = siteModel;
                SiteName = siteModel.SiteName;
                SiteAddress = siteModel.SiteAddress;
                SiteHeight = siteModel.SiteHeight;
                SiteWidth = siteModel.SiteWidth;
                SiteAmount = siteModel.SiteAmount;
                SiteImage = siteModel.SiteImage;
            }
            this.action = action;
            switch (action)
            {
                case "ADD":
                    {
                        ActionLable = "Add New Site";
                        ActionButton = "Add";
                        break;
                    }
                case "MDFY":
                    {
                        ActionLable = "Modify Site";
                        ActionButton = "Modify";
                        break;
                    }
                case "ACTV":
                    {
                        string output = db.db_IactvSite(siteModel, "ACTV");
                        if (output.Equals(Status.SUCC))
                        {
                            parent.close();
                        }
                        break;
                    }
                case "IACT":
                    {
                        string output = db.db_IactvSite(siteModel, "IACT");
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

        #region saveSite Command
        private RelayCommand saveSiteCommand;
        public ICommand SaveSiteCommand
        {
            get
            {
                return saveSiteCommand ?? (saveSiteCommand = new RelayCommand(param => this.saveSite()));
            }
        }
        private void saveSite()
        {
            switch (action)
            {
                case "ADD": { addSite(); break; }
                case "MDFY": { mdfySite(); break; }
            }
        }
        private void addSite()
        {
            if (validation())
            {
                string output = db.db_AddNewSite(_siteName, _siteAddress, _siteHeight, _siteWidth, _siteAmount, _siteImage);
                if (output.Equals(Status.SUCC))
                {
                    StatusString = "Site Added Successfully";
                    ForegroundColor = System.Windows.Media.Brushes.Green;
                }
                else if (output.Equals(Status.ERR))
                {
                    StatusString = "Failed to Add Site";
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

        private void mdfySite()
        {
            if (validation())
            {
                string output = db.db_MdfySite(siteModel, _siteName, _siteAddress, _siteHeight, _siteWidth, _siteAmount, _siteImage);
                if (output.Equals(Status.SUCC))
                {
                    StatusString = "Site Modified Successfully";
                    ForegroundColor = System.Windows.Media.Brushes.Green;
                }
                else if (output.Equals(Status.ERR))
                {
                    StatusString = "Failed to Modify Site";
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
            if (CustomValidation.validateString(_siteName))
            {
                StatusString = "Please Enter Name of Site";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.SiteName.Focus();
                return false;
            }
            if (CustomValidation.validateString(_siteHeight))
            {
                StatusString = "Please Enter Height of Site";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.SiteHeight.Focus();
                return false;
            }
            if (CustomValidation.validateString(_siteWidth))
            {
                StatusString = "Please Enter Width of Site";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.SiteWidth.Focus();
                return false;
            }
            if (CustomValidation.validateString(_siteAmount))
            {
                StatusString = "Please Enter Site Amount";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.SiteAmount.Focus();
                return false;
            }
            if (CustomValidation.validateString(_siteAddress))
            {
                StatusString = "Please Enter Address";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.SiteAddress.Focus();
                return false;
            }
            if (CustomValidation.validateString(_siteImage))
            {
                StatusString = "Please Select Image";
                ForegroundColor = System.Windows.Media.Brushes.Red;
                this.parent.SiteImage.Focus();
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

        #region Upload Image Command
        private RelayCommand uploadImageCommand;
        public ICommand UploadImageCommand
        {
            get
            {
                return uploadImageCommand ?? (uploadImageCommand = new RelayCommand(param => this.UploadImage()));
            }
        }
        private void UploadImage()
        {
            SiteImage = FileOperations.SelectFile();
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
            if ((StatusString.Equals("Site Added Successfully")) || (StatusString.Equals("Site Modified Successfully")))
                parent.Close();

            StatusStringFlag = Visibility.Collapsed;
            StatusString = "";
        }
        #endregion
    }
}
