using BLL;
using filmsite.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace filmsite.Controllers
{
    public class FAQController : Controller
    {
        private FAQLogic FaqLogic;
        public FAQController()
        {
            FaqLogic = new FAQLogic();
        }
        public ActionResult Index()
        {
            var allQuestions = new List<FAQModelDAL>();
            allQuestions = FaqLogic.GetSorted();
            return View(allQuestions);
        }
        public ActionResult UpVote(int ID)
        {
            FaqLogic.UpVote(ID);
            return RedirectToAction("Index");
        }
        public ActionResult DownVote(int ID)
        {
            FaqLogic.DownVote(ID);
            return RedirectToAction("Index");
        }

    }
}