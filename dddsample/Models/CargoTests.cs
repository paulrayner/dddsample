using System;
using System.Collections.Generic;
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
            var leg = new Leg(Location.HongKong, Location.Dallas, new DateTime(2012, 11, 9), new DateTime(2012, 11, 12));
            var legs = new List<Leg>(leg, leg);
            var expectedItinerary = new Itinerary(legs);

            var itinerary = new Itinerary();
            cargo.AssignToRoute(itinerary);

            Assert.AreEqual(RoutingStatus.Routed, cargo.RoutingStatus);
            Assert.AreEqual(expectedItinerary, cargo.Itinerary);
        }
    }
}