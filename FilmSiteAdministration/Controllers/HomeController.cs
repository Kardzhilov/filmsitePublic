using FilmSiteAdministration.Model;
using FilmSiteAdministration.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.ViewModels;
using Model;

namespace FilmSiteAdministration.Controllers
{
    public class HomeController : Controller
    {
        private AdminUserLogic _adminUserLogic;

        public HomeController()
        {
            _adminUserLogic = new AdminUserLogic();
        }

        public ActionResult Index()
        {
            if (Session["LoggedIn"] == null)
            {
                Session["LoggedIn"] = false;
                ViewBag.LoggedIn = false;
            }
            else
            {
                ViewBag.LoggedIn = (bool)Session["LoggedIn"];
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(AdminUserLoginViewModel userInput)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Please make sure all fields are filled out correctly";
                return View();
            }

            bool isLoggedIn = _adminUserLogic.CheckLoginCredentials(ModelMapper.MapFromAdminUserViewModelToAdminUserModelBLL(userInput));

            Session["LoggedIn"] = isLoggedIn;
            ViewBag.LoggedIn = isLoggedIn;

            if (!isLoggedIn) ViewBag.Message = "Wrong username or password";

            return View();
        }

        public ActionResult LogOut()
        {
            Session["LoggedIn"] = false;
            ViewBag.LoggedIn = false;
            return RedirectToAction("Index");
        }
    }
}