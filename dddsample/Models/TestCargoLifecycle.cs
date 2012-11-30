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
            var cargo = new Cargo(new RouteSpecification(new Location("HONG KONG"), 
                                                         new Location("STOCKHOLM")));

            // Test initial state of Cargo
            Assert.AreEqual(TransportStatus.NotReceived, cargo.TransportStatus);
            Assert.AreEqual(RoutingStatus.NotRouted, cargo.RoutingStatus);

            // Route the cargo
            var itinerary = RoutingService.FetchRoutesForSpecification(cargo.RouteSpecification);
            cargo.AssignToRoute(itinerary);

            Assert.AreEqual(RoutingStatus.Routed, cargo.RoutingStatus);
            Assert.AreEqual(TransportStatus.NotReceived, cargo.TransportStatus);

            // Received in Hong Kong
            cargo.Handled(HandlingActivity.ReceiveIn(new Location("HONG KONG")));
            Assert.AreEqual(TransportStatus.InPort, cargo.TransportStatus);
            Assert.AreEqual(new Location("HONG KONG"), cargo.LastKnownLocation);

            // Loaded in Hong Kong
            cargo.Handled(HandlingActivity.LoadOnto(new Voyage(), new Location("HONG KONG")));
            Assert.AreEqual(TransportStatus.OnboardCarrier, cargo.TransportStatus);
            Assert.AreEqual(new Location("HONG KONG"), cargo.LastKnownLocation);

            // Claimed in Dallas
            cargo.Handled(HandlingActivity.ClaimIn(new Location("USDAL")));
            Assert.AreEqual(TransportStatus.Claimed, cargo.TransportStatus);
            Assert.AreEqual(new Location("USDAL"), cargo.LastKnownLocation);
        }
    }

    public class RoutingService
    {
        public static Itinerary FetchRoutesForSpecification(RouteSpecification routeSpecification)
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