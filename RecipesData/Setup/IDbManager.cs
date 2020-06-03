using RecipesData.Context;
using System;

namespace RecipesData.Setup
{
    /// <summary>
    /// Contains all relevant methods used to execute operations on the database
    /// </summary>
    public interface IDbManager
    {
        /// <summary>
        /// Resets database state i.e. delete data from all tables
        /// </summary>
        void ResetDatabaseState();

        /// <summary>
        /// Seeds data to all tables
        /// </summary>
        /// <param name="seedDataPath">Full path of the SeedData.sql file</param>
        void SeedDatabase(string seedDataPath);

        /// <summary>
        /// Adds a new item to the database
        /// </summary>
        /// <param name="item">An entity that corresponds to one of the tables in the database</param>
        /// <returns>True if the operation was successful, false otherwise</returns>
        bool AddItem(object item);

        /// <summary>
        /// Edits an existing item in the database
        /// </summary>
        /// <param name="item">The updated entity</param>
        /// <returns>True if the operation was successful, false otherwise</returns>
        bool EditItem(object item);

        /// <summary>
        /// Reads an existing item from the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Existing item from the database or null if not found</returns>
        object ReadItem(object item);

        /// <summary>
        /// Deletes an item from the database
        /// </summary>
        /// <param name="item">The entity to be deleted. It should have at least an ID.</param>
        /// <returns>True if the operation was successful, false otherwise</returns>
        bool DeleteItem(object item);

        /// <summary>
        /// Retrieves all entities of type <paramref name="entityType"/> from the database
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns>Array of entities found (has length 0 if none was found)</returns>
        object[] BrowseItems(Type entityType);
    }
}
