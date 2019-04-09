using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.API.Model
{
    public class RoutePoints
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public int PointId { get; set; }

        public Route Route { get; set; }

        public Point Point { get; set; }
    }
}
