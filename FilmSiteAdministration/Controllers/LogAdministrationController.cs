using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmSiteAdministration.Controllers
{
    public class LogAdministrationController : Controller
    {
        private LogAdministrationLogic _logAdministrationLogic;

        public LogAdministrationController()
        {
            _logAdministrationLogic = new LogAdministrationLogic();
        }

        public ActionResult Index()
        {
            return View(_logAdministrationLogic.GetAll());
        }
    }
}