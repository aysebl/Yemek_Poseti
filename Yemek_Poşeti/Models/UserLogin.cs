using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Yemek_Poşeti.Models
{
    public class UserLogin
    {
        [Required]
        public String Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Password1 { get; set; }
    }

}