using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Differentiation.DAL
{
    public class DataAccessLayer
    {
        string conStr;
        SqlConnection SqlConnection;
        public DataAccessLayer()
        {
            conStr = ConfigurationManager.ConnectionStrings["University1"].ConnectionString;
            SqlConnection = new SqlConnection(conStr);
        }

        public void Open()
        {
            if (SqlConnection.State == ConnectionState.Closed)
            {
                SqlConnection.Open();
            }
        }

        public void Close()
        {
            if (SqlConnection.State == ConnectionState.Open)
            {
                SqlConnection.Close();
            }
        }
        public DataTable SelectData(string Query)
        {
            SqlCommand sqlcmd = new SqlCommand(Query, SqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcmd);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            Console.WriteLine("no");
            return dataTable;
        }
        //public DataTable SelectData3(string Query)
        //{
        //    SqlCommand sqlcmd = new SqlCommand(Query, SqlConnection);
        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcmd);
        //    DataTable dataTable = new DataTable();
        //    sqlDataAdapter.Fill(dataTable);
        //    return dataTable;
        //}
        public DataTable SelectData2(string query, SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(query, SqlConnection);
            command.Parameters.AddRange(parameters);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public int ExecuteCommand(string Query)
        {
            SqlCommand sqlcmd = new SqlCommand(Query, SqlConnection);
            return sqlcmd.ExecuteNonQuery();
        }

    }
}