using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using App4.Model;
using System.Threading.Tasks;

namespace App4.Services
{
    public class BikeDatabase
    {
        readonly SQLiteAsyncConnection database;

        public BikeDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Bike>().Wait();
        }

        public Task<List<Bike>> GetBikeAsync()
        {
            //Get all notes.
            return database.Table<Bike>().ToListAsync();
        }

        public Task<Model.Bike> GetBikeAsync(int id)
        {
            // Get a specific note.
            return database.Table<Bike>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveBikeAsync(Bike bike)
        {
            if (bike.ID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(bike);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(bike);
            }
        }



        public Task<int> DeleteBikeAsync(Bike bike)
        {
            // Delete a note.
            return database.DeleteAsync(bike);
        }
    }
}
