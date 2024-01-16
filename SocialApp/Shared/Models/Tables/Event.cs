
#pragma warning disable 8618

using SocialApp.Shared.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SocialApp.Shared.Models.Tables
{

    public class Event
    {

        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;

        public int HostId { get; set; }
        // public User Host { get; set; }

        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public int LocationId { get; set; }
        public virtual Location? Location { get; set; }

        //public int? EventSeriesId { get; set; } = null;
        public EventSeries? EventSeries { get; set; } = null;

        //public int? AddressId { get; set; } = null;
        public virtual Address? Address { get; set; } = null;

        [Required, FutureDate]
        public DateTime StartDate { get; set; }

        [Required, FutureDate]
        public DateTime EndDate { get; set; }

        public string? ImageUrl { get; set; }
        public virtual List<Image>? Images { get; set; } = new List<Image>();

        public string PageUrl { get; set; } = string.Empty;  //$"{Title.ToLower().Replace(" ", "-")}-{DateTime.Now.Ticks}";

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } = 0.00M;
        public CurrencyCode? CurrencyCode { get; set; } = null;

        public int AttendeeCount { get; set; } = 0;
        public int MaxAttendees { get; set; } = 0;

        public List<User>? Attendees { get; set; } = new List<User>();
        public virtual List<EventMessage>? Messages { get; set; } = new List<EventMessage>();

        public bool Featured { get; set; } = false;
        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;


    }
}
