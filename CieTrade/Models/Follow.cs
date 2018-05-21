using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CieTrade.Models
{
    public class Follow
    {
        public Card Card { get; set; }
        public ApplicationUser Follower { get; set; }

        [Key]
        [Column(Order = 1)]
        public int CardId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string FollowerId { get; set; }
    }
}