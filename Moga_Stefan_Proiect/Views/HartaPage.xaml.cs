using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Moga_Stefan_Proiect.Services;
using System.Collections.Generic;
using System.Linq;

namespace Moga_Stefan_Proiect.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HartaPage : ContentPage
    {
        public HartaPage()
        {
            InitializeComponent();
            GetCurrentLocation();
            GetOrderPinLocations();
        }
        public async void GetCurrentLocation()
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location != null)
            {
                Position position = new Position(location.Latitude, location.Longitude);
                MapSpan mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(10));
                harta.MoveToRegion(mapSpan);
                Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
            }
        }
        public async void GetOrderPinLocations()
        {
            //var order = await OrderService.GetOrder();
            var order = await App.Database.GetOrderListsAsync();

            if(order != null)
            {
                foreach(var item in order)
                {
                    Geocoder geocoder = new Geocoder();
                    IEnumerable<Position> aproxPositions = await geocoder.GetPositionsForAddressAsync(item.Adrese.Oras +" "+ item.Adrese.Strada +" "+ item.Adrese.Numar);
                    Position position = aproxPositions.FirstOrDefault();
                    var cordLat = Convert.ToDouble(position.Latitude);
                    var cordLong = Convert.ToDouble(position.Longitude);
                    Pin OrderPins = new Pin()
                    {
                        Label = item.Id.ToString() + " - " + item.Tip_plata.Tipul_Platii.ToString(),
                        Position = new Position(cordLat, cordLong)
                    };
                    harta.Pins.Add(OrderPins);
                }
            }
        }
        private void ToolbarRefresh_Clicked(object sender, EventArgs e)
        {
            harta.Pins.Clear();
            GetOrderPinLocations();
        }
    }
}