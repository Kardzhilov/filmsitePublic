using DAL.Interface;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace FilmSiteAdministration.Test.Stubs
{
    class CustomerDALStub : ICustomerDAL
    {
        private List<CustomerModelDAL> _CustomerDB;

        public CustomerDALStub()
        {
            _CustomerDB = new List<CustomerModelDAL>();
        }


        public CustomerDALStub(List<CustomerModelDAL> customers)
        {
            _CustomerDB = customers;
        }

        public bool Create(CustomerModelDAL customer)
        {
            if(customer.Email == "")
            {
                return false;
            }

            _CustomerDB.Add(customer);
            return true;
        }

        public bool Update(CustomerModelDAL customer)
        {
            var customerFound = _CustomerDB.FirstOrDefault(b => b.Email.Equals(customer.Email));

            if (customerFound == null)
            {
                return false;
            }

            _CustomerDB.Remove(customerFound);
            _CustomerDB.Add(customer);
            return true;
        }

        public bool Delete(string email)
        {
            var customerToDelete = _CustomerDB.FirstOrDefault(b => b.Email.Equals(email));

            if (customerToDelete == null)
            {
                return false;
            }

            _CustomerDB.Remove(customerToDelete);
            return true;
        }

        public CustomerModelDAL Get(string email)
        {
            var customerFound = _CustomerDB.FirstOrDefault(b => b.Email.Equals(email));

            if (customerFound == null)
            {
                return null;
            }
            else
            {
                return customerFound;
            }
        }

        public List<CustomerModelDAL> GetAll()
        {
            var allCustomers = _CustomerDB.ToList();

            return allCustomers;
        }

        public bool FindCustomerMatchingCredentials(string userName, byte[] hashedPassword)
        {
            var result = _CustomerDB.Select(user => user.Email == userName && user.Password.ToString() == hashedPassword.ToString()).FirstOrDefault();

            return result;
        }
    }
}
