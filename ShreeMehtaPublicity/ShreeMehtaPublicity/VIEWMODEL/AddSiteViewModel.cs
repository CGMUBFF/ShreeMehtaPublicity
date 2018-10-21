using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;

using ShreeMehtaPublicity.Utility;
using ShreeMehtaPublicity.VIEW;
using ShreeMehtaPublicity.MODEL;

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
            get
            {
                return _siteName;
            }
            set
            {
                _siteName = value;
                OnPropertyChanged("SiteName");
            }
        }

        private String _siteAddress;
        public String SiteAddress
        {
            get
            {
                return _siteAddress;
            }
            set
            {
                _siteAddress = value;
                OnPropertyChanged("SiteAddress");
            }
        }

        private String _siteHeight;
        public String SiteHeight
        {
            get
            {
                return _siteHeight;
            }
            set
            {
                _siteHeight = value;
                OnPropertyChanged("SiteHeight");
            }
        }

        private String _siteWidth;
        public String SiteWidth
        {
            get
            {
                return _siteWidth;
            }
            set
            {
                _siteWidth = value;
                OnPropertyChanged("SiteWidth");
            }
        }

        private String _siteAmount;
        public String SiteAmount
        {
            get
            {
                return _siteAmount;
            }
            set
            {
                _siteAmount = value;
                OnPropertyChanged("SiteAmount");
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
        public AddSiteViewModel(AddSiteView parent, string action, MODEL.SiteModel siteModel)
        {
            db = Database.getInstance();
            this.parent = parent;
            if(siteModel != null)
            { 
                this.siteModel = siteModel;
                SiteName = siteModel.SiteName;
                SiteAddress = siteModel.SiteAddress;
                SiteHeight = siteModel.SiteHeight;
                SiteWidth = siteModel.SiteWidth;
                SiteAmount = siteModel.SiteAmount;
            }
            this.action = action;
            switch(action)
            {
                case "ADD" : 
                {
                    ActionLable = "Add New Site";
                    ActionButton = "Add";
                    break;
                }
                case "MDFY" :
                {
                    ActionLable = "Modify Site";
                    ActionButton = "Modify";
                    break;
                }
                case "ACTV" : 
                {
                    string output = db.db_IactvSite(siteModel, "ACTV");
                    if (output.Equals(Status.SUCC))
                    {
                        parent.close();
                    }
                    break;
                }
                case "IACT" : 
                {
                    string output = db.db_IactvSite(siteModel, "IACT");
                    if (output.Equals(Status.SUCC))
                    {
                        parent.close();
                    }                   
                    break;
                }
                default : 
                {
                    break;
                }
            }
                
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
            switch(action)
            {
                case "ADD": { addSite(); break; }
                case "MDFY": { mdfySite(); break; }
            }
        }
        private void addSite()
        {
            if (SiteName != null && !SiteName.Equals(""))
            {
                string output = db.db_AddNewSite(SiteName, SiteAddress, SiteHeight, SiteWidth, SiteAmount);
                if (output.Equals(Status.SUCC))
                {
                    if (true)
                    {
                        parent.Close();
                    }
                }
            }
            else
            {
                this.parent.SiteName.Focus();
            }
        }

        private void mdfySite()
        {
            if (SiteName != null && !SiteName.Equals("") && siteModel != null)
            {
                string output = db.db_MdfySite(siteModel,SiteName,SiteAddress,SiteHeight,SiteWidth,SiteAmount);
                if (output.Equals(Status.SUCC))
                {
                    if (action.Equals("MDFY"))
                    {
                        if (true)//WpfMessageBox.Show("Site Modified Successfully", Status.SUCC) == MessageBoxResult.OK)
                        {
                            parent.Close();
                        }
                    }
                }
            }
            else
            {
                //WpfMessageBox.Show("Site Name Can not be Empty", Status.ERR);
                this.parent.SiteName.Focus();
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
    }
}
