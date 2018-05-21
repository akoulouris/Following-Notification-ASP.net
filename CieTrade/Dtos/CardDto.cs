using CieTrade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CieTrade.Dtos
{
    public class CardDto
    {

        public int Id { get; set; }

        public bool IsCanceled { get;  set; }

        public UserDto UserProfessionals { get; set; }

        
        public string Description { get; set; }


        public DateTime DateTime { get; set; }


        public ProfessionDto Profession { get; set; }

       
    }
}