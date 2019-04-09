using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilmSiteAdministration.Test.Stubs;
using Model.BLL;

namespace FilmSiteAdministration.BLL.Tests
{
    [TestClass()]
    public class AdminUserLogicTests
    {        
        [TestMethod()]
        public void CheckLoginCredentialsTest()
        {
            //Arrange
            var controller = new AdminUserLogic(new AdminUserDALStub());
            var inputRight = new AdminUserModelBLL
            {
                UserName = "admin",
                Password = "1234"
            };
            var inputWrong = new AdminUserModelBLL
            {
                UserName = "wrong",
                Password = "wrong"
            };

            //Act
            var result1 = controller.CheckLoginCredentials(inputRight);
            var result2 = controller.CheckLoginCredentials(inputWrong);

            //Assert
            Assert.IsTrue(result1 && !result2);
        }

        [TestMethod()]
        public void RegisterAdminUserTest()
        {
            //Arrange
            var controller = new AdminUserLogic(new AdminUserDALStub());
            var inputRight = new AdminUserModelBLL
            {
                UserName = "new",
                Password = "user"
            };
            var inputWrong = new AdminUserModelBLL
            {
                UserName = "",
                Password = ""
            };
            //Act
            var result1 = controller.RegisterAdminUser(inputRight);
            var result2 = controller.RegisterAdminUser(inputWrong);

            //Assert
            Assert.IsTrue(result1 && !result2);
        }
    }
}