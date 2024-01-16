using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Shared.Models
{
    public class EventSearchResult
    {
        public List<Event> Events { get; set; } = new List<Event>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
