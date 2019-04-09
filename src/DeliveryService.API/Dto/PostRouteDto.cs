using DeliveryService.API.Model;
using System.Collections.Generic;

namespace DeliveryService.API.Dto
{
    public class PostRouteDto
    {
        public int Id { get; set; }

        public int OriginPointId { get; set; }

        public int DestinationPointId { get; set; }

        public IEnumerable<int> IntermediatePointsId { get; set; }

        public int Time { get; set; }

        public int Cost { get; set; }

        internal bool IsValid()
        {
            //criar validacao
            return true;
        }

        internal Route ToDomain()
        {
            var ip = new List<Point>();

            foreach (var i in IntermediatePointsId)
            {
                ip.Add(new Point() { Id = i });
            }
            return new Route(Id, new Point() { Id = OriginPointId },
                new Point() { Id = DestinationPointId }, Time, Cost, ip);
        }
    }
}
