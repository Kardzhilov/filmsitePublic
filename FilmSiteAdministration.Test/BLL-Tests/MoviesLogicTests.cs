using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilmSiteAdministration.Test.Stubs;
using Model.BLL;
using Model;
using System.Collections.Generic;

namespace BLL.Tests
{
    [TestClass()]
    public class MoviesLogicTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            //Arrange
            var seedDB = new List<MovieModelDAL>();
            var seed = new MovieModelDAL
            {
                ID = 5050,
                Title = "Movie",
                Year = 2018,
                Rated = "10",
                Runtime = "20 min",
                Genre = "Commedy",
                Director = "Director",
                Plot = "Some Plot",
                Poster = "www.poster.com",
                ImdbRating = 10f,
                ScreenShot = "www.screenshot.com"
            };
            seedDB.Add(seed);
            var controller = new MoviesLogic(new MovieDALStub(seedDB));
            var rightInput = new MovieModelBLL{
                ID = 5050,
                Title = "Movie",
                Year = 2018,
                Rated = "10",
                Runtime = "20 min",
                Genre = "Commedy",
                Director = "Director",
                Plot = "Some Plot",
                Poster = "www.poster.com",
                ImdbRating = 10f,
                ScreenShot = "www.screenshot.com"
            };

            //Act
            var result1 = controller.Create(rightInput);

            //Assert
            Assert.IsTrue(result1);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            //Arrange
            var seedDB = new List<MovieModelDAL>();
            var seed = new MovieModelDAL
            {
                ID = 5050,
                Title = "Movie",
                Year = 2018,
                Rated = "10",
                Runtime = "20 min",
                Genre = "Commedy",
                Director = "Director",
                Plot = "Some Plot",
                Poster = "www.poster.com",
                ImdbRating = 10f,
                ScreenShot = "www.screenshot.com"
            };
            seedDB.Add(seed);
            var controller = new MoviesLogic(new MovieDALStub(seedDB));
            var rightInput = new MovieModelBLL
            {
                ID = 5050,
                Title = "Movie",
                Year = 2018,
                Rated = "10",
                Runtime = "20 min",
                Genre = "Commedy",
                Director = "Director",
                Plot = "Some Plot",
                Poster = "www.poster.com",
                ImdbRating = 10f,
                ScreenShot = "www.screenshot.com"
            };
            var wrongInput = new MovieModelBLL
            {
                ID = -1,
                Title = "",
                Year = -2018,
                Rated = null,
                Runtime = null,
                Genre = null,
                Director = null,
                Plot = null,
                Poster = null,
                ImdbRating = -100f,
                ScreenShot = null
            };

            //Act
            var result1 = controller.Update(rightInput);
            var result2 = controller.Update(wrongInput);

            //Assert
            Assert.IsTrue(result1 && !result2);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //Arrange
            var seedDB = new List<MovieModelDAL>();
            var seed = new MovieModelDAL
            {
                ID = 5050,
                Title = "Movie",
                Year = 2018,
                Rated = "10",
                Runtime = "20 min",
                Genre = "Commedy",
                Director = "Director",
                Plot = "Some Plot",
                Poster = "www.poster.com",
                ImdbRating = 10f,
                ScreenShot = "www.screenshot.com"
            };
            seedDB.Add(seed);
            var controller = new MoviesLogicBLLStub(new MovieDALStub(seedDB));
            var rightInput = 5050;
            var wrongInput = -10;

            //Act
            var result1 = controller.Delete(rightInput);
            var result2 = controller.Delete(wrongInput);

            //Assert
            Assert.IsTrue(result1 && !result2);
        }

        [TestMethod()]
        public void GetMovieTest()
        {
            //Arrange
            var seedDB = new List<MovieModelDAL>();
            var seed = new MovieModelDAL
            {
                ID = 5050,
                Title = "Movie",
                Year = 2018,
                Rated = "10",
                Runtime = "20 min",
                Genre = "Commedy",
                Director = "Director",
                Plot = "Some Plot",
                Poster = "www.poster.com",
                ImdbRating = 10f,
                ScreenShot = "www.screenshot.com"
            };
            seedDB.Add(seed);
            var controller = new MoviesLogic(new MovieDALStub(seedDB));
            var rightInput = 5050;
            var wrongInput = -10;

            //Act
            var result1 = controller.GetMovie(rightInput);
            var result2 = controller.GetMovie(wrongInput);

            //Assert
            Assert.IsNotNull(result1);
            Assert.IsNull(result2);
        }

        [TestMethod()]
        public void GetMoviesTest()
        {
            //Arrange
            var seedDB = new List<MovieModelDAL>();
            var seed = new MovieModelDAL
            {
                ID = 5050,
                Title = "Movie",
                Year = 2018,
                Rated = "10",
                Runtime = "20 min",
                Genre = "Commedy",
                Director = "Director",
                Plot = "Some Plot",
                Poster = "www.poster.com",
                ImdbRating = 10f,
                ScreenShot = "www.screenshot.com"
            };
            seedDB.Add(seed);
            var controller = new MoviesLogic(new MovieDALStub(seedDB));

            //Act
            var result1 = controller.GetMovies(true);

            //Assert
            Assert.IsTrue(result1.Result.Count == 1);
        }

        [TestMethod()]
        public void GetAllMoviesWithTitleMatchingSearchTextTest()
        {
            //Arrange
            var seedDB = new List<MovieModelDAL>();
            var seed = new MovieModelDAL
            {
                ID = 5050,
                Title = "Movie",
                Year = 2018,
                Rated = "10",
                Runtime = "20 min",
                Genre = "Commedy",
                Director = "Director",
                Plot = "Some Plot",
                Poster = "www.poster.com",
                ImdbRating = 10f,
                ScreenShot = "www.screenshot.com"
            };
            seedDB.Add(seed);
            var controller = new MoviesLogic(new MovieDALStub(seedDB));
            var rightInput = "Movie";
            var wrongInput = "Not";
            //Act
            var result1 = controller.GetAllMoviesWithTitleMatchingSearchText(rightInput);
            var result2 = controller.GetAllMoviesWithTitleMatchingSearchText(wrongInput);

            //Assert
            Assert.IsTrue(result1.Count == 1);
            Assert.IsFalse(result2.Count > 0);
        }
    }
}