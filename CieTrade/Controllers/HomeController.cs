using CieTrade.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CieTrade.ViewModels
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _content;

        public HomeController()
        {
            _content = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var card = _content.Cards
                .Include(g => g.UserProfessionals)
                .Include(g => g.Profession)
                .Where(g => !g.IsCanceled);

            var viewModel = new HomeViewModel
            {
                ShowCards = card,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }

        public ActionResult HelloAjax()
        {
            var card2 = _content.Cards
                .Select(x => new { UserProfessionals = x.UserProfessionals.Name, x.Id , x.Profession.Name , x.DateTime}).ToList(); 
            return Json(card2,JsonRequestBehavior.AllowGet);
            //return Content("hello Ajax", "text/plain");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}