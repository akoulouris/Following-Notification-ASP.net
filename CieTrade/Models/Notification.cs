using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CieTrade.Models
{
    public class Notification
    {

        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalDescription { get; private  set; }

        [Required]
        public Card Card { get; private set; }

        protected Notification()
        {

        }

        private Notification(NotificationType type,Card card)
        {
            if (card == null)
                throw new ArgumentNullException("card");

            DateTime = DateTime.Now;
            Card = card;
            Type = type;
        }

        public static Notification CardCreated(Card card)
        {
            return new Notification(NotificationType.CardCreated, card);
        }

        public static Notification CardUpdated(Card newCard, DateTime originalDateTime, string originalDescription)
        {
            var notification= new Notification(NotificationType.CardUpdated, newCard);
            notification.OriginalDateTime = originalDateTime;
            notification.OriginalDescription = originalDescription;
            return notification;
        }

        public static Notification CardCancel(Card card)
        {
            return new Notification(NotificationType.CardCanceled, card);
        }
    }
}