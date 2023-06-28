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
            var orders = await App.Database.GetOrderListsAsync();

            if(orders != null)
            {
                foreach(var item in orders)
                {
                    Geocoder geocoder = new Geocoder();
                    IEnumerable<Position> coordonates = await geocoder.GetPositionsForAddressAsync(item.Adrese.Oras +", Strada "+ item.Adrese.Strada +", numarul "+ item.Adrese.Numar);
                    Position position = coordonates.FirstOrDefault();
                    var cordLat = position.Latitude;
                    var cordLong = position.Longitude;
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