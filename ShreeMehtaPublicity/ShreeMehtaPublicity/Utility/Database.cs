using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Configuration;

using ShreeMehtaPublicity.MODEL;
using System.Data;

namespace ShreeMehtaPublicity.Utility
{
    public class Database
    {
        private DBOperations dBOpertions;
        private static Database db = new Database();
        private Queries queries;
        
        public static Database getInstance()
        {
            return db;
        }

        private Database()
        {
            queries = new Queries();
            dBOpertions = DBOperations.getInstance(queries);
        }
 
        private int db_GetSeqNo(string seq_id)
        {
            int output = 0;
            
            object[] parameters = { seq_id };
            
            DataTable dt = dBOpertions.SELECT(queries.getSeqNo, parameters);
            if(dt.Rows.Count == 1)
            {
                output = Convert.ToInt32(dt.Rows[0]["SEQ_NUM"]);
            }

            return output;
        }
        
        private string db_updateSeqNo(string seq_id, int seq_num)
        {
            string output = null;
            object[] parameters = { seq_num , seq_id };
            
            int rowsUpdated = dBOpertions.UPDATE(queries.updateSeqNo, parameters);
            if(rowsUpdated == 1)
            {
                output = Status.SUCC;
            }
            else
            {
                output = "Technical Error";
            }

            return output;
        }

        #region Login
        public string db_Login(string loginId, string password)
        {
            string output = null;
/*                    
            cmd.CommandText = "SELECT LOGIN_STATUS FROM LOGIN_DETAILS WHERE LOGIN_ID = '" + loginId + "' AND PASSWORD = '" + password + "'";
            DataTable dt = selectData(cmd);

            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                if(dr["LOGIN_STATUS"].ToString().Equals("IACT"))
                {
                    startTransaction();

                    cmd.CommandText = "UPDATE LOGIN_DETAILS SET LOGIN_STATUS = 'ACTV' WHERE LOGIN_ID = '" + loginId + "' AND PASSWORD = '" + password + "'";
                    int rowUpdated = cmd.ExecuteNonQuery();
                    if(rowUpdated == 1)
                    {
                        output = Status.SUCC;
                    }
                    else
                    {
                        output = "Technical Error";
                    }

                    commitTransaction();
                }
                else if (dr["LOGIN_STATUS"].ToString().Equals("ACTV"))
                {
                    output = "User Already Logged In";
                }
                else
                {
                    output = "Technical Error";
                }
            }
            else if(dt.Rows.Count == 0)
            {
                output = "Invalid Username/Password";
            }
            else
            {
                output = "Technical Error";
            }

            */
            return output;
        }

        public string db_Logout(string loginId)
        {
            string output = null;
            /*
            startTransaction();

            cmd.CommandText = "UPDATE LOGIN_DETAILS SET LOGIN_STATUS = 'IACT' WHERE LOGIN_ID = '"+loginId+"'";
            int rowUpdated = cmd.ExecuteNonQuery();
            if (rowUpdated == 1 || rowUpdated == 0)
            {
                output = Status.SUCC;
            }
            else
            {
                output = "Technical Error";
            }

            commitTransaction();
*/
            return output;
        }
        #endregion

        public ObservableCollection<SiteModel> db_GetAllSites()
        {
            DataTable dt = dBOpertions.SELECT(queries.getAllSites);
            
            ObservableCollection<SiteModel> allSites = new ObservableCollection<SiteModel>(
                dt.AsEnumerable().Select(dr => new SiteModel
                {
                    SiteSeqNum = Convert.ToInt32(dr["SITE_SEQ"]),
                    SiteName = Convert.ToString(dr["SITE_NAME"]),
                    SiteStatus = StaticMaster.convertSiteStatusToString(Convert.ToString(dr["SITE_STATUS"])),
                    SiteAddress = Convert.ToString(dr["SITE_ADDRESS"]),
                    SiteHeight = Convert.ToString(dr["SITE_HEIGHT"]),
                    SiteWidth = Convert.ToString(dr["SITE_WIDTH"]),
                    SiteAmount = Convert.ToString(dr["SITE_AMOUNT"]),
                    SiteImage = Convert.ToString(dr["SITE_IMAGE"])
                }
            ));

            return allSites;
        }

