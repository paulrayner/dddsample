using NUnit.Framework;
using dddsample.Model.Shared;
using dddsample.Model.Voyage;

namespace dddsample.Model.Cargo
{
    [TestFixture]
    public class CargoLifecycleTests
    {
        // TODO: Implement cargo.IsReadyToClaim()  <--- based on customs clearance point == destination
        // TODO: Implement cargo.IsMisdirected()
        // TODO: Implement cargo.EstimatedTimeOfArrival()
        // TODO: Implement cargo.NextExpectedActivity()

        [Test]
        public void CargoIsProperlyDelivered()
        {
            // TODO: Add arrival deadline to route specification
            var cargo = new Cargo(new TrackingId("XYZ"),
                                  new RouteSpecification(Location.Location.HongKong, Location.Location.Dallas));

            // Test initial state of Cargo
            Assert.AreEqual(TransportStatus.NotReceived, cargo.TransportStatus);
            Assert.AreEqual(RoutingStatus.NotRouted, cargo.RoutingStatus);

            // Route the cargo
            var itinerary = RoutingService.FetchRoutesForSpecification(cargo.RouteSpecification);
            cargo.AssignToRoute(itinerary);

            Assert.AreEqual(RoutingStatus.Routed, cargo.RoutingStatus);
            Assert.AreEqual(TransportStatus.NotReceived, cargo.TransportStatus);

            // Received in Hong Kong
            cargo.Handled(HandlingActivity.ReceiveIn(Location.Location.HongKong));
            Assert.AreEqual(TransportStatus.InPort, cargo.TransportStatus);
            Assert.AreEqual(Location.Location.HongKong, cargo.LastKnownLocation);

            // Loaded in Hong Kong
            cargo.Handled(HandlingActivity.LoadOnto(new Voyage.Voyage(new VoyageNumber("ABC")), Location.Location.HongKong));
            Assert.AreEqual(TransportStatus.OnboardCarrier, cargo.TransportStatus);
            Assert.AreEqual(Location.Location.HongKong, cargo.LastKnownLocation);

            // Claimed in Dallas
            cargo.Handled(HandlingActivity.ClaimIn(Location.Location.Dallas));
            Assert.AreEqual(TransportStatus.Claimed, cargo.TransportStatus);
            Assert.AreEqual(Location.Location.Dallas, cargo.LastKnownLocation);
        }
    }
}