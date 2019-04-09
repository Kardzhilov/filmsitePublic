using DAL;
using FilmSiteAdministration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using DAL.Interface;

namespace FilmSiteAdministration.DAL
{
    public class AdminUserDAL : IAdminUserDAL
    {
        public bool CheckLoginCredentials(AdminUserModelDAL userInput)
        {
            using (var db = new DB(false))
            {
                var allAdminUsers = db.AdminUsers.ToList();

                var foundAdminUser = db.AdminUsers.FirstOrDefault(b => b.Username.Equals(userInput.Username));

                if(foundAdminUser == null)
                {
                    Loggings.GeneralLog("No Admin User was found using the Username: " + userInput.Username);
                    return false;
                }

                if(foundAdminUser.HashedPassword.SequenceEqual(userInput.HashedPassword))
                {
                    Loggings.GeneralLog("Admin User: " + userInput.Username + " Used the correct login credecials");
                    return true;
                }
                else
                {
                    Loggings.GeneralLog("Admin User: " + userInput.Username + " Used the incorrect login credecials");
                    return false;
                }
            }
        }

        public bool Create(AdminUserModelDAL adminuser)
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    DBConnection.AdminUsers.Add(adminuser);
                    DBConnection.SaveChanges();

                    Loggings.GeneralLog("Created Admin User: " + adminuser.Username);
                    return true;
                }
            }
            catch (Exception ex)
            {
                var logg = new LoggTypeDAL()
                {
                    EventType = "Exception",
                    Created_By = "System",
                    LogMessage = ex.ToString(),
                    Created_date = DateTime.Now
                };
                Loggings.LogToBoth(logg);
                return false;
            }
        }

        public bool Update(AdminUserModelDAL adminUser)
        {
            try
            {
                using (var DBConnection = new DB(false))
                {
                    var adminUserFound = DBConnection.AdminUsers.Find(adminUser.Username);

                    if (adminUserFound == null)
                    {
                        Loggings.GeneralLog("Could not find Admin User: " + adminUser.Username);
                        return false;
                    }

                    adminUserFound.Username = adminUser.Username;
                    adminUserFound.HashedPassword = adminUser.HashedPassword;
                    DBConnection.SaveChanges();
                    Loggings.GeneralLog("Updated credentials for Admin User: " + adminUser.Username);
                    return true;
                }
            }
            catch (Exception ex)
            {
                var logg = new LoggTypeDAL()
                {
                    EventType = "Exception",
                    Created_By = "System",
                    LogMessage = ex.ToString(),
                    Created_date = DateTime.Now
                };
                Loggings.LogToBoth(logg);
                return false;
            }
        }

        public bool Delete(string userName)
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    var adminToDelete = DBConnection.AdminUsers.Find(userName);
                    DBConnection.AdminUsers.Remove(adminToDelete);
                    DBConnection.SaveChanges();
                    Loggings.GeneralLog("Deleted Admin User: " + userName);
                    return true;
                }
            }
            catch (Exception ex)
            {
                var logg = new LoggTypeDAL()
                {
                    EventType = "Exception",
                    Created_By = "System",
                    LogMessage = ex.ToString(),
                    Created_date = DateTime.Now
                };
                Loggings.LogToBoth(logg);
                return false;
            }
        }

        public AdminUserModelDAL Get(string userName)
        {
            try
            {
                using (var DBConnection = new DB(false))
                {
                    var adminUserFound = DBConnection.AdminUsers.Find(userName);

                    if (adminUserFound == null)
                    {
                        Loggings.GeneralLog("Could not find Admin User: " + userName);
                        return null;
                    }
                    else
                    {
                        Loggings.GeneralLog("Found Admin User: " + userName);
                        return adminUserFound;
                    }

                }
            }
            catch (Exception ex)
            {
                var logg = new LoggTypeDAL()
                {
                    EventType = "Exception",
                    Created_By = "System",
                    LogMessage = ex.ToString(),
                    Created_date = DateTime.Now
                };
                Loggings.LogToBoth(logg);
                return null;
            }
        }

        public List<AdminUserModelDAL> GetAll()
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    var allAdminUsers = DBConnection.AdminUsers.ToList();
                    return allAdminUsers;
                }
            }
            catch (Exception ex)
            {
                var logg = new LoggTypeDAL()
                {
                    EventType = "Exception",
                    Created_By = "System",
                    LogMessage = ex.ToString(),
                    Created_date = DateTime.Now
                };
                Loggings.LogToBoth(logg);
                return null;
            }
        }

    }
}
