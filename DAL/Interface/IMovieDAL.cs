using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IMovieDAL
    {
        bool Create(MovieModelDAL movie);
        bool Update(MovieModelDAL movie);
        bool Delete(int movieID);
        MovieModelDAL Get(int movieId);
        Task<List<MovieModelDAL>> GetAll(bool seedNeeded);
        List<MovieModelDAL> GetAllMoviesWithTitleMatchingSearchText(string searchText);
    }
}
