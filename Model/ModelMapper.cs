using FilmSiteAdministration.Model;
using Model.BLL;
using Model.ViewModels;
using SharedLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// This class will do necessary mappings between models in different layers: MVC, BLL and DAL. 
    /// </summary>
    public static class ModelMapper
    {
        /// <summary>
        /// This method is mapping from CustomerModelBLL To CustomerViewModel
        /// </summary>
        /// <param name="customerModelBLL"></param>
        /// <returns></returns>
        public static CustomerViewModel MapFromCustomerModelBLLToCustomerViewModel(CustomerModelBLL customerModelBLL)
        {
            var customerViewModel = new CustomerViewModel()
            {
                FirstName = customerModelBLL.FirstName,
                LastName = customerModelBLL.LastName,
                Email = customerModelBLL.Email,
                Password = customerModelBLL.Password
            };

            return customerViewModel;
        }

        public static List<CustomerViewModel> MapFromListOfCustomerBLLToCustomerViewModelList(List<CustomerModelBLL> customerModelBLLs)
        {
            var customerViewModelList = new List<CustomerViewModel>();

            foreach (var customerModelBLL in customerModelBLLs) {

                var customerViewModel = new CustomerViewModel()
                {
                    FirstName = customerModelBLL.FirstName,
                    LastName = customerModelBLL.LastName,
                    Email = customerModelBLL.Email,
                    Password = customerModelBLL.Password
                };

                customerViewModelList.Add(customerViewModel);
            }

            return customerViewModelList;
        }

        public static CustomerModelBLL MapFromCustomerModelDALToCustomerModelBLL(CustomerModelDAL customerModelDAL)
        {
            var customerModelBLL = new CustomerModelBLL()
            {
                FirstName = customerModelDAL.FirstName,
                LastName = customerModelDAL.LastName,
                Email = customerModelDAL.Email
            };

            return customerModelBLL;
        }

        //Summary: Maps list of "CustomerModelDAL" objcets to "CustomerModelBLL" objects
        public static List<CustomerModelBLL> MapFromListOfCustomerModelBLLToListOfCustomerModelDAL(List<CustomerModelDAL> customersDAL)
        {
            var customersBLL = new List<CustomerModelBLL>();

            foreach (var customerDAL in customersDAL)
            {
                var customerModelBLL = new CustomerModelBLL()
                {
                    FirstName = customerDAL.FirstName,
                    LastName = customerDAL.LastName,
                    Email = customerDAL.Email
                };

                customersBLL.Add(customerModelBLL);
            }

            return customersBLL;
        }

        public static List<MovieOrderModelBLL> MapFromMovieOrderModelDALToMovieOrderModelBLL(List<MovieOrderModelDAL> movieOrderModelDAL)
        {
            var movieOrderModelBLL = new List<MovieOrderModelBLL>();

            foreach (var movieOrderDAL in movieOrderModelDAL)
            {
                var movieOrderBLL = new MovieOrderModelBLL()
                {
                    RentalStartTimeStamp = movieOrderDAL.RentalStartTimeStamp,
                    RentedMovieId = movieOrderDAL.RentedMovieId
                };

                movieOrderModelBLL.Add(movieOrderBLL);
            }

            return movieOrderModelBLL;
        }

        public static List<MovieOrderModelDAL> MapFromMovieOrderModelBLLToMovieOrderModelDAL(List<MovieOrderModelBLL> movieOrderModelBLL)
        {
            var movieOrderModelDAL = new List<MovieOrderModelDAL>();

            foreach (var movieOrder in movieOrderModelBLL)
            {
                var movieOrderDAL = new MovieOrderModelDAL()
                {
                    RentalStartTimeStamp = movieOrder.RentalStartTimeStamp,
                    RentedMovieId = movieOrder.RentedMovieId
                };

                movieOrderModelDAL.Add(movieOrderDAL);
            }

            return movieOrderModelDAL;
        }

        public static CustomerModelDAL MapFromCustomerModelBLLToCustomerModelDAL(CustomerModelBLL customerModelBLL)
        {
            var customerModelDAL = new CustomerModelDAL()
            {
                Email = customerModelBLL.Email,
                FirstName = customerModelBLL.FirstName,
                LastName = customerModelBLL.LastName
            };

            if(customerModelBLL.Password != null)
            {
                customerModelDAL.Password = PasswordHelperTool.PasswordSHA256Hasher(customerModelBLL.Password);
            }

            if (customerModelDAL.MovieRentals != null) {
                customerModelDAL.MovieRentals = MapFromMovieOrderModelBLLToMovieOrderModelDAL(customerModelBLL.MovieRentals);
            }

            return customerModelDAL;
        }

        public static List<MovieModelBLL> MapFromListOfMovieModelDALToListOfMovieModelBLL(List<MovieModelDAL> movieModelDALList)
        {
            var movieModelBLLList = new List<MovieModelBLL>();

            foreach (var movieModelDAL in movieModelDALList)
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

            return movieModelBLLList;
        }

        public static AdminUserModelBLL MapFromAdminUserViewModelToAdminUserModelBLL(AdminUserLoginViewModel adminUserViewModel)
        {
            var adminUserModelBLL = new AdminUserModelBLL()
            {
                UserName = adminUserViewModel.UserName,
                Password = adminUserViewModel.Password
            };

            return adminUserModelBLL;
        }

        public static List<AdminUserViewModel> MapFromListOfAdminUsersBLLToListOfAdminUsersViewModel(List<AdminUserModelBLL> adminUserModelBLLs)
        {
            var adminUserViewModels = new List<AdminUserViewModel>();

            foreach(var adminUserBLL in adminUserModelBLLs)
            {
                var adminUserViewModel = new AdminUserViewModel()
                {
                    UserName = adminUserBLL.UserName
                };

                adminUserViewModels.Add(adminUserViewModel);
            }

            return adminUserViewModels;
        }

        public static List<AdminUserModelBLL> MapFromListOfAdminUsersDALToListOfAdminUsersBLL(List<AdminUserModelDAL> adminUserModelDALs)
        {
            var adminUserModelBLLs = new List<AdminUserModelBLL>();

            foreach(var adminUserModelDAL in adminUserModelDALs)
            {
                var adminUserModelBLL = new AdminUserModelBLL()
                {
                    UserName = adminUserModelDAL.Username
                };

                adminUserModelBLLs.Add(adminUserModelBLL);
            }

            return adminUserModelBLLs;
        }

        public static AdminUserModelBLL MapFromAdminUsersDALToAdminUsersBLL(AdminUserModelDAL adminUserModelDAL)
        {
            var adminUserModelBLL = new AdminUserModelBLL()
            {
                UserName = adminUserModelDAL.Username
            };

            return adminUserModelBLL;    
        }

        public static MovieViewModel MapFromMovieBLLModelToMovieViewModel(MovieModelBLL movieModelBLL)
        {
            var movieViewModel = new MovieViewModel()
            {
                Id = movieModelBLL.ID,
                Title = movieModelBLL.Title,
                Year = movieModelBLL.Year,
                Rated = movieModelBLL.Rated,
                Runtime = movieModelBLL.Runtime,
                Genre = movieModelBLL.Genre,
                Director = movieModelBLL.Director,
                Plot = movieModelBLL.Plot,
                Poster = movieModelBLL.Poster,
                ImdbRating = movieModelBLL.ImdbRating.ToString(),
                ScreenShot = movieModelBLL.ScreenShot
            };

            return movieViewModel;
        }

        public static List<MovieViewModel> MapFromListOfMovieBllModelToListOfMovieViewModelList(List<MovieModelBLL> BLLMovies)
        {
            var viewModelMovies = new List<MovieViewModel>();

            foreach (var BLLMovie in BLLMovies)
            {
                var bllViewModel = new MovieViewModel()
                {
                    Id = BLLMovie.ID,
                    Title = BLLMovie.Title,
                    Year = BLLMovie.Year,
                    Rated = BLLMovie.Rated,
                    Runtime = BLLMovie.Runtime,
                    Genre = BLLMovie.Genre,
                    Director = BLLMovie.Director,
                    Plot = BLLMovie.Plot,
                    Poster = BLLMovie.Poster,
                    ImdbRating = BLLMovie.ImdbRating.ToString(),
                    ScreenShot = BLLMovie.ScreenShot
                };

                viewModelMovies.Add(bllViewModel);
            }

            return viewModelMovies;
        }

    }
}
