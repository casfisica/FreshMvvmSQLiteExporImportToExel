using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FreshMvvmSQLiteExporImportToExel.Model;
using SQLite;


namespace FreshMvvmSQLiteExporImportToExel.Services
{
    public class Repository
    {
        /// <summary>
        /// Coneccion asincrona con la base de datos
        /// </summary>
        private readonly SQLiteAsyncConnection conn;

        /// <summary>
        /// Mensaje de estatus
        /// </summary>
        public string StatusMessage { get; set; }

        /// <summary>
        /// Constructor, crea una coneccion a la base de datos y la almacena en conn
        /// Ademas crea una tabla de Usuarios, usando la clase Users
        /// </summary>
        /// <param name="dbPath"></param>
        public Repository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<User>().Wait();
        }

        public async Task CreateItem(User user)
        {
            try
            {
                // Basic validation to ensure we have an item name.
                if (string.IsNullOrWhiteSpace(user.UserName))
                    throw new Exception("UserName is required");

                // Insert/update items.
                var result = await conn.InsertOrReplaceAsync(user).ConfigureAwait(continueOnCapturedContext: false);
                StatusMessage = $"{result} record(s) added [Item Name: {user.UserName}])";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to create item: {user.UserName}. Error: {ex.Message}";
            }
        }

        /// <summary>
        /// Obtiene lista de todos los elementos usuario de la tabla
        /// </summary>
        /// <returns></returns>
        public Task<List<User>> GetAllUsers()
        {
            // Return a list of items saved to the Item table in the database.
            return conn.Table<User>().ToListAsync();
        }

    }
}
