using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdminLogIn.Models
{
    public class User : DataAccess
    {
        private string email;
        private string password;

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Please enter Email")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Please enter Password")]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        
    }

   

}