        public ObservableCollection<ClientModel> db_GetAllClients()
        {
            DataTable dt = dBOpertions.SELECT(queries.getAllClients);
            
            ObservableCollection<ClientModel> allClients = new ObservableCollection<ClientModel>(
                dt.AsEnumerable().Select(dr => new ClientModel
                {
                    ClientSeqNum = Convert.ToInt32(dr["CLIENT_SEQ"]),
                    ClientName = Convert.ToString(dr["CLIENT_NAME"]),
                    ClientStatus = StaticMaster.convertClientStatusToString(Convert.ToString(dr["CLIENT_STATUS"])),
                    ClientLandline = Convert.ToString(dr["CLIENT_LANDLINE"]),
                    ClientMobile = Convert.ToString(dr["CLIENT_MOBILE"]),
                    ClientMail = Convert.ToString(dr["CLIENT_MAIL"]),
                    ClientGST = Convert.ToString(dr["CLIENT_GST"]),
                    ClientAddress = Convert.ToString(dr["CLIENT_ADDRESS"]),
                    ClientBranch = Convert.ToString(dr["CLIENT_BRANCH"])
                }
            ));
            
            return allClients;
        }

        #region Order Management
        public ObservableCollection<OrderModel> db_GetOrderList(int client_no, int site_no, double amount, string startDate, string endDate, string status)
        {
            object[] parameters = { site_no, site_no, client_no, client_no, amount, amount, startDate, startDate, endDate, endDate, status, status };

            DataTable dt = dBOpertions.SELECT(queries.getOrderList, parameters);
            
            ObservableCollection<OrderModel> allOrders = new ObservableCollection<OrderModel>(
                dt.AsEnumerable().Select(dr => new OrderModel
                {
                    OrderSeqNum = Convert.ToInt32(dr["ORDR_SEQ_NO"]),
                    OrderTotalAmount = Convert.ToDouble(dr["AMOUNT"]),
                    OrderGeneralAmount = Convert.ToDouble(dr["CHARGES"]),
                    OrderPrintingAmount = Convert.ToDouble(dr["PRINTING"]),
                    OrderMountingAmount = Convert.ToDouble(dr["MOUNTING"]),
                    OrderStartDate = StaticMaster.convertStringToDate(Convert.ToString(dr["START_DATE"])),
                    OrderEndDate = StaticMaster.convertStringToDate(Convert.ToString(dr["END_DATE"])),
                    OrderSite = new SiteModel { SiteSeqNum = Convert.ToInt32(dr["SITE_SEQ_NO"]), 
                                                SiteName = Convert.ToString(dr["SITE_NAME"]),
                                                SiteAddress = Convert.ToString(dr["SITE_ADDRESS"]),
                                                SiteAmount = Convert.ToString(dr["SITE_AMOUNT"]),
                                                SiteHeight = Convert.ToString(dr["SITE_HEIGHT"]),
                                                SiteWidth = Convert.ToString(dr["SITE_WIDTH"]),
                                                SiteStatus = Convert.ToString(dr["SITE_STATUS"])},
                    OrderClient = new ClientModel { ClientSeqNum = Convert.ToInt32(dr["CLIENT_SEQ_NO"]), 
                                                    ClientName = Convert.ToString(dr["CLIENT_NAME"]),
                                                    ClientAddress = Convert.ToString(dr["CLIENT_ADDRESS"]),
                                                    ClientBranch = Convert.ToString(dr["CLIENT_BRANCH"]),
                                                    ClientGST = Convert.ToString(dr["CLIENT_GST"]),
                                                    ClientLandline = Convert.ToString(dr["CLIENT_LANDLINE"]),
                                                    ClientMail = Convert.ToString(dr["CLIENT_MAIL"]),
                                                    ClientMobile = Convert.ToString(dr["CLIENT_MOBILE"]),
                                                    ClientStatus = Convert.ToString(dr["CLIENT_STATUS"])},
                    OrderStatus = StaticMaster.convertOrderStatusToString(Convert.ToString(dr["STATUS"]))
                }
            ));

            return allOrders;
        }
        
