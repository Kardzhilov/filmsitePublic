using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    public class MovieOrderViewModel
    {
        public int ID { get; set; }
        public int RentedMovieId { get; set; }
        public MovieViewModel RentedMovie { get; set; }
        public string RentalStartTimeStamp { get; set; }
        public CustomerModelDAL RentalUser { get; set; }
        public string Email { get; set; }
    }
}
