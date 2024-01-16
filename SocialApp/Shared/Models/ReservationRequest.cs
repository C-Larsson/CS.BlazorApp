using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.Shared.Models
{
    public class ReservationRequest
    {
        public int EventId { get; set; }
        public int TicketCount { get; set; }
    }
}
