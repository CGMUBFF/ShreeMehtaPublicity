using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace ShreeMehtaPublicity.Utility
{
    public class DBOperations
    {
        private SQLiteConnection con;
        private SQLiteCommand cmd;
        private SQLiteTransaction transaction;
        private static Queries queries;
        private bool isConnectionOpen = false, isTransactionStart = false;
        private static DBOperations dbOperations = new DBOperations();

        public static DBOperations getInstance(Queries query)
        {
            queries = query;
            return dbOperations;
        }

        private DBOperations()
        {
            //con = new SQLiteConnection("Data Source=C:\\Users\\Mohit Sanghavi\\Documents\\Visual Studio 2013\\Projects\\ShreeMehtaPublicity\\ShreeMehtaPublicity\\ShreeMehtaPublicityDatabase.db;Version=3;New=True;Compress=True;");
            con = new SQLiteConnection("Data Source=D:\\Mohit\\Projects\\Git\\ShreeMehtaPublicity\\ShreeMehtaPublicity\\ShreeMehtaPublicity\\ShreeMehtaPublicityDatabase.db;Version=3;New=True;Compress=True;");

            cmd = con.CreateCommand();
        }

        private void openConnection()
        {
            if (con != null && !isConnectionOpen)
            {
                con.Open();
                isConnectionOpen = true;
                cmd.CommandText = "";
            }
        }

        private void closeConnection()
        {
            if (con != null && isConnectionOpen)
            {
                cmd.CommandText = "";
                con.Close();
                isConnectionOpen = false;
            }
        }

        private void startTransaction()
        {
            if (!isTransactionStart)
            {
                openConnection();
                transaction = con.BeginTransaction();
                isTransactionStart = true;
            }
        }

        private void commitTransaction()
        {
            if (transaction != null)
                transaction.Commit();
            isTransactionStart = false;
            closeConnection();
        }

        private void rollBackTransaction()
        {
            if (transaction != null)
                transaction.Rollback();
            isTransactionStart = false;
            closeConnection();
        }

        public DataTable SELECT(String query, params object[] parameters)
        {
            openConnection();

            cmd.CommandText = "";
            cmd.CommandText = queries.buildQuery(query, parameters);

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];

            closeConnection();

            return dataTable;
        }

        public int UPDATE(String query, params object[] parameters)
        {
            int rowsUpdated = -1;

            startTransaction();

            cmd.CommandText = "";
            cmd.CommandText = queries.buildQuery(query, parameters);
            rowsUpdated = cmd.ExecuteNonQuery();

            commitTransaction();

            return rowsUpdated;
        }

        public int INSERT(String query, params object[] parameters)
        {
            int rowsInserted = -1;

            startTransaction();

            cmd.CommandText = "";
            cmd.CommandText = queries.buildQuery(query, parameters);
            rowsInserted = cmd.ExecuteNonQuery();

            commitTransaction();

            return rowsInserted;
        }

        public int DELETE(String query, params object[] parameters)
        {
            int rowsDeleted = -1;

            startTransaction();

            cmd.CommandText = "";
            cmd.CommandText = queries.buildQuery(query, parameters);
            rowsDeleted = cmd.ExecuteNonQuery();

            commitTransaction();

            return rowsDeleted;
        }
    }
}
