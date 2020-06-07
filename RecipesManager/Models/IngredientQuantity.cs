using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace RecipesManager.Models
{
    /// <summary>
    /// Ingredient quantity model class, based on <see cref="RecipesData.Models.IngredientQuantity"/>
    /// </summary>
    [Serializable()]
    class IngredientQuantity : INotifyPropertyChanged, IEquatable<IngredientQuantity>, ISerializable
    {
        private int id;
        private int ingredientId;
        private int recipeId;
        private string quantity = "";
        private decimal? amount = 0;

        private Ingredient ingredient;
        private Recipe recipe;

        public IngredientQuantity() { }

        public IngredientQuantity(int Id, int IngredientId, int RecipeId, string Quantity, decimal? Amount)
        {
            this.Id = Id;
            this.IngredientId = IngredientId;
            this.RecipeId = RecipeId;
            this.Quantity = Quantity;
            this.Amount = Amount;
        }

        protected IngredientQuantity(SerializationInfo info, StreamingContext context)
        {
            Id = (int)info.GetValue("Id", typeof(int));
            IngredientId = (int)info.GetValue("IngredientId", typeof(int));
            RecipeId = (int)info.GetValue("RecipeId", typeof(int));
            Quantity = (string)info.GetValue("Quantity", typeof(string));
            Amount = (decimal?)info.GetValue("Amount", typeof(decimal?));
            Ingredient = (Ingredient)info.GetValue("Ingredient", typeof(Ingredient));
            Recipe = (Recipe)info.GetValue("Recipe", typeof(Recipe));
        }

        public int Id
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }

        public int IngredientId
        {
            get => ingredientId;
            set
            {
                if (ingredientId != value)
                {
                    ingredientId = value;
                    OnPropertyChanged();
                }
            }
        }

        public int RecipeId
        {
            get => recipeId;
            set
            {
                if (recipeId != value)
                {
                    recipeId = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Quantity
        {
            get => quantity;
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal? Amount
        {
            get => amount;
            set
            {
                if (amount != value)
                {
                    amount = value;
                    OnPropertyChanged();
                }
            }
        }

        public Ingredient Ingredient
        {
            get => ingredient;
            set
            {
                if (ingredient != value)
                {
                    ingredient = value;
                    OnPropertyChanged();
                }
            }
        }

        public Recipe Recipe
        {
            get => recipe;
            set
            {
                if (recipe != value)
                {
                    recipe = value;
                    OnPropertyChanged();
                }
            }
        }

        #region ToString
        public override string ToString()
        {
            return $"{Ingredient.Name} in {Recipe.Name}: Amount: {Amount}, Quantity: {Quantity}";
        }
        #endregion

        #region Equals

        public override bool Equals(object obj)
        {
            return Equals(obj as IngredientQuantity);
        }

        public bool Equals(IngredientQuantity other)
        {
            return other != null &&
                   id == other.id &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            int hashCode = -1496434976;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(IngredientQuantity left, IngredientQuantity right)
        {
            return EqualityComparer<IngredientQuantity>.Default.Equals(left, right);
        }

        public static bool operator !=(IngredientQuantity left, IngredientQuantity right)
        {
            return !(left == right);
        }
        #endregion

        #region ISerializable
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("IngredientId", IngredientId);
            info.AddValue("RecipeId", RecipeId);
            info.AddValue("Quantity", Quantity);
            info.AddValue("Amount", Amount);
            info.AddValue("Ingredient", Ingredient);
            info.AddValue("Recipe", Recipe);
        }
        #endregion

        #region INotifyPropertyChanged
        [field:NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