        public String db_CheckBookingDates(string StartDate, string EndDate, int Site, int Order)
        {
            string ErrorMsg = null;
            object[] parameters = { Site, StartDate, EndDate, StartDate, EndDate, StartDate, EndDate, Order };

            DataTable dt = dBOpertions.SELECT(queries.checkBookingDates, parameters);
            if (dt.Rows.Count > 0)
                ErrorMsg = "Site is already booked during these days";

            return ErrorMsg;
        }

        public string db_PlaceOrder(int siteSqe, int clientSeq, double charges, double printing, double mounting, string startDate, string endDate, string status)
        {
            string output = null;
           
            int order_seq_no = db_GetSeqNo("ORDER");
            if (order_seq_no == 0)
            {
                output = "Technical Error";
            }
            else
            {
                order_seq_no = order_seq_no + 1;

                object[] parameters = { order_seq_no, siteSqe, clientSeq, charges, printing, mounting, (charges + printing + mounting), startDate, endDate, status, StaticMaster.convertDateToString(DateTime.Today) };

                int rowsInserted = dBOpertions.INSERT(queries.placeOrder, parameters);
                if (rowsInserted == 1)
                {
                    string updateOutput = db_updateSeqNo("ORDER", order_seq_no);
                    if (updateOutput.Equals(Status.SUCC))
                    {
                        output = Status.SUCC;
                    }
                    else
                    {
                        output = updateOutput;
                    }
                }
                else
                {
                    output = "Technical Error";
                }
            }
            
            return output;
        }

        public string db_MdfyOrder(int orderSeqNo, double charges, double printing, double mounting, string startDate, string endDate, string status)
        {
            string output = null;

            object[] parameters = { charges , printing , mounting , (charges + printing + mounting) , startDate , endDate , status , orderSeqNo };
            
            int rowsUpdated = dBOpertions.UPDATE(queries.mdfyOrder, parameters);
            if (rowsUpdated == 1)
            {
                output = Status.SUCC;
            }
            else
            {
                output = "Technical Error";
            }

            return output;
        }

        public string db_CnclOrder(int orderSeqNo)
        {
            string output = null;

            object[] parameters = { orderSeqNo };
            
            int rowsUpdated = dBOpertions.UPDATE(queries.cnclOrder, parameters);
            if (rowsUpdated == 1)
            {
                output = Status.SUCC;
            }
            else
            {
                output = "Technical Error";
            }

            return output;
        }
        #endregion

        #region Site Management
        public ObservableCollection<SiteModel> db_GetSiteList(string StartDate, string EndDate, string SelectedStatus, string Height, string Width, string Amount, string Name, string Address)
        {
            object[] parameters = { SelectedStatus, SelectedStatus, Height, Height, Width, Width, Amount, Amount, Name.Trim().ToLower(), Name, Address.Trim().ToLower(), Address, StartDate, EndDate, StartDate, EndDate, StartDate, EndDate };

            DataTable dt = dBOpertions.SELECT(queries.getSiteList, parameters);

            ObservableCollection<SiteModel> allSites = new ObservableCollection<SiteModel>(
                dt.AsEnumerable().Select(dr => new SiteModel
                {
                    SiteSeqNum = Convert.ToInt32(dr["SITE_SEQ"]),
                    SiteName = Convert.ToString(dr["SITE_NAME"]),
                    SiteStatus = StaticMaster.convertSiteStatusToString(Convert.ToString(dr["SITE_STATUS"])),
                    SiteAddress = Convert.ToString(dr["SITE_ADDRESS"]),
                    SiteAmount = Convert.ToString(dr["SITE_AMOUNT"]),
                    SiteHeight = Convert.ToString(dr["SITE_HEIGHT"]),
                    SiteWidth = Convert.ToString(dr["SITE_WIDTH"]),
                    SiteImage = Convert.ToString(dr["SITE_IMAGE"])
                }
            ));

            return allSites;
        }

