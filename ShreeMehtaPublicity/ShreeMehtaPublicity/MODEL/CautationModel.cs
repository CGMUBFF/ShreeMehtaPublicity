using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ShreeMehtaPublicity.MODEL
{
    public class CautationModel : VIEWMODEL.ViewModelBase
    {
        private int _cautationSeqNo;
        public int CautationSeqNo
        {
            get { return _cautationSeqNo; }
            set { _cautationSeqNo = value; OnPropertyChanged("CautationSeqNo"); }
        }

        private ObservableCollection<SiteModel> _siteList;
        public ObservableCollection<SiteModel> SiteList
        {
            get
            {
                return _siteList;
            }
            set
            {
                _siteList = value;
                OnPropertyChanged("SiteCautationList");
            }
        }

        private ObservableCollection<ClientModel> _clientList;
        public ObservableCollection<ClientModel> ClientList
        {
            get
            {
                return _clientList;
            }
            set
            {
                _clientList = value;
                OnPropertyChanged("ClientList");
            }
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

        private string _cautationFileName;
        public string CautationFileName
        {
            get { return _cautationFileName; }
            set { _cautationFileName = value; OnPropertyChanged("CautationFileName"); }
        }

        private string _SendFlag;
        public string SendFlag
        {
            get { return _SendFlag; }
            set { _SendFlag = value; OnPropertyChanged("SendFlag"); }
        }
    }
}
