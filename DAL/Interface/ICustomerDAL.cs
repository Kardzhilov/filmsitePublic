using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using FilmSiteAdministration.Model;
using FilmSiteAdministration.DAL;

namespace DAL.Interface
{
    public interface ICustomerDAL
    {
        bool Create(CustomerModelDAL customer);
        bool Update(CustomerModelDAL customer);
        bool Delete(string email);
        CustomerModelDAL Get(string email);
        List<CustomerModelDAL> GetAll();
        bool FindCustomerMatchingCredentials(string userName, byte[] hashedPassword);
    }
}
