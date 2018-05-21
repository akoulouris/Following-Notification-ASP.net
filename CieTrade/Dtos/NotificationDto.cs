using CieTrade.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CieTrade.Dtos
{
    public class NotificationDto
    {
       
        public DateTime DateTime { get;  set; }
        public NotificationType Type { get;  set; }
        public DateTime? OriginalDateTime { get;  set; }
        public string OriginalDescription { get;  set; }
        public CardDto Card { get;  set; }
    }
}