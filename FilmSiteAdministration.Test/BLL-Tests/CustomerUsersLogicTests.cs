using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilmSiteAdministration.Test.Stubs;
using Model.BLL;
using System.Collections.Generic;
using Model;
using SharedLogic;

namespace BLL.Tests
{
    [TestClass()]
    public class CustomerUsersLogicTests
    {

        [TestMethod()]
        public void CreateTest()
        {
            //Arrange
            var seedDB = new List<CustomerModelDAL>();
            var seed = new CustomerModelDAL
            {
                Email = "correct@email.yes",
                Password = PasswordHelperTool.PasswordSHA256Hasher("password"),
                FirstName = "First",
                LastName = "Last"
            };
            seedDB.Add(seed);
            var controller = new CustomerUsersLogic(new CustomerDALStub(seedDB));
            var rightInput = new CustomerModelBLL {
                Email = "correct@email.yes",
                Password = "password",
                FirstName = "First",
                LastName = "Last"
            };
            var wrongInput = new CustomerModelBLL {
                Email = "",
                Password = "",
                FirstName = "",
                LastName = ""
            };

            //Act
            var result1 = controller.Create(rightInput);
            var result2 = controller.Create(wrongInput);

            //Assert
            Assert.IsTrue(result1 && !result2);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var seedDB = new List<CustomerModelDAL>();
            var seed = new CustomerModelDAL
            {
                Email = "correct@email.yes",
                Password = PasswordHelperTool.PasswordSHA256Hasher("password"),
                FirstName = "First",
                LastName = "Last"
            };
            seedDB.Add(seed);
            //Arrange
            var controller = new CustomerUsersLogic(new CustomerDALStub(seedDB));
            var rightInput = new CustomerModelBLL 
            {
                Email = "correct@email.yes",
                Password = "password",
                FirstName = "First",
                LastName = "Last",
                MovieRentals = null
            };
            var wrongInput = new CustomerModelBLL
            {
                Email = "",
                Password = "",
                FirstName = "",
                LastName = "",
                MovieRentals = null
            };

            //Act
            var result1 = controller.Create(rightInput);
            var result2 = controller.Create(wrongInput);

            //Assert
            Assert.IsTrue(result1 && !result2);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //Arrange
            var seedDB = new List<CustomerModelDAL>();
            var seed = new CustomerModelDAL
            {
                Email = "correct@email.yes",
                Password = PasswordHelperTool.PasswordSHA256Hasher("password"),
                FirstName = "First",
                LastName = "Last"
            };
            seedDB.Add(seed);
            var controller = new CustomerUsersLogic(new CustomerDALStub(seedDB));
            var rightInput = "correct@email.yes";
            var wrongInput = "";

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
            var seedDB = new List<CustomerModelDAL>();
            var seed = new CustomerModelDAL
            {
                Email = "correct@email.yes",
                Password = PasswordHelperTool.PasswordSHA256Hasher("password"),
                FirstName = "First",
                LastName = "Last"
            };
            seedDB.Add(seed);
            var controller = new CustomerUsersLogic(new CustomerDALStub(seedDB));
            var rightInput = "correct@email.yes";
            var wrongInput = "";

            //Act
            var result1 = controller.Get(rightInput);
            var result2 = controller.Get(wrongInput);

            //Assert
            Assert.IsTrue(result1 != null && result2 == null);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            //Arrange
            var seedDB = new List<CustomerModelDAL>();
            var seed = new CustomerModelDAL
            {
                Email = "correct@email.yes",
                Password = PasswordHelperTool.PasswordSHA256Hasher("password"),
                FirstName = "First",
                LastName = "Last"
            };
            seedDB.Add(seed);
            var controller = new CustomerUsersLogic(new CustomerDALStub(seedDB));

            //Act
            var result = controller.GetAll();

            //Assert
            Assert.IsNotNull(result); //Double check
        }

        [TestMethod()]
        public void AuthenticateCustomerTest()
        {
            //Arrange
            var seedDB = new List<CustomerModelDAL>();
            var seed = new CustomerModelDAL
            {
                Email = "correct@email.yes",
                Password = PasswordHelperTool.PasswordSHA256Hasher("password"),
                FirstName = "First",
                LastName = "Last"
            };
            seedDB.Add(seed);
            var controller = new CustomerUsersLogic(new CustomerDALStub(seedDB));
            var rightInput1 = "correct@email.yes"; 
            var rightInput2 = "password";          
            var wrongInput1 = "";
            var wrongInput2 = "";

            //Act
            var result1 = controller.AuthenticateCustomer(rightInput1, rightInput2);
            var result2 = controller.AuthenticateCustomer(wrongInput1, wrongInput2);

            //Assert
            Assert.IsTrue(result1 && !result2);
        }
    }
}