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
        public String Username { get; set; }
        [Required]
        public String Password { get; set; }
        public String Email { get; set; }
        public int Phone { get; set; }
        public bool isAdmin { get; set; }
    }
}