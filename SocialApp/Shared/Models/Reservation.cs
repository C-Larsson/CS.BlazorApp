using System.ComponentModel.DataAnnotations.Schema;
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Shared.Models
{

    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Cancelled,
        Waitlist
    };

    public enum PaymentStatus
    {
        Unpaid,
        Pending,
        Paid,
        Refunded,
        NoFees,
    };


    public class Reservation
    {
        public int Id { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int AttendeeCount { get; set; } = 1;
        public string SpecialRequest { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; } = 0;
        public CurrencyCode? CurrencyCode { get; set; } = null;

        public DateTime ReservationDate { get; set; } = DateTime.Now;
        public DateTime? PaymentDate { get; set; }

        public ReservationStatus ReservationStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set;}

    }
}
