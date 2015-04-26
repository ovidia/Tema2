using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "You need to insert First Name")]
        public String FirstName { get; set; }

           [Required(ErrorMessage = "You need to insert Last Name")]
        public String LastName { get; set; }

           [Required(ErrorMessage = "You need to insert the Username")]
        public String UserName { get; set; }

           [Required(ErrorMessage = "You need to insert the Password")]
        public String Password { get; set; }

           [Required(ErrorMessage = "You need to insert the rol of the user")]
        public String RoleName { get; set; }
    }
}