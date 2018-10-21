using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;


using ShreeMehtaPublicity.Utility;
using ShreeMehtaPublicity.MODEL;

namespace ShreeMehtaPublicity.VIEWMODEL
{
    public class TodayTomorrowSiteViewModel : ViewModelBase
    {
        private Database db;

        #region Variable Declaration
        private ObservableCollection<OrderModel> _siteList;
        public ObservableCollection<OrderModel> SiteList
        {
            get
            {
                return _siteList;
            }
            set
            {
                _siteList = value;
                OnPropertyChanged("SiteList");
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
        #endregion

        #region Constructor
        public TodayTomorrowSiteViewModel(string action)
        {
            db = Database.getInstance();
            
            switch(action)
            {
                case "ENDD" :
                    {
                        ActionLable = "Today End Sites";
                        SiteList = new ObservableCollection<OrderModel>(db.db_GetTodayEndOrderList(StaticMaster.convertDateToString(DateTime.Today), "RUNN"));
                        break;
                    }
                case "STRT" :
                    {
                        ActionLable = "Tomorrow Start Sites";
                        SiteList = new ObservableCollection<OrderModel>(db.db_GetTomorrowStartOrderList(StaticMaster.convertDateToString(DateTime.Today.AddDays(1)), "PREE"));
                        break;
                    }
                default :
                    {
                        break;
                    }
            }
        }
        #endregion

        
    }
}
