using System;
using Xamarin.Forms;
using App4.Services;
using System.IO;

namespace App4
{
    public partial class MainPage : ContentPage
    {
        static BikeDatabase database;

        // Create the database connection as a singleton.
        static BikeDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new BikeDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
