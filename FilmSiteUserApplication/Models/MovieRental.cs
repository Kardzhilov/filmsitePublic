using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace filmsite.Models
{
    public class MovieRental
    {
        public int ID { get; set; }
        public int RentedMovieId { get; set; }
        public Movie RentedMovie { get; set; }
        public string RentalStartTimeStamp { get; set; }
        public User RentalUser { get; set; }
        public string Email { get; set; }
    }
}