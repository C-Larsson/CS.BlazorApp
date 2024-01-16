using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SocialApp.Shared.Models.Tables
{
    public class Image
    {
        public int Id { get; set; }
        public string Data { get; set; } = string.Empty;
    }
}
