using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLogIn.Models
{
    public class User : DataObject
    {
        private string email;
        private string password;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}