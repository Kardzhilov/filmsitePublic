using DAL.Interface;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSiteAdministration.Test.Stubs
{
    class MovieDALStub : IMovieDAL
    {
        private List<MovieModelDAL> _MovieDB;

        public MovieDALStub()
        {
            _MovieDB = new List<MovieModelDAL>();
        }

        public MovieDALStub(List<MovieModelDAL> movies)
        {
            _MovieDB = movies;
        }

        public bool Create(MovieModelDAL movie)
        {
            _MovieDB.Add(movie);
            return true;
        }

        public bool Update(MovieModelDAL movie)
        {
            var movieFound = _MovieDB.FirstOrDefault(b => b.ID.Equals(movie.ID));

            if (movieFound == null)
            {
                return false;
            }

            _MovieDB.Remove(movieFound);
            _MovieDB.Add(movie);
            return true;
        }

        public bool Delete(int movieID)
        {
            var movieToDelete = _MovieDB.FirstOrDefault(b => b.ID.Equals(movieID));
            if(movieToDelete == null)
            {
                return false;
            }

            _MovieDB.Remove(movieToDelete);
            return true;
        }

        public MovieModelDAL Get(int movieId)
        {
            var movieFound = _MovieDB.FirstOrDefault(b => b.ID.Equals(movieId));

            if (movieFound == null)
            {
                return null;
            }
            else
            {
                return movieFound;
            }
        }

        public async Task<List<MovieModelDAL>> GetAll(bool seedNeeded)
        {
            var allMovies = _MovieDB.ToList();
            return allMovies;
        }

        public List<MovieModelDAL> GetAllMoviesWithTitleMatchingSearchText(string searchText)
        {
            var movies = _MovieDB.Where(m => m.Title.Contains(searchText)).ToList();
            return movies;
        }
    }
}
