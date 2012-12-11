using System;
using System.Collections.Generic;
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

            Assert.AreEqual(voyage, delivery.CurrentVoyage);
            Assert.AreEqual(loadInHongKong, delivery.MostRecentHandlingActivity);
            Assert.AreEqual(Location.Location.HongKong, delivery.LastKnownLocation);
        }

        [Test]
        public void UpdateDeliveryUponReceivingInPort()
        {
            var delivery = Delivery.BeforeHandling();

            var receiveInHongKong = HandlingActivity.ReceiveIn(Location.Location.HongKong);
            delivery = delivery.OnHandling(receiveInHongKong);

            //Assert.AreEqual(Voyage.Voyage.NONE, delivery.CurrentVoyage);
            Assert.AreEqual(receiveInHongKong, delivery.MostRecentHandlingActivity);
            Assert.AreEqual(Location.Location.HongKong, delivery.LastKnownLocation);
        }
    }
}