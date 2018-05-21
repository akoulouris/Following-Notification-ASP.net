using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace CieTrade.ViewModels
{
    public class CardFormViewModel
    {
        public int Id { get; set; }


        [Required]
        public string Description { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Profession { get; set; }

        public string Heading { get; set; }
        public string Action {
            get
            {
                Expression<Func<CardController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<CardController, ActionResult>> create = (c => c.Create(this));
                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
               // return (Id != 0) ? "Update" : "Create";
            }
        }

        public IEnumerable<Models.Profession> Professions { get; set; }
        public DateTime GetDateTime()
        {
            
                return DateTime.Parse(string.Format("{0} {1}", Date, Time));
            
        }
    }
}