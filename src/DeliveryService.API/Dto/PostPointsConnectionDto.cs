using DeliveryService.API.Model;

namespace DeliveryService.API.Dto
{
    public class PostPointsConnectionDto
    {
        public int Id { get; set; }

        public int OriginPointId { get; set; }

        public int DestinationPointId { get; set; }

        public int Time { get; set; }

        public int Cost { get; set; }

        internal bool IsValid()
        {
            return OriginPointId > 0 && DestinationPointId > 0 && Time >=0 && Cost >=0;
        }

        internal PointsConnection ToDomain()
        {
            return new PointsConnection()
            {
                Id = this.Id,
                OriginId = this.OriginPointId,
                DestinationId = this.DestinationPointId,
                Time = this.Time,
                Cost = this.Cost
            };
        }
    }
}
