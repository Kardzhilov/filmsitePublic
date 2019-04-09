using System;
using System.Collections.Generic;
using FilmSiteAdministration.Test.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using SharedLogic;

namespace FilmSiteAdministration.Test.DAL_Tests
{

    [TestClass]
    public class MovieOrderDALTest
    {
        //An int to make sure all orders get different ID (usually data framework takes care of this)
        private int _idnr = 1;

        //Seeding movies to use in the tests
        private List<MovieModelDAL> _SeedMovies = new List<MovieModelDAL>
        {
            new MovieModelDAL
            {
                ID = 1,
                Title = "FIRST: the First Movie in This Trilogy",
                Genre = "Comedy",
                Director = "MySelf",
                ImdbRating = 200,
                Plot = "Once upon a time, there was a story",
                Rated = "Old Enough - At least 200 years old",
                Year = 2028
            },
            new MovieModelDAL
            {
                ID = 2,
                Title = "SECOND: the Second Movie in This Trilogy",
                Genre = "Comedy",
                Director = "MySelf",
                ImdbRating = 200,
                Plot = "Once upon a time, there was a story - and that story had a sequel",
                Rated = "Old Enough - But not neccessarily 200 years old",
                Year = 2029
            },
            new MovieModelDAL
            {
                ID = 3,
                Title = "THIRD: Probably the Final Mocvie this trilogy",
                Genre = "Comedy",
                Director = "MySelf",
                ImdbRating = 200,
                Plot = "Once upon a time, there was a story - and now it's soon over",
                Rated = "Old Enough - At least as old as this joke",
                Year = 2030
            }
        };

        //An example movie to use in the tests
        private MovieModelDAL _ExampleMovie = new MovieModelDAL
            {
                ID = 117,
                Title = "MOVIE: the Movie",
                Genre = "Comedy",
                Director = "MySelf",
                ImdbRating = 9000,
                Plot = "This is a movie",
                Rated = "Insert age here...",
                Year = 2018
            };

        //An example user to use in the tests
        private CustomerModelDAL _ExampleUser = new CustomerModelDAL
        {
            Email = "s123456@hioa.no",
            Password = PasswordHelperTool.PasswordSHA256Hasher("password"),
            FirstName = "name",
            LastName = "surname",
            MovieRentals = new List<MovieOrderModelDAL>()
        };

        //A special user used to seed movieorders
        private CustomerModelDAL _SeedUser = new CustomerModelDAL
        {
            Email = "s??????@hioa.no",
            Password = PasswordHelperTool.PasswordSHA256Hasher("********"),
            FirstName = "????",
            LastName = "???????",
            MovieRentals = new List<MovieOrderModelDAL>()
        };

        //A special method used to seed movieorders
        private List<MovieOrderModelDAL> _SeedOrders(List<MovieModelDAL> movies, CustomerModelDAL user)
        {
            var orderList = new List<MovieOrderModelDAL>();
            
            foreach(var movie in movies)
            {
                orderList.Add(new MovieOrderModelDAL
                {
                    ID = _idnr,
                    RentedMovieId = movie.ID,
                    RentalStartTimeStamp = DateTime.Now.ToString(),
                    Email = user.Email
                });
                _idnr++;
            }

            return orderList;
        }

        [TestMethod]
        public void CreateWhenNoExistingOrders_ExpectedResultTrueAreEqual()
        {
            //Arrange
            var DALStub = new MovieOrderDALStub();
            var movieList = new List<MovieModelDAL> { _ExampleMovie };
            var orderList = _SeedOrders(movieList, _ExampleUser);
            var input = orderList[0];

            //Act
            bool test1 = DALStub.Create(input);
            var result = DALStub.Get(1);

            //Assert
            Assert.IsTrue(test1);
            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void Create_WhenMultipleOrdersExists_ExpectedResultTrueAreEqual()
        {
            //Arrange
            var initialOrders = _SeedOrders(_SeedMovies, _SeedUser);
            var DALStub = new MovieOrderDALStub(initialOrders);
            var movieList = new List<MovieModelDAL> { _ExampleMovie };
            var orderList = _SeedOrders(movieList, _ExampleUser);
            var input = orderList[0];
            var expectedResult = new List<MovieOrderModelDAL>
            {
                initialOrders[0],
                initialOrders[1],
                initialOrders[2],
                orderList[0]
            };

            //Act
            bool test1 = DALStub.Create(input);
            var result = DALStub.GetAll();

            //Assert
            Assert.IsTrue(test1);
            Assert.IsTrue(expectedResult.Count == result.Count);
            for(int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].ID, result[i].ID);
                Assert.AreEqual(expectedResult[i].RentedMovieId, result[i].RentedMovieId);
            }
        }

