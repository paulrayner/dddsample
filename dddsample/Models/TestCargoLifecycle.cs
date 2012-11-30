using System;
using NUnit.Framework;
using dddsample.Models;

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
            // TODO: Add arrival deadline to route specification
            var cargo = new Cargo(new TrackingId("XYZ"),
                                  new RouteSpecification(new Location("HONG KONG"), 
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

    public class RouteSpecification : IEquatable<RouteSpecification>
    {
        public Location Origin { get; private set; }
        public Location Destination { get; private set; }

        public RouteSpecification(Location origin, Location destination)
        {
            Origin = origin;
            Destination = destination;
        }

        public bool Equals(RouteSpecification other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Origin, Origin) && Equals(other.Destination, Destination);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (RouteSpecification)) return false;
            return Equals((RouteSpecification) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Origin.GetHashCode()*397) ^ Destination.GetHashCode();
            }
        }

        public static bool operator ==(RouteSpecification left, RouteSpecification right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RouteSpecification left, RouteSpecification right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return string.Format("Origin: {0}, Destination: {1}", Origin, Destination);
        }
    }
}