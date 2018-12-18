using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShreeMehtaPublicity.Utility
{
    public class Queries
    {
        public string getSeqNo = "SELECT SEQ_NUM FROM SEQUENCE_MASTER WHERE SEQ_ID = '?'";
        public string updateSeqNo = "UPDATE SEQUENCE_MASTER SET SEQ_NUM = ? WHERE SEQ_ID = '?'";
        public string getAllSites = "SELECT SITE_SEQ, SITE_NAME, SITE_STATUS, SITE_ADDRESS, SITE_HEIGHT, SITE_WIDTH, SITE_AMOUNT, SITE_IMAGE FROM SITE_MASTER";
        public string getAllClients = "SELECT CLIENT_SEQ, CLIENT_NAME, CLIENT_STATUS, CLIENT_LANDLINE, CLIENT_MOBILE, CLIENT_MAIL, CLIENT_GST, CLIENT_ADDRESS, CLIENT_BRANCH FROM CLIENT_MASTER";
        public string getOrderList = "SELECT o.ORDR_SEQ_NO, o.SITE_SEQ_NO, s.SITE_NAME, s.SITE_STATUS, s.SITE_ADDRESS, s.SITE_HEIGHT, s.SITE_WIDTH, s.SITE_AMOUNT, s.SITE_IMAGE, o.CLIENT_SEQ_NO, c.CLIENT_NAME, c.CLIENT_STATUS, c.CLIENT_LANDLINE, c.CLIENT_MOBILE, c.CLIENT_MAIL, c.CLIENT_GST, c.CLIENT_ADDRESS, c.CLIENT_BRANCH, o.AMOUNT, o.CHARGES, o.PRINTING, o.MOUNTING, o.START_DATE, o.END_DATE, o.STATUS FROM ORDER_MASTER o, SITE_MASTER s, CLIENT_MASTER c WHERE o.SITE_SEQ_NO = s.SITE_SEQ AND o.CLIENT_SEQ_NO = c.CLIENT_SEQ AND (o.SITE_SEQ_NO = ? OR ? = 0) AND (o.CLIENT_SEQ_NO = ? OR ? = 0) AND (o.AMOUNT = ? OR ? = 0) AND (((date(o.START_DATE) >= date('?')) OR (date('?') = date('0001-01-01'))) AND ((date(o.END_DATE) <= date('?')) OR (date('?') = date('0001-01-01')))) AND (o.STATUS = '?' OR '?' = 'ALL') ORDER BY o.STATUS DESC, date(o.END_DATE)";
        public string checkBookingDates = "SELECT * FROM ORDER_MASTER WHERE STATUS IN ('RUNN','PREE') AND SITE_SEQ_NO = ? AND ((date('?') BETWEEN date(START_DATE) AND date(END_DATE)) OR (date('?') BETWEEN date(START_DATE) AND date(END_DATE)) OR (date(START_DATE) BETWEEN date('?') AND date('?')) OR (date(END_DATE) BETWEEN date('?') AND date('?'))) AND ORDR_SEQ_NO != ?";
        public string placeOrder = "INSERT INTO ORDER_MASTER (ORDR_SEQ_NO, SITE_SEQ_NO, CLIENT_SEQ_NO, CHARGES, PRINTING, MOUNTING, AMOUNT, START_DATE, END_DATE, STATUS, PLACE_DATE) VALUES (?,?,?,?,?,?,?,'?','?','?','?')";
        public string mdfyOrder = "UPDATE ORDER_MASTER SET CHARGES = ?, PRINTING = ?, MOUNTING = ?, AMOUNT = ?, START_DATE = '?', END_DATE = '?', STATUS = '?' WHERE ORDR_SEQ_NO = ?";
        public string cnclOrder = "UPDATE ORDER_MASTER SET STATUS = 'CNCL' WHERE ORDR_SEQ_NO = ?";
        public string getSiteList = "SELECT SITE_SEQ, SITE_NAME, SITE_STATUS, SITE_ADDRESS, SITE_HEIGHT, SITE_WIDTH, SITE_AMOUNT, SITE_IMAGE FROM SITE_MASTER WHERE (SITE_STATUS = '?' OR '?' = 'ALL') AND (SITE_HEIGHT = '?' OR '?' = 'ALL') AND (SITE_WIDTH = '?' OR '?' = 'ALL') AND (SITE_AMOUNT = '?' OR '?' = 'ALL') AND (lower(SITE_NAME) like '%?%' OR '?' = 'ALL') AND (lower(SITE_ADDRESS) like '%?%' OR '?' = 'ALL') AND SITE_SEQ NOT IN (SELECT SITE_SEQ_NO FROM ORDER_MASTER WHERE STATUS IN ('RUNN','PREE') AND ((date('?') BETWEEN date(START_DATE) AND date(END_DATE)) OR (date('?') BETWEEN date(START_DATE) AND date(END_DATE)) OR (date(START_DATE) BETWEEN date('?') AND date('?')) OR (date(END_DATE) BETWEEN date('?') AND date('?'))))";
        public string addNewSite = "INSERT INTO SITE_MASTER (SITE_SEQ, SITE_NAME, SITE_ADDRESS, SITE_HEIGHT, SITE_WIDTH, SITE_AMOUNT, SITE_STATUS, SITE_IMAGE) VALUES (?,'?','?','?','?','?','ACTV','?')";
        public string mdfySite = "UPDATE SITE_MASTER SET SITE_NAME = '?', SITE_ADDRESS = '?', SITE_HEIGHT = '?', SITE_WIDTH = '?', SITE_AMOUNT = '?', SITE_IMAGE = '?' WHERE SITE_SEQ = ?";
        public string iactvSite = "UPDATE SITE_MASTER SET SITE_STATUS = '?' WHERE SITE_SEQ = ?";
        public string getClientList = "SELECT CLIENT_SEQ, CLIENT_NAME, CLIENT_STATUS, CLIENT_LANDLINE, CLIENT_MOBILE, CLIENT_MAIL, CLIENT_GST, CLIENT_ADDRESS, CLIENT_BRANCH FROM CLIENT_MASTER WHERE (CLIENT_STATUS = '?' OR '?' = 'ALL') AND (lower(CLIENT_NAME) like '%?%' OR '?' = 'ALL')";
        public string addNewClient = "INSERT INTO CLIENT_MASTER (CLIENT_SEQ, CLIENT_NAME, CLIENT_STATUS, CLIENT_LANDLINE, CLIENT_MOBILE, CLIENT_MAIL, CLIENT_ADDRESS, CLIENT_BRANCH, CLIENT_GST) VALUES (?,'?','ACTV','?','?','?','?','?','?')";
        public string mdfyClient = "UPDATE CLIENT_MASTER SET CLIENT_NAME = '?', CLIENT_LANDLINE = '?', CLIENT_MOBILE = '?', CLIENT_MAIL = '?', CLIENT_ADDRESS = '?', CLIENT_BRANCH = '?', CLIENT_GST = '?' WHERE CLIENT_SEQ = ?";
        public string addContactPerson_delete = "DELETE FROM CONTACT_PERSON WHERE CLIENT_SEQ_NUM = ?";
        public string addContactPerson_insert = "INSERT INTO CONTACT_PERSON (SEQ_NUM, CLIENT_SEQ_NUM, CONTACT_PERSON_NAME, CONTACT_PERSON_MOBILE, CONTACT_PERSON_MAIL) VALUES (?,?,'?','?','?')";
        public string getContactPersonList = "SELECT SEQ_NUM, CLIENT_SEQ_NUM, CONTACT_PERSON_NAME, CONTACT_PERSON_MOBILE, CONTACT_PERSON_MAIL FROM CONTACT_PERSON WHERE CLIENT_SEQ_NUM = ?";
        public string iactvClient = "UPDATE CLIENT_MASTER SET CLIENT_STATUS = '?' WHERE CLIENT_SEQ = ?";
        public string getTodayEndOrderList = "SELECT ORDR_SEQ_NO, SITE_SEQ_NO, (SELECT SITE_NAME FROM SITE_MASTER WHERE SITE_SEQ = SITE_SEQ_NO) SITE_NAME, CLIENT_SEQ_NO, (SELECT CLIENT_NAME FROM CLIENT_MASTER WHERE CLIENT_SEQ = CLIENT_SEQ_NO) CLIENT_NAME, AMOUNT, CHARGES, PRINTING, MOUNTING, START_DATE, END_DATE, STATUS FROM ORDER_MASTER WHERE date(END_DATE) = date('?') AND STATUS = '?' ORDER BY ORDR_SEQ_NO";
        public string getTomorrowStartOrderList = "SELECT ORDR_SEQ_NO, SITE_SEQ_NO, (SELECT SITE_NAME FROM SITE_MASTER WHERE SITE_SEQ = SITE_SEQ_NO) SITE_NAME, CLIENT_SEQ_NO, (SELECT CLIENT_NAME FROM CLIENT_MASTER WHERE CLIENT_SEQ = CLIENT_SEQ_NO) CLIENT_NAME, AMOUNT, CHARGES, PRINTING, MOUNTING, START_DATE, END_DATE, STATUS FROM ORDER_MASTER WHERE date(START_DATE) = date('?') AND STATUS = '?' ORDER BY ORDR_SEQ_NO";
        public string updateOrderStatusForToday_1 = "UPDATE ORDER_MASTER SET STATUS = 'RUNN' WHERE date(START_DATE) <= date('?') AND date(END_DATE) >= date('?') ";
        public string updateOrderStatusForToday_2 = "UPDATE ORDER_MASTER SET STATUS = 'FNSH' WHERE date(END_DATE) < date('?')";
        public string addNewCautation = "INSERT INTO CAUTATION_MASTER (CAUTATION_SEQ_NO, SUBJECT, BODY, CAUTATION_FILE, CAUTATION_SEND_FLAG) VALUES (?,'?','?','?','?')";
        public string updateNewCautation = "UPDATE CAUTATION_MASTER SET SUBJECT = '?', BODY = '?', CAUTATION_FILE = '?', CAUTATION_SEND_FLAG = '?' WHERE CAUTATION_SEQ_NO = ?";
        public string addNewCautationSite = "INSERT INTO CAUTATION_SITE (CAUTATION_SEQ_NO, SITE_SEQ_NO, CAUTATION_SITE_AMOUNT) VALUES (?,?,'?')";
        public string addNewCautationClient = "INSERT INTO CAUTATION_CLIENT (CAUTATION_SEQ_NO, CLIENT_SEQ_NO) VALUES (?,?)";
        public string getCautationDetails = "SELECT CAUTATION_SEQ_NO, SUBJECT, BODY, CAUTATION_FILE, CAUTATION_SEND_FLAG FROM CAUTATION_MASTER WHERE CAUTATION_SEQ_NO = ?";
        public string getCautationSiteDetails = "SELECT SITE_SEQ, SITE_NAME, SITE_STATUS, SITE_ADDRESS, SITE_HEIGHT, SITE_WIDTH, CAUTATION_SITE_AMOUNT, SITE_IMAGE FROM SITE_MASTER, CAUTATION_SITE WHERE SITE_SEQ_NO = SITE_SEQ AND CAUTATION_SEQ_NO = ?";
        public string getCautationClientDetails = "SELECT CLIENT_SEQ, CLIENT_NAME, CLIENT_STATUS, CLIENT_LANDLINE, CLIENT_MOBILE, CLIENT_MAIL, CLIENT_GST, CLIENT_ADDRESS, CLIENT_BRANCH FROM CLIENT_MASTER, CAUTATION_CLIENT WHERE CLIENT_SEQ_NO = CLIENT_SEQ AND CAUTATION_SEQ_NO = ?";
        
        public string buildQuery(string query, params object[] parameters)
        {
            if (parameters.Count() > 0)
            {
                string[] queryBuilder = query.Split('?');
                int i = 0;
                query = queryBuilder[i++];
                foreach (var parameter in parameters)
                {
                    query += parameter + queryBuilder[i++];
                }
                return query;
            }
            return query;
        }
    }

}
