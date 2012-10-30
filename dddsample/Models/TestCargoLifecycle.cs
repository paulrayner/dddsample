using System;
using NUnit.Framework;

namespace dddsample
{
    [TestFixture]
    public class CargoLifecycle
    {
        // TODO: Implement cargo.IsReadyToClaim()  <--- based on customs clearance point == destination
        // TODO: Implement cargo.IsMisdirected()
        // TODO: Implement cargo.EstimatedTimeOfArrival()
        // TODO: Implement cargo.NextExpectedActivity()

        [Test]
        public void CargoIsProperlyDelivered()
        {
            // TODO: Add tracking ID to cargo, and arrival deadline to route specification
            var cargo = new Cargo(new RouteSpecification(new Location("HONGKONG"), 
                                                         new Location("STOCKHOLM")));

            // Test initial state of Cargo
            Assert.AreEqual(TransportStatus.NotReceived, cargo.TransportStatus);
            Assert.AreEqual(RoutingStatus.NotRouted, cargo.RoutingStatus);

            // Route the cargo
            var itinerary = routingService.fetchRoutesForSpecification(cargo.RouteSpecification);
            cargo.AssignToRoute(itinerary);
            Assert.AreEqual(RoutingStatus.Routed, cargo.RoutingStatus);

            cargo.Handled(HandlingActivity.ClaimIn(new Location("USDAL")));
            Assert.AreEqual(TransportStatus.Claimed, cargo.TransportStatus);

            //Assert.IsNull(cargo.NextExpectedActivity());
        }
    }

    public class routingService
    {
        public static Itinerary fetchRoutesForSpecification(RouteSpecification routeSpecification)
        {
            return new Itinerary();
        }
    }

    public class Itinerary
    {
    }

    public class RouteSpecification
    {
        public Location Origin { get; private set; }
        public Location Destination { get; private set; }

        public RouteSpecification(Location origin, Location destination)
        {
            Origin = origin;
            Destination = destination;
        }
    }
}