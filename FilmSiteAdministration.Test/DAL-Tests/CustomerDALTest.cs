using System;
using FilmSiteAdministration.Test.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using SharedLogic;
using System.Collections.Generic;

namespace FilmSiteAdministration.Test.DAL_Tests
{
    [TestClass]
    public class CustomerDALTest
    {
        [TestMethod]
        public void Create_WhenNoExistingUsers_ExpectedResultTrueAreEqual()
        {
            //Arrange
            var DALStub = new CustomerDALStub();
            var input = new CustomerModelDAL
            {
                Email = "s123456@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword"),
                FirstName = "Someones-Fistname",
                LastName = "Someones-Lastname",
                MovieRentals = new List<MovieOrderModelDAL>()
            };

            //Act
            bool test1 = DALStub.Create(input);
            var result = DALStub.Get(input.Email);

            //Assert
            Assert.IsTrue(test1);
            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void Create_WhenOtherUsersExisits_ExpectedResultTrueAreEqual()
        {
            //Arrange
            var user1 = new CustomerModelDAL
            {
                Email = "s111111@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword1"),
                FirstName = "number-one",
                LastName = "one",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var user2 = new CustomerModelDAL
            {
                Email = "s222222@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword2"),
                FirstName = "number-two",
                LastName = "two",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var user3 = new CustomerModelDAL
            {
                Email = "s333333@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword3"),
                FirstName = "number-three",
                LastName = "three",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var initialCustomers = new List<CustomerModelDAL>
            {
                user1, user2, user3
            };

            var DALStub = new CustomerDALStub(initialCustomers);
            var input = new CustomerModelDAL
            {
                Email = "s123456@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword"),
                FirstName = "Someones-Fistname",
                LastName = "Someones-Lastname",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var expectedResult = new List<CustomerModelDAL>
            {
                user1, user2, user3, input
            };

            //Act
            bool test1 = DALStub.Create(input);
            var result = DALStub.GetAll();

            //Assert
            Assert.IsTrue(test1);
            Assert.IsTrue(expectedResult.Count == result.Count);
            for(int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Email, result[i].Email);
            }
        }

