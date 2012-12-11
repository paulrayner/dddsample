using System;
using System.Collections.Generic;
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

        [Test]
        public void UpdateDeliveryUponLoad()
        {
            var delivery = Delivery.BeforeHandling();
            var voyage = new Voyage.Voyage(new VoyageNumber("abc"));
            var loadInHongKong = HandlingActivity.LoadOnto(voyage, Location.Location.HongKong);
            delivery = delivery.OnHandling(loadInHongKong);

            SystemTime.Now = () => DateTime.Now.AddSeconds(1);
            Assert.AreEqual(voyage, delivery.CurrentVoyage);
            Assert.AreEqual(TransportStatus.OnboardCarrier, delivery.TransportStatus);
            Assert.AreEqual(loadInHongKong, delivery.MostRecentHandlingActivity);
            Assert.AreEqual(Location.Location.HongKong, delivery.LastKnownLocation);
            Assert.Less(delivery.LastUpdatedOn, SystemTime.Now());
        }

        [Test]
        public void UpdateDeliveryUponReceivingInPort()
        {
            var delivery = Delivery.BeforeHandling();
            var receiveInHongKong = HandlingActivity.ReceiveIn(Location.Location.HongKong);
            delivery = delivery.OnHandling(receiveInHongKong);

            SystemTime.Now = () => DateTime.Now.AddSeconds(1);
            Assert.AreEqual(Voyage.Voyage.None, delivery.CurrentVoyage);
            Assert.AreEqual(TransportStatus.InPort, delivery.TransportStatus);
            Assert.AreEqual(receiveInHongKong, delivery.MostRecentHandlingActivity);
            Assert.AreEqual(Location.Location.HongKong, delivery.LastKnownLocation);
            Assert.Less(delivery.LastUpdatedOn, SystemTime.Now());
        }

        [Test]
        public void UpdateDeliveryUponUnloadInPort()
        {
            var delivery = Delivery.BeforeHandling();
            var voyage = new Voyage.Voyage(new VoyageNumber("abc"));
            var unloadInLongBeach = HandlingActivity.UnloadOff(voyage, Location.Location.LongBeach);
            delivery = delivery.OnHandling(unloadInLongBeach);

            SystemTime.Now = () => DateTime.Now.AddSeconds(1);
            Assert.AreEqual(Voyage.Voyage.None, delivery.CurrentVoyage);
            Assert.AreEqual(TransportStatus.InPort, delivery.TransportStatus);
            Assert.AreEqual(unloadInLongBeach, delivery.MostRecentHandlingActivity);
            Assert.AreEqual(Location.Location.LongBeach, delivery.LastKnownLocation);
            Assert.Less(delivery.LastUpdatedOn, SystemTime.Now());
        }

        [Test]
        public void UpdateDeliveryUponClaimInPort()
        {
            var delivery = Delivery.BeforeHandling();
            var claimInLongBeach = HandlingActivity.ClaimIn(Location.Location.LongBeach);
            delivery = delivery.OnHandling(claimInLongBeach);

            SystemTime.Now = () => DateTime.Now.AddSeconds(1);
            Assert.AreEqual(Voyage.Voyage.None, delivery.CurrentVoyage);
            Assert.AreEqual(TransportStatus.Claimed, delivery.TransportStatus);
            Assert.AreEqual(claimInLongBeach, delivery.MostRecentHandlingActivity);
            Assert.AreEqual(Location.Location.LongBeach, delivery.LastKnownLocation);
            Assert.Less(delivery.LastUpdatedOn, SystemTime.Now());
        }

        // TODO Derive from RouteSpecification and Itinerary
        // TODO Logic for RoutingStatus on Delivery based on routeSpecification being satisfied by Itinerary
    }
}