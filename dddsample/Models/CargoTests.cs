using System;
using NUnit.Framework;

namespace dddsample.Models
{
    [TestFixture]
    public class CargoTests
    {
        [Test]
        public void CargoIsInitializedCorrectly()
        {
            var cargo = new Cargo(new TrackingId("XYZ"),
                                  new RouteSpecification(Location.HongKong, Location.Dallas));

            var expectedRouteSpecification = new RouteSpecification(Location.HongKong, Location.Dallas);

            Assert.AreEqual(new TrackingId("XYZ"), cargo.TrackingId);
            Assert.AreEqual(expectedRouteSpecification, cargo.RouteSpecification);

            Assert.AreEqual(TransportStatus.NotReceived, cargo.TransportStatus);
            Assert.AreEqual(RoutingStatus.NotRouted, cargo.RoutingStatus);
        }

        [Test]
        public void CargoCanBeRouted()
        {
            var cargo = new Cargo(new TrackingId("XYZ"),
                                  new RouteSpecification(Location.HongKong, Location.Dallas));

            var itinerary = new Itinerary();

            cargo.AssignToRoute(itinerary);
        }
    }
}