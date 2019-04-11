using System.Collections.Generic;

namespace DeliveryService.API.Model
{
    public class Point
    {
        public Point() { }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<PointsConnection> Origins { get; set; }

        public ICollection<PointsConnection> Destinations { get; set; }
    }
}
