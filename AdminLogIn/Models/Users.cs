using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdminLogIn.Models
{
    public class User
    {
        [Required]
        public int id { get; set; }
        [Required]

        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string address { get; set;}
        [Required]
        public string city { get; set; }
        [Required]
        public string province { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string phoneNumer { get; set; }
        [Required]
        public int isAdmin { get; set; }



        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Please enter Email")]
        public string Email
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Please enter Password")]
        public string Password
        {
            get;
            set;
        }

    }

   

}