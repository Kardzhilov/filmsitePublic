using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public interface IMoviesDAL
    {
        bool Create(MovieModelDAL movie);
        bool Delete(int movieID);
        MovieModelDAL Get(int movieId);
        Task<List<MovieModelDAL>> GetAll(bool seedNeeded);
        List<MovieModelDAL> GetAllMoviesWithTitleMatchingSearchText(string searchText);
        bool Update(MovieModelDAL movie);
    }
}