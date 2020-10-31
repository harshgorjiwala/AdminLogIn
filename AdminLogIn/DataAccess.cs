using AdminLogIn.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdminLogIn
{
    public class DataAccess
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnection"].ToString());

        public void AddUser(User userobj)
        {
            try
            {

                con.Open();
                string query = "insert into users (Email, Password) values ('" + userobj.Email + "','" + userobj.Password + "');";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                gridview.DataSource = dt;
                gridview.DataBind();
            }

            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }

            finally 
            {
                con.Close();  
                BindGridview();
            }
            

        }

        public List<User> GetUser()
        {
            List<User> usersList = new List<User>();

            SqlCommand cmd = new SqlCommand("SP_getUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                sd.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    usersList.Add(new User
                    {
                        id = Convert.ToInt32(dr["id"]),
                        firstName = Convert.ToString(dr["FirstName"]),
                        lastName = Convert.ToString(dr["LastName"]),
                        address = Convert.ToString(dr["Address"]),
                        city = Convert.ToString(dr["City"]),
                        province = Convert.ToString(dr["Province"]),
                        country = Convert.ToString(dr["Country"]),
                        phoneNumer = Convert.ToString(dr["PhoneNumber"]),
                        Email = Convert.ToString(dr["Email"]),
                        Password = Convert.ToString(dr["Password"]),
                        isAdmin = Convert.ToInt32(dr["isAdmin"])

                    });
                }
                return usersList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }

        }


    }
}