        public string db_AddNewSite(string SiteName, string SiteAddress, string SiteHeight, string SiteWidth, string SiteAmount, string SiteImage)
        {
            string output = null;
            int site_seq_no = db_GetSeqNo("SITE");
            if (site_seq_no == 0)
            {
                output = "Technical Error";
            }
            else
            {
                site_seq_no = site_seq_no + 1;
                SiteImage = FileOperations.CopySiteImage(SiteImage, site_seq_no);
                if (CustomValidation.validateString(SiteImage))
                {
                    return "Failure in copying image";
                }
                object[] parameters = { site_seq_no, SiteName, SiteAddress, SiteHeight, SiteWidth, SiteAmount, SiteImage };
                
                int rowsInserted = dBOpertions.INSERT(queries.addNewSite, parameters);
                if (rowsInserted == 1)
                {
                    string updateOutput = db_updateSeqNo("SITE", site_seq_no);
                    if (updateOutput.Equals(Status.SUCC))
                    {
                        output = Status.SUCC;
                    }
                    else
                    {
                        output = updateOutput;
                    }
                }
                else
                {
                    output = "Technical Error";
                }
            }
                        
            return output;
        }

        public string db_MdfySite(SiteModel siteModel, string SiteName, string SiteAddress, string SiteHeight, string SiteWidth, string SiteAmount, string SiteImage)
        {
            string output = null;

            SiteImage = FileOperations.CopySiteImage(SiteImage, siteModel.SiteSeqNum);
            if (CustomValidation.validateString(SiteImage))
            {
                return "Failure in copying image";
            }
            object[] parameters = { SiteName, SiteAddress, SiteHeight, SiteWidth, SiteAmount, SiteImage, siteModel.SiteSeqNum };
            
            int rowsUpdated = dBOpertions.UPDATE(queries.mdfySite, parameters);
            if (rowsUpdated == 1)
            {
                output = Status.SUCC;
            }
            else
            {
                output = "Technical Error";
            }

            return output;
        }

        public string db_IactvSite(SiteModel siteModel, string status)
        {
            string output = null;
            
            object[] parameters = { status, siteModel.SiteSeqNum };

            int rowsUpdated = dBOpertions.UPDATE(queries.iactvSite, parameters);
            if (rowsUpdated == 1)
            {
                output = Status.SUCC;
            }
            else
            {
                output = "Technical Error";
            }

            return output;
        }
        #endregion

        #region Client Management
        public ObservableCollection<ClientModel> db_GetClientList(string SelectedStatus, string Client)
        {
            object[] parameters = { SelectedStatus, SelectedStatus, Client.Trim().ToLower(), Client };

            DataTable dt = dBOpertions.SELECT(queries.getClientList, parameters);

            ObservableCollection<ClientModel> allClients = new ObservableCollection<ClientModel>(
                dt.AsEnumerable().Select(dr => new ClientModel
                {
                    ClientSeqNum = Convert.ToInt32(dr["CLIENT_SEQ"]),
                    ClientName = Convert.ToString(dr["CLIENT_NAME"]),
                    ClientStatus = StaticMaster.convertClientStatusToString(Convert.ToString(dr["CLIENT_STATUS"])),
                    ClientAddress = Convert.ToString(dr["CLIENT_ADDRESS"]),
                    ClientBranch = Convert.ToString(dr["CLIENT_BRANCH"]),
                    ClientLandline = Convert.ToString(dr["CLIENT_LANDLINE"]),
                    ClientMobile = Convert.ToString(dr["CLIENT_MOBILE"]),
                    ClientGST = Convert.ToString(dr["CLIENT_GST"]),
                    ClientMail = Convert.ToString(dr["CLIENT_MAIL"])
                }
            ));

            return allClients;
        }

        public string db_AddNewClient(string ClientName, string ClientAddress, string ClientBranch, string ClientLandline, string ClientMobile, string ClientGST, string ClientMail, ObservableCollection<ContactPersonModel> contactPersonModel)
        {
            string output = null;
            int client_seq_no = db_GetSeqNo("CLIENT");
            if (client_seq_no == 0)
            {
                output = "Technical Error";
            }
            else
            {
                client_seq_no = client_seq_no + 1;

                object[] parameters = { client_seq_no, ClientName, ClientLandline, ClientMobile, ClientMail, ClientAddress, ClientBranch, ClientGST };
                
                int rowsInserted = dBOpertions.INSERT(queries.addNewClient, parameters);
                if (rowsInserted == 1)
                {
                    string updateOutput = db_updateSeqNo("CLIENT", client_seq_no);
                    if (updateOutput.Equals(Status.SUCC))
                    {
                        output = Status.SUCC;
                        if (db_AddContactPerson(contactPersonModel, client_seq_no).Equals(Status.SUCC))
                        {
                            output = Status.SUCC;
                        }
                    }
                    else
                    {
                        output = updateOutput;
                    }
                }
                else
                {
                    output = "Technical Error";
                }
            }
            
            return output;
        }

