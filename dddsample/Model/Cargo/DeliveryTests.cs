using System;
using System.Diagnostics;
using NUnit.Framework;
using dddsample.Model.Shared;
using dddsample.Model.Voyage;

namespace dddsample.Model.Cargo
{
    [TestFixture]
    public class DeliveryTests
    {
        // TODO Put in value object tests
        // TODO Derive from RouteSpecification and Itinerary
        // TODO Logic for RoutingStatus on Delivery based on routeSpecification being satisfied by Itinerary
        private DateTime now;

        [SetUp]
        public void Init()
        {
            // Override System time to verify that LastUpdatedOn works correctly
            now = DateTime.Now;
            SystemTime.Now = () => now;
        }

        [Test]
        public void UpdateDeliveryUponLoad()
        {
            var delivery = Delivery.BeforeHandling();
            var voyage = new Voyage.Voyage(new VoyageNumber("abc"));
            var loadInHongKong = HandlingActivity.LoadOnto(voyage, Location.Location.HongKong);
            delivery = delivery.OnHandling(loadInHongKong);

            Assert.AreEqual(now, delivery.LastUpdatedOn);
            Assert.AreEqual(voyage, delivery.CurrentVoyage);
            Assert.AreEqual(TransportStatus.OnboardCarrier, delivery.TransportStatus);
            Assert.AreEqual(loadInHongKong, delivery.MostRecentHandlingActivity);
            Assert.AreEqual(Location.Location.HongKong, delivery.LastKnownLocation);
        }

        [Test]
        public void UpdateDeliveryUponReceivingInPort()
        {
            var delivery = Delivery.BeforeHandling();
            var receiveInHongKong = HandlingActivity.ReceiveIn(Location.Location.HongKong);
            delivery = delivery.OnHandling(receiveInHongKong);

            Assert.AreEqual(now, delivery.LastUpdatedOn);
            Assert.AreEqual(Voyage.Voyage.None, delivery.CurrentVoyage);
            Assert.AreEqual(TransportStatus.InPort, delivery.TransportStatus);
            Assert.AreEqual(receiveInHongKong, delivery.MostRecentHandlingActivity);
            Assert.AreEqual(Location.Location.HongKong, delivery.LastKnownLocation);
        }

        [Test]
        public void UpdateDeliveryUponUnloadInPort()
        {
            var delivery = Delivery.BeforeHandling();
            var voyage = new Voyage.Voyage(new VoyageNumber("abc"));
            var unloadInLongBeach = HandlingActivity.UnloadOff(voyage, Location.Location.LongBeach);
            delivery = delivery.OnHandling(unloadInLongBeach);

            Assert.AreEqual(now, delivery.LastUpdatedOn);
            Assert.AreEqual(Voyage.Voyage.None, delivery.CurrentVoyage);
            Assert.AreEqual(TransportStatus.InPort, delivery.TransportStatus);
            Assert.AreEqual(unloadInLongBeach, delivery.MostRecentHandlingActivity);
            Assert.AreEqual(Location.Location.LongBeach, delivery.LastKnownLocation);
        }

        [Test]
        public void UpdateDeliveryUponClaimInPort()
        {
            var delivery = Delivery.BeforeHandling();
            var claimInLongBeach = HandlingActivity.ClaimIn(Location.Location.LongBeach);
            delivery = delivery.OnHandling(claimInLongBeach);

            Assert.AreEqual(now, delivery.LastUpdatedOn);
            Assert.AreEqual(Voyage.Voyage.None, delivery.CurrentVoyage);
            Assert.AreEqual(TransportStatus.Claimed, delivery.TransportStatus);
            Assert.AreEqual(claimInLongBeach, delivery.MostRecentHandlingActivity);
            Assert.AreEqual(Location.Location.LongBeach, delivery.LastKnownLocation);
        }
    }
}