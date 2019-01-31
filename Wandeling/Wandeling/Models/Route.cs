using System;
using System.Collections.Generic;
using System.Text;

namespace WandelApp.Models
{
    class Route
    {
        public string RouteId;
        public string Startpoint;
        public string Endpoint;
        public string PoiList;
        public string RouteCategory;
        public int RouteDifficulty;
        public List<Double> coordinates;
        public List<string> PinName;
    }
}
