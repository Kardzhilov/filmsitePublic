using BLL;
using Model;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmSiteAdministration.Controllers
{
    public class MoviesOrderAdministrationController : Controller
    {
        private MovieOrdersLogic _movieOrdersLogic;
        private MoviesLogic _moviesLogic;


        public MoviesOrderAdministrationController()
        {
            _movieOrdersLogic = new MovieOrdersLogic();
            _moviesLogic = new MoviesLogic();
        }


        /// <summary>
        /// This controller action returns a view which shows you all the movie orders of a particular user.
        /// </summary>
        [Route("MoviesOrderAdministrationController/Index/{email}")]
        public ActionResult Index(string email)
        {
            var orders = _movieOrdersLogic.GetUserMovieOrders(email);

            var movieOrderViewModels = new List<MovieOrderViewModel>();

            foreach (var entry in orders)
            {
                var movieOrderModal = new MovieOrderViewModel()
                {
                    ID = entry.ID,
                    RentalStartTimeStamp = entry.RentalStartTimeStamp,
                    RentedMovieId = entry.RentedMovieId,
                    Email = email
                };

                var movie = _moviesLogic.GetMovie(entry.RentedMovieId);
                var movieViewModel = ModelMapper.MapFromMovieBLLModelToMovieViewModel(movie);

                movieOrderModal.RentedMovie = movieViewModel;
                movieOrderViewModels.Add(movieOrderModal);
            }

            return View(movieOrderViewModels);
        }

        /// <summary>
        /// This controller action returns a detailed view which shows you specified movie order.
        /// </summary>
        public ActionResult GetMovieOrder(int movieOrderId)
        {
            return View("");
        }

        /// <summary>
        /// Method for deleting an adminUser
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Delete(int movieOrderId)
        {
            if (Session["LoggedIn"] == null || Session["LoggedIn"].Equals(false))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            var result = _movieOrdersLogic.Delete(movieOrderId);

            if (result)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}