using BLL;
using filmsite.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace filmsite.Controllers
{
    public class MyMoviesController : Controller
    {
        private MovieOrdersLogic _movieOrdersLogic;
        private MoviesLogic _moviesLogic;

        public MyMoviesController()
        {
            _movieOrdersLogic = new MovieOrdersLogic();
            _moviesLogic = new MoviesLogic();
        }

        public ActionResult Index()
        {
            var username = (string)Session["Username"];

            if (username == null || (bool)Session["LoggedIn"] != true)
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "LogInModal"
                });
            }

            try
            {
                var result = _movieOrdersLogic.GetUserMovieOrders(username);
                var myMovies = new List<MovieRental>();

                foreach(var entry in result)
                {
                    var movieRental = new MovieRental()
                    {
                        RentedMovieId = entry.RentedMovieId
                    };

                    var movie = _moviesLogic.GetMovie(movieRental.RentedMovieId);

                    var newRentedMovie = new Movie()
                    {
                        Title = movie.Title,
                        Year = movie.Year,
                        Rated = movie.Rated,
                        Runtime = movie.Runtime,
                        Genre = movie.Genre,
                        Director = movie.Director,
                        Plot = movie.Plot,
                        Poster = movie.Poster,
                        ImdbRating = movie.ImdbRating,
                        ScreenShot = movie.ScreenShot
                    };

                    movieRental.RentedMovie = newRentedMovie;

                    myMovies.Add(movieRental);
                }

                return View(myMovies);
            }
            catch (Exception)
            {
                return View("ErrorPage");
            }
        }

        public FileResult DownloadFile(string movieTitle)
        {
            string filename = movieTitle + ".mp4";
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "/Content/movie.mp4";
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filename,
                Inline = true,
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(filedata, contentType);
        }

    }
}