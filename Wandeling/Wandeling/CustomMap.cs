using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace Wandeling.Models
{
    public class CustomMap : Map
    {
        public List<CustomPin> CustomPins { get; set; }
        public List<Position> RouteCoordinates { get; set; }

        public CustomMap()
        {
            RouteCoordinates = new List<Position>();
        }
    }
}
