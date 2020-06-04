using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesData.Models
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public virtual string Name { get; set; }

        [Column(TypeName = "TEXT")]
        public string Method { get; set; } = "Instructions currently not available";

        public int Serves { get; set; } = 1;

        public int? PreparationTime { get; set; }

        public int? KcalPerServe { get; set; }

        public virtual Category Category { get; set; }
    }
}
