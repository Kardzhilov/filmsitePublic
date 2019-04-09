using BLL;
using filmsite.Models;
using Model;
using System.Web.Mvc;

namespace filmsite.Controllers
{
    public class MyPageController : Controller
    {
        private CustomerUsersLogic _customerUserLogic;

        public MyPageController()
        {
            _customerUserLogic = new CustomerUsersLogic();
        }

        public ActionResult Index()
        {
             var username = Session["username"];

             if(username == null)
             {
                return RedirectToRoute("~/Home/LogInModal");
             }

            var customer = _customerUserLogic.Get(username.ToString());
            return View(ModelMapper.MapFromCustomerModelBLLToCustomerViewModel(customer));
        }

        public ActionResult ChangedUser(User changedUser)
        {
            return RedirectToAction("Index", changedUser);
        }
    }
}