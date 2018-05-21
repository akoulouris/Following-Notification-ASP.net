
using AutoMapper;
using CieTrade.Dtos;
using CieTrade.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CieTrade.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notification = _context.UserNotifications
                .Where(um => um.UserId == userId && !um.Isread )
                .Select(um => um.Notification)
                .Include(n => n.Card.UserProfessionals)
                .ToList();
            return notification.Select(Mapper.Map<Notification, NotificationDto>);
            //you can change the bellow lamda exresion with autoMapper
            //    return notification.Select(n => new NotificationDto() {

            //        DateTime = n.DateTime,
            //        Card =new CardDto()
            //        {
            //            UserProfessionals =new UserDto()
            //            {
            //                Id = n.Card.UserProfessionals.Id,
            //                Name = n.Card.UserProfessionals.Name
            //            },
            //            DateTime = n.Card.DateTime,
            //            Id = n.Card.Id,
            //            IsCanceled = n.Card.IsCanceled,
            //            Description = n.Card.Description
            //        },
            //        OriginalDateTime =n.OriginalDateTime,
            //        OriginalDescription = n.OriginalDescription,
            //        Type=n.Type


            //    });
        }
    }
}
