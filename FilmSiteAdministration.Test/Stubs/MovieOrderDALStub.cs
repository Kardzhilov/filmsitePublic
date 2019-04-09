using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using Model;

namespace FilmSiteAdministration.Test.Stubs
{
    class MovieOrderDALStub : IMovieOrderDAL
    {
        private List<MovieOrderModelDAL> _MovieOrderDB;

        public MovieOrderDALStub()
        {
            _MovieOrderDB = new List<MovieOrderModelDAL>();
            
        }

        public MovieOrderDALStub(List<MovieOrderModelDAL> orders)
        {
            _MovieOrderDB = orders;
        }

        public bool Create(MovieOrderModelDAL movieOrder)
        {
            _MovieOrderDB.Add(movieOrder);
            return true;
        }

        public bool Update(MovieOrderModelDAL movieOrder)
        {
            var movieOrderFound = _MovieOrderDB.FirstOrDefault(b => b.ID.Equals(movieOrder.ID));

            if (movieOrderFound == null)
            {
                return false;
            }

            _MovieOrderDB.Remove(movieOrderFound);
            _MovieOrderDB.Add(movieOrder);
            return true;
        }

        public bool Delete(int movieOrderID)
        {
            var movieOrderToDelete = _MovieOrderDB.FirstOrDefault(b => b.ID.Equals(movieOrderID));
            if(movieOrderToDelete == null)
            {
                return false;
            }

            _MovieOrderDB.Remove(movieOrderToDelete);
            return true;
        }

        public MovieOrderModelDAL Get(int movieOrderID)
        {
            var movieOrderFound = _MovieOrderDB.FirstOrDefault(b => b.ID.Equals(movieOrderID));

            if (movieOrderFound == null)
            {
                return null;
            }
            else
            {
                return movieOrderFound;
            }
        }

        public List<MovieOrderModelDAL> GetAll()
        {
            var allCustomers = _MovieOrderDB.Select(c => new MovieOrderModelDAL()
            {
                ID = c.ID,
                RentedMovieId = c.RentedMovieId,
                RentalStartTimeStamp = c.RentalStartTimeStamp
            }).ToList();

            return allCustomers;
        }

        public List<MovieOrderModelDAL> GetUserMovies(string userEmail)
        {
            var orderedMovies = _MovieOrderDB.Where(movieRental => movieRental.Email == userEmail).ToList();
            return orderedMovies;
        }
        
    }
}
