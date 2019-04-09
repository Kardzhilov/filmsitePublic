using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IMovieOrderDAL
    {
        bool Create(MovieOrderModelDAL movieOrder);
        bool Update(MovieOrderModelDAL movieOrder);
        bool Delete(int movieOrderID);
        MovieOrderModelDAL Get(int movieOrderID);
        List<MovieOrderModelDAL> GetAll();
        List<MovieOrderModelDAL> GetUserMovies(string userEmail);
    }
}
