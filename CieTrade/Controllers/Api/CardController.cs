using CieTrade.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace CieTrade.Controllers.Api
{
    [Authorize]
    public class CardController : ApiController
    {
        private readonly ApplicationDbContext _context;
        
        public CardController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var card = _context.Cards
                .Include(g => g.Followers.Select(a => a.Follower))
                .Single(a => a.Id == id && a.UserProfessionalsId == userId);

            if (card.IsCanceled)
            {
                return NotFound();
            }
            card.Cancel();
           
            //{
            //    DateTime = DateTime.Now,
            //    Card = card,
            //    Type = NotificationType.CardCanceled

            //};

            //var followers = _context.Followers
            //    .Where(a => a.CardId == card.Id)
            //    .Select(a => a.Follower).ToList();


            

            //foreach (var follower in card.Followers.Select(g => g.Follower))
            //{
            //    follower.Notify(notification);
            //    //var userNotification = new UserNotification
            //    //{
            //    //    User = follower,
            //    //    Notification =notification
            //    //};
            //    //_context.UserNotifications.Add(userNotification);
            //    //_context.SaveChanges();
            //}
            _context.SaveChanges();

            return Ok();
        }
    }
}
