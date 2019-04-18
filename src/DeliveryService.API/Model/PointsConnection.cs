using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryService.API.Model
{
    public class PointsConnection
    {
        public PointsConnection() { }

        public int Id { get; set; }

        public int? OriginId { get; set; }
        public virtual Point Origin { get; set; }

        public int? DestinationId { get; set; }
        public virtual Point Destination { get; set; }

        public int Time { get; set; }

        public int Cost { get; set; }
    }
}
