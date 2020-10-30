using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AdminLogIn
{
    public class DataObject
    {
        public DataObject()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

        }
        private string _connectionString;

        public string ConnectionString => _connectionString;
    }
}