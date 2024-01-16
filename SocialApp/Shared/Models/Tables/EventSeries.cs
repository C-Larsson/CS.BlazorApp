using SocialApp.Shared.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace SocialApp.Shared.Models.Tables

#pragma warning disable 8618
{
    /// <summary>
    /// 
    /// </summary>
    public class EventSeries
    {
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int HostId { get; set; }
        //public User Host { get; set; }

        [Required, MaxLength(30)]
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;

        [Required, MaxLength(30)]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        [Required, FutureDate]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int SeriesFrequency { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
        public string PageUrl { get; set; } = string.Empty;  //$"{Title.ToLower().Replace(" ", "-")}-{DateTime.Now.Ticks}";

        [Column(TypeName = "decimal(18,2)")]
        public double Price { get; set; }
        public string Currency { get; set; } = string.Empty;

        [Range(1, 1000)]
        public int MaxAttendees { get; set; }

        //public ICollection<Event> Events { get; set; } = new List<Event>();

        public bool Visible { get; set; } = true;

        public bool Deleted { get; set; } = false;

        [NotMapped]
        public bool Editing { get; set; } = false;

        [NotMapped]
        public bool IsNew { get; set; } = false;


    }
}