        [TestMethod]
        public void Update_WhenAllOK_ExpectedResultTrueAreEqual()
        {
            //Arrange
            var initialOrders = _SeedOrders(_SeedMovies, _SeedUser);
            var DALStub = new MovieOrderDALStub(initialOrders);
            var input = new MovieOrderModelDAL
            {
                ID = 2,
                RentedMovieId = _ExampleMovie.ID,
                RentalStartTimeStamp = DateTime.Now.ToString(),
                Email = _ExampleUser.Email
            };

            var expectedResult = new List<MovieOrderModelDAL>
            {
                initialOrders[0], initialOrders[2], input
            };

            //Act
            bool test1 = DALStub.Update(input);
            var result = DALStub.GetAll();

            //Assert
            Assert.IsTrue(test1);
            Assert.IsTrue(expectedResult.Count == result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].ID, result[i].ID);
                Assert.AreEqual(expectedResult[i].RentedMovieId, result[i].RentedMovieId);
            }
        }

        [TestMethod]
        public void Update_WhenOrderNotExists_ExpectedResultFalse()
        {
            //Arrange
            var initialOrders = _SeedOrders(_SeedMovies, _SeedUser);
            var DALStub = new MovieOrderDALStub(initialOrders);
            var input = new MovieOrderModelDAL
            {
                ID = 4,
                RentedMovieId = _ExampleMovie.ID,
                RentalStartTimeStamp = DateTime.Now.ToString(),
                Email = _ExampleUser.Email
            };

            //Act
            bool test = DALStub.Update(input);

            //Assert
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void Delete_WhenThreeOrdersExsists_ExpectedResultCount2()
        {
            //Arrange
            var initialOrders = _SeedOrders(_SeedMovies, _SeedUser);
            var DALStub = new MovieOrderDALStub(initialOrders);
            var expectedResult = new List<MovieOrderModelDAL>
            {
                initialOrders[0], initialOrders[2]
            };

            //Act
            bool test1 = DALStub.Delete(2);
            var result = DALStub.GetAll();

            //Assert
            Assert.IsTrue(test1);
            Assert.IsTrue(result.Count == 2);
            for(int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].ID, result[i].ID);
                Assert.AreEqual(expectedResult[i].RentedMovieId, result[i].RentedMovieId);
            }
        }

        [TestMethod]
        public void Delete_WhenOneOrderExsists_ExpectedResultCount0()
        {
            //Arrange
            var movieList = new List<MovieModelDAL> { _ExampleMovie };
            var initialOrders = _SeedOrders(movieList, _SeedUser);
            var DALStub = new MovieOrderDALStub(initialOrders);

            //Act
            bool test1 = DALStub.Delete(1);
            var result = DALStub.GetAll();

            //Assert
            Assert.IsTrue(test1);
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Delete_WhenTargetNotExsists_ExpectedResultFalse()
        {
            //Arrange
            var initialOrders = _SeedOrders(_SeedMovies, _SeedUser);
            var DALStub = new MovieOrderDALStub(initialOrders);

            //Act
            bool test = DALStub.Delete(4);

            //Assert
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void Get_WhenAllOK_ExpectedResultTrueAreEqual()
        {
            //Arrange
            var initialOrders = _SeedOrders(_SeedMovies, _SeedUser);
            var DALStub = new MovieOrderDALStub(initialOrders);
            var expectedResult = initialOrders[1];

            //Act
            var result = DALStub.Get(2);

            //Assert
            Assert.AreEqual(expectedResult.ID, result.ID);
            Assert.AreEqual(expectedResult.RentedMovieId, result.RentedMovieId);
        }

        [TestMethod]
        public void Get_WhenTargetNotExists_ExpectedResultNull()
        {
            //Arrange
            var initialOrders = _SeedOrders(_SeedMovies, _SeedUser);
            var DALStub = new MovieOrderDALStub(initialOrders);

            //Act
            var result = DALStub.Get(4);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAll_WhenAllOK_ExpectedResultAreEqual()
        {
            //Arrange
            var initialOrders = _SeedOrders(_SeedMovies, _SeedUser);
            var DALStub = new MovieOrderDALStub(initialOrders);
            var expectedResult = initialOrders;

            //Act
            var result = DALStub.GetAll();

            //Assert
            Assert.IsTrue(result.Count == 3);
            for(int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].ID, result[i].ID);
                Assert.AreEqual(expectedResult[i].RentedMovieId, result[i].RentedMovieId);
            }
        }

        [TestMethod]
        public void GetUserMovies_WhenAllOK_ExpectedResultAreEqual()
        {
            //Arrange
            var initialOrders = _SeedOrders(_SeedMovies, _SeedUser);
            var userOrders = _SeedOrders(_SeedMovies, _ExampleUser);
            userOrders.ForEach(order => initialOrders.Add(order));
            var DALStub = new MovieOrderDALStub(initialOrders);
            var expectedResult = userOrders;

            //Act
            var result = DALStub.GetUserMovies(_ExampleUser.Email);

            //Assert
            Assert.IsTrue(result.Count == 3);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].ID, result[i].ID);
                Assert.AreEqual(expectedResult[i].RentedMovieId, result[i].RentedMovieId);
            }
        }
    }
}
