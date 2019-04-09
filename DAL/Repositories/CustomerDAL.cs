using DAL.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    //This DAL class is for administrating customers
    public class CustomerDAL : ICustomerDAL
    {
        public bool Create(CustomerModelDAL customer)
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    DBConnection.Customers.Add(customer);
                    DBConnection.SaveChanges();
                    Loggings.GeneralLog("Created Customer with Email: " + customer.Email);
                    return true; 
                }
            }
            catch(Exception ex)
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

        public bool Update(CustomerModelDAL customer)
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    var customerFound = DBConnection.Customers.Find(customer.Email);

                    if(customerFound == null)
                    {
                        Loggings.GeneralLog("Could not find Customer with Email: " + customer.Email);
                        return false; 
                    }

                    customerFound.Email = customer.Email;
                    customerFound.FirstName = customer.FirstName;
                    customerFound.LastName = customer.LastName;


                    if (customerFound.Password != null)
                    {
                        customerFound.Password = customer.Password;
                    }
                    DBConnection.SaveChanges();
                    Loggings.GeneralLog("Updated Customer with Email: " + customer.Email);
                    return true; 
                }
            }
            catch(Exception ex)
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

        public bool Delete(string email)
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    var customerToDelete = DBConnection.Customers.Find(email);
                    DBConnection.Customers.Remove(customerToDelete);
                    DBConnection.SaveChanges();
                    Loggings.GeneralLog("Delted Customer with Email: " + email);
                    return true;
                }
            }
            catch(Exception ex)
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

        public CustomerModelDAL Get(string email)
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    var customerFound = DBConnection.Customers.Find(email);

                    if(customerFound == null)
                    {
                        Loggings.GeneralLog("Could not find Customer with Email: " + email);
                        return null; 
                    }
                    else
                    {
                        Loggings.GeneralLog("Found with Email: " + email);
                        return customerFound;
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

        public List<CustomerModelDAL> GetAll()
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    var allCustomers = DBConnection.Customers.ToList();
                    return allCustomers;
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

        /// <summary>
        /// This is a method for finding customer with matching credentials.
        /// </summary>
        /// <param name="userName">The username of the customer</param>
        /// <param name="hashedPassword">The hashed password of the customer</param>
        /// <returns>
        /// 1. Returns true if an entry is found with the specified credentials.
        /// 2. Return false if an entry is not found with the specified credentials. 
        /// </returns>
        public bool FindCustomerMatchingCredentials(string userName, byte[] hashedPassword)
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    var result = DBConnection.Customers.Find(userName);

                    if (result == null)
                    {
                        return false;
                    }
                    else
                    {
                        if(result.Password.SequenceEqual(hashedPassword))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
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
                return false;
            }
        }
    }
}
