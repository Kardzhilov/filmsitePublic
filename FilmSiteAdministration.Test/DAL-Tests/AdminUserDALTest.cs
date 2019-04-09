using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilmSiteAdministration.Test.Stubs;
using FilmSiteAdministration.Model;
using SharedLogic;
using System.Collections.Generic;

namespace FilmSiteAdministration.Test.DAL_Tests
{
    [TestClass]
    public class AdminUserDALTest
    {
        [TestMethod]
        public void CheckLoginCredentials_WhenCorrectCombination_ExpectedResultTrue()
        {
            //Arrange
            var DALStub = new AdminUserDALStub();
            var input = new AdminUserModelDAL
            {
                Username = "admin",
                HashedPassword = PasswordHelperTool.PasswordSHA256Hasher("1234")
            };

            //Act
            bool test = DALStub.CheckLoginCredentials(input);

            //Assert
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void CheckLoginCredentials_WhenWrongUsername_ExpectedResultFalse()
        {
            //Arrange
            var DALStub = new AdminUserDALStub();
            var input = new AdminUserModelDAL
            {
                Username = "Tor",
                HashedPassword = PasswordHelperTool.PasswordSHA256Hasher("1234")
            };

            //Act
            bool test = DALStub.CheckLoginCredentials(input);

            //Assert
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void CheckLoginCredentials_WhenWrongPassword_ExpectedResultFalse()
        {
            //Arrange
            var DALStub = new AdminUserDALStub();
            var input = new AdminUserModelDAL
            {
                Username = "admin",
                HashedPassword = PasswordHelperTool.PasswordSHA256Hasher("admin")
            };

            //Act
            bool test = DALStub.CheckLoginCredentials(input);

            //Assert
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void Create_WhenAllOK_ExpectedResultTrueAreEqual()
        {
            //Arrange
            var DALStub = new AdminUserDALStub();
            var input = new AdminUserModelDAL
            {
                Username = "newadmin",
                HashedPassword = PasswordHelperTool.PasswordSHA256Hasher("password")
            };

            //Act
            bool test = DALStub.Create(input);
            var result = DALStub.Get("newadmin");

            //Assert
            Assert.IsTrue(test);
            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void Create_WhenEmptyUsername_ExpectedResultFalse()
        {
            //Arrange
            var DALStub = new AdminUserDALStub();
            var input = new AdminUserModelDAL
            {
                Username = "",
                HashedPassword = PasswordHelperTool.PasswordSHA256Hasher("password")
            };

            //Act
            bool test = DALStub.Create(input);

            //Assert
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void Update_WhenAllOK_ExpectedResultAreEqual()
        {
            //Arrange
            var DALStub = new AdminUserDALStub();
            var input = new AdminUserModelDAL
            {
                Username = "admin",
                HashedPassword = PasswordHelperTool.PasswordSHA256Hasher("newpassword")
            };

            //Act
            bool test1 = DALStub.Update(input);
            AdminUserModelDAL result = DALStub.Get("admin");

            //Assert
            Assert.IsTrue(test1);
            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void Update_WhenUserNotExists_ExpectedResultFalse()
        {
            //Arrange
            var DALStub = new AdminUserDALStub();
            var input = new AdminUserModelDAL
            {
                Username = "tor",
                HashedPassword = PasswordHelperTool.PasswordSHA256Hasher("newpassword")
            };

            //Act
            bool test = DALStub.Update(input);

            //Assert
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void Delete_WhenTwoExistingUsers_ExpectedResultCount1()
        {
            //Arrange
            var DALStub = new AdminUserDALStub();
            var defaultAdminUser = new AdminUserModelDAL
            {
                Username = "admin",
                HashedPassword = PasswordHelperTool.PasswordSHA256Hasher("1234")
            };
            var adminUserToDelete = new AdminUserModelDAL
            {
                Username = "tor",
                HashedPassword = PasswordHelperTool.PasswordSHA256Hasher("torspassword")
            };
            bool successfullCreate = DALStub.Create(adminUserToDelete);
            var expectedResult = new List<AdminUserModelDAL>();
            expectedResult.Add(defaultAdminUser);

            //Act
            bool successfullDelete = DALStub.Delete("tor");
            var result = DALStub.GetAll();

            //Assert
            Assert.IsTrue(successfullCreate);       // Here to make sure the test doesnt pass from it's target not existing
            Assert.IsTrue(successfullDelete);       // Test to se if Delete() is executed
            Assert.IsTrue(result.Count == 1);       // Test to se if Count is back to one
            for (int i = 0; i < result.Count; i++)  // Test to se if correct user has been deleted by comparing to expectations
            {
                Assert.AreEqual(expectedResult[i].Username, result[i].Username);
            }
        }

        [TestMethod]
        public void Delete_WhenOneExistingUser_ExpectedResultCount0EqualsNull()
        {
            //Arrange
            var DALStub = new AdminUserDALStub();

            //Act
            bool successfullDelete = DALStub.Delete("admin");
            var result = DALStub.GetAll();

            //Assert
            Assert.IsTrue(successfullDelete);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Delete_WhenTargetNotExists_ExpectedResultFalse()
        {
            //Arrange
            var DALStub = new AdminUserDALStub();

            //Act
            bool test = DALStub.Delete("tor");

            //Assert
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void Get_WhenOnExistingUser_ExpectedResultAreEqual()
        {
            //Arrange
            var DALStub = new AdminUserDALStub();
            var initial = new AdminUserModelDAL
            {
                Username = "admin",
                HashedPassword = PasswordHelperTool.PasswordSHA256Hasher("1234")
            };

            //Act
            var result = DALStub.Get("admin");

            //Assert
            Assert.AreEqual(initial.Username, result.Username);
        }

        [TestMethod]
        public void Get_WhenUserNotExists_ExpectedResultIsNull()
        {
            //Arrange
            var DALStub = new AdminUserDALStub();

            //Act
            var result = DALStub.Get("tor");

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAll_WhenOneExistingUser_ExpectedResultAreEqual()
        {
            //Arrange
            var DALStub = new AdminUserDALStub();
            var defaultAdminUser = new AdminUserModelDAL
            {
                Username = "admin",
                HashedPassword = PasswordHelperTool.PasswordSHA256Hasher("1234")
            };
            var expectedResult = new List<AdminUserModelDAL>();
            expectedResult.Add(defaultAdminUser);

            //Act
            var result = DALStub.GetAll();

            //Assert
            Assert.IsTrue(expectedResult.Count == result.Count);
            for(int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Username, result[i].Username);
            }
        }

        [TestMethod]
        public void GetAll_WhenTwoExistingUsers_ExpectedResultAreEqual()
        {
            //Arrange
            var DALStub = new AdminUserDALStub();
            var defaultAdminUser = new AdminUserModelDAL
            {
                Username = "admin",
                HashedPassword = PasswordHelperTool.PasswordSHA256Hasher("1234")
            };
            var newAdminUser = new AdminUserModelDAL
            {
                Username = "newadmin",
                HashedPassword = PasswordHelperTool.PasswordSHA256Hasher("newadmin")
            };
            bool successfullCreate = DALStub.Create(newAdminUser);
            var expectedResult = new List<AdminUserModelDAL>();
            expectedResult.Add(defaultAdminUser);
            expectedResult.Add(newAdminUser);

            //Act
            var result = DALStub.GetAll();

            //Assert
            Assert.IsTrue(expectedResult.Count == result.Count);
            for(int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Username, result[i].Username);
            }
        }

        [TestMethod]
        public void GetAll_WhenNoExistingUsers_ExpectedResultNull()
        {
            //Arrange
            var DALStub = new AdminUserDALStub();
            bool successFullDelete = DALStub.Delete("admin");

            //Act
            var result = DALStub.GetAll();

            //Assert
            Assert.IsNull(result);
        }
    }
}
