using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.Shared.Models
{
    public class PaymentRequest
    {

        public PaymentRequest(List<Reservation> reservations)
        { 
            foreach (var reservation in reservations)
            {
                Reservations.Add(reservation.Id);
            }   
        }

        public List<int> Reservations { get; set; } = new List<int>();


    }
}
