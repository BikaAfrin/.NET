using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mid.Models
{
    public class LoginDTO
    {
        [Required]
        public String Username { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public String Type { get; set; }
    }
}