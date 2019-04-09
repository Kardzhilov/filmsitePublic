using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using Model;
using Model.BLL;
using System.Threading;
using DAL.Interface;
using BLL;

namespace FilmSiteAdministration.Test.Stubs
{
    public class MoviesLogicBLLStub : IMovieLogic
    {
        private IMovieDAL MovieDAL;

        public MoviesLogicBLLStub()
        {
            MovieDAL = new MoviesDAL();
        }

        public MoviesLogicBLLStub(IMovieDAL stub)
        {
            MovieDAL = stub;
        }
        //Summary: Create a movie
        public bool Create(MovieModelBLL movieModelBLL)
        {

            var movieModelDAL = new MovieModelDAL()
            {
                Director = movieModelBLL.Director,
                Genre = movieModelBLL.Genre,
                ImdbRating = movieModelBLL.ImdbRating,
                Title = movieModelBLL.Title,
                Year = movieModelBLL.Year,
                Rated = movieModelBLL.Rated,
                Runtime = movieModelBLL.Runtime,
                Plot = movieModelBLL.Plot,
                Poster = movieModelBLL.Poster,
                ScreenShot = movieModelBLL.ScreenShot
            };

            var result = MovieDAL.Create(movieModelDAL);
            return result;
        }

        //Summary: Update a movie
        public bool Update(MovieModelBLL movieModelBLL)
        {
            var movieModelDAL = new MovieModelDAL()
            {
                ID = movieModelBLL.ID,
                Director = movieModelBLL.Director,
                Genre = movieModelBLL.Genre,
                ImdbRating = movieModelBLL.ImdbRating,
                Title = movieModelBLL.Title,
                Year = movieModelBLL.Year,
                Rated = movieModelBLL.Rated,
                Runtime = movieModelBLL.Runtime,
                Plot = movieModelBLL.Plot,
                Poster = movieModelBLL.Poster,
                ScreenShot = movieModelBLL.ScreenShot
            };

            var result = MovieDAL.Update(movieModelDAL);
            return result;
        }

        //Summary: Delete a movie
        public bool Delete(int movieId)
        {
            var resultMovie = MovieDAL.Delete(movieId);

            if (!resultMovie) { return false; }
            
            return (true);
        }

        //Summary: Get a movie
        public MovieModelBLL GetMovie(int movieId)
        {
            var result = MovieDAL.Get(movieId);

            if (result == null)
            {
                return null;
            }

            var movieModelBLL = new MovieModelBLL()
            {
                ID = result.ID,
                Director = result.Director,
                Genre = result.Genre,
                ImdbRating = result.ImdbRating,
                Title = result.Title,
                Year = result.Year,
                Rated = result.Rated,
                Runtime = result.Runtime,
                Plot = result.Plot,
                Poster = result.Poster,
                ScreenShot = result.ScreenShot
            };

            return movieModelBLL;
        }

        public async Task<List<MovieModelBLL>> GetMovies(bool seedNeeded)
        {
            var result = await MovieDAL.GetAll(seedNeeded);

            //Retry logic, because result can never be null when we seed it with data.
            if (result == null)
            {
                Thread.Sleep(5000);
                result = await MovieDAL.GetAll(seedNeeded);
            }

            var movieModelBLLList = new List<MovieModelBLL>();

            if (result != null)
            {
                foreach (var movieModelDAL in result)
                {
                    var movieModelBLL = new MovieModelBLL()
                    {
                        ID = movieModelDAL.ID,
                        Director = movieModelDAL.Director,
                        Genre = movieModelDAL.Genre,
                        ImdbRating = movieModelDAL.ImdbRating,
                        Title = movieModelDAL.Title,
                        Year = movieModelDAL.Year,
                        Rated = movieModelDAL.Rated,
                        Runtime = movieModelDAL.Runtime,
                        Plot = movieModelDAL.Plot,
                        Poster = movieModelDAL.Poster,
                        ScreenShot = movieModelDAL.ScreenShot
                    };

                    movieModelBLLList.Add(movieModelBLL);
                };
            }

            return movieModelBLLList;
        }

        public List<MovieModelBLL> GetAllMoviesWithTitleMatchingSearchText(string searchQuery)
        {
            var movies = MovieDAL.GetAllMoviesWithTitleMatchingSearchText(searchQuery);
            if (movies != null)
            {
                return ModelMapper.MapFromListOfMovieModelDALToListOfMovieModelBLL(movies);
            }

            return new List<MovieModelBLL>();
        }
    }
}
