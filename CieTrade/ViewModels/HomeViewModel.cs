using System.Collections.Generic;
using System.Linq;
using CieTrade.Models;
using Newtonsoft.Json.Linq;

namespace CieTrade.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Card> ShowCards { get; set; }
        public bool ShowAction { get; set; }
    }
}