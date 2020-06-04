using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RecipesManager.Models
{
    class Recipe : INotifyPropertyChanged, IEquatable<Recipe>
    {
        private int id;
        private int categoryId;
        private string name;
        private string method;
        private int serves;
        private int? preparationTime;
        private int? kcalPerServe;

        private Category category;

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

        public int CategoryId
        {
            get => categoryId;
            set
            {
                if (categoryId != value)
                {
                    categoryId = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Method
        {
            get => method;
            set
            {
                if (method != value)
                {
                    method = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Serves
        {
            get => serves;
            set
            {
                if (serves != value)
                {
                    serves = value;
                    OnPropertyChanged();
                }
            }
        }

        public int? PreparationTime
        {
            get => preparationTime;
            set
            {
                if (preparationTime != value)
                {
                    preparationTime = value;
                    OnPropertyChanged();
                }
            }
        }

        public int? KcalPerServe
        {
            get => kcalPerServe;
            set
            {
                if (KcalPerServe != value)
                {
                    kcalPerServe = value;
                    OnPropertyChanged();
                }
            }
        }

        public Category Category
        {
            get => category;
            set
            {
                if (category != value)
                {
                    category = value;
                    OnPropertyChanged();
                }
            }
        }

        #region ToString
        public override string ToString()
        {
            return Name;
        }
        #endregion

        #region Equals

        public override bool Equals(object obj)
        {
            return Equals(obj as Recipe);
        }

        public bool Equals(Recipe other)
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

        public static bool operator ==(Recipe left, Recipe right)
        {
            return EqualityComparer<Recipe>.Default.Equals(left, right);
        }

        public static bool operator !=(Recipe left, Recipe right)
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
