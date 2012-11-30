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

            var itinerary = StubItinerary();
            cargo.AssignToRoute(itinerary);

            Assert.AreEqual(RoutingStatus.Routed, cargo.RoutingStatus);
            var expectedItinerary = StubItinerary();
            Assert.AreEqual(expectedItinerary, cargo.Itinerary);
        }

        [Test]
        public void RoutedCargoCanBeReceivedInPort()
        {
            var cargo = new Cargo(new TrackingId("XYZ"),
                                  new RouteSpecification(Location.HongKong, Location.Dallas));
            cargo.AssignToRoute(StubItinerary());

            cargo.Handled(HandlingActivity.ReceiveIn(Location.HongKong));

            Assert.AreEqual(TransportStatus.InPort, cargo.TransportStatus);
            Assert.AreEqual(Location.HongKong, cargo.LastKnownLocation);
        }

        [Test]
        public void RoutedCargoCanBeLoaded()
        {
            var cargo = new Cargo(new TrackingId("XYZ"),
                                  new RouteSpecification(Location.HongKong, Location.Dallas));
            cargo.AssignToRoute(StubItinerary());

            cargo.Handled(HandlingActivity.LoadOnto(new Voyage(), Location.HongKong));

            Assert.AreEqual(TransportStatus.OnboardCarrier, cargo.TransportStatus);
        }



        private static Itinerary StubItinerary()
        {
            return new Itinerary(GetStubLegs());
        }

        private static List<Leg> GetStubLegs()
        {
            var leg = new Leg(Location.HongKong, Location.Dallas, new DateTime(2012, 11, 9), new DateTime(2012, 11, 12));
            var legs = new List<Leg> {leg};
            return legs;
        }

    }
}