using System.Collections.Generic;

namespace DeliveryService.API.Model
{
    public class Point
    {
        public Point (int id, string name)
        {
            Id = id;
            Name = name;
            RoutePoints = new List<RoutePoints>();
        }

        public Point() { }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<RoutePoints> RoutePoints { get; set; }
    }
}
