using CieTrade.Models;
using CieTrade.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CieTrade.ViewModels
{
    public class CardController : Controller
    {
        private readonly ApplicationDbContext _context;
        // GET: Card
        public CardController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Mine()
        {
            var userid = User.Identity.GetUserId();

            var cards = _context.Cards
                .Where(g => g.UserProfessionalsId == userid && g.DateTime > DateTime.Now && !g.IsCanceled)
                .Include(g => g.Profession)
                //.Include(g => g.Description)
                .ToList();
            return View(cards);
        }

                
        [Authorize] 
        public ActionResult Following()
        {
            var userID = User.Identity.GetUserId();
            var mycards = _context.Followers
                .Where(a => a.FollowerId == userID)
                .Select(a => a.Card)
                .Include(g => g.UserProfessionals)
                .Include(g => g.Profession)
                .ToList();
                var viewModel = new HomeViewModel
                {
                    ShowCards = mycards,
                    ShowAction = User.Identity.IsAuthenticated
                };
            return View(viewModel);
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CardFormViewModel
            {
                Professions = _context.Professions.ToList(),
                Heading = "Add a card"
            };

            return View("CardForm",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var userid = User.Identity.GetUserId();
            var card = _context.Cards.Single(g => g.Id == id && g.UserProfessionalsId == userid);

            var viewModel = new CardFormViewModel
            {
                Professions = _context.Professions.ToList(),
                Id = card.Id,
                Date = card.DateTime.ToString("d MMM yyyy"),
                Time = card.DateTime.ToString("HH:mm"),
                Profession = card.ProfessionId,
                Description = card.Description,
                Heading = "Edit a card"
            };

            return View("CardForm", viewModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(CardFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {

                viewModel.Professions = _context.Professions.ToList();
                return View("CardForm", viewModel);
            }
            //var userProfessionalsId = User.Identity.GetUserId();
            //var userProfessionals = _context.Users.Single(u => u.Id == userProfessionalsId);
            //var profession = _context.Professions.Single(u => u.Id == viewModel.Profession);
            var card = new Card
            {
                UserProfessionalsId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                ProfessionId = viewModel.Profession,
                Description = viewModel.Description

            };
            _context.Cards.Add(card);
            _context.SaveChanges();
            return RedirectToAction("Mine", "Card");
         }

        [Authorize]
        [HttpPost]
        public ActionResult Update(CardFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {

                viewModel.Professions = _context.Professions.ToList();
                return View("CardForm", viewModel);
            }
            //var userProfessionalsId = User.Identity.GetUserId();
            //var userProfessionals = _context.Users.Single(u => u.Id == userProfessionalsId);
            //var profession = _context.Professions.Single(u => u.Id == viewModel.Profession);
            var userId = User.Identity.GetUserId();
            var card = _context.Cards
                .Include(g => g.Followers.Select(a => a.Follower))
                .Single(g => g.Id == viewModel.Id && g.UserProfessionalsId == userId);

            card.Modify(viewModel.GetDateTime(), viewModel.Description, viewModel.Profession);

            //card.Description = viewModel.Description;
            //card.DateTime = viewModel.GetDateTime();
            //card.ProfessionId = viewModel.Profession;
            
            _context.SaveChanges();
            return RedirectToAction("Mine", "Card");
        }
    }
}