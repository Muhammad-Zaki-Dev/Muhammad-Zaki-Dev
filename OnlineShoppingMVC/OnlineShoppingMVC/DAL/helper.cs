using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace OnlineShoppingMVC.DAL
{
    public class Helper
    {
        public Helper()
        {
        }

        //Insert Update
        public static int ExecuteQuery(string query, SqlParameter[] prm)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            int num = 0;
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = sqlConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = query
            };
            sqlCommand.Parameters.AddRange(prm);
            sqlConnection.Open();
            num = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return num;
        }

        //Random Code generator
        public static string generateRandomCode(int length)
        {
            Random random = new Random();
            string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz1234567890";
            char[] chrArray = new char[length];
            for (int i = 0; i < (int)chrArray.Length; i++)
            {
                chrArray[i] = str[random.Next(str.Length - 1)];
            }
            return new string(chrArray);
        }

        //Get Multiple Tables
        public static DataSet GetDataSet(string query, SqlParameter[] prm)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = sqlConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = query
            };
            sqlCommand.Parameters.AddRange(prm);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return dataSet;
        }

        //Get Single Table 
        public static DataTable GetDataTable(string query, SqlParameter[] prm)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = sqlConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = query
            };
            sqlCommand.Parameters.AddRange(prm);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        //Get Single Table 
        public static DataTable GetDataTable(string query)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = sqlConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = query
            };
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        //Get Latest ID
        public static int OutputExecuteQuery(string query, SqlParameter[] prm)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = sqlConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = query
            };
            sqlCommand.Parameters.AddRange(prm);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return Convert.ToInt32(sqlCommand.Parameters["@NewID"].Value);
        }

        //Plane Query
        public static DataTable query(string query)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = sqlConnection,
                CommandType = CommandType.Text,
                CommandText = query
            };
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }




        //       	<connectionStrings>
        //	<add name = "Connection" connectionString="data source=DESKTOP-22J3NGK;initial catalog=OnlineShopping; Integrated Security=true;" />
        //</connectionStrings>

    }
}