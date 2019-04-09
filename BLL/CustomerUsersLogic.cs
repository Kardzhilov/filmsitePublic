using DAL;
using Model;
using Model.BLL;
using SharedLogic;
using System.Collections.Generic;
using DAL.Interface;


namespace BLL
{
    public class CustomerUsersLogic : ICustomerUsersLogic
    {
        private ICustomerDAL CustomerDAL { get; set; }

        public CustomerUsersLogic()
        {
            CustomerDAL = new CustomerDAL();
        }

        public CustomerUsersLogic(ICustomerDAL stub)
        {
            CustomerDAL = stub;
        }

        //Summary: Create a customer
        public bool Create(CustomerModelBLL customerModelBLL)
        {
            var customerModelDAL = new CustomerModelDAL()
            {
                Email = customerModelBLL.Email,
                Password = PasswordHelperTool.PasswordSHA256Hasher(customerModelBLL.Password),
                FirstName = customerModelBLL.FirstName,
                LastName = customerModelBLL.LastName
            };

            if(customerModelBLL.MovieRentals != null)
            {
                customerModelDAL.MovieRentals = ModelMapper.MapFromMovieOrderModelBLLToMovieOrderModelDAL(customerModelBLL.MovieRentals);
            }

            var result = CustomerDAL.Create(customerModelDAL);
            return result;
        }

        //Summary: Update a customer
        public bool Update(CustomerModelBLL customerModelBLL)
        {
            var customerModelDAL = new CustomerModelDAL()
            {
                Email = customerModelBLL.Email,
                FirstName = customerModelBLL.FirstName,
                LastName = customerModelBLL.LastName
            };

            if(customerModelBLL.Password != null)
            {
                customerModelDAL.Password = PasswordHelperTool.PasswordSHA256Hasher(customerModelBLL.Password);
            }

            if(customerModelBLL.MovieRentals != null)
            {
                customerModelDAL.MovieRentals = ModelMapper.MapFromMovieOrderModelBLLToMovieOrderModelDAL(customerModelBLL.MovieRentals);
            }

            var result = CustomerDAL.Update(customerModelDAL);
            return result;
        }

        //Summary: Delete a customer
        public bool Delete(string email)
        {
            var result = CustomerDAL.Delete(email);
            return result;
        }

        // Summary: Get a customer 
        public CustomerModelBLL Get(string email)
        {
            var result = CustomerDAL.Get(email);

            if(result == null)
            {
                return null;
            };

            var customerBLL = new CustomerModelBLL()
            {
                Email = result.Email,
                FirstName = result.FirstName,
                LastName = result.LastName,
            };

            return customerBLL;
        }

        //Summary: Get all customers
        public List<CustomerModelBLL> GetAll()
        {
            var customers = CustomerDAL.GetAll();
            return ModelMapper.MapFromListOfCustomerModelBLLToListOfCustomerModelDAL(customers);
        }

        public bool AuthenticateCustomer(string userName, string password)
        {
            return CustomerDAL.FindCustomerMatchingCredentials(userName,  PasswordHelperTool.PasswordSHA256Hasher(password));
        }

    }
}
