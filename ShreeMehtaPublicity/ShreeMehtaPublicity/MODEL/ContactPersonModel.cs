using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShreeMehtaPublicity.MODEL
{
    public class ContactPersonModel : VIEWMODEL.ViewModelBase
    {
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
                OnPropertyChanged("ClientSeqNum");
            }
        }

        private string _contactPersonName;
        public string ContactPersonName
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

    }
}
