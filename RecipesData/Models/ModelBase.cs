using System;

namespace RecipesData.Models
{
    public class ModelBase
    {
        public DateTime? CreatedAt { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("W. Australia Standard Time"));
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
