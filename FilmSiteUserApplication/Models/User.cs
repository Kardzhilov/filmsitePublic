using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace filmsite.Models
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<MovieRental> MovieRentals { get; set; }
    }
}