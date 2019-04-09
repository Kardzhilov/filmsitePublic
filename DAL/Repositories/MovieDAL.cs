using DAL.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    //This DAL class is for administrating Movies
    public class MoviesDAL : IMovieDAL
    {
        public bool Create(MovieModelDAL movie)
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    DBConnection.Movies.Add(movie);
                    DBConnection.SaveChanges();
                    Loggings.GeneralLog("Created Movie with ID: " + movie.ID);
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

        public bool Update(MovieModelDAL movie)
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    var movieFound = DBConnection.Movies.Find(movie.ID);

                    if (movieFound == null)
                    {
                        Loggings.GeneralLog("Could not find Movie with ID: " + movie.ID);
                        return false;
                    }

                    movieFound.Title = movie.Title;
                    movieFound.Year = movie.Year;
                    movieFound.Rated = movie.Rated;
                    movieFound.Runtime = movie.Runtime;
                    movieFound.Genre = movie.Genre;
                    movieFound.Director = movie.Director;
                    movieFound.Plot = movie.Plot;
                    movieFound.Poster = movie.Poster;
                    movieFound.ImdbRating = movie.ImdbRating;
                    movieFound.ScreenShot = movie.ScreenShot;
                    DBConnection.SaveChanges();
                    Loggings.GeneralLog("Updated Movie with ID: " + movie.ID);
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

        public bool Delete(int movieID)
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    var movieToDelete = DBConnection.Movies.Find(movieID);
                    DBConnection.Movies.Remove(movieToDelete);
                    DBConnection.SaveChanges();
                    Loggings.GeneralLog("Deleted Movie with ID: " + movieID);
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

        public MovieModelDAL Get(int movieId)
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    var movieFound = DBConnection.Movies.Find(movieId);

                    if (movieFound == null)
                    {
                        Loggings.GeneralLog("Could not find Movie with ID: " + movieId);
                        return null;
                    }
                    else
                    {
                        Loggings.GeneralLog("Found Movie with ID: " + movieId);
                        return movieFound;
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

        public async Task<List<MovieModelDAL>> GetAll(bool seedNeeded)
        {
            try
            {
                using (var DBConnection = new DB(seedNeeded))
                {
                    var allMovies = DBConnection.Movies.ToList();
                    return allMovies;
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

        public List<MovieModelDAL> GetAllMoviesWithTitleMatchingSearchText(string searchText)
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    var movies = DBConnection.Movies.Where(m => m.Title.Contains(searchText)).ToList();
                    return movies;
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
