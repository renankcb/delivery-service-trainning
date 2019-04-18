using System.Collections.Generic;
using System.Linq;

namespace DeliveryService.API.Model
{
    /// <summary>
    /// Routes model, contains data related to routes from origin to destination, 
    /// there are all availlable routes, lowest time route and lowest cost route
    /// </summary>
    public class Routes
    {
        public Routes(int originId, int destinationId, List<PointsConnection> connections)
        {
            OriginId = originId;
            DestinationId = destinationId;
            Connections = connections;
            RoutesAvailable = new List<List<PointsConnection>>();
            FindRoutes(OriginId, new List<PointsConnection>());
        }

        public int OriginId { get; private set; }

        public int DestinationId { get; private set; }

        public List<PointsConnection> Connections { get; private set; }

        public List<PointsConnection> BestTimeRout
        {
            get
            {
                var routesTime = RoutesAvailable.Select(rt => rt.Sum(conn => conn.Time));
                return RoutesAvailable.Find(pc => pc.Sum(conn => conn.Time) == routesTime.Min());
            }
        }

        public List<PointsConnection> BestCostRout
        {
            get
            {
                var routesCosts = RoutesAvailable.Select(rt => rt.Sum(conn => conn.Cost));
                return RoutesAvailable.Find(pc => pc.Sum(conn => conn.Cost) == routesCosts.Min());
            }
        }

        public List<List<PointsConnection>> RoutesAvailable { get; private set; }

        /// <summary>
        /// Logic where return all availlable routes with intermidiate points
        /// </summary>
        /// <param name="originId"></param>
        /// <param name="visitedPoints"></param>
        private void FindRoutes(int originId, List<PointsConnection> visitedPoints)
        {
            if (originId != DestinationId)
            {
                var currentOriginChildren = Connections.FindAll(pc => pc.OriginId == originId);

                foreach (var pc in currentOriginChildren)
                {
                    if (HasIntermidiatePoints(visitedPoints, pc))
                    {
                        var currentOrigin = Connections.Find(pci => pci.Id == pc.Id);
                        visitedPoints.Add(currentOrigin);

                        if (IsFinalDestination(pc))
                            RoutesAvailable.Add(visitedPoints.ToList());

                        FindRoutes(pc.DestinationId.Value, visitedPoints);
                        visitedPoints.Remove(currentOrigin);

                    }

                }

            }
        }

        private bool IsFinalDestination(PointsConnection pc) => pc.DestinationId == DestinationId;

        private bool HasIntermidiatePoints(List<PointsConnection> visitedPoints, PointsConnection pc) => visitedPoints.Any() || pc.DestinationId != DestinationId;
    }
}
