using DeliveryService.API.Model;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DeliveryService.DL.Tests
{
    public class RoutesTest
    {
        private readonly List<PointsConnection> connections;

        public RoutesTest()
        {

            var connAtoB = NewMock(3, 1, 2, 1, 5);
            var connAtoD = NewMock(5, 2, 3, 2, 10);
            var connBtoC = NewMock(6, 1, 3, 2, 2);
            var connDtoE = NewMock(7, 1, 4, 4, 1);
            var connDtoF = NewMock(8, 4, 5, 2, 10);
            var connEtoC = NewMock(9, 5, 3, 3, 2);
            var connAtoF = NewMock(10, 4, 7, 3, 15);
            var connFtoE = NewMock(11, 7, 5, 2, 10);
            var connAtoC = NewMock(12, 1, 7, 5, 5);
            connections = new List<PointsConnection>()
            {
                connAtoB,
                connAtoD,
                connBtoC,
                connDtoE,
                connDtoF,
                connEtoC,
                connAtoF,
                connFtoE,
                connAtoC
            };

        }

        [Fact]
        public void ReturnCorrectRoutesQuantityFromOriginToDestinyWithIntermidiatePoints()
        {
            var originId = 1;
            var destinationId = 3;

            var routes = new Routes(originId, destinationId, connections);

            Assert.Equal(4, routes.RoutesAvailable.Count);
        }

        [Fact]
        public void ReturnBestTimeRouteBetweenRoutes()
        {
            var originId = 1;
            var destinationId = 3;

            var routes = new Routes(originId, destinationId, connections);
            Assert.Equal(3, routes.BestTimeRout.Sum(pc => pc.Time));
        }

        [Fact]
        public void ReturnBestCostRouteBetweenRoutes()
        {
            var originId = 1;
            var destinationId = 3;

            var routes = new Routes(originId, destinationId, connections);
            Assert.Equal(13, routes.BestCostRout.Sum(pc => pc.Cost));
        }

        [Fact]
        public void TestShouldNotReturnRoutesWithoutIntermediatePoints()
        {
            var originId = 1;
            var destinationId = 3;
            var directPointAtoC = NewMock(6, 1, 3, 2, 2);
            var connectionTest = new List<PointsConnection>() { directPointAtoC };

            var routes = new Routes(originId, destinationId, connectionTest);
            Assert.Empty(routes.RoutesAvailable);
        }

        private PointsConnection NewMock(int id, int originId, int destinationId, int time, int cost) => new PointsConnection()
        {
            Id = id,
            OriginId = originId,
            DestinationId = destinationId,
            Time = time,
            Cost = cost
        };
    }
}
