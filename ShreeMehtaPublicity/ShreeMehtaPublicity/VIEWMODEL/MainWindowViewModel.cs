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

using ShreeMehtaPublicity.VIEW;

namespace ShreeMehtaPublicity.VIEWMODEL
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Database db;

        #region Variable Declaration
        private ObservableCollection<OrderModel> _todayEndSite;
        public ObservableCollection<OrderModel> TodayEndSite
        {
            get
            {
                return _todayEndSite;
            }
            set
            {
                _todayEndSite = value;
                OnPropertyChanged("TodayEndSite");
            }
        }

        private ObservableCollection<OrderModel> _tomorrowStartSite;
        public ObservableCollection<OrderModel> TomorrowStartSite
        {
            get
            {
                return _tomorrowStartSite;
            }
            set
            {
                _tomorrowStartSite = value;
                OnPropertyChanged("TomorrowStartSite");
            }
        }
        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            db = Database.getInstance();
            
            this.Update();
        }
        #endregion

        private void Update()
        {
            string output = db.db_UpdateOrderStatusForToday();
            if (!output.Equals(Status.SUCC)) { }
                //WpfMessageBox.Show("Order Status Updation Failed", Status.ERR);
        }
    }
}
