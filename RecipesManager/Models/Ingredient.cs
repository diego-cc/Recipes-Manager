﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace RecipesManager.Models
{
    /// <summary>
    /// Ingredient model class, based on <see cref="RecipesData.Models.Ingredient"/>
    /// </summary>
    [Serializable()]
    class Ingredient : INotifyPropertyChanged, IEquatable<Ingredient>, ISerializable
    {
        private int id;
        private string name;

        public Ingredient() { }
        public Ingredient(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        protected Ingredient(SerializationInfo info, StreamingContext context)
        {
            Id = (int)info.GetValue("Id", typeof(int));
            Name = (string)info.GetValue("Name", typeof(string));
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

        #region ISerializable
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Name", Name);
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

        [field:NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
