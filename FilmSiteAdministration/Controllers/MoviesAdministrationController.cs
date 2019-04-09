using BLL;
using Model;
using Model.BLL;
using Model.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FilmSiteAdministration.Controllers
{
    public class MoviesAdministrationController : Controller
    {
        /// <summary>
        /// List of global objects
        /// </summary>
        private MoviesLogic _moviesLogic;

        /// <summary>
        /// Constructor to intialize objects.
        /// </summary>
        public MoviesAdministrationController()
        {
            _moviesLogic = new MoviesLogic();
        }

        /// <summary>
        /// This controller action returns a view which shows you all the movies.
        /// </summary>
        public async Task<ActionResult> Index(string message)
        {
            if (Session["LoggedIn"] == null || Session["LoggedIn"].Equals(false))
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }

            ViewBag.Message = message;

            var movies = await _moviesLogic.GetMovies(false);
            var mappedMovies = ModelMapper.MapFromListOfMovieBllModelToListOfMovieViewModelList(movies);

            var moviesListWrapperObject = new MoviesListWrapperViewModel()
            {
                Movies = mappedMovies,
                SearchText = ""
            };

            return View(moviesListWrapperObject);
        }

        [Route("MoviesAdministration/Search/{searchText}")]
        public ActionResult Search(string searchText)
        {
            if (Session["LoggedIn"] == null || Session["LoggedIn"].Equals(false))
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }

            var movies = _moviesLogic.GetAllMoviesWithTitleMatchingSearchText(searchText);
            var mappedMovies = ModelMapper.MapFromListOfMovieBllModelToListOfMovieViewModelList(movies);

            var moviesListWrapperObject = new MoviesListWrapperViewModel()
            {
                Movies = mappedMovies,
                SearchText = ""
            };
            return View("Index", moviesListWrapperObject);
        }


        /// <summary>
        /// This controller action returns a view which make it possible to edit or create a new movie
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [Route("MoviesAdministration/EditOrCreateMovie/{movieId}")]
        public ActionResult EditOrCreateMovie(int movieId = 0)
        {
            if (Session["LoggedIn"] == null || Session["LoggedIn"].Equals(false))
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }

            if (movieId == 0)
            {
                return View(new MovieViewModel());
            }

            var movie = _moviesLogic.GetMovie(movieId);
            if (movie != null)
            {
                var movieViewModel = ModelMapper.MapFromMovieBLLModelToMovieViewModel(movie);
                return View(movieViewModel);
            }
            else
            {
                return View(new MovieViewModel());
            }
        }

        /// <summary>
        /// This controller action returns a detailed view which shows you the specified movie.
        /// </summary>
        public ActionResult GetMovie(int movieId)
        {

            if (Session["LoggedIn"] == null || Session["LoggedIn"].Equals(false))
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }

            var movie = _moviesLogic.GetMovie(movieId);
            var bllViewModel = new MovieViewModel()
            {
                Id = movie.ID,
                Title = movie.Title,
                Year = movie.Year,
                Rated = movie.Rated,
                Runtime = movie.Runtime,
                Genre = movie.Genre,
                Director = movie.Director,
                Plot = movie.Plot,
                Poster = movie.Poster,
                ImdbRating = movie.ImdbRating.ToString(),
                ScreenShot = movie.ScreenShot
            };

            return View(movie);
        }



        /// <summary>
        /// Method for creating a movie
        /// </summary>
        /// <param name="movieViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostMovie(MovieViewModel movieViewModel)
        {
            if (Session["LoggedIn"] == null || Session["LoggedIn"].Equals(false))
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }

            var movieModelBLL = new MovieModelBLL()
            {
                Title = movieViewModel.Title,
                Year = movieViewModel.Year,
                Rated = movieViewModel.Rated,
                Runtime = movieViewModel.Runtime,
                Genre = movieViewModel.Genre,
                Director = movieViewModel.Director,
                Plot = movieViewModel.Plot,
                Poster = movieViewModel.Poster,
                ImdbRating = float.Parse(movieViewModel.ImdbRating),
                ScreenShot = movieViewModel.ScreenShot
            };

            var result = _moviesLogic.Create(movieModelBLL);
            if (result)
            {
                TempData["SuccessMessage"] = "Movie created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Could not save movie";
                return RedirectToAction("EditOrCreateMovie");
            }
        }


        /// <summary>
        /// Method for updating a movie
        /// </summary>
        /// <param name="movieViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PutMovie(MovieViewModel movieViewModel)
        {
            if (Session["LoggedIn"] == null || Session["LoggedIn"].Equals(false))
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }

            var movieModelBLL = new MovieModelBLL()
            {
                ID = movieViewModel.Id,
                Title = movieViewModel.Title,
                Year = movieViewModel.Year,
                Rated = movieViewModel.Rated,
                Runtime = movieViewModel.Runtime,
                Genre = movieViewModel.Genre,
                Director = movieViewModel.Director,
                Plot = movieViewModel.Plot,
                Poster = movieViewModel.Poster,
                ImdbRating = float.Parse(movieViewModel.ImdbRating),
                ScreenShot = movieViewModel.ScreenShot
            };

            var result = _moviesLogic.Update(movieModelBLL);
            if (result)
            {
                TempData["SuccessMessage"] = "Movie created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Could not save movie";
                return RedirectToAction("EditOrCreateMovie", movieViewModel.Id);
            }
        }

        /// <summary>
        /// Method for deleting a movie
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult DeleteMovie(int movieId)
        {
            if (Session["LoggedIn"] == null || Session["LoggedIn"].Equals(false))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            var result = _moviesLogic.Delete(movieId);

            if(result)
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