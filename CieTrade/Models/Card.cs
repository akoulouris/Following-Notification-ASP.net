using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CieTrade.Models
{
    public class Card
    {
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }

        public ApplicationUser UserProfessionals { get; set; }

        [Required]
        public string UserProfessionalsId { get; set; }


        [Required]
        public string Description { get; set; }


        public DateTime DateTime { get; set; }


        public Profession Profession { get; set; }

        [Required]
        public byte ProfessionId { get; set; }

        public ICollection<Follow> Followers { get; private set; }

        public Card()
        {
            Followers = new Collection<Follow>();
        }

        public void Cancel()
        {
            this.IsCanceled = true;
            var notification =  Notification.CardCancel(this);
            foreach (var follower in this.Followers.Select(g => g.Follower))
            {
                follower.Notify(notification);
            }
        }

        public void Modify(DateTime dateTime, string description, byte profession)
        {
            var notification =  Notification.CardUpdated(this , DateTime ,Description);
           
            Description = description;
            DateTime = dateTime;
            ProfessionId = profession;
            foreach (var follower in this.Followers.Select(g => g.Follower))
            {
                follower.Notify(notification);
            }
        }

    }
}