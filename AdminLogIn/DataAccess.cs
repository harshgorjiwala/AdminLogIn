using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdminLogIn
{
    public class DataAccess
    {
        public DataAccess()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

        }
        private string _connectionString;

        public string ConnectionString => _connectionString;

        SqlConnection con = new SqlConnection(ConnectionString);
        public int AddUser(DataAccess ObjBO)
        {
            try
            {
                string query = "insert into Users (Email, Password) values ('" + ObjBO.Email + "','" + ObjBO.Password + "');";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int Result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                return Result;
            }
            catch
            {
                throw;
            }
        }
    }
}