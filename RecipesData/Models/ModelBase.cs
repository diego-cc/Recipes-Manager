using System;

namespace RecipesData.Models
{
    /// <summary>
    /// Contains properties common to all entities
    /// Note: Timestamps are currently not quite working, they can be a little bit tricky to implement since EF does not support them out of the box with the code-first approach
    /// </summary>
    public class ModelBase
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
