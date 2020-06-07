using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace RecipesManager.Models
{
    /// <summary>
    /// Recipe model class, based on <see cref="RecipesData.Models.Recipe"/>
    /// </summary>
    [Serializable()]
    class Recipe : INotifyPropertyChanged, IEquatable<Recipe>, IComparable<Recipe>, ISerializable
    {
        private int id;
        private int categoryId;
        private string name;
        private string method;
        private int serves;
        private int? preparationTime;
        private int? kcalPerServe;
        private bool? favourite;

        public Recipe() { }

        public Recipe(int Id, int CategoryId, string Name, string Method, int Serves, int? PreparationTime, int? KcalPerServe, bool? Favourite, Category category)
        {
            this.Id = Id;
            this.CategoryId = CategoryId;
            this.Name = Name;
            this.Method = Method;
            this.Serves = Serves;
            this.PreparationTime = PreparationTime;
            this.KcalPerServe = KcalPerServe;
            this.Favourite = Favourite;
            this.Category = category;
        }

        protected Recipe(SerializationInfo info, StreamingContext context)
        {
            Id = (int)info.GetValue("Id", typeof(int));
            Name = (string)info.GetValue("Name", typeof(string));
            Method = (string)info.GetValue("Method", typeof(string));
            PreparationTime = (int?)info.GetValue("PreparationTime", typeof(int?));
            KcalPerServe = (int?)info.GetValue("KcalPerServe", typeof(int?));
            Serves = (int)info.GetValue("Serves", typeof(int));
            Favourite = (bool?)info.GetValue("Favourite", typeof(bool));
            CategoryId = (int)info.GetValue("CategoryId", typeof(int));
            Category = (Category)info.GetValue("Category", typeof(Category));
        }

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

        public bool? Favourite
        {
            get => favourite;
            set
            {
                if (favourite != value)
                {
                    favourite = value;
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

        public int CompareTo(Recipe other)
        {
            if (other != null)
            {
                return this.Category.CompareTo(other.Category);
            }

            return 0;
        }

        #region INotifyPropertyChanged

        [field:NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region ISerializable
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Name", Name);
            info.AddValue("Method", Method);
            info.AddValue("PreparationTime", PreparationTime);
            info.AddValue("KcalPerServe", KcalPerServe);
            info.AddValue("Serves", Serves);
            info.AddValue("Favourite", Favourite);
            info.AddValue("CategoryId", CategoryId);
            info.AddValue("Category", Category);
        }
        #endregion
    }
}
