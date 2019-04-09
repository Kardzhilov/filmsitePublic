using System.Collections.Generic;
using Model;
using Model.BLL;

namespace BLL
{
    public interface IMovieOrdersLogic
    {
        bool Create(MovieOrderModelBLL movieOrderModelBLL);
        bool Delete(int movieOrderID);
        MovieOrderModelBLL Get(int movieOrderID);
        List<MovieOrderModelBLL> GetAll();
        List<MovieOrderModelBLL> GetMovieOrdersBLL(List<MovieOrderModelDAL> movieOrderModelDAL);
        List<MovieOrderModelBLL> GetUserMovieOrders(string username);
        bool Update(MovieOrderModelBLL movieOrderModelBLL);
    }
}