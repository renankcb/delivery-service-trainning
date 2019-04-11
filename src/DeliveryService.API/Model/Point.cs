using System;
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

        internal bool Any()
        {
            throw new NotImplementedException();
        }

        internal Point FirstOrDefault()
        {
            throw new NotImplementedException();
        }
    }
}
