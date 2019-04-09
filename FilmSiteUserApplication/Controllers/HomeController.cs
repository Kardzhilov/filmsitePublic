using filmsite.Models;
using System.Web.Mvc;
using System;
using System.Web.Script.Serialization;
using System.Web.Routing;
using BLL;
using Model.BLL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace filmsite.Controllers
{
    public class HomeController : Controller
    {
        private MoviesLogic _moviesLogic;
        private CustomerUsersLogic _customerUsersLogic;
        private MovieOrdersLogic _movieOrdersLogic;

        public HomeController()
        {
            _moviesLogic = new MoviesLogic();
            _customerUsersLogic = new CustomerUsersLogic();
            _movieOrdersLogic = new MovieOrdersLogic();
        }

        public async Task<ActionResult> Index()
        {
            var allMovies = await _moviesLogic.GetMovies(true);
            
            if (Session["LoggedIn"] == null)
            {
                Session["LoggedIn"] = false;
            }
            else
            {
                ViewBag.LoggedIn = (bool)Session["LoggedIn"];
            }

            var movies = new List<Movie>();

            foreach (var movie in allMovies)
            {
                var newMovie = new Movie()
                {
                    ID = movie.ID,
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

                movies.Add(newMovie);
            };

            return View(movies);
        }

        public ActionResult Search(string searchText)
        {
            var moviesList = new System.Collections.Generic.List<Movie>();

            return RedirectToAction("Index", moviesList);
        }

        [Route("Home/LogInModal")]
        public ActionResult LogInModal()
        {
            return View();
        }

        public ActionResult LogIn(WrapperUserObject userInput)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _customerUsersLogic.AuthenticateCustomer(userInput.UserLoginObject.Email, userInput.UserLoginObject.Password);
                    if(result)
                    {
                        Session["LoggedIn"] = true;
                        Session["Username"] = userInput.UserLoginObject.Email;
                    }
                    else
                    {
                        var errorWrapper = new WrapperUserObject("Incorrect username or password", true);
                        return View("LogInModal", errorWrapper);
                    }
                }
                catch(Exception e)
                {
                    var errorWrapper = new WrapperUserObject(e.ToString(), true);
                    return View("LogInModal", errorWrapper);
                }

                return RedirectToAction("Index");
            }

            return RedirectToAction("LogInModal");
        }

        public ActionResult Register(WrapperUserObject userInput)
        {
            if (ModelState.IsValid)
            {
                var customer = _customerUsersLogic.Get(userInput.UserRegistrationObject.Email);
                if (customer == null)
                {
                    var customerModelBLL = new CustomerModelBLL()
                    {
                        Email = userInput.UserRegistrationObject.Email,
                        Password = userInput.UserRegistrationObject.Password,
                        FirstName = userInput.UserRegistrationObject.FirstName,
                        LastName = userInput.UserRegistrationObject.LastName
                    };

                    var result = _customerUsersLogic.Create(customerModelBLL);

                    if (result)
                    {
                        Session["LoggedIn"] = true;
                        Session["Username"] = userInput.UserRegistrationObject.Email;
                    }
                }
                else
                {
                    var errorWrapper = new WrapperUserObject("Email already in use/Already existing user");
                    return View("LogInModal", errorWrapper);
                }

                return RedirectToAction("Index");
            }

            return RedirectToAction("LogInModal");
        }

        [HttpGet]
        public  JsonResult NewRental(string movieId)
        {
            if ((bool)Session["LoggedIn"] != true)
            {
                // Ingen innlogget bruker; returnerer feil
                return Json("UserError", JsonRequestBehavior.AllowGet);
            }

            try
            {
                string username = (string)Session["Username"];
                var user = _customerUsersLogic.Get(username);

                var movId = Int32.Parse(movieId);
                var movie = _moviesLogic.GetMovie(movId);

                var movieOrderModelBLL = new MovieOrderModelBLL()
                {
                    RentedMovieId = movie.ID,
                    RentalStartTimeStamp = DateTime.Now.ToString("dd-MM-yyyy - HH:mm:ss"),
                    RentalUser = user
                };

                _movieOrdersLogic.Create(movieOrderModelBLL);
            }
            catch(Exception ex)
            {
                return Json("Some error occured", JsonRequestBehavior.AllowGet);
            }

            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserNotLoggedInRedirect()
        {
            var errorWrapper = new WrapperUserObject("You need to log in or register an account in order to use our services");
            return View("LogInModal", errorWrapper);
        }

        public ActionResult Logout()
        {
            Session["LoggedIn"] = false;
            return RedirectToAction("Index");
        }

        //Function for returning movies from the database to a view
        [HttpGet]
        public string GetMovieData(string searchQuery)
        {
            if (searchQuery == null || searchQuery == "")
            {
                var json = "[]";
                return json;
            }
            else {
                var movie = _moviesLogic.GetAllMoviesWithTitleMatchingSearchText(searchQuery);
                var json = new JavaScriptSerializer().Serialize(movie).ToString();
                return json;
            }
        }

        [HttpGet]
        public string GetMovieById(int id)
        {
            var movie = _moviesLogic.GetMovie(id);
            var json = new JavaScriptSerializer().Serialize(movie).ToString();
            return json;
        }
    }
}
