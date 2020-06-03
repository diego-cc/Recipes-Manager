using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RecipesManager.Models
{
    class IngredientQuantity : INotifyPropertyChanged, IEquatable<IngredientQuantity>
    {
        private int id;
        private int ingredientId;
        private int recipeId;
        private string quantity;
        private decimal? amount;

        private Ingredient ingredient;
        private Recipe recipe;

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


        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion
    }
}
