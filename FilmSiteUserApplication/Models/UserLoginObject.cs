using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace filmsite.Models
{
    public class UserLoginObject
    {
        [Required(ErrorMessage = "This field is required!")]
        [EmailAddress(ErrorMessage = "This is not a valid email adress!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ErrorState { get; set; }
    }
}