        public string db_MdfyClient(ClientModel clientModel, string ClientName, string ClientAddress, string ClientBranch, string ClientGST, string ClientLandline, string ClientMobile, string ClientMail, ObservableCollection<ContactPersonModel> contactPersonModel)
        {
            string output = null;
            
            object[] parameters = { ClientName, ClientLandline, ClientMobile, ClientMail, ClientAddress, ClientBranch, ClientGST, clientModel.ClientSeqNum };
            
            int rowsUpdated = dBOpertions.UPDATE(queries.mdfyClient, parameters);
            if (rowsUpdated == 1)
            {
                if (db_AddContactPerson(contactPersonModel, clientModel.ClientSeqNum).Equals(Status.SUCC))
                    output = Status.SUCC;
                else
                    output = "Technical Error";
            }
            else
            {
                output = "Technical Error";
            }

            return output;
        }
        
        private string db_AddContactPerson(ObservableCollection<ContactPersonModel> contactPersonList, int client_id)
        {
            if (contactPersonList != null)
            {
                string output = null;

                object[] parameters_delete = { client_id };

                int rowsDeleted = dBOpertions.DELETE(queries.addContactPerson_delete, parameters_delete);
                if (rowsDeleted >= 0)
                {
                    int contact_seq_no = db_GetSeqNo("CONTACT_PERSON");
                    if (contact_seq_no == 0)
                    {
                        output = "Technical Error";
                    }
                    else
                    {
                        for (int i = 0; i < contactPersonList.Count; i++)
                        {
                            contact_seq_no = contact_seq_no + 1;
                            object[] parameters_insert = { contact_seq_no, client_id, contactPersonList.ElementAt(i).ContactPersonName, contactPersonList.ElementAt(i).ContactPersonMobile, contactPersonList.ElementAt(i).ContactPersonMail };

                            int rowsInserted = dBOpertions.INSERT(queries.addContactPerson_insert, parameters_insert);
                            if (rowsInserted == 1)
                            {
                                continue;
                            }
                            else
                            {
                                output = "Technical Error";
                            }
                        }
                        string updateOutput = db_updateSeqNo("CONTACT_PERSON", contact_seq_no);
                        if (updateOutput.Equals(Status.SUCC))
                        {
                            output = Status.SUCC;
                        }
                        else
                        {
                            output = updateOutput;
                        }
                    }
                }
                else
                {
                    output = "Technical Error";
                }
                return output;
            }
            return Status.SUCC;
        }

        public ObservableCollection<ContactPersonModel> db_GetContactPersonList(int client_id)
        {
            object[] parameters = { client_id };

            DataTable dt = dBOpertions.SELECT(queries.getContactPersonList, parameters);
            
            ObservableCollection<ContactPersonModel> contactPersonList = new ObservableCollection<ContactPersonModel>(
                dt.AsEnumerable().Select(dr => new ContactPersonModel
                {
                    ClientSeqNum = Convert.ToInt32(dr["CLIENT_SEQ_NUM"]),
                    ContactPersonSeqNum = Convert.ToInt32(dr["SEQ_NUM"]),
                    ContactPersonMail = Convert.ToString(dr["CONTACT_PERSON_MAIL"]),
                    ContactPersonMobile = Convert.ToString(dr["CONTACT_PERSON_MOBILE"]),
                    ContactPersonName = Convert.ToString(dr["CONTACT_PERSON_NAME"])
                }
            ));

            
            return contactPersonList;
        }
        
        public string db_IactvClient(ClientModel clientModel, string status)
        {
            string output = null;

            object[] parameters = { status, clientModel.ClientSeqNum };

            int rowsUpdated = dBOpertions.UPDATE(queries.iactvClient, parameters);
            if (rowsUpdated == 1)
            {
                output = Status.SUCC;
            }
            else
            {
                output = "Technical Error";
            }

            return output;
        }
        #endregion

