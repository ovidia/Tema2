using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BookStore.Models
{
    public class LogInModel
    {
        [Required(ErrorMessage = "Please type your Username")]
        [Display(Name = "User name")]
          public String Username { get; set; }

        [Required(ErrorMessage = "Please type your Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String Password { get; set; }

        [Display(Name = "Remember on this computer")]
        public bool RememberMe { get; set; }
        
    }
}