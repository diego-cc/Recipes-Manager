using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesData.Models
{
    /// <summary>
    /// Ingredient entity
    /// </summary>
    public class Ingredient : ModelBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}
