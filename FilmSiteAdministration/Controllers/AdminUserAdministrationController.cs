using FilmSiteAdministration.BLL;
using Model;
using Model.BLL;
using Model.ViewModels;
using System.Web.Mvc;

namespace FilmSiteAdministration.Controllers
{
    public class AdminUserAdministrationController : Controller
    {
        private AdminUserLogic _adminUserLogic;

        public AdminUserAdministrationController()
        {
            _adminUserLogic = new AdminUserLogic();
        }

        // GET: AdminUser
        public ActionResult Index()
        {
            if (Session["LoggedIn"] == null || Session["LoggedIn"].Equals(false))
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }

            var adminUsersBLL = _adminUserLogic.GetAll();
            var mappedUsers =  ModelMapper.MapFromListOfAdminUsersBLLToListOfAdminUsersViewModel(adminUsersBLL);
            return View(mappedUsers);
        }

        /// <summary>
        /// Method for creating an admin
        /// </summary>
        /// <param name="adminUserViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostAdminUser(AdminUserViewModel adminUserViewModel)
        {
            if (Session["LoggedIn"] == null || Session["LoggedIn"].Equals(false))
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }

            var adminUserBLL = new AdminUserModelBLL()
            {
                UserName = adminUserViewModel.UserName,
                Password = adminUserViewModel.Password
            };

            var result = _adminUserLogic.RegisterAdminUser(adminUserBLL);
            if (result)
            {
                TempData["SuccessMessage"] = "Admin user created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Could not create admin user";
                return RedirectToAction("EditOrCreateAdminUser");
            }
        }


        /// <summary>
        /// Method for updating a customer
        /// </summary>
        /// <param name="customerViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PutAdminUser(AdminUserViewModel adminUserViewModel)
        {
            if (Session["LoggedIn"] == null || Session["LoggedIn"].Equals(false))
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }

            var adminUserBLL = new AdminUserModelBLL()
            {
                UserName = adminUserViewModel.UserName,
                Password = adminUserViewModel.Password
            };

            var result = _adminUserLogic.Update(adminUserBLL);
            if (result)
            {
                TempData["SuccessMessage"] = "Admin updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Could not update admin user";
                return RedirectToAction("EditOrCreateMovie", adminUserBLL.UserName);
            }
        }

        /// <summary>
        /// This controller action returns a view which make it possible to edit or create an admin
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [Route("AdminUserAdministration/EditOrCreateAdminUser/{email}")]
        public ActionResult EditOrCreateAdminUser(string email = "")
        {
            if (Session["LoggedIn"] == null || Session["LoggedIn"].Equals(false))
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }

            if (email == null || email.Equals(""))
            {
                return View(new AdminUserViewModel() { UserName= "", Password = "", RepeatPassword = ""});
            }

            var adminUser = _adminUserLogic.Get(email);
            if (adminUser != null)
            {
                var adminViewModel = new AdminUserViewModel()
                {
                    UserName = adminUser.UserName
                };
                return View(adminViewModel);
            }
            else
            {
                return View(new AdminUserViewModel());
            }
        }


        /// <summary>
        /// Method for deleting an adminUser
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

            var result = _adminUserLogic.Delete(userName);

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