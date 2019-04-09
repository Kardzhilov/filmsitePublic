using FilmSiteAdministration.Model;
using FilmSiteAdministration.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.BLL;
using SharedLogic;
using Model.ViewModels;
using Model;
using DAL.Interface;

namespace FilmSiteAdministration.BLL
{
    public class AdminUserLogic : IAdminUserLogic
    {
        private IAdminUserDAL _adminUserDAL;

        public AdminUserLogic()
        {
            _adminUserDAL = new AdminUserDAL();
        }

        public AdminUserLogic(IAdminUserDAL stub)
        {
            _adminUserDAL = stub;
        }

        public bool CheckLoginCredentials(AdminUserModelBLL userInput)
        {
            var adminUserModelDAL = new AdminUserModelDAL()
            {
                Username = userInput.UserName,
                HashedPassword = PasswordHelperTool.PasswordSHA256Hasher(userInput.Password)
            };

            return _adminUserDAL.CheckLoginCredentials(adminUserModelDAL);
        }

        public bool RegisterAdminUser(AdminUserModelBLL userInput)
        {
            var adminUserModelDAL = new AdminUserModelDAL()
            {
                Username = userInput.UserName,
                HashedPassword = PasswordHelperTool.PasswordSHA256Hasher(userInput.Password)
            };

            return _adminUserDAL.Create(adminUserModelDAL);
        }

        //Summary: Update a customer
        public bool Update(AdminUserModelBLL adminModelBLL)
        {
            var adminModelDAL = new AdminUserModelDAL()
            {
                Username = adminModelBLL.UserName,
                HashedPassword = PasswordHelperTool.PasswordSHA256Hasher(adminModelBLL.Password)
            };

            var result = _adminUserDAL.Update(adminModelDAL);
            return result;
        }

        public List<AdminUserModelBLL> GetAll()
        {
            var adminUsersDAL = _adminUserDAL.GetAll();
            var adminUsersBLL = ModelMapper.MapFromListOfAdminUsersDALToListOfAdminUsersBLL(adminUsersDAL);

            return adminUsersBLL;
        }

        public AdminUserModelBLL Get(string userName)
        {
            var adminUserDAL = _adminUserDAL.Get(userName);
            var adminUserBLL = ModelMapper.MapFromAdminUsersDALToAdminUsersBLL(adminUserDAL);

            return adminUserBLL;
        }

        //Summary: Delete a customer
        public bool Delete(string userName)
        {
            var result = _adminUserDAL.Delete(userName);
            return result;
        }

    }
}
