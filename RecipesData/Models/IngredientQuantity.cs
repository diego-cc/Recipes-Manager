using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesData.Models
{
    public class IngredientQuantity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Column(Order = 1)]
        [Index("IX_IngredientId", 1)]
        public int IngredientId { get; set; }
        
        [Column(Order = 2)]
        [Index("IX_RecipeId", 2)]
        public int RecipeId { get; set; }

        public string Quantity { get; set; } = "";

        public decimal? Amount { get; set; } = 0;

        [ForeignKey("IngredientId")]
        public virtual Ingredient Ingredient { get; set; }

        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }
    }
}
