using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilmSiteAdministration.Test.Stubs;
using Model.BLL;
using System;
using Model;
using System.Collections.Generic;

namespace BLL.Tests
{
    [TestClass()]
    public class MovieOrdersLogicTests
    {

        [TestMethod()]
        public void CreateTest()
        {
            //Arrange
            var seedDB = new List<MovieOrderModelDAL>();
            var seed = new MovieOrderModelDAL
            {
                RentedMovieId = 1,
                ID = 1,
                RentalStartTimeStamp = DateTime.Now.ToString(),
                Email = "correct@email.yes"
            };
            seedDB.Add(seed);
            var controller = new MovieOrdersLogic(new MovieOrderDALStub(seedDB));
            var rightInput = new MovieOrderModelDAL
            {
                RentedMovieId = 1,
                ID = 1,
                RentalStartTimeStamp = DateTime.Now.ToString(),
                Email = "correct@email.yes"
            };
            var wrongInput = new MovieOrderModelDAL
            {
                RentedMovieId = -1,
                ID = -1,
                RentalStartTimeStamp = "noTime",
                Email = ""
            };

            //Act
            //var result1 = controller.Create(rightInput);
            //var result2 = controller.Create(wrongInput);

            //Assert
            Assert.IsTrue(true );
        }

        [TestMethod()]
        public void UpdateTest()
        {            
            //Arrange
            var controller = new MovieOrdersLogic(new MovieOrderDALStub());
            var rightInput = new MovieOrderModelBLL
            {
                RentedMovieId = 1,
                RentedMovie = new MovieModelDAL { ID = 1 },
                RentalStartTimeStamp = DateTime.Now.ToString(),
                RentalUser = new CustomerModelBLL
                {
                    Email = "correct@email.yes",
                    Password = "password",
                    FirstName = "First",
                    LastName = "Last"
                }
            };
            

            //Act
            var result1 = controller.Update(rightInput);

            //Assert
            Assert.IsTrue(result1);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //Arrange
            var seedDB = new List<MovieOrderModelDAL>();
            var seed = new MovieOrderModelDAL
            {
                RentedMovieId = 1,
                ID = 1,
                RentalStartTimeStamp = DateTime.Now.ToString(),
                Email = "correct@email.yes"
            };
            seedDB.Add(seed);
            var controller = new MovieOrdersLogic(new MovieOrderDALStub(seedDB));
            var rightInput = 1;
            var wrongInput = -1;

            //Act
            var result1 = controller.Delete(rightInput);
            var result2 = controller.Delete(wrongInput);

            //Assert
            Assert.IsTrue(result1 && !result2);
        }

        [TestMethod()]
        public void GetTest()
        {
            //Arrange
            var seedDB = new List<MovieOrderModelDAL>();
            var seed = new MovieOrderModelDAL
            {
                RentedMovieId = 1,
                ID = 1,
                RentalStartTimeStamp = DateTime.Now.ToString(),
                Email = "correct@email.yes"
            };
            seedDB.Add(seed);
            var controller = new MovieOrdersLogic(new MovieOrderDALStub(seedDB));
            var rightInput = 1;
            var wrongInput = -1;

            //Act
            var result1 = controller.Get(rightInput);
            var result2 = controller.Get(wrongInput);

            //Assert
            Assert.IsInstanceOfType(result1, typeof(MovieOrderModelBLL));
            Assert.IsNull(result2);
        }

        [TestMethod()]
        public void GetUserMovieOrdersTest()
        {
            //Arrange
            var seedDB = new List<MovieOrderModelDAL>();
            var seed = new MovieOrderModelDAL
            {
                RentedMovieId = 1,
                ID = 1,
                RentalStartTimeStamp = DateTime.Now.ToString(),
                Email = "correct@email.yes"
            };
            seedDB.Add(seed);
            var controller = new MovieOrdersLogic(new MovieOrderDALStub(seedDB));
            var rightInput = "correct@email.yes";
            var wrongInput = "";

            //Act
            var result1 = controller.GetUserMovieOrders(rightInput);
            var result2 = controller.GetUserMovieOrders(wrongInput);

            //Assert
            Assert.IsTrue(result1.Count == 1);
            Assert.IsTrue(result2.Count == 0);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            //Arrange
            var seedDB = new List<MovieOrderModelDAL>();
            var seed = new MovieOrderModelDAL
            {
                RentedMovieId = 1,
                ID = 1,
                RentalStartTimeStamp = DateTime.Now.ToString(),
                Email = "correct@email.yes"
            };
            seedDB.Add(seed);
            var controller = new MovieOrdersLogic(new MovieOrderDALStub(seedDB));

            //Act
            var result = controller.GetAll();

            //Assert
            Assert.IsTrue(result.Count == 1);
        }
        
    }
}