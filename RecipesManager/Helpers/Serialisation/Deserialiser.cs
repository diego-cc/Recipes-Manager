using RecipesManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RecipesManager.Helpers.Serialisation
{
    /// <summary>
    /// Manages deserialisations
    /// <para>Currently only supports from binary to collections of models</para>
    /// </summary>
    class Deserialiser
    {
        public string FileName { get; set; }
        public ISerializable DeserialisedObject { get; set; }

        public List<Recipe> DeserialisedRecipes { get; set; } = new List<Recipe>();
        public List<IngredientQuantity> DeserialisedIngredientQuantities { get; set; } = new List<IngredientQuantity>();
        public List<Ingredient> DeserialisedIngredients { get; set; } = new List<Ingredient>();
        public List<Category> DeserialisedCategories { get; set; } = new List<Category>();

        public Deserialiser() { }

        public Deserialiser(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Starts the deserialisation process. It is assumed that a valid file path is provided.
        /// <para>Maps raw binary data to entities</para>
        /// </summary>
        /// <returns>Result of the operation</returns>
        public bool Deserialise()
        {
            Stream stream;

            try
            {
                stream = File.Open(FileName, FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                object raw = binaryFormatter.Deserialize(stream);
                List<object> rawData = raw as List<object>;

                foreach (var obj in rawData)
                {
                    if (obj != null)
                    {
                        if (obj is Recipe)
                        {
                            DeserialisedRecipes.Add(obj as Recipe);
                        }

                        if (obj is IngredientQuantity)
                        {
                            DeserialisedIngredientQuantities.Add(obj as IngredientQuantity);
                        }

                        if (obj is Ingredient)
                        {
                            DeserialisedIngredients.Add(obj as Ingredient);
                        }

                        if (obj is Category)
                        {
                            DeserialisedCategories.Add(obj as Category);
                        }
                    }
                }

                stream.Close();

                return true;
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Serialisation exception: could not deserialise object");
                Console.WriteLine(e.Message);

                return false;
            }
            catch (IOException e)
            {
                Console.WriteLine("I/O exception: could not open file to deserialise object");
                Console.WriteLine(e.Message);

                return false;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Unauthorised access exception: insufficient file system permissions");
                Console.WriteLine(e.Message);

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not deserialise object");
                Console.WriteLine(e.Message);

                return false;
            }
        }
    }
}