        [TestMethod]
        public void Create_WhenEmptyEmail_ExpectedResultFalse()
        {
            //Arrange
            var DALStub = new CustomerDALStub();
            var input = new CustomerModelDAL
            {
                Email = "",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword"),
                FirstName = "Someones-Fistname",
                LastName = "Someones-Lastname",
                MovieRentals = new List<MovieOrderModelDAL>()
            };

            //Act
            bool test = DALStub.Create(input);

            //Assert
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void Update_WhenOneUserExists_ExpectedResultTrueAreEqual()
        {
            //Arrange
            var user1 = new CustomerModelDAL
            {
                Email = "s123456@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword"),
                FirstName = "Someones-Fistname",
                LastName = "Someones-Lastname",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var initialCustomers = new List<CustomerModelDAL> { user1 };

            var DALStub = new CustomerDALStub(initialCustomers);
            var input = new CustomerModelDAL
            {
                Email = "s123456@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newandbetterpassword"),
                FirstName = "Someones-Fistname",
                LastName = "New-Lastname",
                MovieRentals = new List<MovieOrderModelDAL>()
            };

            //Act
            bool test1 = DALStub.Update(input);
            var result = DALStub.Get(user1.Email);

            //Assert
            Assert.IsTrue(test1);
            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void Update_WhenMultipleUsersExists_ExpectedResultTrueAreEqual()
        {
            //Arrange
            var user1 = new CustomerModelDAL
            {
                Email = "s111111@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword1"),
                FirstName = "number-one",
                LastName = "one",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var user2 = new CustomerModelDAL
            {
                Email = "s222222@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword2"),
                FirstName = "number-two",
                LastName = "two",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var user3 = new CustomerModelDAL
            {
                Email = "s333333@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword3"),
                FirstName = "number-three",
                LastName = "three",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var initialCustomers = new List<CustomerModelDAL>
            {
                user1, user2, user3
            };

            var DALStub = new CustomerDALStub(initialCustomers);
            var input = new CustomerModelDAL
            {
                Email = "s222222@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newandbetterpassword"),
                FirstName = "number-two",
                LastName = "New-Lastname",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var expectedResult = new List<CustomerModelDAL>
            {
                user1, user3, input
            };

            //Act
            bool test1 = DALStub.Update(input);
            var result = DALStub.GetAll();

            //Assert
            Assert.IsTrue(test1);
            Assert.IsTrue(expectedResult.Count == result.Count);
            for(int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }
        }

        [TestMethod]
        public void Update_WhenUpdatingMovieOrders_ExpectedResultTrueAreEqual()
        {
            //Arrange
            var user1 = new CustomerModelDAL
            {
                Email = "s123456@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword"),
                FirstName = "Someones-Fistname",
                LastName = "Someones-Lastname",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var initialCustomers = new List<CustomerModelDAL> { user1 };

            var DALStub = new CustomerDALStub(initialCustomers);
            var newMovieOrder = new MovieOrderModelDAL
            {
                RentedMovieId = 1,
                RentalStartTimeStamp = DateTime.Now.ToString(),
                Email = user1.Email
            };
            var newMovieRenatlList = new List<MovieOrderModelDAL> { newMovieOrder };

            var input = new CustomerModelDAL
            {
                Email = "s123456@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword"),
                FirstName = "Someones-Fistname",
                LastName = "Someones-Lastname",
                MovieRentals = newMovieRenatlList
            };

            //Act
            bool test1 = DALStub.Update(input);
            var result = DALStub.Get(user1.Email);

            //Assert
            Assert.IsTrue(test1);
            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void Update_WhenUserNotExists_ExpectedResultFalse()
        {
            //Arrange
            var user1 = new CustomerModelDAL
            {
                Email = "s123456@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword"),
                FirstName = "Someones-Fistname",
                LastName = "Someones-Lastname",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var initialCustomers = new List<CustomerModelDAL> { user1 };

            var DALStub = new CustomerDALStub(initialCustomers);
            var input = new CustomerModelDAL
            {
                Email = "s111111@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newandbetterpassword"),
                FirstName = "Someones-Fistname",
                LastName = "New-Lastname",
                MovieRentals = new List<MovieOrderModelDAL>()
            };

            //Act
            bool test = DALStub.Update(input);

            //Assert
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void Delete_WhenThreeUsersExists_ExpectedResultCount2()
        {
            //Arrange
            var user1 = new CustomerModelDAL
            {
                Email = "s111111@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword1"),
                FirstName = "number-one",
                LastName = "one",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var user2 = new CustomerModelDAL
            {
                Email = "s222222@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword2"),
                FirstName = "number-two",
                LastName = "two",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var user3 = new CustomerModelDAL
            {
                Email = "s333333@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword3"),
                FirstName = "number-three",
                LastName = "three",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var initialCustomers = new List<CustomerModelDAL> { user1, user2, user3 };
            var expectedResult = new List<CustomerModelDAL>   { user1, user3 };

            var DALStub = new CustomerDALStub(initialCustomers);

            //Act
            bool test1 = DALStub.Delete(user2.Email);
            var result = DALStub.GetAll();

            //Assert
            Assert.IsTrue(test1);
            Assert.IsTrue(result.Count == 2);
            for(int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Email, result[i].Email);
            }
        }

