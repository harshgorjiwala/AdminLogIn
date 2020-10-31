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

        private void BindGridview()
        {
            DataTable DT = new DataTable();

            try
            {
                con.Open();
                string query = "select * from users";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(DT);

                if (DT.Rows.Count > 0)
                {
                    gridview.DataSource = DT;
                    gridview.DataBind();
                }
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
            }
        }


    }
}