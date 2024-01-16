
namespace SocialApp.Shared.Models
{
    public class EventReservation
    {

        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime DateApplied { get; set; } = DateTime.Now;
        public bool IsApproved { get; set; } = false;
        public bool Paid { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

    }
}