        [TestMethod]
        public void Delete_WhenOneUserExists_ExpectedResultCount0()
        {
            //Arrange
            var user1 = new CustomerModelDAL
            {
                Email = "s123456@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword"),
                FirstName = "Someones-Fistname",
                LastName = "Someones-Lastname",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var initialCustomers = new List<CustomerModelDAL> { user1 };

            var DALStub = new CustomerDALStub(initialCustomers);

            //Act
            bool test1 = DALStub.Delete(user1.Email);
            var result = DALStub.GetAll();

            //Assert
            Assert.IsTrue(test1);
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Delete_WhenTargetNotExists_ExpectedResultFalse()
        {
            //Arrange
            var user1 = new CustomerModelDAL
            {
                Email = "s123456@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword"),
                FirstName = "Someones-Fistname",
                LastName = "Someones-Lastname",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var initialCustomers = new List<CustomerModelDAL> { user1 };

            var DALStub = new CustomerDALStub(initialCustomers);

            //Act
            bool test = DALStub.Delete("sabcdefg@oslomet.no");

            //Assert
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void Get_WhenOneUserExists_ExpectedResultAreEqual()
        {
            //Arrange
            var user1 = new CustomerModelDAL
            {
                Email = "s123456@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword"),
                FirstName = "Someones-Fistname",
                LastName = "Someones-Lastname",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var initialCustomers = new List<CustomerModelDAL> { user1 };
            var expectedResult = user1;

            var DALStub = new CustomerDALStub(initialCustomers);

            //Arrange
            var result = DALStub.Get(user1.Email);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Get_WhenMultipleUsersExist_ExpectedResultAreEqual()
        {
            //Arrange
            var user1 = new CustomerModelDAL
            {
                Email = "s111111@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword1"),
                FirstName = "number-one",
                LastName = "one",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var user2 = new CustomerModelDAL
            {
                Email = "s222222@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword2"),
                FirstName = "number-two",
                LastName = "two",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var user3 = new CustomerModelDAL
            {
                Email = "s333333@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword3"),
                FirstName = "number-three",
                LastName = "three",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var initialCustomers = new List<CustomerModelDAL> { user1, user2, user3 };
            var expectedResult = user2;

            var DALStub = new CustomerDALStub(initialCustomers);

            //Act
            var result = DALStub.Get(user2.Email);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Get_WhenTargetNotExists_ExpectedResultNull()
        {
            //Arrange
            var user1 = new CustomerModelDAL
            {
                Email = "s123456@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword"),
                FirstName = "Someones-Fistname",
                LastName = "Someones-Lastname",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var initialCustomers = new List<CustomerModelDAL> { user1 };

            var DALStub = new CustomerDALStub(initialCustomers);

            //Arrange
            var result = DALStub.Get("sabcdef@oslomet.no");

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAll_WhenOneExistingUser_ExpectedResultAreEqual()
        {
            //Arrange
            var user1 = new CustomerModelDAL
            {
                Email = "s123456@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword"),
                FirstName = "Someones-Fistname",
                LastName = "Someones-Lastname",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var initialCustomers = new List<CustomerModelDAL> { user1 };
            var expectedResult = new List<CustomerModelDAL>   { user1 };

            var DALStub = new CustomerDALStub(initialCustomers);

            //Act
            var result = DALStub.GetAll();

            //Assert
            Assert.IsTrue(expectedResult.Count == result.Count);
            for(int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Email, result[i].Email);
            }
        }

        [TestMethod]
        public void GetAll_WhenMultipleExistingUsers_ExpectedResultAreEqual()
        {
            //Arrange
            var user1 = new CustomerModelDAL
            {
                Email = "s111111@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword1"),
                FirstName = "number-one",
                LastName = "one",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var user2 = new CustomerModelDAL
            {
                Email = "s222222@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword2"),
                FirstName = "number-two",
                LastName = "two",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var user3 = new CustomerModelDAL
            {
                Email = "s333333@oslomet.no",
                Password = PasswordHelperTool.PasswordSHA256Hasher("newbypassword3"),
                FirstName = "number-three",
                LastName = "three",
                MovieRentals = new List<MovieOrderModelDAL>()
            };
            var initialCustomers = new List<CustomerModelDAL> { user1, user2, user3 };
            var expectedResult = new List<CustomerModelDAL>   { user1, user2, user3 };

            var DALStub = new CustomerDALStub(initialCustomers);

            //Act
            var result = DALStub.GetAll();

            //Assert
            Assert.IsTrue(expectedResult.Count == result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Email, result[i].Email);
            }
        }
    }
}
