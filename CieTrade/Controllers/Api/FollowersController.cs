using CieTrade.Dtos;
using CieTrade.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CieTrade.ViewModels.Api
{

    
    [Authorize]
    public class FollowersController : ApiController
    {
        private readonly ApplicationDbContext _context;
        // GET: Card
        public FollowersController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        
        //public IHttpActionResult Follow([FromBody] int cardId)
        public IHttpActionResult Follow(FollowDto dto)
        {
            var userId = User.Identity.GetUserId();
            var exists = _context.Followers.Any(a=>a.FollowerId == userId && a.CardId == dto.CardId);

            if(exists)
            {
                return BadRequest("you are already follow");
            }
            var follower = new Follow
            {
                CardId = dto.CardId,
                FollowerId = userId
            };
            _context.Followers.Add(follower);
            _context.SaveChanges();

            return Ok();
        }
    }
}
