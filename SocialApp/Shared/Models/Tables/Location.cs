using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.Shared.Models.Tables
{
    public class Location
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string City { get; set; } = string.Empty;

        public string? State { get; set; } = null;

        public string Country { get; set; } = string.Empty;

        public string CountryCode { get; set; } = string.Empty;

        [Column(TypeName = "decimal(9,6)")]
        public decimal? Latitude { get; set; }
        [Column(TypeName = "decimal(9,6)")]
        public decimal? Longitude { get; set; }

    }
}
