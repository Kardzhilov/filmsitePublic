using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface;

namespace DAL
{
    //This DAL class is for administrating customers
    public class MovieOrderDAL : IMovieOrderDAL
    {
        public bool Create(MovieOrderModelDAL movieOrder)
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    DBConnection.MovieOrders.Add(movieOrder);
                    DBConnection.SaveChanges();
                    Loggings.GeneralLog("Created Movie Order with ID: " + movieOrder.ID);
                    return true;
                }
            }
            catch (Exception ex)
            {
                var logg = new LoggTypeDAL()
                {
                    EventType = "Exception",
                    Created_By = "System",
                    LogMessage = ex.ToString(),
                    Created_date = DateTime.Now
                };
                Loggings.LogToBoth(logg);
                return false;
            }
        }

        public bool Update(MovieOrderModelDAL movieOrder)
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    var movieOrderFound = DBConnection.MovieOrders.Find(movieOrder.ID);

                    if (movieOrderFound == null)
                    {
                        Loggings.GeneralLog("Could not find Movie Order with ID: " + movieOrder.ID);
                        return false;
                    }

                    movieOrderFound.RentalStartTimeStamp = movieOrder.RentalStartTimeStamp;
                    movieOrderFound.RentedMovieId = movieOrder.RentedMovieId;
                    DBConnection.SaveChanges();

                    Loggings.GeneralLog("Updated Movie Order with ID: " + movieOrder.ID);
                    return true;
                }
            }
            catch (Exception ex)
            {
                var logg = new LoggTypeDAL()
                {
                    EventType = "Exception",
                    Created_By = "System",
                    LogMessage = ex.ToString(),
                    Created_date = DateTime.Now
                };
                Loggings.LogToBoth(logg);
                return false;
            }
        }

        public bool Delete(int movieOrderID)
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    var movieOrderToDelete = DBConnection.MovieOrders.Find(movieOrderID);
                    DBConnection.MovieOrders.Remove(movieOrderToDelete);
                    DBConnection.SaveChanges();

                    Loggings.GeneralLog("Deleted Movie Order with ID: " + movieOrderID);
                    return true;
                }
            }
            catch (Exception ex)
            {
                var logg = new LoggTypeDAL()
                {
                    EventType = "Exception",
                    Created_By = "System",
                    LogMessage = ex.ToString(),
                    Created_date = DateTime.Now
                };
                Loggings.LogToBoth(logg);
                return false;
            }
        }

        public MovieOrderModelDAL Get(int movieOrderID)
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    var movieOrderFound = DBConnection.MovieOrders.Find(movieOrderID);

                    if (movieOrderFound == null)
                    {

                        Loggings.GeneralLog("Could not find Movie Order with ID: " + movieOrderID);
                        return null;
                    }
                    else
                    {

                        Loggings.GeneralLog("Found Movie Order with ID: " + movieOrderID);
                        return movieOrderFound;
                    }

                }
            }
            catch (Exception ex)
            {
                var logg = new LoggTypeDAL()
                {
                    EventType = "Exception",
                    Created_By = "System",
                    LogMessage = ex.ToString(),
                    Created_date = DateTime.Now
                };
                Loggings.LogToBoth(logg);
                return null;
            }
        }

        public List<MovieOrderModelDAL> GetAll()
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    var allOrders = DBConnection.MovieOrders.ToList();

                    return allOrders;
                }
            }
            catch (Exception ex)
            {
                var logg = new LoggTypeDAL()
                {
                    EventType = "Exception",
                    Created_By = "System",
                    LogMessage = ex.ToString(),
                    Created_date = DateTime.Now
                };
                Loggings.LogToBoth(logg);
                return null;
            }
        }

        public List<MovieOrderModelDAL> GetUserMovies(string userEmail)
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    var orderedMovies = DBConnection.MovieOrders.Where(movieRental => movieRental.Email == userEmail).ToList();
                    return orderedMovies;
                }
            }
            catch (Exception ex)
            {
                var logg = new LoggTypeDAL()
                {
                    EventType = "Exception",
                    Created_By = "System",
                    LogMessage = ex.ToString(),
                    Created_date = DateTime.Now
                };
                Loggings.LogToBoth(logg);
                return null;
            }
        }
    }
}
