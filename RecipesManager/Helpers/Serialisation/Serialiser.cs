using RecipesManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace RecipesManager.Helpers.Serialisation
{
    /// <summary>
    /// Serialises collections of models
    /// <para>Only binary output is supported for now</para>
    /// </summary>
    public class Serialiser
    {
        public string FileName { get; set; }
        public ISerializable ObjectToSerialise { get; set; }

        private List<Recipe> recipes;
        private List<Ingredient> ingredients;
        private List<IngredientQuantity> ingredientQuantities;
        private List<Category> categories;

        public Serialiser() { }

        public Serialiser(string fileName, ISerializable objectToSerialise)
        {
            ObjectToSerialise = objectToSerialise;
            FileName = fileName;
        }

        public Serialiser(ISerializable objectToSerialise) : this("", objectToSerialise) { }

        internal Serialiser(string fileName, List<Recipe> recipes)
        {
            this.recipes = recipes;
            this.FileName = fileName;
        }

        internal Serialiser(string fileName, List<Recipe> recipes, List<Ingredient> ingredients, List<Category> categories, List<IngredientQuantity> iq)
        {
            this.FileName = fileName;
            this.recipes = recipes;
            this.ingredients = ingredients;
            this.categories = categories;
            this.ingredientQuantities = iq;
        }

        /// <summary>
        /// Starts the serialisation process
        /// <para>If no filename is provided, the data will be saved as "serialised.bin" in the bin/Debug directory</para>
        /// </summary>
        /// <returns>Result of the operation</returns>
        public bool Serialise()
        {
            Stream stream;

            try
            {
                if (string.IsNullOrWhiteSpace(FileName))
                {
                    FileName = "serialised.bin";
                }

                stream = File.Open(FileName, FileMode.Create);
                BinaryFormatter b = new BinaryFormatter();

                // Merge all models into a single list of objects
                List<object> merged = recipes.Cast<object>().Concat(ingredientQuantities.Cast<object>().ToList()).Concat(ingredients.Cast<object>().ToList()).Concat(categories.Cast<object>().ToList()).ToList();

                b.Serialize(stream, merged);

                stream.Close();
                return true;
            }
            catch(SerializationException e)
            {
                Console.WriteLine("Serialisation exception: could not serialise object");
                Console.WriteLine(e.Message);

                return false;
            }
            catch(IOException e)
            {
                Console.WriteLine("I/O exception: could not create file to serialise object");
                Console.WriteLine(e.Message);

                return false;
            }
            catch(UnauthorizedAccessException e)
            {
                Console.WriteLine("Unauthorised access exception: insufficient file system permissions");
                Console.WriteLine(e.Message);

                return false;
            }
            catch(Exception e)
            {
                Console.WriteLine("Could not serialise object");
                Console.WriteLine(e.Message);

                return false;
            }
        }
    }
}
