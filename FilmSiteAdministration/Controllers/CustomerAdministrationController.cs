using BLL;
using Model;
using Model.BLL;
using Model.ViewModels;
using System.Web.Mvc;

namespace FilmSiteAdministration.Controllers
{
    public class CustomerAdministrationController : Controller
    {
        private CustomerUsersLogic _customerUsersLogic;

        public CustomerAdministrationController()
        {
            _customerUsersLogic = new CustomerUsersLogic();
        }

        /// <summary>
        /// This controller action returns a view which shows you all the users.
        /// </summary>
        public ActionResult Index(string message)
        {
            if (Session["LoggedIn"] == null || Session["LoggedIn"].Equals(false))
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }

            var allCustomers = _customerUsersLogic.GetAll();
            var mapepdAllCustomees = ModelMapper.MapFromListOfCustomerBLLToCustomerViewModelList(allCustomers);
            return View(mapepdAllCustomees);
        }

        /// <summary>
        /// Method for creating a customer
        /// </summary>
        /// <param name="customerViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostCustomer(CustomerViewModel customerViewModel)
        {
            if (Session["LoggedIn"] == null || Session["LoggedIn"].Equals(false))
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }

            var customerModelBLL = new CustomerModelBLL()
            {
                FirstName = customerViewModel.FirstName,
                LastName = customerViewModel.LastName,
                Email = customerViewModel.Email,
                Password = customerViewModel.Password,
            };

            var result = _customerUsersLogic.Create(customerModelBLL);
            if (result)
            {
                TempData["SuccessMessage"] = "Customer created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Could not create customer";
                return RedirectToAction("EditOrCreateCustomer");
            }
        }


        /// <summary>
        /// Method for updating a customer
        /// </summary>
        /// <param name="customerViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PutCustomer(CustomerViewModel customerViewModel)
        {
            if (Session["LoggedIn"] == null || Session["LoggedIn"].Equals(false))
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }

            var customerModelBLL = new CustomerModelBLL()
            {
               Email = customerViewModel.Email,
               FirstName = customerViewModel.FirstName,
               LastName = customerViewModel.LastName,
            };

            if(customerViewModel.Password != null)
            {
                customerModelBLL.Password = customerViewModel.Password;
            }

            var result = _customerUsersLogic.Update(customerModelBLL);
            if (result)
            {
                TempData["SuccessMessage"] = "Customer updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Could not update customer";
                return RedirectToAction("EditOrCreateMovie", customerViewModel.Email);
            }
        }



        /// <summary>
        /// This controller action returns a view which make it possible to edit or create a customer
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [Route("CustomerAdministration/EditOrCreateCustomer/{email}")]
        public ActionResult EditOrCreateCustomer(string email = "")
        {
            if (Session["LoggedIn"] == null || Session["LoggedIn"].Equals(false))
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }

            if (email == null || email.Equals("") )
            {
                return View(new CustomerViewModel());
            }

            var customer = _customerUsersLogic.Get(email);
            if (customer != null)
            {
                var customerViewModel = ModelMapper.MapFromCustomerModelBLLToCustomerViewModel(customer);
                return View(customerViewModel);
            }
            else
            {
                return View(new CustomerViewModel());
            }
        }

        /// <summary>
        /// Method for deleting a customer
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Delete(string userName)
        {
            if (Session["LoggedIn"] == null || Session["LoggedIn"].Equals(false))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            var result = _customerUsersLogic.Delete(userName);

            if (result)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}