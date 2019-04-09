using System.Collections.Generic;

namespace DeliveryService.API.Model
{
    public class Route
    {
        public Route(int id, Point origin, Point destination, int time, int cost, ICollection<Point> intermidiatePoints)
        {
            Id = id;
            Origin = origin;
            Destination = destination;
            Time = time;
            Cost = cost;
            IntermidiatePoints = intermidiatePoints;
            RoutePoints = new List<RoutePoints>();
        }

        public Route() { }

        public int Id { get; private set; }

        public Point Origin { get; set; }

        public Point Destination { get; set; }

        public int Time { get; set; }

        public int Cost { get; set; }

        public ICollection<Point> IntermidiatePoints { get; set; }

        public ICollection<RoutePoints> RoutePoints { get; set; }
    }
}
