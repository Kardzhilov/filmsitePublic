using System.Collections.Generic;
using Model.BLL;

namespace BLL
{
    public interface ICustomerUsersLogic
    {
        bool AuthenticateCustomer(string userName, string password);
        bool Create(CustomerModelBLL customerModelBLL);
        bool Delete(string email);
        CustomerModelBLL Get(string email);
        List<CustomerModelBLL> GetAll();
        bool Update(CustomerModelBLL customerModelBLL);
    }
}