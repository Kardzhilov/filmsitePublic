using System.Collections.Generic;
using System.Threading.Tasks;
using Model.BLL;

namespace BLL
{
    public interface IMovieLogic
    {
        bool Create(MovieModelBLL movieModelBLL);
        bool Delete(int movieId);
        List<MovieModelBLL> GetAllMoviesWithTitleMatchingSearchText(string searchQuery);
        MovieModelBLL GetMovie(int movieId);
        Task<List<MovieModelBLL>> GetMovies(bool seedNeeded);
        bool Update(MovieModelBLL movieModelBLL);
    }
}