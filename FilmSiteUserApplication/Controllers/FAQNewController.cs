using BLL;
using filmsite.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace filmsite.Controllers
{
    public class FAQNewController : Controller
    {
        private FAQLogic FaqLogic;
        public FAQNewController()
        {
            FaqLogic = new FAQLogic();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateQuestion(FAQModelDAL model)
        {
            if (model.Question.Length > 0 && model.Question.Length != null)
            {
                var newQuestion = new FAQModelDAL
                {
                    Question = model.Question,
                    Answer = "",
                    UserSubmitted = true,
                    Score = 0
                };
                FaqLogic.Create(newQuestion);
            }

            return RedirectToRoute(new
            {
                controller = "FAQ",
                action = "Index"
            });
        }
    }
}