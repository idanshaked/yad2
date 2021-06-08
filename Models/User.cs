using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yad2.Models
{
    public class User
    {
        [Key]
        [Required (ErrorMessage = "please enter username")]
        public String Username { get; set; }

        [Required(ErrorMessage = "please enter password")]
        public String Password { get; set; }

        [Required(ErrorMessage = "please enter mail")]
        [EmailAddress (ErrorMessage = "email invalid")]
        public String Email { get; set; }

        [Required(ErrorMessage = "please enter phone number")]
        public int Phone { get; set; }
        public bool isAdmin { get; set; }
    }
}