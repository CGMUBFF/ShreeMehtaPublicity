using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;

using ShreeMehtaPublicity.VIEW;
using ShreeMehtaPublicity.Utility;

namespace ShreeMehtaPublicity.VIEWMODEL
{
    public class LoginViewModel : ViewModelBase
    {
        private Database db;

        #region Variable Declaration
        private string _loginId;
        public string LoginId
        {
            get {
                return _loginId;
            }
            set {
                _loginId = value;
                OnPropertyChanged("LoginId"); 
            }
        }

        private string _password;
        public string Password
        {
            get {
                return _password;
            }
            set {
                _password = value;
                OnPropertyChanged("Password"); 
            }
        }
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            db = Database.getInstance();
        }
        #endregion

        #region Login Command
        private RelayCommand<Window> loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new RelayCommand<Window>(param => this.Login((Window)param)));
            }
        }
        public void Login(Window loginWindow)
        {
            string output = db.db_Login(_loginId, _password);

            if (output.Equals(Status.SUCC))
            {
                MainWindow mainWindow = new MainWindow(/*LoginId*/);
                mainWindow.Show();

                if (loginWindow != null)
                    loginWindow.Close();
            }
            else
            {
                //WpfMessageBox.Show(output,Status.ERR);
                LoginId = "";
                Password = "";
            }
        }
        #endregion

        #region Cancle Command
        private RelayCommand<Window> cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return cancelCommand ?? (cancelCommand = new RelayCommand<Window>(param => this.CancelLogin((Window)param)));
            }
        }
        private void CancelLogin(Window loginWindow)
        {
            if (loginWindow != null)
                loginWindow.Close(); 
        }
        #endregion
    }
}
