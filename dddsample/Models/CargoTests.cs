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
                                   new RouteSpecification(new Location("HONG KONG"),
                                                          new Location("STOCKHOLM")));

            var expectedRouteSpecification = new RouteSpecification(new Location("HONG KONG"),
                                                          new Location("STOCKHOLM"));

            Assert.AreEqual(TransportStatus.NotReceived, cargo.TransportStatus);
            Assert.AreEqual(RoutingStatus.NotRouted, cargo.RoutingStatus);
            Assert.AreEqual(new TrackingId("XYZ"), cargo.TrackingId);
            Assert.AreEqual(expectedRouteSpecification, cargo.RouteSpecification);
        }
    }
}