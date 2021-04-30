using System;
using Xamarin.Forms;
using App4.Services;
using System.IO;
using App4.Model;
using System.Collections.Generic;
using App4.View;

namespace App4
{
    public partial class MainPage : ContentPage
    {
        List<Bike> Bicycles = new List<Bike>();

        // Create the database connection as a singleton.
      

        public MainPage()
        {
            InitializeComponent();
            this.getData();
            
        }
        public async void getData()
        {
          
  
            this.Bicycles = await App.Database.GetBikeAsync();
            // Navigate backwards
            this.bycicles.ItemsSource = this.Bicycles;

        }

       
 
        public async void clickElement(object sender, ItemTappedEventArgs e) {
          
            ListView lv = (ListView)sender;

            // this assumes your List is bound to a List<Club>
            Bike bike = (Bike)lv.SelectedItem;

            int id = bike.ID;
            Application.Current.MainPage = new NavigationPage(new Crear(id, "Modificar"));

        }

        async void añadirBycicle(object sender, EventArgs args)
        {
            Application.Current.MainPage = new NavigationPage(new Crear(0, "Añadir"));
        }


    }
}
