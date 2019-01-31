using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.Geolocator.Abstractions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Wandeling.Models;
using Position = Xamarin.Forms.Maps.Position;
using System.Collections.Generic;

namespace Wandeling
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
        
        private bool hasLocationPermission = false;
        public MapPage()
        {
            InitializeComponent();
            GetPermissions();

        }

        private async void GetPermissions()
        {
            try
            {
                //Er wordt gecheckt of de user toestemming heeft gegeven om de locatie te mogen gebruiken
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        await DisplayAlert("Locatie vereist", "Locatie vereist", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
                    if (results.ContainsKey(Permission.LocationWhenInUse))
                        status = results[Permission.LocationWhenInUse];
                }
                //Als de permissie verleend is, kan de app de locatie opvragen
                if (status == PermissionStatus.Granted)
                {
                    hasLocationPermission = true;
                    locationsMap.IsShowingUser = true;

                    GetLocation();

                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 1;

                    var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(100));

                }
                //Zo niet dan wordt er een message verstuurd met "Locatie vereist"
                else
                {
                    await DisplayAlert("Locatie vereist", "Locatie vereist", "OK");
                }
            }

            //Mocht er helemaal niks gebeuren dan wordt er een error message weergegeven
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }
        protected override async void OnAppearing()
        {
            
            base.OnAppearing();

            OnAppearingHeerlen();
            OnAppearingVijlen();

            //locationsMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(50.788476, 5.972722),
            //    Distance.FromKilometers(3)));

            //var pin1 = new Pin
            //{
            //    Position = new Position(50.788476, 5.972722),
            //    Label = "Test Label #1",
            //    Address = "Adress #1"
            //};

            //var pin2 = new Pin
            //{
            //    Position = new Position(50.789476, 5.973722),
            //    Label = "Test Label #2",
            //    Address = "Adress #2"
            //};

            //var pin3 = new Pin
            //{
            //    Position = new Position(50.790476, 5.973322),
            //    Label = "Test Label #3",
            //    Address = "Adress #3"
            //};

            //var pin4 = new Pin
            //{
            //    Position = new Position(50.791476, 5.973422),
            //    Label = "Test Label #4",
            //    Address = "Adress #4"
            //};

            //var pin5 = new Pin
            //{
            //    Position = new Position(50.881253, 5.95881),
            //    Label = "Test Label #4",
            //    Address = "Adress #4"
            //};

            //var pin6 = new Pin
            //{
            //    Position = new Position(50.880251, 5.966939),
            //    Label = "Test Label #4",
            //    Address = "Adress #4"
            //};

            //var pin7 = new Pin
            //{
            //    Position = new Position(50.881734, 5.966660),
            //    Label = "Test Label #4",
            //    Address = "Adress #4"
            //};

            //var pin8 = new Pin
            //{
            //    Position = new Position(50.888476, 5.96665),
            //    Label = "Test Label #4",
            //    Address = "Adress #4"
            //};

            //var pin9 = new Pin
            //{
            //    Position = new Position(50.788476, 5.966699),
            //    Label = "Test Label #4",
            //    Address = "Adress #4"
            //};

            //var pin10 = new Pin
            //{
            //    Position = new Position(50.788476, 8.972722),
            //    Label = "Test Label #4",
            //    Address = "Adress #4"
            //};

            //locationsMap.Pins.Add(pin1);
            //locationsMap.Pins.Add(pin2);
            //locationsMap.Pins.Add(pin3);
            //locationsMap.Pins.Add(pin4);
            //locationsMap.Pins.Add(pin5);
            //locationsMap.Pins.Add(pin6);
            //locationsMap.Pins.Add(pin7);
            //locationsMap.Pins.Add(pin8);
            //locationsMap.Pins.Add(pin9);
            //locationsMap.Pins.Add(pin10);

            
            //    locationsMap.RouteCoordinates.Add(new Position(50.788476, 5.972722));
            //    locationsMap.RouteCoordinates.Add(new Position(50.789476, 5.973722));
            //    locationsMap.RouteCoordinates.Add(new Position(50.790476, 5.973322));
            //    locationsMap.RouteCoordinates.Add(new Position(50.791476, 5.973422));
            //    locationsMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(50.788476, 5.972722), Distance.FromMeters(120)));

            
            

           
            //    locationsMap.RouteCoordinates.Add(new Position(50.881253, 5.95881));
            //    locationsMap.RouteCoordinates.Add(new Position(50.880251, 5.966939));
            //    locationsMap.RouteCoordinates.Add(new Position(50.881734, 5.966660));
            //    locationsMap.RouteCoordinates.Add(new Position(50.888476, 5.96665));
            //    locationsMap.RouteCoordinates.Add(new Position(50.788476, 5.966699));
            //    locationsMap.RouteCoordinates.Add(new Position(50.788476, 5.972722));
            //    locationsMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(50.881253, 5.95881), Distance.FromMeters(120)));
            
        
            
            //Als de locatie veranderd is werkt de app deze bij
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;

                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(TimeSpan.Zero, 100);
            }

            GetLocation();
        }

        protected void OnAppearingHeerlen()
        {
            var pin5 = new Pin
            {
                Position = new Position(50.881253, 5.95881),
                Label = "Test Label #4",
                Address = "Adress #4"
            };

            var pin6 = new Pin
            {
                Position = new Position(50.880251, 5.966939),
                Label = "Test Label #4",
                Address = "Adress #4"
            };

            var pin7 = new Pin
            {
                Position = new Position(50.881734, 5.966660),
                Label = "Test Label #4",
                Address = "Adress #4"
            };

            var pin8 = new Pin
            {
                Position = new Position(50.888476, 5.96665),
                Label = "Test Label #4",
                Address = "Adress #4"
            };

            var pin9 = new Pin
            {
                Position = new Position(50.788476, 5.966699),
                Label = "Test Label #4",
                Address = "Adress #4"
            };

            var pin10 = new Pin
            {
                Position = new Position(50.788476, 8.972722),
                Label = "Test Label #4",
                Address = "Adress #4"
            };

            locationsMap.Pins.Add(pin5);
            locationsMap.Pins.Add(pin6);
            locationsMap.Pins.Add(pin7);
            locationsMap.Pins.Add(pin8);
            locationsMap.Pins.Add(pin9);
            locationsMap.Pins.Add(pin10);

            locationsMap.RouteCoordinates.Add(new Position(50.881253, 5.95881));
            locationsMap.RouteCoordinates.Add(new Position(50.880251, 5.966939));
            locationsMap.RouteCoordinates.Add(new Position(50.881734, 5.966660));
            locationsMap.RouteCoordinates.Add(new Position(50.888476, 5.96665));
            locationsMap.RouteCoordinates.Add(new Position(50.788476, 5.966699));
            locationsMap.RouteCoordinates.Add(new Position(50.788476, 5.972722));
            locationsMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(50.881253, 5.95881), Distance.FromMeters(120)));

        }

        protected void OnAppearingVijlen()
        {
            base.OnAppearing();

            locationsMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(50.788476, 5.972722),
                Distance.FromKilometers(3)));

            var pin1 = new Pin
            {
                Position = new Position(50.788476, 5.972722),
                Label = "Test Label #1",
                Address = "Adress #1"
            };

            var pin2 = new Pin
            {
                Position = new Position(50.789476, 5.973722),
                Label = "Test Label #2",
                Address = "Adress #2"
            };

            var pin3 = new Pin
            {
                Position = new Position(50.790476, 5.973322),
                Label = "Test Label #3",
                Address = "Adress #3"
            };

            var pin4 = new Pin
            {
                Position = new Position(50.791476, 5.973422),
                Label = "Test Label #4",
                Address = "Adress #4"
            };

            locationsMap.Pins.Add(pin1);
            locationsMap.Pins.Add(pin2);
            locationsMap.Pins.Add(pin3);
            locationsMap.Pins.Add(pin4);

            locationsMap.RouteCoordinates.Add(new Position(50.788476, 5.972722));
            locationsMap.RouteCoordinates.Add(new Position(50.789476, 5.973722));
            locationsMap.RouteCoordinates.Add(new Position(50.790476, 5.973322));
            locationsMap.RouteCoordinates.Add(new Position(50.791476, 5.973422));
            locationsMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(50.788476, 5.972722), Distance.FromMeters(120)));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            CrossGeolocator.Current.StopListeningAsync();
            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;
        }

        void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            MoveMap(e.Position);
        }

        private async void GetLocation()
        {
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();

                MoveMap(position);
            }
        }

        private void MoveMap(Plugin.Geolocator.Abstractions.Position position)
        {
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);

            locationsMap.MoveToRegion(span);
        }


    }
}