        public ObservableCollection<OrderModel> db_GetTodayEndOrderList(string endDate, string status)
        {
            object[] parameters = { endDate, status };

            DataTable dt = dBOpertions.SELECT(queries.getTodayEndOrderList, parameters);
            
            ObservableCollection<OrderModel> allOrders = new ObservableCollection<OrderModel>(
                dt.AsEnumerable().Select(dr => new OrderModel
                {
                    OrderSeqNum = Convert.ToInt32(dr["ORDR_SEQ_NO"]),
                    OrderTotalAmount = Convert.ToDouble(dr["AMOUNT"]),
                    OrderGeneralAmount = Convert.ToDouble(dr["CHARGES"]),
                    OrderPrintingAmount = Convert.ToDouble(dr["PRINTING"]),
                    OrderMountingAmount = Convert.ToDouble(dr["MOUNTING"]),
                    OrderStartDate = StaticMaster.convertStringToDate(Convert.ToString(dr["START_DATE"])),
                    OrderEndDate = StaticMaster.convertStringToDate(Convert.ToString(dr["END_DATE"])),
                    OrderSite = new SiteModel { SiteSeqNum = Convert.ToInt32(dr["SITE_SEQ_NO"]), SiteName = Convert.ToString(dr["SITE_NAME"]) },
                    OrderClient = new ClientModel { ClientSeqNum = Convert.ToInt32(dr["CLIENT_SEQ_NO"]), ClientName = Convert.ToString(dr["CLIENT_NAME"]) },
                    OrderStatus = StaticMaster.convertOrderStatusToString(Convert.ToString(dr["STATUS"]))
                }
            ));

            return allOrders;
        }

        public ObservableCollection<OrderModel> db_GetTomorrowStartOrderList(string startDate, string status)
        {
            object[] parameters = { startDate, status };

            DataTable dt = dBOpertions.SELECT(queries.getTomorrowStartOrderList, parameters);
            
            ObservableCollection<OrderModel> allOrders = new ObservableCollection<OrderModel>(
                dt.AsEnumerable().Select(dr => new OrderModel
                {
                    OrderSeqNum = Convert.ToInt32(dr["ORDR_SEQ_NO"]),
                    OrderTotalAmount = Convert.ToDouble(dr["AMOUNT"]),
                    OrderGeneralAmount = Convert.ToDouble(dr["CHARGES"]),
                    OrderPrintingAmount = Convert.ToDouble(dr["PRINTING"]),
                    OrderMountingAmount = Convert.ToDouble(dr["MOUNTING"]),
                    OrderStartDate = StaticMaster.convertStringToDate(Convert.ToString(dr["START_DATE"])),
                    OrderEndDate = StaticMaster.convertStringToDate(Convert.ToString(dr["END_DATE"])),
                    OrderSite = new SiteModel { SiteSeqNum = Convert.ToInt32(dr["SITE_SEQ_NO"]), SiteName = Convert.ToString(dr["SITE_NAME"]) },
                    OrderClient = new ClientModel { ClientSeqNum = Convert.ToInt32(dr["CLIENT_SEQ_NO"]), ClientName = Convert.ToString(dr["CLIENT_NAME"]) },
                    OrderStatus = StaticMaster.convertOrderStatusToString(Convert.ToString(dr["STATUS"]))
                }
            ));

            return allOrders;
        }

        public string db_UpdateOrderStatusForToday()
        {
            string output = null;

            object[] parameter_1 = {StaticMaster.convertDateToString(DateTime.Today), StaticMaster.convertDateToString(DateTime.Today)};
            object[] parameter_2 = { StaticMaster.convertDateToString(DateTime.Today) };
            
            int rowsUpdated_1 = dBOpertions.UPDATE(queries.updateOrderStatusForToday_1, parameter_1);
            if (rowsUpdated_1 >= 0)
            {
                int rowsUpdated_2 = dBOpertions.UPDATE(queries.updateOrderStatusForToday_2, parameter_2);
                if (rowsUpdated_2 >= 0)
                {
                    output = Status.SUCC;
                }
                else
                {
                    output = "Technical Error";
                }
            }
            else
            {
                output = "Technical Error";
            }

            return output;            
        }
    }
}
