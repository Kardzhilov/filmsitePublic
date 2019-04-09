using DAL;
using Model;
using Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;

namespace BLL
{
    public class MovieOrdersLogic : IMovieOrdersLogic
    {
        private IMovieOrderDAL MovieOrderDAL { get; set; }

        public MovieOrdersLogic()
        {
            MovieOrderDAL = new MovieOrderDAL();
        }
        public MovieOrdersLogic(IMovieOrderDAL stub)
        {
            MovieOrderDAL = stub;
        }

        //Create movie order
        public bool Create(MovieOrderModelBLL movieOrderModelBLL)
        {
            var movieOrderModelDAL = new MovieOrderModelDAL()
            {
                RentedMovieId = movieOrderModelBLL.RentedMovieId,
                Email = movieOrderModelBLL.RentalUser.Email,
                RentalStartTimeStamp = movieOrderModelBLL.RentalStartTimeStamp
            };

            var result = MovieOrderDAL.Create(movieOrderModelDAL);
            return true;
        }

        //Summary: Update movie order
        public bool Update(MovieOrderModelBLL movieOrderModelBLL)
        {
            var movieOrderModelDAL = new MovieOrderModelDAL()
            {
                RentedMovieId = movieOrderModelBLL.RentedMovieId,
                RentalStartTimeStamp = movieOrderModelBLL.RentalStartTimeStamp
            };

            var result = MovieOrderDAL.Create(movieOrderModelDAL);
            return true;
        }

        //Summary: Delete movie order
        public bool Delete(int movieOrderID)
        {
            var result = MovieOrderDAL.Delete(movieOrderID);
            return result;
        }

        //Summary: Get movie order
        public MovieOrderModelBLL Get(int movieOrderID)
        {
            var result = MovieOrderDAL.Get(movieOrderID);

            if(result == null)
            {
                return null;
            }

            var movieOrderBLL = new MovieOrderModelBLL()
            {
                RentalStartTimeStamp = result.RentalStartTimeStamp,
                RentedMovieId = result.RentedMovieId
            };

            return movieOrderBLL;
        }

        public List<MovieOrderModelBLL> GetUserMovieOrders(string username)
        {
            var movieOrders = MovieOrderDAL.GetUserMovies(username);
            return GetMovieOrdersBLL(movieOrders);
        }

        //Summary: Get all movie orders
        public List<MovieOrderModelBLL> GetAll()
        {
            var result = MovieOrderDAL.GetAll();

            if (result == null)
            {
                return null;
            }

            return GetMovieOrdersBLL(result);
            
        }


        //Summary: Maps list of "MovieOrderModelDAL" objects to "MovieOrderModelBLL" objects.
        public List<MovieOrderModelBLL> GetMovieOrdersBLL(List<MovieOrderModelDAL> movieOrderModelDAL)
        {
            var movieOrderModelBLL = new List<MovieOrderModelBLL>();

            foreach (var movieOrderDAL in movieOrderModelDAL)
            {
                var movieOrderBLL = new MovieOrderModelBLL()
                {
                    ID = movieOrderDAL.ID,
                    RentalStartTimeStamp = movieOrderDAL.RentalStartTimeStamp,
                    RentedMovieId = movieOrderDAL.RentedMovieId
                };

                movieOrderModelBLL.Add(movieOrderBLL);
            }

            return movieOrderModelBLL;
        }

    }
}
