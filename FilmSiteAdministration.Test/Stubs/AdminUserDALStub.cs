using System.Collections.Generic;
using System.Linq;
using FilmSiteAdministration.Model;
using DAL.Interface;
using SharedLogic;


namespace FilmSiteAdministration.Test.Stubs
{
    class AdminUserDALStub : IAdminUserDAL
    {
        private List<AdminUserModelDAL> _AdminUserDB;

        public AdminUserDALStub()
        {
            _AdminUserDB = new List<AdminUserModelDAL>();

            //Seed an admin user in "artificial" database
            var seed = new AdminUserModelDAL
            {
                Username = "admin",
                HashedPassword = PasswordHelperTool.PasswordSHA256Hasher("1234")
            };
            _AdminUserDB.Add(seed);
        }

        public bool CheckLoginCredentials(AdminUserModelDAL userInput)
        {
            var foundAdminUser = _AdminUserDB.Find(b => b.Username.Equals(userInput.Username));

            if (foundAdminUser == null)
            {
                return false;
            }

            if (foundAdminUser.HashedPassword.SequenceEqual(userInput.HashedPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Create(AdminUserModelDAL adminuser)
        {
            if (adminuser.Username == "" || !adminuser.HashedPassword.Any())
            {
                return false;
            }

            _AdminUserDB.Add(adminuser);
            return true;
        }

        public bool Update(AdminUserModelDAL adminUser)
        {
            var adminUserFound = _AdminUserDB.FirstOrDefault(b => b.Username.Equals(adminUser.Username));

            if (adminUserFound == null)
            {
                return false;
            }

            _AdminUserDB.Remove(adminUserFound);
            _AdminUserDB.Add(adminUser);
            return true;
        }

        public bool Delete(string userName)
        {
            var adminToDelete = _AdminUserDB.FirstOrDefault(b => b.Username.Equals(userName));

            if(adminToDelete == null)
            {
                return false;
            }

            _AdminUserDB.Remove(adminToDelete);
            return true;
        }

        public AdminUserModelDAL Get(string userName)
        {
            var adminUserFound = _AdminUserDB.FirstOrDefault(b => b.Username.Equals(userName));

            if (adminUserFound == null)
            {
                return null;
            }
            else
            {
                return adminUserFound;
            }
        }

        public List<AdminUserModelDAL> GetAll()
        {
            var allAdminUsers = _AdminUserDB.Select(c => new AdminUserModelDAL()
            {
                Username = c.Username,
                HashedPassword = c.HashedPassword
            }).ToList();

            if(!allAdminUsers.Any())
            {
                return null;
            }

            return allAdminUsers;
        }
    }
}
