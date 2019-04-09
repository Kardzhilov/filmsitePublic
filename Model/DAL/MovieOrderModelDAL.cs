using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MovieOrderModelDAL
    {
        public int ID { get; set; }
        public int RentedMovieId { get; set; }
        public string RentalStartTimeStamp { get; set; }
        public string Email { get; set; }
    }
}
