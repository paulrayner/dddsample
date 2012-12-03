using System;
using System.Collections.Generic;
using NUnit.Framework;
using dddsample.Model.Shared;

namespace dddsample.Model.Cargo
{
    [TestFixture]
    public class CargoTests
    {
        [Test]
        public void CargoIsInitializedCorrectly()
        {
            var cargo = new Cargo(new TrackingId("XYZ"),
                                  new RouteSpecification(Location.Location.HongKong, Location.Location.Dallas));

            var expectedRouteSpecification = new RouteSpecification(Location.Location.HongKong, Location.Location.Dallas);

            Assert.AreEqual(new TrackingId("XYZ"), cargo.TrackingId);
            Assert.AreEqual(expectedRouteSpecification, cargo.RouteSpecification);

            Assert.AreEqual(TransportStatus.NotReceived, cargo.TransportStatus);
            Assert.AreEqual(RoutingStatus.NotRouted, cargo.RoutingStatus);
        }

        [Test]
        public void CargoCanBeRouted()
        {
            var cargo = new Cargo(new TrackingId("XYZ"),
                                  new RouteSpecification(Location.Location.HongKong, Location.Location.Dallas));

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
                                  new RouteSpecification(Location.Location.HongKong, Location.Location.Dallas));
            cargo.AssignToRoute(StubItinerary());

            cargo.Handled(HandlingActivity.ReceiveIn(Location.Location.HongKong));

            Assert.AreEqual(TransportStatus.InPort, cargo.TransportStatus);
            Assert.AreEqual(Location.Location.HongKong, cargo.LastKnownLocation);
        }

        [Test]
        public void RoutedCargoCanBeLoaded()
        {
            var cargo = new Cargo(new TrackingId("XYZ"),
                                  new RouteSpecification(Location.Location.HongKong, Location.Location.Dallas));
            cargo.AssignToRoute(StubItinerary());

            cargo.Handled(HandlingActivity.LoadOnto(new Voyage.Voyage(), Location.Location.HongKong));

            Assert.AreEqual(TransportStatus.OnboardCarrier, cargo.TransportStatus);
        }



        private static Itinerary StubItinerary()
        {
            return new Itinerary(GetStubLegs());
        }

        private static List<Leg> GetStubLegs()
        {
            var leg = new Leg(Location.Location.HongKong, Location.Location.Dallas, new DateTime(2012, 11, 9), new DateTime(2012, 11, 12));
            var legs = new List<Leg> {leg};
            return legs;
        }

    }
}