using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmSiteAdministration.Model;

namespace DAL.Interface
{
    public interface IAdminUserDAL
    {
        bool CheckLoginCredentials(AdminUserModelDAL userInput);
        bool Create(AdminUserModelDAL adminuser);
        bool Update(AdminUserModelDAL adminUser);
        bool Delete(string userName);
        AdminUserModelDAL Get(string userName);
        List<AdminUserModelDAL> GetAll();
    }
}
