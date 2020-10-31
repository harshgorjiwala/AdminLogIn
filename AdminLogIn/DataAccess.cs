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
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnection"].ToString());


        public List<Users> GetUser()
        {
            List<Users> usersList = new List<Users>();

            SqlCommand cmd = new SqlCommand("SP_getUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                sd.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    usersList.Add(new Users
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
        public bool AddUsers(Users user)
        {
            SqlCommand cmd = new SqlCommand("SP_Insert_UserInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", user.id);
            cmd.Parameters.AddWithValue("@firstName", user.firstName);
            cmd.Parameters.AddWithValue("@lastName", user.lastName);
            cmd.Parameters.AddWithValue("@address", user.address);
            cmd.Parameters.AddWithValue("@city", user.city);
            cmd.Parameters.AddWithValue("@province", user.province);
            cmd.Parameters.AddWithValue("@country", user.country);
            cmd.Parameters.AddWithValue("@phoneNumer", user.phoneNumer);
            cmd.Parameters.AddWithValue("@isAdmin", user.isAdmin);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool UpdateUsers(Users user)
        {
            SqlCommand cmd = new SqlCommand("SP_Update_UserInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@id", user.id);
            cmd.Parameters.AddWithValue("@firstName", user.firstName);
            cmd.Parameters.AddWithValue("@lastName", user.lastName);
            cmd.Parameters.AddWithValue("@address", user.address);
            cmd.Parameters.AddWithValue("@city", user.city);
            cmd.Parameters.AddWithValue("@province", user.province);
            cmd.Parameters.AddWithValue("@country", user.country);
            cmd.Parameters.AddWithValue("@phoneNumer", user.phoneNumer);
            cmd.Parameters.AddWithValue("@isAdmin", user.isAdmin);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool DeleteUsers(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from UserInfo where Id=" + id, con);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();

            if (result >= 1)
                return true;
            else
                return false;
        }


    }
}