using System.Collections.Generic;
using System.Threading.Tasks;
using FilmSiteAdministration.Test.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace FilmSiteAdministration.Test.DAL_Tests
{
    [TestClass]
    public class MovieDALTest
    {
        private List<MovieModelDAL> _Seed = new List<MovieModelDAL>
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

        [TestMethod]
        public void Create_WhenNoExistingMovies_ExpectedResultTrueAreEqual()
        {
            //Arrange
            var DALStub = new MovieDALStub();
            var input = new MovieModelDAL
            {
                ID = 4,
                Title = "MOVIE: the Movie",
                Genre = "Comedy",
                Director = "MySelf",
                ImdbRating = 9000,
                Plot = "This is a movie",
                Rated = "Insert age here...",
                Year = 2018
            };

            //Act
            bool test1 = DALStub.Create(input);
            var result = DALStub.Get(4);

            //Assert
            Assert.IsTrue(test1);
            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public async Task Create_WhenOtherMoviesExist_ExpectedResultTrueAreEqual()
        {
            //Arrange
            var DALStub = new MovieDALStub(_Seed);
            var input = new MovieModelDAL
            {
                ID = 4,
                Title = "MOVIE: the Movie",
                Genre = "Comedy",
                Director = "MySelf",
                ImdbRating = 9000,
                Plot = "This is a movie",
                Rated = "Insert age here...",
                Year = 2018
            };

            var expectedResult = new List<MovieModelDAL>(_Seed);
            expectedResult.Add(input);

            //Act
            bool test1 = DALStub.Create(input);
            var result = await DALStub.GetAll(false);

            //Assert
            Assert.IsTrue(test1);
            Assert.IsTrue(expectedResult.Count == result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].ID, result[i].ID);
                Assert.AreEqual(expectedResult[i].Title, result[i].Title);
            }
        }

        [TestMethod]
        public async Task Update_WhenAllOK_ExpectedResultTrueAreEqual()
        {
            //Arrange
            var DALStub = new MovieDALStub(_Seed);

            var input = new MovieModelDAL
            {
                ID = 2,
                Title = "MOVIE: the Movie",
                Genre = "Comedy",
                Director = "MySelf",
                ImdbRating = 9000,
                Plot = "This is a movie",
                Rated = "Insert age here...",
                Year = 2018
            };

            var expectedResult = new List<MovieModelDAL>
            {
                _Seed[0], _Seed[2], input
            };

            //Act
            bool test1 = DALStub.Update(input);
            var result = await DALStub.GetAll(false);

            //Assert
            Assert.IsTrue(test1);
            Assert.IsTrue(expectedResult.Count == result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }
        }

        [TestMethod]
        public void Update_WhenMovieNotExists_ExpectedResultFalse()
        {
            //Arrange
            var DALStub = new MovieDALStub(_Seed);

            var input = new MovieModelDAL
            {
                ID = 4,
                Title = "MOVIE: the Movie",
                Genre = "Comedy",
                Director = "MySelf",
                ImdbRating = 9000,
                Plot = "This is a movie",
                Rated = "Insert age here...",
                Year = 2018
            };

            //Act
            bool test = DALStub.Update(input);

            //Assert
            Assert.IsFalse(test);
        }

        [TestMethod]
        public async Task Delete_WhenThreeMoviesExists_ExpectedResultCount2()
        {
            //Arrange
            var DALStub = new MovieDALStub(_Seed);

            var expectedResult = new List<MovieModelDAL>
            {
                _Seed[0], _Seed[2]
            };

            //Act
            bool test1 = DALStub.Delete(2);
            var result = await DALStub.GetAll(false);

            //Assert
            Assert.IsTrue(test1);
            Assert.IsTrue(result.Count == 2);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].ID, result[i].ID);
                Assert.AreEqual(expectedResult[i].Title, result[i].Title);
            }
        }

        [TestMethod]
        public async Task Delete_WhenOneMovieExists_ExpectedResultCount0()
        {
            //Arrange
            var input = new MovieModelDAL
            {
                ID = 1,
                Title = "MOVIE: the Movie",
                Genre = "Comedy",
                Director = "MySelf",
                ImdbRating = 9000,
                Plot = "This is a movie",
                Rated = "Insert age here...",
                Year = 2018
            };
            var initialMovies = new List<MovieModelDAL> { input };

            var DALStub = new MovieDALStub(initialMovies);

            //Act
            bool test1 = DALStub.Delete(1);
            var result = await DALStub.GetAll(false);

            //Assert
            Assert.IsTrue(test1);
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Delete_WhenTargetNotExists_ExpectedResultFalse()
        {
            //Arrange
            var DALStub = new MovieDALStub(_Seed);

            //Act
            bool test = DALStub.Delete(4);

            //Assert
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void Get_WhenAllOK_ExpectedResultAreEqual()
        {
            //Arrange
            var DALStub = new MovieDALStub(_Seed);
            var expectedResult = _Seed[1];

            //Act
            var result = DALStub.Get(2);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Get_WhenTargetNotExists_ExpectedResultNull()
        {
            //Arrange
            var DALStub = new MovieDALStub(_Seed);

            //Act
            var result = DALStub.Get(4);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task GetAll_WhenAllOK_ExpectedResultAreEqual()
        {
            //Arrange
            var DALStub = new MovieDALStub(_Seed);
            var expectedResult = _Seed;

            //Act
            var result = await DALStub.GetAll(false);

            //Assert
            Assert.IsTrue(expectedResult.Count == result.Count);
            for(var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }
        }
    }
}
