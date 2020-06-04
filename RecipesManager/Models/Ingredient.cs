using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RecipesManager.Models
{
    class Ingredient : INotifyPropertyChanged, IEquatable<Ingredient>
    {
        private int id;
        private string name;

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

        #region ToString
        public override string ToString()
        {
            return Name;
        }
        #endregion

        #region Equals

        public override bool Equals(object obj)
        {
            return Equals(obj as Ingredient);
        }

        public bool Equals(Ingredient other)
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

        public static bool operator ==(Ingredient left, Ingredient right)
        {
            return EqualityComparer<Ingredient>.Default.Equals(left, right);
        }

        public static bool operator !=(Ingredient left, Ingredient right)
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
