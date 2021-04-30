using App4.Model;
using App4.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Crear : ContentPage
	{

        int id;
        Bike bike;

        public Crear (int id, string option)
		{
            InitializeComponent ();
            this.id = id;
            if(option.Equals("Añadir"))
            {
                btnUpdate.IsVisible = false;
                btnDelete.IsVisible = false;
            }

            if(option.Equals("Modificar"))
            {
                getBycicle(id);
                btnInsert.IsVisible = false;
            }
        }

        public async void getBycicle(int id)
        {
            Bike bike = await App.Database.GetBikeAsync(id);
            Marca.Text = bike.name;
            Imagen.Text = bike.imagen;

        }

        public async void saveData(object sender, EventArgs args)
        {
            if(!string.IsNullOrWhiteSpace(Marca.Text) && !string.IsNullOrWhiteSpace(Imagen.Text))
            {
                Bike bike = new Bike();
                bike.name = Marca.Text;
                bike.imagen = Imagen.Text;
                await App.Database.SaveBikeAsync(bike);
                Application.Current.MainPage = new NavigationPage(new MainPage());
            } else
            {
                await DisplayAlert("Alert", "Algunos datos no estan bien diligenciados", "OK");
            }
          
        }

        public async void update(object sender, EventArgs args)
        {
            Bike bike = new Bike();
            bike.ID = id;
             bike.name = Marca.Text;
            bike.imagen = Imagen.Text;
            await App.Database.SaveBikeAsync(bike);

            Application.Current.MainPage = new NavigationPage(new MainPage());
        }

        public async void delete(object sender, EventArgs args)
        {
            Bike bike = new Bike();
            bike.ID = id;
            bike.name = Marca.Text;
            bike.imagen = Imagen.Text;
            await App.Database.DeleteBikeAsync(bike);
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }


        public async void cancel(object sender, EventArgs args)
        {
            
            Application.Current.MainPage = new NavigationPage(new MainPage());

        }
    }
}