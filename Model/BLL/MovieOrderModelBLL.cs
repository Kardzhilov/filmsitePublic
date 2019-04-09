using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BLL
{
    public class MovieOrderModelBLL
    {
        public int ID { get; set; }
        public int RentedMovieId { get; set; }
        public MovieModelDAL RentedMovie { get; set; }
        public string RentalStartTimeStamp { get; set; }
        public CustomerModelBLL RentalUser { get; set; }
    }
}
