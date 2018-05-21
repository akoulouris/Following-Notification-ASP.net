using AutoMapper;
using CieTrade.Dtos;
using CieTrade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CieTrade.App_Start
{
    public class MapperProfile:Profile
    {

        public MapperProfile()
        { 

            CreateMap<Card, CardDto>();
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<Notification, NotificationDto>();   
        }
    }
}